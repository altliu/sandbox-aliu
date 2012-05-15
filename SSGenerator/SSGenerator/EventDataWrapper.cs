using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace SSGenerator
{
    public class EventDataWrapper
    {
        [XmlAttribute]
        public string Name;
        public EventDefinitionData EventDefinition;
        [XmlArrayItem("MetadataWrapper")]        
        public MetadataWrapper[] MetadataValues;
        [XmlAttribute]
        [DefaultValue(2)]
        public int Delta;
        [XmlAttribute]
        [DefaultValue(false)]
        public bool Active;
        [XmlAttribute]
        [DefaultValue(10)]
        public int StartDelta;
        [XmlAttribute]
        [DefaultValue(-10)]
        public int EndDelta;

        public EventDataWrapper()
        {
        }

        public EventDataWrapper(EventDefinitionData eventDefinition)
        {
            EventDefinition = eventDefinition;

            MetadataValues = new MetadataWrapper[eventDefinition.MetadataFields.Length];
            for (int i = 0; i < MetadataValues.Length; i++)
            {
                MetadataValues[i] = new MetadataWrapper();
            }
        }

        public override string ToString()
        {
            return "[" + Name + "]";
        }
    }

    public class MetadataWrapper
    {
        [XmlAttribute]
        public string Value;
    }
}
