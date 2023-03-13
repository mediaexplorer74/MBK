namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class HistoryFolder_t
    {
        private HistoryFolder_t[] folderField;
        private ActivityReference_t[] activityRefField;
        private Week_t[] weekField;
        private string notesField;
        private string nameField;

        [XmlElement("Folder")]
        public HistoryFolder_t[] Folder { get; set; }

        [XmlElement("ActivityRef")]
        public ActivityReference_t[] ActivityRef { get; set; }

        [XmlElement("Week")]
        public Week_t[] Week { get; set; }

        public string Notes { get; set; }

        [XmlAttribute]
        public string Name { get; set; }
    }
}

