namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [XmlInclude((Type) typeof(UserInitiated_t)), XmlInclude((Type) typeof(CaloriesBurned_t)), XmlInclude((Type) typeof(HeartRateBelow_t)), XmlInclude((Type) typeof(HeartRateAbove_t)), XmlInclude((Type) typeof(Distance_t)), XmlInclude((Type) typeof(Time_t)), GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public abstract class Duration_t
    {
        protected Duration_t();
    }
}

