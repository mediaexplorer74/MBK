using System;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x0200005E RID: 94
	public class ProgressEventArgs : EventArgs
	{
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0000B137 File Offset: 0x00009337
		// (set) Token: 0x06000364 RID: 868 RVA: 0x0000B13F File Offset: 0x0000933F
		public ulong Completed { get; private set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0000B148 File Offset: 0x00009348
		// (set) Token: 0x06000366 RID: 870 RVA: 0x0000B150 File Offset: 0x00009350
		public ulong Total { get; private set; }

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000367 RID: 871 RVA: 0x0000B159 File Offset: 0x00009359
		// (set) Token: 0x06000368 RID: 872 RVA: 0x0000B161 File Offset: 0x00009361
		public string StatusText { get; private set; }

		// Token: 0x06000369 RID: 873 RVA: 0x0000B16A File Offset: 0x0000936A
		public ProgressEventArgs(ulong uiCompleted, ulong uiTotal, string strStatusText)
		{
			this.Completed = uiCompleted;
			this.Total = uiTotal;
			this.StatusText = strStatusText;
		}
	}
}
