// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.BandClientManager
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Band
{
    internal class BandClientManager
    {
        internal static class Instance
        {
            internal static Task<IBandClient> ConnectAsync(IBandInfo native)
            {
                throw new NotImplementedException();
            }

            internal static Task<IEnumerable<IBandInfo>> GetBandsAsync(bool isBackgound)
            {
                throw new NotImplementedException();
            }
        }
    }
}