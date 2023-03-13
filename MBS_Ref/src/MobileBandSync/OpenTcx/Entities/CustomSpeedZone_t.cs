namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class CustomSpeedZone_t : Zone_t
    {
        private SpeedType_t viewAsField;
        private double lowInMetersPerSecondField;
        private double highInMetersPerSecondField;

        public SpeedType_t ViewAs { get; set; }

        public double LowInMetersPerSecond { get; set; }

        public double HighInMetersPerSecond { get; set; }
    }
}

