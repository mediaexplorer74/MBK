using System;
using System.Collections.Generic;
using MobileBandSync.MSFTBandLib.Command;

namespace MobileBandSync.MSFTBandLib.Helpers
{
	// Token: 0x0200006C RID: 108
	public static class TimeHelper
	{
		// Token: 0x060003C1 RID: 961 RVA: 0x0000BADA File Offset: 0x00009CDA
		public static DateTime DateTimeUshorts(ushort[] t)
		{
			return new DateTime((int)t[0], (int)t[1], (int)t[2], (int)t[3], (int)t[4], (int)t[5]);
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000BAF3 File Offset: 0x00009CF3
		public static DateTime DateTimeResponse(CommandResponse response, int position = 0)
		{
			List<ushort> list = new List<ushort>(response.GetByteStream(0).GetUshorts(8, position));
			list.RemoveAt(2);
			return TimeHelper.DateTimeUshorts(list.ToArray());
		}
	}
}
