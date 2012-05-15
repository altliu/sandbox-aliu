using System;
using System.Drawing;
using System.IO;

namespace SSGenerator
{
    internal class EventDefinitionManager
    {
        // Event Definition
        public const string DefinitionName = "CCure Event";
        public const string ShortName = "CCure";
        public const string HelpText = "CCure 9000 Event";

        private static readonly Guid _eventGuid = new Guid("8B2E6A02-EDD6-4832-9295-FAE9BB427FB9");
        private const int MetadataFieldCount = 5;
        private const int StartReferenceDelta = 10;
        private const int EndReferenceDelta = 10;

        private static readonly Guid _typeGuid = new Guid("32CA43F5-B38D-4ab8-84FE-9BE0597CF022");
        private static readonly Guid _locationGuid = new Guid("C01B7EA2-6C11-4e0e-B0E7-DBCEEEAFBE04");
        private static readonly Guid _descriptionGuid = new Guid("9864A420-82DF-4240-890A-B9CFF2440255");
        private static readonly Guid _userGuid = new Guid("D9425318-0E4D-498c-BE27-303C21D40BE9");
        private static readonly Guid _cardGuid = new Guid("60923A81-4EB4-42c5-8CC7-2BBA61924966");

        //private readonly static string[] _typeValues = new[] { "AreaActivity", "CardAdmitted", "CardRejected", "DeviceActivity", "DeviceError", "DoubleSwipe", "LogMessage", "ManualAction", "NetVideoActivity", "ObjectChangedState", "OperatorActivity", "OperatorLogin", "SystemActivity", "SystemError" };
        private static readonly MetadataField _typeField = makeMetadataField("Event Type", "Type", MetadataType.String, 1, "{name}: {value} ", _typeGuid);
        private static readonly MetadataField _locationField = makeMetadataField("Location", "Location", MetadataType.String, 2, "Loc: {value} ", _locationGuid);
        private static readonly MetadataField _cardField = makeMetadataField("Card Number", "Card", MetadataType.Number, 3, "{name}: {value} ", _cardGuid);
        private static readonly MetadataField _userField = makeMetadataField("Cardholder", "User", MetadataType.String, 4, "{name}: {value} ", _userGuid);
        private static readonly MetadataField _descriptionField = makeMetadataField("Event Description", "Description", MetadataType.String, 5, "{value} ", _descriptionGuid);
        private static EventDefinitionData _eventDefinition;

        static EventDefinitionManager()
        {
            //if (eventData.ImageBuffer != null)
            //{
            //    GenericEventImage genericEventImage = makeGenericEventImage(eventData.ImageBuffer);
            //    if (genericEventImage == null)
            //    {
            //        return genericEventData;
            //    }

            //    ReferenceComparison referenceComparison = new ReferenceComparison();
            //    referenceComparison.StartTimeReferenceDelta = StartReferenceDelta;
            //    referenceComparison.EndTimeReferenceDelta = EndReferenceDelta;
            //    referenceComparison.ReferenceImage = genericEventImage;

            //    genericEventData.FaceComparison = referenceComparison;
            //}
        }

        public static EventDefinitionData EventDefinition
        {
            get { return _eventDefinition; }
        }

        //public static GenericEventData CreateBaseEventData(EventData eventData)
        //{
        //    GenericEventData genericEventData = new GenericEventData();
        //    genericEventData.DefinitionGuid = _eventGuid;
        //    genericEventData.EventTime = DateTime.Now;
        //    genericEventData.UseServerTime = true;
        //    genericEventData.CloseEvent = true;
        //    genericEventData.MetadataList = makeMetaDataList(eventData);

        //    if (eventData.ImageBuffer != null)
        //    {
        //        GenericEventImage genericEventImage = makeGenericEventImage(eventData.ImageBuffer);
        //        if (genericEventImage == null)
        //        {
        //            return genericEventData;
        //        }

        //        ReferenceComparison referenceComparison = new ReferenceComparison();
        //        referenceComparison.StartTimeReferenceDelta = StartReferenceDelta;
        //        referenceComparison.EndTimeReferenceDelta = EndReferenceDelta;
        //        referenceComparison.ReferenceImage = genericEventImage;

        //        genericEventData.FaceComparison = referenceComparison;
        //    }
        //    return genericEventData;
        //}

        private static GenericEventImage makeGenericEventImage(byte[] imageBuffer)
        {
            // TODO: test different image formats
            GenericEventImage referenceImage;
            using (MemoryStream ms = new MemoryStream(imageBuffer))
            using (Image hirschImage = Image.FromStream(ms))
            {
                if (hirschImage == null)
                {
                    return null;
                }

                referenceImage = new GenericEventImage();
                referenceImage.ImageBuffer = imageBuffer;
                referenceImage.Width = hirschImage.Width;
                referenceImage.Height = hirschImage.Height;
                referenceImage.Format = PictureFormat.Bitmap;
                referenceImage.AspectRatioAdjustment = 2;
                referenceImage.NominalAspectRatio = 2;
                referenceImage.ImageTime = DateTime.Now;
                return referenceImage;
            }
        }

        public static void InitializeEventDefinition()
        {
            EventDefinitionData eventDefinition = makeEventDefinition();
            _eventDefinition = eventDefinition;
        }

        public static void CheckEventDefinition(IGenericEventService ges)
        {
            EventDefinitionData eventDefinition = ges.GenericEventDefinitionByGuid(_eventGuid);

            if (eventDefinition == null)
            {
                eventDefinition = makeEventDefinition();
                eventDefinition = ges.CreateGenericEventDefinition(eventDefinition);
            }

            _eventDefinition = eventDefinition;
        }

        private static EventDefinitionData makeEventDefinition()
        {
            EventDefinitionData accessEventDefinition = new EventDefinitionData();
            accessEventDefinition.Guid = _eventGuid;
            accessEventDefinition.Name = DefinitionName;
            accessEventDefinition.ShortName = ShortName;
            accessEventDefinition.HelpText = HelpText;

            MetadataField[] accessMetadataFields = new MetadataField[MetadataFieldCount];
            accessEventDefinition.MetadataFields = accessMetadataFields;

            //// Handle Enumeration Values for Type metadata
            //_typeField.EnumeratedData = new EnumeratedData();
            //_typeField.EnumeratedData.Name = "Type Values";
            //_typeField.EnumeratedData.Values = _typeValues;

            int idx = 0;
            accessMetadataFields[idx++] = _typeField;
            accessMetadataFields[idx++] = _locationField;
            accessMetadataFields[idx++] = _descriptionField;
            accessMetadataFields[idx++] = _userField;
            accessMetadataFields[idx++] = _cardField;

            return accessEventDefinition;
        }

        private static MetadataField makeMetadataField(string description, string name, MetadataType type, int pos,
                                                       string format, Guid guid)
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

        //private static GenericEventMetadata[] makeMetaDataList(EventData eventData)
        private static GenericEventMetadata[] makeMetaDataList()
        {
            GenericEventMetadata[] metadataList = new GenericEventMetadata[MetadataFieldCount];
            metadataList[0] = makeMetadata("Type", _typeGuid);
            metadataList[1] = makeMetadata("Location", _locationGuid);
            metadataList[2] = makeMetadata("Card", _cardGuid);
            metadataList[3] = makeMetadata("CardHolder", _userGuid);
            metadataList[4] = makeMetadata("Description", _descriptionGuid);

            return metadataList;
        }

        private static GenericEventMetadata makeMetadata(string value, Guid guid)
        {
            GenericEventMetadata metadata = new GenericEventMetadata();
            metadata.Guid = guid;
            metadata.Value = value;
            return metadata;
        }

        public static Guid EventGuid
        {
            get { return _eventGuid; }
        }
    }
}