// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.BandDeviceInfo
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable
{
  public class BandDeviceInfo
  {
    internal readonly IBandInfo Native;

    private BandDeviceInfo()
    {
    }

    internal BandDeviceInfo(IBandInfo info) => this.Native = info;

    public string Name => this.Native.Name;
  }
}
