namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Course_t
    {
        private string nameField;
        private CourseLap_t[] lapField;
        private Trackpoint_t[] trackField;
        private string notesField;
        private CoursePoint_t[] coursePointField;
        private AbstractSource_t creatorField;

        [XmlElement(DataType="token")]
        public string Name { get; set; }

        [XmlElement("Lap")]
        public CourseLap_t[] Lap { get; set; }

        [XmlArrayItem("Trackpoint", (Type) typeof(Trackpoint_t), IsNullable=false)]
        public Trackpoint_t[] Track { get; set; }

        public string Notes { get; set; }

        [XmlElement("CoursePoint")]
        public CoursePoint_t[] CoursePoint { get; set; }

        public AbstractSource_t Creator { get; set; }
    }
}

