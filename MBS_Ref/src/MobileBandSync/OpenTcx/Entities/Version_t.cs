namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Version_t
    {
        private ushort versionMajorField;
        private ushort versionMinorField;
        private ushort buildMajorField;
        private bool buildMajorFieldSpecified;
        private ushort buildMinorField;
        private bool buildMinorFieldSpecified;

        public ushort VersionMajor { get; set; }

        public ushort VersionMinor { get; set; }

        public ushort BuildMajor { get; set; }

        [XmlIgnore]
        public bool BuildMajorSpecified { get; set; }

        public ushort BuildMinor { get; set; }

        [XmlIgnore]
        public bool BuildMinorSpecified { get; set; }
    }
}

