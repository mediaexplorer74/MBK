// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Phone.WinRtResourceManager
// Assembly: Microsoft.Band.Phone_UAP, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 29D5BD9B-4535-4F2F-BDC5-1BF47D7C3CF4
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Phone_UAP.dll

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using Windows.ApplicationModel.Resources;

namespace Microsoft.Band.Phone
{
  internal class WinRtResourceManager : ResourceManager
  {
    private readonly ResourceLoader resourceLoader;

    private WinRtResourceManager(string baseName, Assembly assembly)
      : base(baseName, assembly)
    {
      this.resourceLoader = ResourceLoader.GetForViewIndependentUse(baseName);
    }

    public static void InjectIntoResxGeneratedApplicationResourcesClass(
      Type resxGeneratedApplicationResourcesClass,
      bool ignoreException)
    {
      try
      {
        resxGeneratedApplicationResourcesClass.GetRuntimeFields().First<FieldInfo>((Func<FieldInfo, bool>) (m => m.Name == "resourceMan")).SetValue((object) null, (object) new WinRtResourceManager(resxGeneratedApplicationResourcesClass.FullName, resxGeneratedApplicationResourcesClass.GetTypeInfo().Assembly));
      }
      catch (Exception ex)
      {
        if (ignoreException)
          return;
        throw;
      }
    }

    public override string GetString(string name, CultureInfo culture) => this.resourceLoader.GetString(name);
  }
}
