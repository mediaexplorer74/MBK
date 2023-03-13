namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class CourseFolder_t
    {
        private CourseFolder_t[] folderField;
        private NameKeyReference_t[] courseNameRefField;
        private string notesField;
        private string nameField;

        [XmlElement("Folder")]
        public CourseFolder_t[] Folder { get; set; }

        [XmlElement("CourseNameRef")]
        public NameKeyReference_t[] CourseNameRef { get; set; }

        public string Notes { get; set; }

        [XmlAttribute]
        public string Name { get; set; }
    }
}

