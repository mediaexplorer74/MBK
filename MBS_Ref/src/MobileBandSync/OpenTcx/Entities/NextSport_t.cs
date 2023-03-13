namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class NextSport_t
    {
        private ActivityLap_t transitionField;
        private Activity_t activityField;

        public ActivityLap_t Transition { get; set; }

        public Activity_t Activity { get; set; }
    }
}

