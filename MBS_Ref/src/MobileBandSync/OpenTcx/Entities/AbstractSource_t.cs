namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [XmlInclude((Type) typeof(Application_t)), XmlInclude((Type) typeof(Device_t)), GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public abstract class AbstractSource_t
    {
        private string nameField;

        protected AbstractSource_t();

        [XmlElement(DataType="token")]
        public string Name { get; set; }
    }
}

