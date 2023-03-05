// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandGyroscopeSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandGyroscopeSensor : BandSensorBase<BandGyroscopeReading>
  {
    //internal readonly IBandSensor<IBandGyroscopeReading> Native;
    internal readonly BandSensorManager manager;

    internal BandGyroscopeSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = manager.Native.Gyroscope;
      //this.Native.ReadingChanged += new EventHandler<BandSensorReadingEventArgs<IBandGyroscopeReading>>(this.OnReadingChanged);
    }

        /*
    private void OnReadingChanged(
      object sender,
      BandSensorReadingEventArgs<IBandGyroscopeReading> e)
    {
      IBandGyroscopeReading sensorReading = e.SensorReading;
      this.OnReadingChanged(new BandGyroscopeReading(sensorReading.AngularVelocityX, sensorReading.AngularVelocityY, sensorReading.AngularVelocityZ));
    }
        */

    public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
    {
      //this.Native.ApplySampleRate<IBandGyroscopeReading>(sampleRate);
      //int num = await this.Native.StartReadingsAsync() ? 1 : 0;
    }

        public override async Task StopReadingsAsync()
        {
            //await this.Native.StopReadingsAsync();
        }
    }
}
