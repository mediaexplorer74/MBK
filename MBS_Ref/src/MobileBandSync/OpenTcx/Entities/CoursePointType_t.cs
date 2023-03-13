namespace MobileBandSync.OpenTcx.Entities
{
    using System;
    using System.CodeDom.Compiler;
    using System.Xml.Serialization;

    [GeneratedCode("xsd", "4.0.30319.1"), XmlType(Namespace="http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
    public enum CoursePointType_t
    {
        public const CoursePointType_t Generic = CoursePointType_t.Generic;,
        public const CoursePointType_t Summit = CoursePointType_t.Summit;,
        public const CoursePointType_t Valley = CoursePointType_t.Valley;,
        public const CoursePointType_t Water = CoursePointType_t.Water;,
        public const CoursePointType_t Food = CoursePointType_t.Food;,
        public const CoursePointType_t Danger = CoursePointType_t.Danger;,
        public const CoursePointType_t Left = CoursePointType_t.Left;,
        public const CoursePointType_t Right = CoursePointType_t.Right;,
        public const CoursePointType_t Straight = CoursePointType_t.Straight;,
        [XmlEnum("First Aid")]
        public const CoursePointType_t FirstAid = CoursePointType_t.FirstAid;,
        [XmlEnum("4th Category")]
        public const CoursePointType_t Item4thCategory = CoursePointType_t.Item4thCategory;,
        [XmlEnum("3rd Category")]
        public const CoursePointType_t Item3rdCategory = CoursePointType_t.Item3rdCategory;,
        [XmlEnum("2nd Category")]
        public const CoursePointType_t Item2ndCategory = CoursePointType_t.Item2ndCategory;,
        [XmlEnum("1st Category")]
        public const CoursePointType_t Item1stCategory = CoursePointType_t.Item1stCategory;,
        [XmlEnum("Hors Category")]
        public const CoursePointType_t HorsCategory = CoursePointType_t.HorsCategory;,
        public const CoursePointType_t Sprint = CoursePointType_t.Sprint;
    }
}

