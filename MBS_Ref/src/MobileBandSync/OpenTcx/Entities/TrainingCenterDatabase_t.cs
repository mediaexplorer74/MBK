namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2"), XmlRoot("TrainingCenterDatabase", Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2", IsNullable=false)]
    public class TrainingCenterDatabase_t
    {
        private Folders_t foldersField;
        private ActivityList_t activitiesField;
        private Workout_t[] workoutsField;
        private Course_t[] coursesField;
        private AbstractSource_t authorField;

        public Folders_t Folders { get; set; }

        public ActivityList_t Activities { get; set; }

        [XmlArrayItem("Workout", IsNullable=false)]
        public Workout_t[] Workouts { get; set; }

        [XmlArrayItem("Course", IsNullable=false)]
        public Course_t[] Courses { get; set; }

        public AbstractSource_t Author { get; set; }
    }
}

