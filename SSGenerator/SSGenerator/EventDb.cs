using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SSGenerator
{
    [XmlRoot("Root")]
    public class EventDb
    {
        [XmlArrayItem("EventDataWrapper")]
        public List<EventDataWrapper> EventDataWrappers;
        //[XmlArrayItem("Disk")]
        //public List<DiskInfo> Disks;
        //[XmlArrayItem("Volume")]
        //public List<VolumeInfo> Volumes;

        public EventDb()
        {
            EventDataWrappers = new List<EventDataWrapper>();
        }
    }
}
