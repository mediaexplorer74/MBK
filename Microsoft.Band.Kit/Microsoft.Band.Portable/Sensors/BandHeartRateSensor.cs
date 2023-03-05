// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandHeartRateSensor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandHeartRateSensor : 
    BandSensorBase<BandHeartRateReading>,
    IUserConsentingBandSensor<BandHeartRateReading>,
    IBandSensor<BandHeartRateReading>
  {
    //internal readonly IBandSensor<IBandHeartRateReading> Native;
    internal readonly BandSensorManager manager;

    internal BandHeartRateSensor(BandSensorManager manager)
    {
      this.manager = manager;
      //this.Native = manager.Native.HeartRate;
      //this.Native.ReadingChanged += new EventHandler<BandSensorReadingEventArgs<IBandHeartRateReading>>(this.OnReadingChanged);
    }

        /*
    private void OnReadingChanged(
      object sender,
      BandSensorReadingEventArgs<IBandHeartRateReading> e)
    {
      IBandHeartRateReading sensorReading = e.SensorReading;
      this.OnReadingChanged(new BandHeartRateReading(sensorReading.Quality.FromNative(), sensorReading.HeartRate));
    }
        */


    public override async Task StartReadingsAsync(BandSensorSampleRate sampleRate)
    {
      //this.Native.ApplySampleRate<IBandHeartRateReading>(sampleRate);
      //int num = await this.Native.StartReadingsAsync() ? 1 : 0;
    }

        public override async Task StopReadingsAsync()
        {
            //await this.Native.StopReadingsAsync();
        }

        public Microsoft.Band.Portable.UserConsent UserConsented
        {
            get
            {
                return default;//this.Native.GetCurrentUserConsent().FromNative();
            }
        }

        public async Task<bool> RequestUserConsent()
        {
            return default;//await this.Native.RequestUserConsentAsync();
        }
    }
}
