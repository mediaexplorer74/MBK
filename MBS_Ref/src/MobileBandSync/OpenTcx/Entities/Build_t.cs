namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Build_t
    {
        private Version_t versionField;
        private BuildType_t typeField;
        private bool typeFieldSpecified;
        private string timeField;
        private string builderField;

        public Version_t Version { get; set; }

        public BuildType_t Type { get; set; }

        [XmlIgnore]
        public bool TypeSpecified { get; set; }

        [XmlElement(DataType="token")]
        public string Time { get; set; }

        [XmlElement(DataType="token")]
        public string Builder { get; set; }
    }
}

