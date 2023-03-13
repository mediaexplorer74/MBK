using System;

namespace MobileBandSync.Data
{
	// Token: 0x0200007E RID: 126
	public class SleepItem
	{
		// Token: 0x060004B0 RID: 1200 RVA: 0x0000D993 File Offset: 0x0000BB93
		public SleepItem(string uniqueId, string title, string subtitle, string imagePath, string description, string content)
		{
			this.Title = title;
			this.Subtitle = subtitle;
			this.Description = description;
			this.ImagePath = imagePath;
			this.Content = content;
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00008E70 File Offset: 0x00007070
		public SleepItem()
		{
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x0000D9C4 File Offset: 0x0000BBC4
		public string UniqueId
		{
			get
			{
				return this.SleepId.ToString("B");
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0000D9E4 File Offset: 0x0000BBE4
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x0000D9EC File Offset: 0x0000BBEC
		public string Title { get; private set; }

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060004B5 RID: 1205 RVA: 0x0000D9F5 File Offset: 0x0000BBF5
		// (set) Token: 0x060004B6 RID: 1206 RVA: 0x0000D9FD File Offset: 0x0000BBFD
		public string Subtitle { get; private set; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x0000DA06 File Offset: 0x0000BC06
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x0000DA0E File Offset: 0x0000BC0E
		public string Description { get; private set; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x0000DA17 File Offset: 0x0000BC17
		// (set) Token: 0x060004BA RID: 1210 RVA: 0x0000DA1F File Offset: 0x0000BC1F
		public string ImagePath { get; private set; }

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x0000DA28 File Offset: 0x0000BC28
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x0000DA30 File Offset: 0x0000BC30
		public string Content { get; private set; }

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0000DA39 File Offset: 0x0000BC39
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x0000DA41 File Offset: 0x0000BC41
		public int SleepId { get; set; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x0000DA4A File Offset: 0x0000BC4A
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x0000DA52 File Offset: 0x0000BC52
		public int SleepActivityId { get; set; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0000DA5B File Offset: 0x0000BC5B
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x0000DA63 File Offset: 0x0000BC63
		public int SecFromStart { get; set; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x0000DA6C File Offset: 0x0000BC6C
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x0000DA74 File Offset: 0x0000BC74
		public byte SegmentType { get; set; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060004C5 RID: 1221 RVA: 0x0000DA7D File Offset: 0x0000BC7D
		// (set) Token: 0x060004C6 RID: 1222 RVA: 0x0000DA85 File Offset: 0x0000BC85
		public byte SleepType { get; set; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x0000DA8E File Offset: 0x0000BC8E
		// (set) Token: 0x060004C8 RID: 1224 RVA: 0x0000DA96 File Offset: 0x0000BC96
		public byte Heartrate { get; set; }

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000DA9F File Offset: 0x0000BC9F
		public override string ToString()
		{
			return this.Title;
		}
	}
}
