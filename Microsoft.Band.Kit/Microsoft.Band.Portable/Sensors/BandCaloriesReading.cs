// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandCaloriesReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandCaloriesReading : IBandSensorReading
  {
    internal BandCaloriesReading(long calories, long caloriesToday)
    {
      this.Calories = calories;
      this.CaloriesToday = caloriesToday;
    }

    public long Calories { get; private set; }

    public long CaloriesToday { get; private set; }

    public override string ToString() => string.Format("Calories={0}, CaloriesToday={1}", (object) this.Calories, (object) this.CaloriesToday);
  }
}
