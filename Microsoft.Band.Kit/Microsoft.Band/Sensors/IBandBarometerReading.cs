﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Sensors.IBandBarometerReading
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

namespace Microsoft.Band.Sensors
{
  public interface IBandBarometerReading : IBandSensorReading
  {
    double AirPressure { get; }

    double Temperature { get; }
  }
}
