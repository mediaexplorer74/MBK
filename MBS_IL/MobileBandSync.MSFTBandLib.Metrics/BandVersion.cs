using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Metrics;

public class BandVersion
{
	public string AppName { get; protected set; }

	public byte PCBId { get; protected set; }

	public ushort VersionMajor { get; protected set; }

	public ushort VersionMinor { get; protected set; }

	public uint Revision { get; protected set; }

	public uint BuildNumber { get; protected set; }

	public byte DebugBuild { get; protected set; }

	public BandVersion()
	{
	}

	public BandVersion(CommandResponse response)
	{
		ByteStream byteStream = response.GetByteStream();
		int num = 0;
		string text = "";
		for (char @byte = (char)byteStream.GetByte(num++); @byte != 0; @byte = (char)byteStream.GetByte(num++))
		{
			text += @byte;
		}
		AppName = text;
		PCBId = byteStream.GetByte(num);
		VersionMajor = byteStream.GetUshort(num + 1);
		VersionMinor = byteStream.GetUshort(num + 3);
		Revision = byteStream.GetUint32(num + 5);
		BuildNumber = byteStream.GetUint32(num + 9);
		DebugBuild = byteStream.GetByte(num + 13);
	}
}
