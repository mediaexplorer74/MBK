// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandHeartRateReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandHeartRateReading : IBandSensorReading
  {
    internal BandHeartRateReading(HeartRateQuality quality, int rate)
    {
      this.Quality = quality;
      this.HeartRate = rate;
    }

    public HeartRateQuality Quality { get; private set; }

    public int HeartRate { get; private set; }

    public override string ToString() => string.Format("Quality={0}, HeartRate={1}", (object) this.Quality, (object) this.HeartRate);
  }
}
