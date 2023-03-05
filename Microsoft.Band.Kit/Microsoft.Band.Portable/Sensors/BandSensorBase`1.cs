// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandSensorBase`1
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public abstract class BandSensorBase<T> : IBandSensor<T> where T : IBandSensorReading
  {
    public event EventHandler<BandSensorReadingEventArgs<T>> ReadingChanged;

    protected void OnReadingChanged(T reading)
    {
      EventHandler<BandSensorReadingEventArgs<T>> readingChanged = this.ReadingChanged;
      if (readingChanged == null)
        return;
      readingChanged((object) this, new BandSensorReadingEventArgs<T>(reading));
    }

    public virtual Task StartReadingsAsync() => this.StartReadingsAsync(BandSensorSampleRate.Ms16);

    public abstract Task StartReadingsAsync(BandSensorSampleRate sampleRate);

    public abstract Task StopReadingsAsync();
  }
}
