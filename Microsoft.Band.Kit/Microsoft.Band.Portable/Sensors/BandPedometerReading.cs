// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandPedometerReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandPedometerReading : IBandSensorReading
  {
    internal BandPedometerReading(long total, long stepsToday)
    {
      this.TotalSteps = total;
      this.StepsToday = stepsToday;
    }

    public long TotalSteps { get; private set; }

    public long StepsToday { get; private set; }

    public override string ToString() => string.Format("TotalSteps={0}, StepsToday={1}", (object) this.TotalSteps, (object) this.StepsToday);
  }
}
