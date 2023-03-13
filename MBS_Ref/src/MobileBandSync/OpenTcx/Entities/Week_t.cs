namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Week_t
    {
        private string notesField;
        private DateTime startDayField;

        public string Notes { get; set; }

        [XmlAttribute(DataType="date")]
        public DateTime StartDay { get; set; }
    }
}

