using System;

namespace MobileBandSync.Common
{
	// Token: 0x02000091 RID: 145
	public class Waypoint
	{
		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x0000E491 File Offset: 0x0000C691
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x0000E499 File Offset: 0x0000C699
		public double Longitude { get; set; }

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x0000E4A2 File Offset: 0x0000C6A2
		// (set) Token: 0x06000552 RID: 1362 RVA: 0x0000E4AA File Offset: 0x0000C6AA
		public double Latitude { get; set; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x0000E4B3 File Offset: 0x0000C6B3
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x0000E4BB File Offset: 0x0000C6BB
		public double SpeedOverGround { get; set; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0000E4C4 File Offset: 0x0000C6C4
		// (set) Token: 0x06000556 RID: 1366 RVA: 0x0000E4CC File Offset: 0x0000C6CC
		public double ElevationFromMeanSeaLevel { get; set; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x0000E4D5 File Offset: 0x0000C6D5
		// (set) Token: 0x06000558 RID: 1368 RVA: 0x0000E4DD File Offset: 0x0000C6DD
		public double EstimatedHorizontalError { get; set; }

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x0000E4E6 File Offset: 0x0000C6E6
		// (set) Token: 0x0600055A RID: 1370 RVA: 0x0000E4EE File Offset: 0x0000C6EE
		public double EstimatedVerticalError { get; set; }

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x0000E4F7 File Offset: 0x0000C6F7
		// (set) Token: 0x0600055C RID: 1372 RVA: 0x0000E4FF File Offset: 0x0000C6FF
		public DateTime TimeStamp { get; set; }
	}
}
