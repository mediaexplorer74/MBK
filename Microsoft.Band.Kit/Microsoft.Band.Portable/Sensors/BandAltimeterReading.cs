// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Sensors.BandAltimeterReading
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Sensors
{
  public class BandAltimeterReading : IBandSensorReading
  {
    internal BandAltimeterReading(
      long flightsAscended,
      long flightsDescended,
      double rate,
      long steppingGain,
      long steppingLoss,
      long stepsAscended,
      long stepsDescended,
      long totalGain,
      long totalLoss,
      long flightsAscendedToday,
      long totalGainToday)
    {
      this.FlightsAscended = flightsAscended;
      this.FlightsDescended = flightsDescended;
      this.Rate = rate;
      this.SteppingGain = steppingGain;
      this.SteppingLoss = steppingLoss;
      this.StepsAscended = stepsAscended;
      this.StepsDescended = stepsDescended;
      this.TotalGain = totalGain;
      this.TotalLoss = totalLoss;
      this.FlightsAscendedToday = flightsAscendedToday;
      this.TotalGainToday = totalGainToday;
    }

    public long FlightsAscended { get; private set; }

    public long FlightsDescended { get; private set; }

    public double Rate { get; private set; }

    public long SteppingGain { get; private set; }

    public long SteppingLoss { get; private set; }

    public long StepsAscended { get; private set; }

    public long StepsDescended { get; private set; }

    public long TotalGain { get; private set; }

    public long TotalLoss { get; private set; }

    public long FlightsAscendedToday { get; private set; }

    public long TotalGainToday { get; private set; }

    public override string ToString() => string.Format("FlightsAscended={0}, FlightsDescended={1}, Rate={2}, SteppingGain={3}, SteppingLoss={4}, StepsAscended={5}, StepsDescended={6}, TotalGain={7}, TotalLoss={8}, FlightsAscendedToday={9}, TotalGainToday={10}", (object) this.FlightsAscended, (object) this.FlightsDescended, (object) this.Rate, (object) this.SteppingGain, (object) this.SteppingLoss, (object) this.StepsAscended, (object) this.StepsDescended, (object) this.TotalGain, (object) this.TotalLoss, (object) this.FlightsAscendedToday, (object) this.TotalGainToday);
  }
}
