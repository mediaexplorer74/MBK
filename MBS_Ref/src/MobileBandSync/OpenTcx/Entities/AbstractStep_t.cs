namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [XmlInclude((Type) typeof(Step_t)), XmlInclude((Type) typeof(Repeat_t)), GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public abstract class AbstractStep_t
    {
        private string stepIdField;

        protected AbstractStep_t();

        [XmlElement(DataType="positiveInteger")]
        public string StepId { get; set; }
    }
}

