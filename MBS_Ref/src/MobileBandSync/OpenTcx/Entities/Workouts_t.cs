namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Workouts_t
    {
        private WorkoutFolder_t runningField;
        private WorkoutFolder_t bikingField;
        private WorkoutFolder_t otherField;

        public WorkoutFolder_t Running { get; set; }

        public WorkoutFolder_t Biking { get; set; }

        public WorkoutFolder_t Other { get; set; }
    }
}

