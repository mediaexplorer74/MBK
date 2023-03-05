// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandPedometerSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandPedometerSensor : BandSensorBase<BandPedometerReading>
  {
    //internal readonly IBandSensor<IBandPedometerReading> Native;
    internal readonly BandSensorManager manager;

    internal BandPedometerSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = manager.Native.Pedometer;
      //this.Native.ReadingChanged
      //   += new EventHandler<BandSensorReadingEventArgs<IBandPedometerReading>>(this.OnReadingChanged);
    }

        /*
    private void OnReadingChanged(
      object sender,
      BandSensorReadingEventArgs<IBandPedometerReading> e)
    {
      IBandPedometerReading sensorReading = e.SensorReading;
      this.OnReadingChanged(new BandPedometerReading(sensorReading.TotalSteps, sensorReading.StepsToday));
    }
        */

    public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
    {
     // this.Native.ApplySampleRate<IBandPedometerReading>(sampleRate);
     // int num = await this.Native.StartReadingsAsync() ? 1 : 0;
    }

        public override async Task StopReadingsAsync()
        {
            //await this.Native.StopReadingsAsync();
        }
    }
}
