using System;

namespace MobileBandSync.Common
{
	// Token: 0x02000093 RID: 147
	public class Sensor
	{
		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000563 RID: 1379 RVA: 0x0000E52A File Offset: 0x0000C72A
		// (set) Token: 0x06000564 RID: 1380 RVA: 0x0000E532 File Offset: 0x0000C732
		public uint GalvanicSkinResponse { get; set; }

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000565 RID: 1381 RVA: 0x0000E53B File Offset: 0x0000C73B
		// (set) Token: 0x06000566 RID: 1382 RVA: 0x0000E543 File Offset: 0x0000C743
		public uint Value1 { get; set; }

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x0000E54C File Offset: 0x0000C74C
		// (set) Token: 0x06000568 RID: 1384 RVA: 0x0000E554 File Offset: 0x0000C754
		public uint Value2 { get; set; }

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x0000E55D File Offset: 0x0000C75D
		// (set) Token: 0x0600056A RID: 1386 RVA: 0x0000E565 File Offset: 0x0000C765
		public uint Value3 { get; set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0000E56E File Offset: 0x0000C76E
		// (set) Token: 0x0600056C RID: 1388 RVA: 0x0000E576 File Offset: 0x0000C776
		public DateTime TimeStamp { get; set; }
	}
}
