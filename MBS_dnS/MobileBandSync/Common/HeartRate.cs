using System;

namespace MobileBandSync.Common
{
	// Token: 0x0200008C RID: 140
	public class HeartRate
	{
		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x0000E2D7 File Offset: 0x0000C4D7
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x0000E2DF File Offset: 0x0000C4DF
		public int Bpm { get; set; }

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x0000E2E8 File Offset: 0x0000C4E8
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x0000E2F0 File Offset: 0x0000C4F0
		public int Accuracy { get; set; }

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x0000E2F9 File Offset: 0x0000C4F9
		// (set) Token: 0x0600051B RID: 1307 RVA: 0x0000E301 File Offset: 0x0000C501
		public DateTime TimeStamp { get; set; }
	}
}
