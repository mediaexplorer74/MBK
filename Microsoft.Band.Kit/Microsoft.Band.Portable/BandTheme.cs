// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.BandTheme
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable
{
  public struct BandTheme
  {
    public static readonly BandTheme Empty;

    public BandTheme(
      BandColor baseColor,
      BandColor highContrastColor,
      BandColor highlightColor,
      BandColor lowlightColor,
      BandColor mutedColor,
      BandColor secondaryTextColor)
      : this()
    {
      this.Base = baseColor;
      this.HighContrast = highContrastColor;
      this.Highlight = highlightColor;
      this.Lowlight = lowlightColor;
      this.Muted = mutedColor;
      this.SecondaryText = secondaryTextColor;
    }

    public bool IsEmpty => this.Base.IsEmpty && this.HighContrast.IsEmpty && this.Highlight.IsEmpty && this.Lowlight.IsEmpty && this.Muted.IsEmpty && this.SecondaryText.IsEmpty;

    public BandColor Base { get; set; }

    public BandColor HighContrast { get; set; }

    public BandColor Highlight { get; set; }

    public BandColor Lowlight { get; set; }

    public BandColor Muted { get; set; }

    public BandColor SecondaryText { get; set; }

    public static bool operator ==(BandTheme theme1, BandTheme theme2) => theme1.Equals((object) theme2);

    public static bool operator !=(BandTheme theme1, BandTheme theme2) => !theme1.Equals((object) theme2);

    public override bool Equals(object obj)
    {
      if (!(obj is BandTheme bandTheme1))
        return this.Equals(obj);
      BandTheme bandTheme2 = this;
      return bandTheme2.Base == bandTheme1.Base && bandTheme2.HighContrast == bandTheme1.HighContrast && bandTheme2.Highlight == bandTheme1.Highlight && bandTheme2.Lowlight == bandTheme1.Lowlight && bandTheme2.Muted == bandTheme1.Muted && bandTheme2.SecondaryText == bandTheme1.SecondaryText;
    }
  }
}
