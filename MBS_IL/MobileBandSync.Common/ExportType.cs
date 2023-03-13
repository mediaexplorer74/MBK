namespace MobileBandSync.Common;

public enum ExportType
{
	Unknown = 0,
	GPX = 1,
	TCX = 2,
	FIT = 4,
	HeartRate = 8,
	Cadence = 0x10,
	Temperature = 0x20,
	GalvanicSkinResponse = 0x40
}
