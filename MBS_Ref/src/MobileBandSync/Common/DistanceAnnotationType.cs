namespace MobileBandSync.Common
{
    using System;

    public enum DistanceAnnotationType
    {
        public const DistanceAnnotationType Unknown = DistanceAnnotationType.Unknown;,
        public const DistanceAnnotationType Start = DistanceAnnotationType.Start;,
        public const DistanceAnnotationType End = DistanceAnnotationType.End;,
        public const DistanceAnnotationType Split = DistanceAnnotationType.Split;,
        public const DistanceAnnotationType Pause = DistanceAnnotationType.Pause;,
        public const DistanceAnnotationType UserGenerated = DistanceAnnotationType.UserGenerated;,
        public const DistanceAnnotationType ElevationMax = DistanceAnnotationType.ElevationMax;,
        public const DistanceAnnotationType ElevationMin = DistanceAnnotationType.ElevationMin;,
        public const DistanceAnnotationType TimeMidPoint = DistanceAnnotationType.TimeMidPoint;,
        public const DistanceAnnotationType Sunrise = DistanceAnnotationType.Sunrise;,
        public const DistanceAnnotationType Sunset = DistanceAnnotationType.Sunset;
    }
}

