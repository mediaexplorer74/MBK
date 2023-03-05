// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandSensorReadingEventArgs`1
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using System;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandSensorReadingEventArgs<T> : EventArgs where T : IBandSensorReading
  {
    public BandSensorReadingEventArgs(T reading) => this.SensorReading = reading;

    public T SensorReading { get; private set; }
  }
}
