﻿// Decompiled with JetBrains decompiler
// Type: MobileBandSync.OpenTcx.Entities.CaloriesBurned_t
// Assembly: MobileBandSync, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AE79C20-CD20-4792-8F76-8817DEB4DE21
// Assembly location: C:\Users\Admin\Desktop\re\mobile\MobileBandSync.exe

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MobileBandSync.OpenTcx.Entities
{
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [XmlType(Namespace = "http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2")]
  public class CaloriesBurned_t : Duration_t
  {
    private ushort caloriesField;

    public ushort Calories
    {
      get => this.caloriesField;
      set => this.caloriesField = value;
    }
  }
}
