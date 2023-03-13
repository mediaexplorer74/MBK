using System;

namespace MobileBandSync.MSFTBandLib.Command;

public class CommandDataSize : Attribute
{
	public int DataSize { get; protected set; }

	public CommandDataSize(int DataSize)
	{
		this.DataSize = DataSize;
	}
}
