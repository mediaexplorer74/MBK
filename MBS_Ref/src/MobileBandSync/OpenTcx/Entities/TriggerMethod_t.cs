namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public enum TriggerMethod_t
    {
        public const TriggerMethod_t Manual = TriggerMethod_t.Manual;,
        public const TriggerMethod_t Distance = TriggerMethod_t.Distance;,
        public const TriggerMethod_t Location = TriggerMethod_t.Location;,
        public const TriggerMethod_t Time = TriggerMethod_t.Time;,
        public const TriggerMethod_t HeartRate = TriggerMethod_t.HeartRate;
    }
}

