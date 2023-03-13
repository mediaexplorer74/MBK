namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Training_t
    {
        private QuickWorkout_t quickWorkoutResultsField;
        private Plan_t planField;
        private bool virtualPartnerField;

        public QuickWorkout_t QuickWorkoutResults { get; set; }

        public Plan_t Plan { get; set; }

        [XmlAttribute]
        public bool VirtualPartner { get; set; }
    }
}

