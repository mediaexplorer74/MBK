// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandSkinTemperatureReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandSkinTemperatureReading : IBandSensorReading
  {
    internal BandSkinTemperatureReading(double temp) => this.Temperature = temp;

    public double Temperature { get; private set; }

    public override string ToString() => string.Format("Temperature={0}", (object) this.Temperature);
  }
}
