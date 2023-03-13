using System;

namespace MobileBandSync.OpenTcx
{
	// Token: 0x02000011 RID: 17
	public class OpenTcxException : Exception
	{
		// Token: 0x06000175 RID: 373 RVA: 0x00008D13 File Offset: 0x00006F13
		public OpenTcxException(string message) : base(message)
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00008D1C File Offset: 0x00006F1C
		public OpenTcxException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
