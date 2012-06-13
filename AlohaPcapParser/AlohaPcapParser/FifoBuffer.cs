using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlohaPcapParser
{
    public class FifoBuffer : Stream
    {
        public FifoBuffer()
        {
            ReadTimeout = -1;
        }

        private readonly object _writeSyncRoot = new object();
        private readonly object _readSyncRoot = new object();
        private readonly LinkedList<ArraySegment<byte>> _pendingSegments = new LinkedList<ArraySegment<byte>>();
        private readonly ManualResetEventSlim _dataAvailableResetEvent = new ManualResetEventSlim();

        #region Overrides of Stream

        public int ReadTimeout { get; set; }

        public override void Flush()
        {
            _pendingSegments.Clear();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (Length < count && _dataAvailableResetEvent.Wait(ReadTimeout))
                throw new TimeoutException("No data available");

            lock (_readSyncRoot)
            {
                int currentCount = 0;
                int segmentCount = 1;


                while (currentCount < count)
                {
                    ArraySegment<byte> segment = _pendingSegments.First.Value;
                    _pendingSegments.RemoveFirst();

                    int x = segment.Offset;
                    for (; x < segment.Array.Length; x++)
                    {
                        if (currentCount >= count)
                        {
                            _pendingSegments.AddFirst(new ArraySegment<byte>(segment.Array, x, segment.Array.Length - x));
                            break;
                        }
                        buffer[currentCount] = segment.Array[x];
                        currentCount++;
                    }
                }

                return currentCount;
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            lock (_writeSyncRoot)
            {
                byte[] copy = new byte[count];
                Array.Copy(buffer, offset, copy, 0, count);

                _pendingSegments.AddLast(new ArraySegment<byte>(copy));

                _dataAvailableResetEvent.Set();
            }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override long Length
        {
            get
            {
                long length = 0;
                foreach (ArraySegment<byte> pendingSegment in _pendingSegments)
                {
                    length += pendingSegment.Count;
                }
                return length;
            }
        }

        public override long Position
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region Public Methods

        public int PeekByte()
        {
            if (Length < 1)
                throw new TimeoutException("No data available");

            lock (_readSyncRoot)
            {
                return _pendingSegments.First.Value.Array[0];
            }
        }

        public int PeekInt()
        {
            if (Length < 4)
                throw new TimeoutException("No data available");

            lock (_readSyncRoot)
            {
                return BitConverter.ToInt32(_pendingSegments.First.Value.Array, _pendingSegments.First.Value.Offset);
            }
        }

        public byte[] Peek(int count)
        {
            if (Length < count && _dataAvailableResetEvent.Wait(ReadTimeout))
                throw new TimeoutException("No data available");

            byte[] buffer = new byte[count];

            lock (_readSyncRoot)
            {
                int currentCount = 0;
                int segmentCount = 1;

                while (currentCount < count)
                {
                    ArraySegment<byte> segment = _pendingSegments.First.Value;
                    _pendingSegments.RemoveFirst();

                    int x = segment.Offset;
                    for (; x < segment.Array.Length; x++)
                    {
                        if (currentCount >= count)
                        {
                            _pendingSegments.AddFirst(new ArraySegment<byte>(segment.Array, x, segment.Array.Length - x));
                            break;
                        }
                        buffer[currentCount] = segment.Array[x];
                        currentCount++;
                    }
                }

                return buffer;
            }
        }

        #endregion
    }
}
