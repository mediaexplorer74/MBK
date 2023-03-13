namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class ActivityLap_t
    {
        private double totalTimeSecondsField;
        private double distanceMetersField;
        private double maximumSpeedField;
        private bool maximumSpeedFieldSpecified;
        private ushort caloriesField;
        private HeartRateInBeatsPerMinute_t averageHeartRateBpmField;
        private HeartRateInBeatsPerMinute_t maximumHeartRateBpmField;
        private Intensity_t intensityField;
        private byte cadenceField;
        private bool cadenceFieldSpecified;
        private TriggerMethod_t triggerMethodField;
        private Trackpoint_t[] trackField;
        private string notesField;
        private DateTime startTimeField;

        public double TotalTimeSeconds { get; set; }

        public double DistanceMeters { get; set; }

        public double MaximumSpeed { get; set; }

        [XmlIgnore]
        public bool MaximumSpeedSpecified { get; set; }

        public ushort Calories { get; set; }

        public HeartRateInBeatsPerMinute_t AverageHeartRateBpm { get; set; }

        public HeartRateInBeatsPerMinute_t MaximumHeartRateBpm { get; set; }

        public Intensity_t Intensity { get; set; }

        public byte Cadence { get; set; }

        [XmlIgnore]
        public bool CadenceSpecified { get; set; }

        public TriggerMethod_t TriggerMethod { get; set; }

        [XmlArrayItem("Trackpoint", (Type) typeof(Trackpoint_t), IsNullable=false)]
        public Trackpoint_t[] Track { get; set; }

        public string Notes { get; set; }

        [XmlAttribute]
        public DateTime StartTime { get; set; }
    }
}

