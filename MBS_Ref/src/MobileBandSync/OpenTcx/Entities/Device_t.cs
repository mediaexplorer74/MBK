namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Device_t : AbstractSource_t
    {
        private uint unitIdField;
        private ushort productIDField;
        private Version_t versionField;

        public uint UnitId { get; set; }

        public ushort ProductID { get; set; }

        public Version_t Version { get; set; }
    }
}

