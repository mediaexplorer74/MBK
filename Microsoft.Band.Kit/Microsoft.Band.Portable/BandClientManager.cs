// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.BandClientManager
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable
{
  public class BandClientManager
  {
    private static Lazy<BandClientManager> instance = new Lazy<BandClientManager>((Func<BandClientManager>) (() => new BandClientManager()));

    public static BandClientManager Instance => BandClientManager.instance.Value;

    public async Task<IEnumerable<BandDeviceInfo>> GetPairedBandsAsync(
      bool isBackgound)
    {
      return ((IEnumerable<IBandInfo>) await Microsoft.Band.BandClientManager.Instance.GetBandsAsync(isBackgound)).Select<IBandInfo, BandDeviceInfo>((Func<IBandInfo, BandDeviceInfo>) (b => new BandDeviceInfo(b)));
    }

    public Task<IEnumerable<BandDeviceInfo>> GetPairedBandsAsync() => this.GetPairedBandsAsync(false);

        public async Task<BandClient> ConnectAsync(BandDeviceInfo info)
        {
            return new BandClient(await Microsoft.Band.BandClientManager.Instance.ConnectAsync(info.Native));
        }
    }
}
