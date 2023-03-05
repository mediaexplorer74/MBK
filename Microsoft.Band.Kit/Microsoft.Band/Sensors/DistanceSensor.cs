﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Sensors.DistanceSensor
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System;
using System.Collections.Generic;

namespace Microsoft.Band.Sensors
{
  internal sealed class DistanceSensor : BandSensorBase<IBandDistanceReading>
  {
    public DistanceSensor(BandClient bandClient)
      : base(bandClient, (IEnumerable<BandType>) new List<BandType>()
      {
        BandType.Cargo,
        BandType.Envoy
      }, new Dictionary<TimeSpan, SubscriptionType>()
      {
        {
          TimeSpan.FromSeconds(1.0),
          bandClient.BandTypeConstants.GetBandSpecificValue<SubscriptionType>(SubscriptionType.Distance, SubscriptionType.DistanceWithDailyValues)
        }
      })
    {
    }
  }
}
