namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [XmlInclude((Type) typeof(CustomHeartRateZone_t)), XmlInclude((Type) typeof(PredefinedHeartRateZone_t)), XmlInclude((Type) typeof(CustomSpeedZone_t)), XmlInclude((Type) typeof(PredefinedSpeedZone_t)), GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public abstract class Zone_t
    {
        protected Zone_t();
    }
}

