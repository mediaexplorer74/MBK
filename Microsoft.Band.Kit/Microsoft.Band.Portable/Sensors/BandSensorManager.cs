// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandSensorManager
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Sensors;
using System;

namespace Microsoft.Band.Portable.Sensors
{
  public class BandSensorManager
  {
    private readonly Lazy<BandAccelerometerSensor> accelerometer;
    private readonly Lazy<BandAltimeterSensor> altimeter;
    private readonly Lazy<BandAmbientLightSensor> ambientLight;
    private readonly Lazy<BandBarometerSensor> barometer;
    private readonly Lazy<BandCaloriesSensor> calories;
    private readonly Lazy<BandContactSensor> contact;
    private readonly Lazy<BandDistanceSensor> distance;
    private readonly Lazy<BandGyroscopeSensor> gyroscope;
    private readonly Lazy<BandGsrSensor> gsr;
    private readonly Lazy<BandHeartRateSensor> heartRate;
    private readonly Lazy<BandPedometerSensor> pedometer;
    private readonly Lazy<BandRRIntervalSensor> rrInterval;
    private readonly Lazy<BandSkinTemperatureSensor> skinTemperature;
    private readonly Lazy<BandUltravioletLightSensor> ultravioletLight;
    private readonly Microsoft.Band.Portable.BandClient client;
    internal readonly IBandSensorManager Native;

    internal BandSensorManager(Microsoft.Band.Portable.BandClient client, IBandSensorManager sensorManager)
    {
      this.Native = sensorManager;
      this.client = client;
      this.accelerometer = new Lazy<BandAccelerometerSensor>((Func<BandAccelerometerSensor>) (() => new BandAccelerometerSensor(this)));
      this.altimeter = new Lazy<BandAltimeterSensor>((Func<BandAltimeterSensor>) (() => new BandAltimeterSensor(this)));
      this.ambientLight = new Lazy<BandAmbientLightSensor>((Func<BandAmbientLightSensor>) (() => new BandAmbientLightSensor(this)));
      this.barometer = new Lazy<BandBarometerSensor>((Func<BandBarometerSensor>) (() => new BandBarometerSensor(this)));
      this.calories = new Lazy<BandCaloriesSensor>((Func<BandCaloriesSensor>) (() => new BandCaloriesSensor(this)));
      this.contact = new Lazy<BandContactSensor>((Func<BandContactSensor>) (() => new BandContactSensor(this)));
      this.distance = new Lazy<BandDistanceSensor>((Func<BandDistanceSensor>) (() => new BandDistanceSensor(this)));
      this.gsr = new Lazy<BandGsrSensor>((Func<BandGsrSensor>) (() => new BandGsrSensor(this)));
      this.gyroscope = new Lazy<BandGyroscopeSensor>((Func<BandGyroscopeSensor>) (() => new BandGyroscopeSensor(this)));
      this.heartRate = new Lazy<BandHeartRateSensor>((Func<BandHeartRateSensor>) (() => new BandHeartRateSensor(this)));
      this.pedometer = new Lazy<BandPedometerSensor>((Func<BandPedometerSensor>) (() => new BandPedometerSensor(this)));
      this.rrInterval = new Lazy<BandRRIntervalSensor>((Func<BandRRIntervalSensor>) (() => new BandRRIntervalSensor(this)));
      this.skinTemperature = new Lazy<BandSkinTemperatureSensor>((Func<BandSkinTemperatureSensor>) (() => new BandSkinTemperatureSensor(this)));
      this.ultravioletLight = new Lazy<BandUltravioletLightSensor>((Func<BandUltravioletLightSensor>) (() => new BandUltravioletLightSensor(this)));
    }

    public BandAccelerometerSensor Accelerometer => this.accelerometer.Value;

    public BandAltimeterSensor Altimeter => this.altimeter.Value;

    public BandAmbientLightSensor AmbientLight => this.ambientLight.Value;

    public BandBarometerSensor Barometer => this.barometer.Value;

    public BandCaloriesSensor Calories => this.calories.Value;

    public BandContactSensor Contact => this.contact.Value;

    public BandDistanceSensor Distance => this.distance.Value;

    public BandGsrSensor Gsr => this.gsr.Value;

    public BandGyroscopeSensor Gyroscope => this.gyroscope.Value;

    public BandHeartRateSensor HeartRate => this.heartRate.Value;

    public BandPedometerSensor Pedometer => this.pedometer.Value;

    public BandRRIntervalSensor RRInterval => this.rrInterval.Value;

    public BandSkinTemperatureSensor SkinTemperature => this.skinTemperature.Value;

    public BandUltravioletLightSensor UltravioletLight => this.ultravioletLight.Value;
  }
}
