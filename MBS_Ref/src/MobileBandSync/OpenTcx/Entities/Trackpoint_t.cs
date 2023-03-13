namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Trackpoint_t
    {
        private DateTime timeField;
        private Position_t positionField;
        private double altitudeMetersField;
        private bool altitudeMetersFieldSpecified;
        private double distanceMetersField;
        private bool distanceMetersFieldSpecified;
        private HeartRateInBeatsPerMinute_t heartRateBpmField;
        private byte cadenceField;
        private bool cadenceFieldSpecified;
        private SensorState_t sensorStateField;
        private bool sensorStateFieldSpecified;

        public DateTime Time { get; set; }

        public Position_t Position { get; set; }

        public double AltitudeMeters { get; set; }

        [XmlIgnore]
        public bool AltitudeMetersSpecified { get; set; }

        public double DistanceMeters { get; set; }

        [XmlIgnore]
        public bool DistanceMetersSpecified { get; set; }

        public HeartRateInBeatsPerMinute_t HeartRateBpm { get; set; }

        public byte Cadence { get; set; }

        [XmlIgnore]
        public bool CadenceSpecified { get; set; }

        public SensorState_t SensorState { get; set; }

        [XmlIgnore]
        public bool SensorStateSpecified { get; set; }
    }
}

