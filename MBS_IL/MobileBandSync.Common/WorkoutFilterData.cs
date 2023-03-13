using System;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;

namespace MobileBandSync.Common;

public class WorkoutFilterData
{
	public string strSearchText;

	public GeoboundingBox MapBoundingBox;

	public bool MapSelected;

	public DateTime Start { get; set; }

	public DateTime End { get; set; }

	public bool? IsRunningWorkout { get; set; }

	public bool? IsBikingWorkout { get; set; }

	public bool? IsWalkingWorkout { get; set; }

	public bool? IsSleepingWorkout { get; set; }

	public GeoboundingBox SetBounds(MapControl map)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		if (map == null)
		{
			MapBoundingBox = null;
		}
		else
		{
			Geopoint val = null;
			try
			{
				map.GetLocationFromOffset(new Point(0.0, 0.0), ref val);
			}
			catch
			{
				BasicGeoposition val2 = default(BasicGeoposition);
				val2.Latitude = 85.0;
				val2.Longitude = 0.0;
				Geopoint val3 = new Geopoint(val2);
				Point val4 = default(Point);
				map.GetOffsetFromLocation(val3, ref val4);
				map.GetLocationFromOffset(new Point(0.0, ((Point)(ref val4)).Y), ref val);
			}
			Geopoint val5 = null;
			try
			{
				map.GetLocationFromOffset(new Point(((FrameworkElement)map).ActualWidth, ((FrameworkElement)map).ActualHeight), ref val5);
			}
			catch
			{
				BasicGeoposition val2 = default(BasicGeoposition);
				val2.Latitude = -85.0;
				val2.Longitude = 0.0;
				Geopoint val6 = new Geopoint(val2);
				Point val7 = default(Point);
				map.GetOffsetFromLocation(val6, ref val7);
				map.GetLocationFromOffset(new Point(0.0, ((Point)(ref val7)).Y), ref val5);
			}
			if (val != null && val5 != null)
			{
				MapBoundingBox = new GeoboundingBox(val.Position, val5.Position);
				return MapBoundingBox;
			}
		}
		return null;
	}
}
