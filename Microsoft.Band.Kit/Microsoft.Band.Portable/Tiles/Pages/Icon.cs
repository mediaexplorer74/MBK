// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Icon
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class Icon : Element
  {
    private static readonly Microsoft.Band.Portable.BandColor DefaultColor = Microsoft.Band.Portable.BandColor.Empty;
    private static readonly ElementColorSource DefaultColorSource = ElementColorSource.Custom;

    public Icon()
    {
      this.Color = Icon.DefaultColor;
      this.ColorSource = Icon.DefaultColorSource;
    }

    public Icon(Microsoft.Band.Portable.BandColor color)
    {
      this.Color = color;
      this.ColorSource = Icon.DefaultColorSource;
    }

    public Icon(ElementColorSource colorSource)
    {
      this.Color = Icon.DefaultColor;
      this.ColorSource = colorSource;
    }

    public Microsoft.Band.Portable.BandColor Color { get; set; }

    public ElementColorSource ColorSource { get; set; }

    internal Icon(Microsoft.Band.Tiles.Pages.Icon native)
      : base((PageElement) native)
    {
      this.Color = native.Color.FromNative();
      this.ColorSource = native.ColorSource.FromNative();
    }

    internal override PageElement ToNative(PageElement element)
    {
      Microsoft.Band.Tiles.Pages.Icon element1 = this.EnsureDerived<Microsoft.Band.Tiles.Pages.Icon>(element) ?? new Microsoft.Band.Tiles.Pages.Icon();
      if (this.Color != Microsoft.Band.Portable.BandColor.Empty)
        element1.Color = this.Color.ToNative();
      element1.ColorSource = this.ColorSource.ToNative();
      return base.ToNative((PageElement) element1);
    }
  }
}
