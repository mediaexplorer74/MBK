namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Plan_t
    {
        private string nameField;
        private TrainingType_t typeField;
        private bool intervalWorkoutField;

        [XmlElement(DataType="token")]
        public string Name { get; set; }

        [XmlAttribute]
        public TrainingType_t Type { get; set; }

        [XmlAttribute]
        public bool IntervalWorkout { get; set; }
    }
}

