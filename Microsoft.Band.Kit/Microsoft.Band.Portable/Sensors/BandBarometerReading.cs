// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandBarometerReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandBarometerReading : IBandSensorReading
  {
    internal BandBarometerReading(double airPressure, double temperature)
    {
      this.AirPressure = airPressure;
      this.Temperature = temperature;
    }

    public double AirPressure { get; private set; }

    public double Temperature { get; private set; }

    public override string ToString() => string.Format("AirPressure={0}, Temperature={1}", (object) this.AirPressure, (object) this.Temperature);
  }
}
