namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class MultiSportSession_t
    {
        private DateTime idField;
        private FirstSport_t firstSportField;
        private NextSport_t[] nextSportField;
        private string notesField;

        public DateTime Id { get; set; }

        public FirstSport_t FirstSport { get; set; }

        [XmlElement("NextSport")]
        public NextSport_t[] NextSport { get; set; }

        public string Notes { get; set; }
    }
}

