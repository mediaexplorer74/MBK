// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandSkinTemperatureSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandSkinTemperatureSensor : BandSensorBase<BandSkinTemperatureReading>
  {
    //internal readonly IBandSensor<IBandSkinTemperatureReading> Native;
    internal readonly BandSensorManager manager;

    internal BandSkinTemperatureSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = manager.Native.SkinTemperature;
      //this.Native.ReadingChanged += new EventHandler<BandSensorReadingEventArgs<IBandSkinTemperatureReading>>(this.OnReadingChanged);
    }

        /*
    private void OnReadingChanged(
      object sender,
      BandSensorReadingEventArgs<IBandSkinTemperatureReading> e)
    {
      this.OnReadingChanged(new BandSkinTemperatureReading(e.SensorReading.Temperature));
    }
        */

    public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
    {
      //this.Native.ApplySampleRate<IBandSkinTemperatureReading>(sampleRate);
      //int num = await this.Native.StartReadingsAsync() ? 1 : 0;
    }

        public override async Task StopReadingsAsync()
        {
           // await this.Native.StopReadingsAsync();
        }
    }
}
