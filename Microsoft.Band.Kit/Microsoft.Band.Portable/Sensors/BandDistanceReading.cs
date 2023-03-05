// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandDistanceReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandDistanceReading : IBandSensorReading
  {
    internal BandDistanceReading(
      MotionType motion,
      double pace,
      double speed,
      long total,
      long distanceToday)
    {
      this.CurrentMotion = motion;
      this.Pace = pace;
      this.Speed = speed;
      this.TotalDistance = total;
      this.DistanceToday = distanceToday;
    }

    public MotionType CurrentMotion { get; private set; }

    public double Pace { get; private set; }

    public double Speed { get; private set; }

    public long TotalDistance { get; private set; }

    public long DistanceToday { get; private set; }

    public override string ToString() => string.Format("CurrentMotion={0}, Pace={1}, Speed={2}, TotalDistance={3}, DistanceToday={4}", (object) this.CurrentMotion, (object) this.Pace, (object) this.Speed, (object) this.TotalDistance, (object) this.DistanceToday);
  }
}
