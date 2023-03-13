namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class CourseLap_t
    {
        private double totalTimeSecondsField;
        private double distanceMetersField;
        private Position_t beginPositionField;
        private double beginAltitudeMetersField;
        private bool beginAltitudeMetersFieldSpecified;
        private Position_t endPositionField;
        private double endAltitudeMetersField;
        private bool endAltitudeMetersFieldSpecified;
        private HeartRateInBeatsPerMinute_t averageHeartRateBpmField;
        private HeartRateInBeatsPerMinute_t maximumHeartRateBpmField;
        private Intensity_t intensityField;
        private byte cadenceField;
        private bool cadenceFieldSpecified;

        public double TotalTimeSeconds { get; set; }

        public double DistanceMeters { get; set; }

        public Position_t BeginPosition { get; set; }

        public double BeginAltitudeMeters { get; set; }

        [XmlIgnore]
        public bool BeginAltitudeMetersSpecified { get; set; }

        public Position_t EndPosition { get; set; }

        public double EndAltitudeMeters { get; set; }

        [XmlIgnore]
        public bool EndAltitudeMetersSpecified { get; set; }

        public HeartRateInBeatsPerMinute_t AverageHeartRateBpm { get; set; }

        public HeartRateInBeatsPerMinute_t MaximumHeartRateBpm { get; set; }

        public Intensity_t Intensity { get; set; }

        public byte Cadence { get; set; }

        [XmlIgnore]
        public bool CadenceSpecified { get; set; }
    }
}

