namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Repeat_t : AbstractStep_t
    {
        private string repetitionsField;
        private AbstractStep_t[] childField;

        [XmlElement(DataType="positiveInteger")]
        public string Repetitions { get; set; }

        [XmlElement("Child")]
        public AbstractStep_t[] Child { get; set; }
    }
}

