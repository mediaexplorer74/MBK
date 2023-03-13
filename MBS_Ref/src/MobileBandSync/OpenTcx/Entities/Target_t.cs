namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [XmlInclude((Type) typeof(None_t)), XmlInclude((Type) typeof(Cadence_t)), XmlInclude((Type) typeof(HeartRate_t)), XmlInclude((Type) typeof(Speed_t)), GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public abstract class Target_t
    {
        protected Target_t();
    }
}

