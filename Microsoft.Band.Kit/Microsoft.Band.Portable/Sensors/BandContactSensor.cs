// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandContactSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandContactSensor : BandSensorBase<BandContactReading>
  {
    //internal readonly IBandSensor<IBandContactReading> Native;
    internal readonly BandSensorManager manager;

    internal BandContactSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = (IBandSensor<IBandContactReading>) manager.Native.Contact;
      //this.Native.ReadingChanged += new EventHandler<BandSensorReadingEventArgs<IBandContactReading>>(this.OnReadingChanged);
    }

   // private void OnReadingChanged(object sender, BandSensorReadingEventArgs<IBandContactReading> e) => this.OnReadingChanged(new BandContactReading(e.SensorReading.State.FromNative()));

    public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
    {
      //this.Native.ApplySampleRate<IBandContactReading>(sampleRate);
      //int num = await this.Native.StartReadingsAsync() ? 1 : 0;
    }

        public override async Task StopReadingsAsync()
        {
            //await this.Native.StopReadingsAsync();
        }
    }
}
