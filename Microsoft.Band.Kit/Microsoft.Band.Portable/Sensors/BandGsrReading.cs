// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandGsrReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandGsrReading : IBandSensorReading
  {
    internal BandGsrReading(long resistance) => this.Resistance = resistance;

    public long Resistance { get; private set; }

    public override string ToString() => string.Format("Resistance={0}", (object) this.Resistance);
  }
}
