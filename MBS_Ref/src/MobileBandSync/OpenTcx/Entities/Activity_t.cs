namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Activity_t
    {
        private DateTime idField;
        private ActivityLap_t[] lapField;
        private string notesField;
        private Training_t trainingField;
        private AbstractSource_t creatorField;
        private Sport_t sportField;

        public DateTime Id { get; set; }

        [XmlElement("Lap")]
        public ActivityLap_t[] Lap { get; set; }

        public string Notes { get; set; }

        public Training_t Training { get; set; }

        public AbstractSource_t Creator { get; set; }

        [XmlAttribute]
        public Sport_t Sport { get; set; }
    }
}

