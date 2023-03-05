// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandGyroscopeReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandGyroscopeReading : IBandSensorReading
  {
    internal BandGyroscopeReading(double x, double y, double z)
    {
      this.AngularVelocityX = x;
      this.AngularVelocityY = y;
      this.AngularVelocityZ = z;
    }

    public double AngularVelocityX { get; private set; }

    public double AngularVelocityY { get; private set; }

    public double AngularVelocityZ { get; private set; }

    public override string ToString() => string.Format("AngularVelocityX={0}, AngularVelocityY={1}, AngularVelocityZ={2}", (object) this.AngularVelocityX, (object) this.AngularVelocityY, (object) this.AngularVelocityZ);
  }
}
