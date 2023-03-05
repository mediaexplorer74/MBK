// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Personalization.BandPersonalizationManager
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Personalization;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Personalization
{
  public class BandPersonalizationManager
  {
    private readonly Microsoft.Band.Portable.BandClient client;
    internal readonly IBandPersonalizationManager Native;
        private class WriteableBitmapExtensions
        {
            internal static Band.Personalization.BandImage ToBandImage(WriteableBitmap writeableBitmap)
            {
                throw new NotImplementedException();
            }
        }

        internal BandPersonalizationManager(
      Microsoft.Band.Portable.BandClient client,
      IBandPersonalizationManager personalizationManager)
    {
      this.Native = personalizationManager;
      this.client = client;
    }

    public async Task<Microsoft.Band.Portable.BandImage> GetMeTileImageAsync()
    {
      Microsoft.Band.Personalization.BandImage meTileImageAsync = await this.Native.GetMeTileImageAsync();
      return meTileImageAsync == null ? (Microsoft.Band.Portable.BandImage) null : new Microsoft.Band.Portable.BandImage(
         /* BandImageExtensions.ToWriteableBitmap(meTileImageAsync)*/default, meTileImageAsync.Width, meTileImageAsync.Height);
    }

    public async Task<Microsoft.Band.Portable.BandTheme> GetThemeAsync() => (await this.Native.GetThemeAsync()).FromNative();

    public async Task SetMeTileImageAsync(Microsoft.Band.Portable.BandImage image) => await this.Native.SetMeTileImageAsync(WriteableBitmapExtensions.ToBandImage(image.ToWriteableBitmap()));

    public async Task SetThemeAsync(Microsoft.Band.Portable.BandTheme theme) => await this.Native.SetThemeAsync(theme.ToNative());
  }
}
