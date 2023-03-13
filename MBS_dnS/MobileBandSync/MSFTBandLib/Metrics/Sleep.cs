using System;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Metrics
{
	// Token: 0x02000067 RID: 103
	public class Sleep
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600039B RID: 923 RVA: 0x0000B7A7 File Offset: 0x000099A7
		// (set) Token: 0x0600039C RID: 924 RVA: 0x0000B7AF File Offset: 0x000099AF
		public uint Calories { get; protected set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600039D RID: 925 RVA: 0x0000B7B8 File Offset: 0x000099B8
		// (set) Token: 0x0600039E RID: 926 RVA: 0x0000B7C0 File Offset: 0x000099C0
		public uint Duration { get; protected set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600039F RID: 927 RVA: 0x0000B7C9 File Offset: 0x000099C9
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x0000B7D1 File Offset: 0x000099D1
		public uint Feeling { get; protected set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x0000B7DA File Offset: 0x000099DA
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x0000B7E2 File Offset: 0x000099E2
		public uint RestingHR { get; protected set; }

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0000B7EB File Offset: 0x000099EB
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x0000B7F3 File Offset: 0x000099F3
		public uint TimeAsleep { get; protected set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0000B7FC File Offset: 0x000099FC
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x0000B804 File Offset: 0x00009A04
		public uint TimeAwake { get; protected set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x0000B80D File Offset: 0x00009A0D
		// (set) Token: 0x060003A8 RID: 936 RVA: 0x0000B815 File Offset: 0x00009A15
		public uint TimeToSleep { get; protected set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003A9 RID: 937 RVA: 0x0000B81E File Offset: 0x00009A1E
		// (set) Token: 0x060003AA RID: 938 RVA: 0x0000B826 File Offset: 0x00009A26
		public uint TimesAwoke { get; protected set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003AB RID: 939 RVA: 0x0000B82F File Offset: 0x00009A2F
		// (set) Token: 0x060003AC RID: 940 RVA: 0x0000B837 File Offset: 0x00009A37
		public DateTime Timestamp { get; protected set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060003AD RID: 941 RVA: 0x0000B840 File Offset: 0x00009A40
		// (set) Token: 0x060003AE RID: 942 RVA: 0x0000B848 File Offset: 0x00009A48
		public DateTime WokeUp { get; protected set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003AF RID: 943 RVA: 0x0000B851 File Offset: 0x00009A51
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x0000B859 File Offset: 0x00009A59
		public ushort Version { get; protected set; }

		// Token: 0x060003B1 RID: 945 RVA: 0x00008E70 File Offset: 0x00007070
		public Sleep()
		{
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000B864 File Offset: 0x00009A64
		public Sleep(CommandResponse response)
		{
			ByteStream byteStream = response.GetByteStream(0);
			this.Calories = byteStream.GetUint32(26);
			this.Duration = byteStream.GetUint32(10) / 1000U;
			this.Feeling = byteStream.GetUint32(50);
			this.RestingHR = byteStream.GetUint32(30);
			this.TimeAsleep = byteStream.GetUint32(22) / 1000U;
			this.TimeAwake = byteStream.GetUint32(18) / 1000U;
			this.TimeToSleep = byteStream.GetUint32(46) / 1000U;
			this.TimesAwoke = byteStream.GetUint32(14);
			this.Timestamp = DateTime.FromFileTime((long)byteStream.GetUint64(0));
			this.WokeUp = DateTime.FromFileTime((long)byteStream.GetUint64(38));
			this.Version = byteStream.GetUshort(8);
		}
	}
}
