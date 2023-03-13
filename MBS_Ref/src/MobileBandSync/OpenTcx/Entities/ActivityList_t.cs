namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class ActivityList_t
    {
        private Activity_t[] activityField;
        private MultiSportSession_t[] multiSportSessionField;

        [XmlElement("Activity")]
        public Activity_t[] Activity { get; set; }

        [XmlElement("MultiSportSession")]
        public MultiSportSession_t[] MultiSportSession { get; set; }
    }
}

