// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandDistanceSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandDistanceSensor : BandSensorBase<BandDistanceReading>
  {
    //internal readonly IBandSensor<IBandDistanceReading> Native;
    internal readonly BandSensorManager manager;

    internal BandDistanceSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = manager.Native.Distance;
      //this.Native.ReadingChanged += new EventHandler<BandSensorReadingEventArgs<IBandDistanceReading>>(this.OnReadingChanged);
    }

   // private void OnReadingChanged(object sender, BandSensorReadingEventArgs<IBandDistanceReading> e)
   // {
   //   IBandDistanceReading sensorReading = e.SensorReading;
   //   this.OnReadingChanged(new BandDistanceReading(sensorReading.CurrentMotion.FromNative(), sensorReading.Pace, sensorReading.Speed, sensorReading.TotalDistance, sensorReading.DistanceToday));
   // }

    public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
    {
     // this.Native.ApplySampleRate<IBandDistanceReading>(sampleRate);
     // int num = await this.Native.StartReadingsAsync() ? 1 : 0;
    }

        public override async Task StopReadingsAsync()
        {
            //await this.Native.StopReadingsAsync();
        }
    }
}
