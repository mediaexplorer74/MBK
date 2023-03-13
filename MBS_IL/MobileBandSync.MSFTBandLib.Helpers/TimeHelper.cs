using System;
using System.Collections.Generic;
using MobileBandSync.MSFTBandLib.Command;

namespace MobileBandSync.MSFTBandLib.Helpers;

public static class TimeHelper
{
	public static DateTime DateTimeUshorts(ushort[] t)
	{
		return new DateTime(t[0], t[1], t[2], t[3], t[4], t[5]);
	}

	public static DateTime DateTimeResponse(CommandResponse response, int position = 0)
	{
		List<ushort> list = new List<ushort>(response.GetByteStream().GetUshorts(8, position));
		list.RemoveAt(2);
		return DateTimeUshorts(list.ToArray());
	}
}
