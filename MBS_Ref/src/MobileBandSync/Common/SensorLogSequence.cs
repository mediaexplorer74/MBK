namespace MobileBandSync.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class SensorLogSequence
    {
        public SensorLogSequence(long lFileTime);

        public DateTime? TimeStamp { get; set; }

        public TimeSpan? Duration { get; set; }

        public int ID { get; set; }

        public int UtcOffset { get; set; }

        public List<HeartRate> HeartRates { get; }

        public List<Waypoint> Waypoints { get; }

        public List<Counter> Counters { get; }

        public List<SkinTemperature> Temperatures { get; }

        public List<Sensor> SensorList { get; }

        public List<Steps> StepSnapshots { get; }

        public List<SleepSummary> SleepSummaries { get; }

        public List<WorkoutMarker> WorkoutMarkers { get; }

        public List<WorkoutMarker2> WorkoutMarkers2 { get; }

        public List<SensorValueCollection1> SensorValues1 { get; }

        public List<SensorValueCollection2> SensorValues2 { get; }

        public List<SensorValueCollection3> SensorValues3 { get; }

        public List<UnknownData> AdditionalData { get; }

        public List<WorkoutSummary> WorkoutSummaries { get; }

        public List<DailySummary> DailySummaries { get; }
    }
}

