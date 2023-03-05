// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Sensors.BandGyroscopeReading
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System;

namespace Microsoft.Band.Sensors
{
  internal sealed class BandGyroscopeReading : 
    BandAccelerometerReading,
    IBandGyroscopeReading,
    IBandAccelerometerReading,
    IBandSensorReading
  {
    private const double ConversionFactor = 0.030487804878048783;
    private new const int serializedByteCount = 12;

    private BandGyroscopeReading(DateTimeOffset timestamp)
      : base(timestamp)
    {
    }

    public double AngularVelocityX { get; private set; }

    public double AngularVelocityY { get; private set; }

    public double AngularVelocityZ { get; private set; }

    internal override void Dispatch(BandClient client)
    {
      if (client.gyroscope == null)
        return;
      client.gyroscope.ProcessSensorReading((IBandGyroscopeReading) this);
    }

    internal new static int GetSerializedByteCount(RemoteSubscriptionSampleHeader header) => 12;

    internal static BandGyroscopeReading DeserializeFromBand(
      ICargoReader reader,
      RemoteSubscriptionSampleHeader header,
      DateTimeOffset timestamp)
    {
      BandGyroscopeReading gyroscopeReading = new BandGyroscopeReading(timestamp);
      gyroscopeReading.DeserializeFromBand(reader);
      return gyroscopeReading;
    }

    private new void DeserializeFromBand(ICargoReader reader)
    {
      base.DeserializeFromBand(reader);
      this.AngularVelocityX = (double) reader.ReadInt16() * (5.0 / 164.0);
      this.AngularVelocityY = (double) reader.ReadInt16() * (5.0 / 164.0);
      this.AngularVelocityZ = (double) reader.ReadInt16() * (5.0 / 164.0);
    }
  }
}
