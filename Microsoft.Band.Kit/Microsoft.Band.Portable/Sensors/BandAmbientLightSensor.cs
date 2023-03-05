// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandAmbientLightSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandAmbientLightSensor : BandSensorBase<BandAmbientLightReading>
  {
    //internal readonly IBandSensor<IBandAmbientLightReading> Native;
    internal readonly BandSensorManager manager;

    internal BandAmbientLightSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = manager.Native.AmbientLight;
      //this.Native.ReadingChanged += new EventHandler<BandSensorReadingEventArgs<IBandAmbientLightReading>>(this.OnReadingChanged);
    }

   // private void OnReadingChanged(
    //  object sender,
    //  BandSensorReadingEventArgs<IBandAmbientLightReading> e)
    //{
    //  this.OnReadingChanged(new BandAmbientLightReading(e.SensorReading.Brightness));
    //}

        public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
        {
        //  this.Native.ApplySampleRate<IBandAmbientLightReading>(sampleRate);
        //  int num = await this.Native.StartReadingsAsync() ? 1 : 0;
        }

        public override async Task StopReadingsAsync()
        {
            //await this.Native.StopReadingsAsync();
        }
    }
}
