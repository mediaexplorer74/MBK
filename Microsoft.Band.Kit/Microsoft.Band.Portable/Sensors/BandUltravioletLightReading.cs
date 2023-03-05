// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandUltravioletLightReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandUltravioletLightReading : IBandSensorReading
  {
    internal BandUltravioletLightReading(UVIndexLevel level, long exposureToday)
    {
      this.Level = level;
      this.ExposureToday = exposureToday;
    }

    public UVIndexLevel Level { get; private set; }

    public long ExposureToday { get; private set; }

    public override string ToString() => string.Format("Level={0}, ExposureToday={1}", (object) this.Level, (object) this.ExposureToday);
  }
}
