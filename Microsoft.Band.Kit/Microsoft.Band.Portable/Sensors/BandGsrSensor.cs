// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandGsrSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandGsrSensor : BandSensorBase<BandGsrReading>
  {
    //internal readonly IBandSensor<IBandGsrReading> Native;
    internal readonly BandSensorManager manager;

    internal BandGsrSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = manager.Native.Gsr;
      //this.Native.ReadingChanged += new EventHandler<BandSensorReadingEventArgs<IBandGsrReading>>(this.OnReadingChanged);
    }

    //private void OnReadingChanged(object sender, BandSensorReadingEventArgs<IBandGsrReading> e) 
    //        => this.OnReadingChanged(new BandGsrReading((long) e.SensorReading.Resistance));

    public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
    {
      //this.Native.ApplySampleRate<IBandGsrReading>(sampleRate);
      //int num = await this.Native.StartReadingsAsync() ? 1 : 0;
    }

        public override async Task StopReadingsAsync()
        {
           // await this.Native.StopReadingsAsync();
        }
    }
}
