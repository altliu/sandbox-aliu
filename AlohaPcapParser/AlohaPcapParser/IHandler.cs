using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlohaPcapParser
{
    public interface IHandler
    {
        void HandleBytes(byte[] data);
    }

    public class DiskWriter : IHandler
    {
        #region Implementation of IHandler

        public void HandleBytes(byte[] data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
