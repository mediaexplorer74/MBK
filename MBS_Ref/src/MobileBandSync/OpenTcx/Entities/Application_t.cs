namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Application_t : AbstractSource_t
    {
        private Build_t buildField;
        private string langIDField;
        private string partNumberField;

        public Build_t Build { get; set; }

        [XmlElement(DataType="token")]
        public string LangID { get; set; }

        [XmlElement(DataType="token")]
        public string PartNumber { get; set; }
    }
}

