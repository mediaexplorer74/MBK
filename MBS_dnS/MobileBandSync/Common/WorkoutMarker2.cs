using System;

namespace MobileBandSync.Common
{
	// Token: 0x0200008F RID: 143
	public class WorkoutMarker2
	{
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x0000E392 File Offset: 0x0000C592
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x0000E39A File Offset: 0x0000C59A
		public int Value1 { get; set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0000E3A3 File Offset: 0x0000C5A3
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x0000E3AB File Offset: 0x0000C5AB
		public int Value2 { get; set; }

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0000E3B4 File Offset: 0x0000C5B4
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x0000E3BC File Offset: 0x0000C5BC
		public DateTime TimeStamp { get; set; }
	}
}
