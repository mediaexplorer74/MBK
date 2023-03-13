namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class WorkoutFolder_t
    {
        private WorkoutFolder_t[] folderField;
        private NameKeyReference_t[] workoutNameRefField;
        private string nameField;

        [XmlElement("Folder")]
        public WorkoutFolder_t[] Folder { get; set; }

        [XmlElement("WorkoutNameRef")]
        public NameKeyReference_t[] WorkoutNameRef { get; set; }

        [XmlAttribute]
        public string Name { get; set; }
    }
}

