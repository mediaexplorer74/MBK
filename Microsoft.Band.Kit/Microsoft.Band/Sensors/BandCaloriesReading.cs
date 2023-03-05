﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Sensors.BandCaloriesReading
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System;

namespace Microsoft.Band.Sensors
{
  internal class BandCaloriesReading : 
    BandSensorReadingBase,
    IBandCaloriesReading,
    IBandSensorReading
  {
    private const int cargoSerializedByteCount = 20;
    private const int envoySerializedByteCount = 8;

    private BandCaloriesReading(DateTimeOffset timestamp)
      : base(timestamp)
    {
    }

    public long Calories { get; private set; }

    public long CaloriesToday { get; private set; }

    internal override void Dispatch(BandClient client)
    {
      if (client.calories == null)
        return;
      client.calories.ProcessSensorReading((IBandCaloriesReading) this);
    }

    internal static int GetSerializedByteCount(RemoteSubscriptionSampleHeader header)
    {
      switch (header.SubscriptionType)
      {
        case SubscriptionType.Calories1S:
          return 20;
        case SubscriptionType.CaloriesWithDailyValues:
          return 8;
        default:
          throw new InvalidOperationException();
      }
    }

    internal static BandCaloriesReading DeserializeFromBand(
      ICargoReader reader,
      RemoteSubscriptionSampleHeader header,
      DateTimeOffset timestamp)
    {
      BandCaloriesReading bandCaloriesReading = new BandCaloriesReading(timestamp);
      if (header.SubscriptionType == SubscriptionType.Calories1S)
      {
        bandCaloriesReading.Calories = (long) reader.ReadUInt32();
        reader.ReadExactAndDiscard(16);
      }
      else
      {
        bandCaloriesReading.Calories = (long) reader.ReadUInt32();
        bandCaloriesReading.CaloriesToday = (long) reader.ReadUInt32();
      }
      return bandCaloriesReading;
    }
  }
}
