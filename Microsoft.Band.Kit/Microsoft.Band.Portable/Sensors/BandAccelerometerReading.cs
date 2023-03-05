// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandAccelerometerReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandAccelerometerReading : IBandSensorReading
  {
    internal BandAccelerometerReading(double x, double y, double z)
    {
      this.AccelerationX = x;
      this.AccelerationY = y;
      this.AccelerationZ = z;
    }

    public double AccelerationX { get; private set; }

    public double AccelerationY { get; private set; }

    public double AccelerationZ { get; private set; }

    public override string ToString() => string.Format("AccelerationX={0}, AccelerationY={1}, AccelerationZ={2}", (object) this.AccelerationX, (object) this.AccelerationY, (object) this.AccelerationZ);
  }
}
