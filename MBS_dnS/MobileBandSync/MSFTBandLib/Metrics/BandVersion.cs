using System;
using MobileBandSync.MSFTBandLib.Command;
using MobileBandSync.MSFTBandLib.Includes;

namespace MobileBandSync.MSFTBandLib.Metrics
{
	// Token: 0x02000066 RID: 102
	public class BandVersion
	{
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0000B681 File Offset: 0x00009881
		// (set) Token: 0x0600038C RID: 908 RVA: 0x0000B689 File Offset: 0x00009889
		public string AppName { get; protected set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0000B692 File Offset: 0x00009892
		// (set) Token: 0x0600038E RID: 910 RVA: 0x0000B69A File Offset: 0x0000989A
		public byte PCBId { get; protected set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600038F RID: 911 RVA: 0x0000B6A3 File Offset: 0x000098A3
		// (set) Token: 0x06000390 RID: 912 RVA: 0x0000B6AB File Offset: 0x000098AB
		public ushort VersionMajor { get; protected set; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0000B6B4 File Offset: 0x000098B4
		// (set) Token: 0x06000392 RID: 914 RVA: 0x0000B6BC File Offset: 0x000098BC
		public ushort VersionMinor { get; protected set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000393 RID: 915 RVA: 0x0000B6C5 File Offset: 0x000098C5
		// (set) Token: 0x06000394 RID: 916 RVA: 0x0000B6CD File Offset: 0x000098CD
		public uint Revision { get; protected set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000395 RID: 917 RVA: 0x0000B6D6 File Offset: 0x000098D6
		// (set) Token: 0x06000396 RID: 918 RVA: 0x0000B6DE File Offset: 0x000098DE
		public uint BuildNumber { get; protected set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000397 RID: 919 RVA: 0x0000B6E7 File Offset: 0x000098E7
		// (set) Token: 0x06000398 RID: 920 RVA: 0x0000B6EF File Offset: 0x000098EF
		public byte DebugBuild { get; protected set; }

		// Token: 0x06000399 RID: 921 RVA: 0x00008E70 File Offset: 0x00007070
		public BandVersion()
		{
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000B6F8 File Offset: 0x000098F8
		public BandVersion(CommandResponse response)
		{
			ByteStream byteStream = response.GetByteStream(0);
			int num = 0;
			string text = "";
			for (char @byte = (char)byteStream.GetByte(num++); @byte != '\0'; @byte = (char)byteStream.GetByte(num++))
			{
				text += @byte.ToString();
			}
			this.AppName = text;
			this.PCBId = byteStream.GetByte(num);
			this.VersionMajor = byteStream.GetUshort(num + 1);
			this.VersionMinor = byteStream.GetUshort(num + 3);
			this.Revision = byteStream.GetUint32(num + 5);
			this.BuildNumber = byteStream.GetUint32(num + 9);
			this.DebugBuild = byteStream.GetByte(num + 13);
		}
	}
}
