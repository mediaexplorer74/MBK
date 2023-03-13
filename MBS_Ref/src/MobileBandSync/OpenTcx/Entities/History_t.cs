namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class History_t
    {
        private HistoryFolder_t runningField;
        private HistoryFolder_t bikingField;
        private HistoryFolder_t otherField;
        private MultiSportFolder_t multiSportField;

        public HistoryFolder_t Running { get; set; }

        public HistoryFolder_t Biking { get; set; }

        public HistoryFolder_t Other { get; set; }

        public MultiSportFolder_t MultiSport { get; set; }
    }
}

