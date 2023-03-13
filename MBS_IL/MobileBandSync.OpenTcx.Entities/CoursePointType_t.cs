using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities;

[GeneratedCode("xsd", "4.0.30319.1")]
[XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
public enum CoursePointType_t
{
	Generic,
	Summit,
	Valley,
	Water,
	Food,
	Danger,
	Left,
	Right,
	Straight,
	[XmlEnum("First Aid")]
	FirstAid,
	[XmlEnum("4th Category")]
	Item4thCategory,
	[XmlEnum("3rd Category")]
	Item3rdCategory,
	[XmlEnum("2nd Category")]
	Item2ndCategory,
	[XmlEnum("1st Category")]
	Item1stCategory,
	[XmlEnum("Hors Category")]
	HorsCategory,
	Sprint
}
