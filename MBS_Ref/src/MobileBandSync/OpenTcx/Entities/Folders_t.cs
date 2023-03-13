namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Folders_t
    {
        private History_t historyField;
        private Workouts_t workoutsField;
        private Courses_t coursesField;

        public History_t History { get; set; }

        public Workouts_t Workouts { get; set; }

        public Courses_t Courses { get; set; }
    }
}

