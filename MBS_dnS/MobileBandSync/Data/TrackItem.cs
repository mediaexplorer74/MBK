using System;

namespace MobileBandSync.Data
{
	// Token: 0x0200007D RID: 125
	public class TrackItem
	{
		// Token: 0x06000482 RID: 1154 RVA: 0x0000D7CC File Offset: 0x0000B9CC
		public TrackItem(string uniqueId, string title, string subtitle, string imagePath, string description, string content)
		{
			this.Title = title;
			this.Subtitle = subtitle;
			this.Description = description;
			this.ImagePath = imagePath;
			this.Content = content;
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00008E70 File Offset: 0x00007070
		public TrackItem()
		{
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0000D7FC File Offset: 0x0000B9FC
		public string UniqueId
		{
			get
			{
				return this.TrackId.ToString("B");
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x0000D81C File Offset: 0x0000BA1C
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x0000D824 File Offset: 0x0000BA24
		public string Title { get; private set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x0000D82D File Offset: 0x0000BA2D
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x0000D835 File Offset: 0x0000BA35
		public string Subtitle { get; private set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x0000D83E File Offset: 0x0000BA3E
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x0000D846 File Offset: 0x0000BA46
		public string Description { get; private set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x0000D84F File Offset: 0x0000BA4F
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x0000D857 File Offset: 0x0000BA57
		public string ImagePath { get; private set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x0000D860 File Offset: 0x0000BA60
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x0000D868 File Offset: 0x0000BA68
		public string Content { get; private set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x0000D871 File Offset: 0x0000BA71
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x0000D879 File Offset: 0x0000BA79
		public int TrackId { get; set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0000D882 File Offset: 0x0000BA82
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x0000D88A File Offset: 0x0000BA8A
		public int WorkoutId { get; set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x0000D893 File Offset: 0x0000BA93
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x0000D89B File Offset: 0x0000BA9B
		public int SecFromStart { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x0000D8A4 File Offset: 0x0000BAA4
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x0000D8AC File Offset: 0x0000BAAC
		public int LongDelta { get; set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000D8B5 File Offset: 0x0000BAB5
		// (set) Token: 0x06000498 RID: 1176 RVA: 0x0000D8BD File Offset: 0x0000BABD
		public int LatDelta { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000D8C6 File Offset: 0x0000BAC6
		// (set) Token: 0x0600049A RID: 1178 RVA: 0x0000D8CE File Offset: 0x0000BACE
		public int Elevation { get; set; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x0000D8D7 File Offset: 0x0000BAD7
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x0000D8DF File Offset: 0x0000BADF
		public byte Heartrate { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000D8E8 File Offset: 0x0000BAE8
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x0000D8F0 File Offset: 0x0000BAF0
		public int Barometer { get; set; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000D8F9 File Offset: 0x0000BAF9
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0000D901 File Offset: 0x0000BB01
		public uint Cadence { get; set; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000D90A File Offset: 0x0000BB0A
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0000D912 File Offset: 0x0000BB12
		public double SkinTemp { get; set; }

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0000D91B File Offset: 0x0000BB1B
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x0000D923 File Offset: 0x0000BB23
		public int GSR { get; set; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0000D92C File Offset: 0x0000BB2C
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x0000D934 File Offset: 0x0000BB34
		public int UV { get; set; }

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0000D93D File Offset: 0x0000BB3D
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x0000D945 File Offset: 0x0000BB45
		public double DistMeter { get; set; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x0000D94E File Offset: 0x0000BB4E
		// (set) Token: 0x060004AA RID: 1194 RVA: 0x0000D956 File Offset: 0x0000BB56
		public double SpeedMeterPerSecond { get; set; }

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0000D95F File Offset: 0x0000BB5F
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x0000D967 File Offset: 0x0000BB67
		public double TotalMeters { get; internal set; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000D970 File Offset: 0x0000BB70
		public ushort SleepType
		{
			get
			{
				return (ushort)(this.Cadence >> 16);
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0000D97C File Offset: 0x0000BB7C
		public ushort SegmentType
		{
			get
			{
				return (ushort)(this.Cadence & 65535U);
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0000D98B File Offset: 0x0000BB8B
		public override string ToString()
		{
			return this.Title;
		}
	}
}
