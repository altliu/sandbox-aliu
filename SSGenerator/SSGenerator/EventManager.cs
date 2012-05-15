using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SSGenerator
{
    public class EventManager
    {
        private const string Filename = "manager.data";

        private static EventDb _eventDb;

        public static EventDb EventDatabase
        {
            get { return _eventDb; }
        }

        public static bool LoadManager()
        {
            if (File.Exists(Filename))
            {
                FileInfo fi = new FileInfo(Filename);
                byte[] binaryDiskDb = File.ReadAllBytes(fi.FullName);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof (EventDb));
                try
                {
                    using (MemoryStream ms = new MemoryStream(binaryDiskDb))
                    {
                        _eventDb = (EventDb) xmlSerializer.Deserialize(ms);
                        ms.Position = 0;
                        using (StreamReader sr = new StreamReader(ms))
                        {
                            sr.ReadToEnd();
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deserializing diskdb - " + ex);
                }
            }
            _eventDb = new EventDb();
            return false;
        }

        public static void SaveManager()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(EventDb));
            using (MemoryStream saveStream = new MemoryStream())
            {
                xmlSerializer.Serialize(saveStream, _eventDb);

                byte[] binaryDiskDb = saveStream.GetBuffer();
                int count = (int) saveStream.Length;

                //SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                //byte[] hash = sha1.ComputeHash(binaryDiskDb, 0, count);

                FileInfo fi = new FileInfo(Filename);

                using (FileStream fs = fi.Open(FileMode.Create, FileAccess.Write))
                {
                    fs.Write(binaryDiskDb, 0, count);
                }
            }
        }
    }
}
