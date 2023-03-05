// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.PersonalizationExtensions
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable
{
  internal static class PersonalizationExtensions
  {
    public static Microsoft.Band.BandTheme ToNative(this BandTheme theme) => new Microsoft.Band.BandTheme()
    {
      Base = theme.Base.ToNative(),
      HighContrast = theme.HighContrast.ToNative(),
      Highlight = theme.Highlight.ToNative(),
      Lowlight = theme.Lowlight.ToNative(),
      Muted = theme.Muted.ToNative(),
      SecondaryText = theme.SecondaryText.ToNative()
    };

    public static BandTheme FromNative(this Microsoft.Band.BandTheme theme) => new BandTheme()
    {
      Base = theme.Base.FromNative(),
      HighContrast = theme.HighContrast.FromNative(),
      Highlight = theme.Highlight.FromNative(),
      Lowlight = theme.Lowlight.FromNative(),
      Muted = theme.Muted.FromNative(),
      SecondaryText = theme.SecondaryText.FromNative()
    };

    public static Microsoft.Band.BandColor ToNative(this BandColor color) => new Microsoft.Band.BandColor(color.R, color.G, color.B);

    public static BandColor FromNative(this Microsoft.Band.BandColor color) => new BandColor()
    {
      R = color.R,
      G = color.G,
      B = color.B
    };
  }
}
