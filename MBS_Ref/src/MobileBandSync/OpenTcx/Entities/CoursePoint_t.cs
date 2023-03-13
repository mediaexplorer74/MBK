namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class CoursePoint_t
    {
        private string nameField;
        private DateTime timeField;
        private Position_t positionField;
        private double altitudeMetersField;
        private bool altitudeMetersFieldSpecified;
        private CoursePointType_t pointTypeField;
        private string notesField;

        [XmlElement(DataType="token")]
        public string Name { get; set; }

        public DateTime Time { get; set; }

        public Position_t Position { get; set; }

        public double AltitudeMeters { get; set; }

        [XmlIgnore]
        public bool AltitudeMetersSpecified { get; set; }

        public CoursePointType_t PointType { get; set; }

        public string Notes { get; set; }
    }
}

