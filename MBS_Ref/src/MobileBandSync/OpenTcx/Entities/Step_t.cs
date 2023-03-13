namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), DebuggerStepThrough, XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public class Step_t : AbstractStep_t
    {
        private string nameField;
        private Duration_t durationField;
        private Intensity_t intensityField;
        private Target_t targetField;

        [XmlElement(DataType="token")]
        public string Name { get; set; }

        public Duration_t Duration { get; set; }

        public Intensity_t Intensity { get; set; }

        public Target_t Target { get; set; }
    }
}

