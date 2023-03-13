namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class PredefinedHeartRateZone_t : Zone_t
    {
        private string numberField;

        [XmlElement(DataType="positiveInteger")]
        public string Number { get; set; }
    }
}

