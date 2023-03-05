// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandAltimeterSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandAltimeterSensor : BandSensorBase<BandAltimeterReading>
  {
    //internal readonly IBandSensor<IBandAltimeterReading> Native;
    internal readonly BandSensorManager manager;

    internal BandAltimeterSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = manager.Native.Altimeter;
      //this.Native.ReadingChanged += new EventHandler<BandSensorReadingEventArgs<IBandAltimeterReading>>(this.OnReadingChanged);
    }

    //private void OnReadingChanged(
    //  object sender,
    //  BandSensorReadingEventArgs<IBandAltimeterReading> e)
    //{
    //  IBandAltimeterReading sensorReading = e.SensorReading;
    //  this.OnReadingChanged(new BandAltimeterReading(sensorReading.FlightsAscended, sensorReading.FlightsDescended, (double) sensorReading.Rate, sensorReading.SteppingGain, sensorReading.SteppingLoss, sensorReading.StepsAscended, sensorReading.StepsDescended, sensorReading.TotalGain, sensorReading.TotalLoss, sensorReading.FlightsAscendedToday, sensorReading.TotalGainToday));
    //}

    public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
    {
     // this.Native.ApplySampleRate<IBandAltimeterReading>(sampleRate);
     // int num = await this.Native.StartReadingsAsync() ? 1 : 0;
    }

        public override async Task StopReadingsAsync()
        {
            //await this.Native.StopReadingsAsync();
        }
    }
}
