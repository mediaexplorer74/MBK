using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Maps;

namespace MobileBandSync.Common
{
	// Token: 0x020000A4 RID: 164
	public class WorkoutFilterData
	{
		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00010289 File Offset: 0x0000E489
		// (set) Token: 0x06000642 RID: 1602 RVA: 0x00010291 File Offset: 0x0000E491
		public DateTime Start { get; set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x0001029A File Offset: 0x0000E49A
		// (set) Token: 0x06000644 RID: 1604 RVA: 0x000102A2 File Offset: 0x0000E4A2
		public DateTime End { get; set; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x000102AB File Offset: 0x0000E4AB
		// (set) Token: 0x06000646 RID: 1606 RVA: 0x000102B3 File Offset: 0x0000E4B3
		public bool? IsRunningWorkout { get; set; }

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x000102BC File Offset: 0x0000E4BC
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x000102C4 File Offset: 0x0000E4C4
		public bool? IsBikingWorkout { get; set; }

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x000102CD File Offset: 0x0000E4CD
		// (set) Token: 0x0600064A RID: 1610 RVA: 0x000102D5 File Offset: 0x0000E4D5
		public bool? IsWalkingWorkout { get; set; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x000102DE File Offset: 0x0000E4DE
		// (set) Token: 0x0600064C RID: 1612 RVA: 0x000102E6 File Offset: 0x0000E4E6
		public bool? IsSleepingWorkout { get; set; }

		// Token: 0x0600064E RID: 1614 RVA: 0x000102F0 File Offset: 0x0000E4F0
		public GeoboundingBox SetBounds(MapControl map)
		{
			if (map == null)
			{
				this.MapBoundingBox = null;
			}
			else
			{
				Geopoint geopoint = null;
				try
				{
					map.GetLocationFromOffset(new Point(0.0, 0.0), ref geopoint);
				}
				catch
				{
					BasicGeoposition basicGeoposition = default(BasicGeoposition);
					basicGeoposition.Latitude = 85.0;
					basicGeoposition.Longitude = 0.0;
					Geopoint geopoint2 = new Geopoint(basicGeoposition);
					Point point;
					map.GetOffsetFromLocation(geopoint2, ref point);
					map.GetLocationFromOffset(new Point(0.0, point.Y), ref geopoint);
				}
				Geopoint geopoint3 = null;
				try
				{
					map.GetLocationFromOffset(new Point(map.ActualWidth, map.ActualHeight), ref geopoint3);
				}
				catch
				{
					BasicGeoposition basicGeoposition = default(BasicGeoposition);
					basicGeoposition.Latitude = -85.0;
					basicGeoposition.Longitude = 0.0;
					Geopoint geopoint4 = new Geopoint(basicGeoposition);
					Point point2;
					map.GetOffsetFromLocation(geopoint4, ref point2);
					map.GetLocationFromOffset(new Point(0.0, point2.Y), ref geopoint3);
				}
				if (geopoint != null && geopoint3 != null)
				{
					this.MapBoundingBox = new GeoboundingBox(geopoint.Position, geopoint3.Position);
					return this.MapBoundingBox;
				}
			}
			return null;
		}

		// Token: 0x04000416 RID: 1046
		public string strSearchText;

		// Token: 0x0400041B RID: 1051
		public GeoboundingBox MapBoundingBox;

		// Token: 0x0400041C RID: 1052
		public bool MapSelected;
	}
}
