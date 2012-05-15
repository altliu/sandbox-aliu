using System;
using System.Collections.Generic;
using System.Text;

namespace SSGenerator
{
    class EventDefintionWrapperBase
    {
        // Event Definition
        private const int StartReferenceDelta = 10;
        private const int EndReferenceDelta = 10;

        private static readonly Guid _eventGuid = new Guid("8B2E6A02-EDD6-4832-9295-FAE9BB427FB9");
        private const string DefinitionName = "CCure Event";
        private const string ShortName = "CCure";
        private const string HelpText = "CCure 9000 Event";

        static internal readonly List<MetadataField> _metadataFields = new List<MetadataField>();

        private static readonly Guid _typeGuid = new Guid("32CA43F5-B38D-4ab8-84FE-9BE0597CF022");
        private static readonly Guid _locationGuid = new Guid("C01B7EA2-6C11-4e0e-B0E7-DBCEEEAFBE04");
        private static readonly Guid _descriptionGuid = new Guid("9864A420-82DF-4240-890A-B9CFF2440255");
        private static readonly Guid _userGuid = new Guid("D9425318-0E4D-498c-BE27-303C21D40BE9");
        private static readonly Guid _cardGuid = new Guid("60923A81-4EB4-42c5-8CC7-2BBA61924966");

        private static readonly MetadataField _typeField = makeMetadataField("Event Type", "Type", MetadataType.String, 1, "{name}: {value} ", _typeGuid);
        private static readonly MetadataField _locationField = makeMetadataField("Location", "Location", MetadataType.String, 2, "Loc: {value} ", _locationGuid);
        private static readonly MetadataField _cardField = makeMetadataField("Card Number", "Card", MetadataType.Number, 3, "{name}: {value} ", _cardGuid);
        private static readonly MetadataField _userField = makeMetadataField("Cardholder", "User", MetadataType.String, 4, "{name}: {value} ", _userGuid);
        private static readonly MetadataField _descriptionField = makeMetadataField("Event Description", "Description", MetadataType.String, 5, "{value} ", _descriptionGuid);
        
        private static EventDefinitionData _eventDefinition;

        public static EventDefinitionData EventDefinition
        {
            get { return _eventDefinition ?? (_eventDefinition = makeEventDefinition()); }
        }

        internal static MetadataField makeMetadataField(string description, string name, MetadataType type, int pos, string format, Guid guid)
        {
            MetadataField metadataField = new MetadataField();
            metadataField.Description = description;
            metadataField.Name = name;
            metadataField.Type = type;
            metadataField.Guid = guid;
            metadataField.DisplayPosition = pos;
            metadataField.DisplayFormat = format;

            return metadataField;
        }

        private static EventDefinitionData makeEventDefinition()
        {
            EventDefinitionData accessEventDefinition = new EventDefinitionData();
            accessEventDefinition.Guid = _eventGuid;
            accessEventDefinition.Name = DefinitionName;
            accessEventDefinition.ShortName = ShortName;
            accessEventDefinition.HelpText = HelpText;

            accessEventDefinition.MetadataFields = _metadataFields.ToArray();

            //// Handle Enumeration Values for Type metadata
            //_typeField.EnumeratedData = new EnumeratedData();
            //_typeField.EnumeratedData.Name = "Type Values";
            //_typeField.EnumeratedData.Values = _typeValues;

            //int idx = 0;
            //accessMetadataFields[idx++] = _typeField;
            //accessMetadataFields[idx++] = _locationField;
            //accessMetadataFields[idx++] = _descriptionField;
            //accessMetadataFields[idx++] = _userField;
            //accessMetadataFields[idx++] = _cardField;

            return accessEventDefinition;
        }
    }
}
