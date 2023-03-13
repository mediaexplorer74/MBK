namespace MobileBandSync.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class WorkoutData
    {
        private IEnumerable<WorkoutItem> _workouts;
        private string _workoutTitle;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null);

        public string WorkoutTitle { get; set; }

        public IEnumerable<WorkoutItem> Workouts { get; set; }
    }
}

