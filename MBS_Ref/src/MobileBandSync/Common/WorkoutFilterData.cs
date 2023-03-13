namespace MobileBandSync.Common
{
    using System;
    using System.Runtime.CompilerServices;
    using Windows.Devices.Geolocation;
    using Windows.UI.Xaml.Controls.Maps;

    public class WorkoutFilterData
    {
        public string strSearchText;
        public GeoboundingBox MapBoundingBox;
        public bool MapSelected;

        public GeoboundingBox SetBounds(MapControl map);

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool? IsRunningWorkout { get; set; }

        public bool? IsBikingWorkout { get; set; }

        public bool? IsWalkingWorkout { get; set; }

        public bool? IsSleepingWorkout { get; set; }
    }
}

