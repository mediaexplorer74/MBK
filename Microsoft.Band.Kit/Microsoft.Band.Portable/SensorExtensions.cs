// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.SensorExtensions
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Portable.Sensors;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Band.Portable
{
  internal static class SensorExtensions
  {
    public static void ApplySampleRate<T>(
      this Band.Sensors.IBandSensor<T> sensor,
      BandSensorSampleRate sampleRate)
      where T : Microsoft.Band.Sensors.IBandSensorReading
    {
      TimeSpan native = sampleRate.ToNative();
      IEnumerable<TimeSpan> reportingIntervals = sensor.SupportedReportingIntervals;
      if (reportingIntervals.Contains<TimeSpan>(native))
        sensor.ReportingInterval = native;
      else
        sensor.ReportingInterval = reportingIntervals.First<TimeSpan>();
    }

    public static TimeSpan ToNative(this BandSensorSampleRate sampleRate)
    {
      switch (sampleRate)
      {
        case BandSensorSampleRate.Ms32:
          return TimeSpan.FromMilliseconds(32.0);
        case BandSensorSampleRate.Ms128:
          return TimeSpan.FromMilliseconds(128.0);
        default:
          return TimeSpan.FromMilliseconds(16.0);
      }
    }

    public static Microsoft.Band.Portable.Sensors.MotionType FromNative(
      this Microsoft.Band.Sensors.MotionType motion)
    {
      switch (motion)
      {
        case Microsoft.Band.Sensors.MotionType.Idle:
          return Microsoft.Band.Portable.Sensors.MotionType.Idle;
        case Microsoft.Band.Sensors.MotionType.Walking:
          return Microsoft.Band.Portable.Sensors.MotionType.Walking;
        case Microsoft.Band.Sensors.MotionType.Jogging:
          return Microsoft.Band.Portable.Sensors.MotionType.Jogging;
        case Microsoft.Band.Sensors.MotionType.Running:
          return Microsoft.Band.Portable.Sensors.MotionType.Running;
        default:
          return Microsoft.Band.Portable.Sensors.MotionType.Unknown;
      }
    }

    public static Microsoft.Band.Portable.Sensors.HeartRateQuality FromNative(
      this Microsoft.Band.Sensors.HeartRateQuality motion)
    {
      if (motion == Microsoft.Band.Sensors.HeartRateQuality.Locked)
        return Microsoft.Band.Portable.Sensors.HeartRateQuality.Locked;
      return motion == Microsoft.Band.Sensors.HeartRateQuality.Acquiring ? Microsoft.Band.Portable.Sensors.HeartRateQuality.Acquiring : Microsoft.Band.Portable.Sensors.HeartRateQuality.Unknown;
    }

    public static Microsoft.Band.Portable.Sensors.UVIndexLevel FromNative(
      this Microsoft.Band.Sensors.UVIndexLevel level)
    {
      switch (level)
      {
        case Microsoft.Band.Sensors.UVIndexLevel.None:
          return Microsoft.Band.Portable.Sensors.UVIndexLevel.None;
        case Microsoft.Band.Sensors.UVIndexLevel.Low:
          return Microsoft.Band.Portable.Sensors.UVIndexLevel.Low;
        case Microsoft.Band.Sensors.UVIndexLevel.Medium:
          return Microsoft.Band.Portable.Sensors.UVIndexLevel.Medium;
        case Microsoft.Band.Sensors.UVIndexLevel.High:
          return Microsoft.Band.Portable.Sensors.UVIndexLevel.High;
        case Microsoft.Band.Sensors.UVIndexLevel.VeryHigh:
          return Microsoft.Band.Portable.Sensors.UVIndexLevel.VeryHigh;
        default:
          return Microsoft.Band.Portable.Sensors.UVIndexLevel.Unknown;
      }
    }

    public static ContactState FromNative(this BandContactState state)
    {
      if (state == BandContactState.NotWorn)
        return ContactState.NotWorn;
      return state == BandContactState.Worn ? ContactState.Worn : ContactState.Unknown;
    }
  }
}
