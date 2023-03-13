namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Workout_t
    {
        private string nameField;
        private AbstractStep_t[] stepField;
        private DateTime[] scheduledOnField;
        private string notesField;
        private AbstractSource_t creatorField;
        private Sport_t sportField;

        [XmlElement(DataType="token")]
        public string Name { get; set; }

        [XmlElement("Step")]
        public AbstractStep_t[] Step { get; set; }

        [XmlElement("ScheduledOn", DataType="date")]
        public DateTime[] ScheduledOn { get; set; }

        public string Notes { get; set; }

        public AbstractSource_t Creator { get; set; }

        [XmlAttribute]
        public Sport_t Sport { get; set; }
    }
}

