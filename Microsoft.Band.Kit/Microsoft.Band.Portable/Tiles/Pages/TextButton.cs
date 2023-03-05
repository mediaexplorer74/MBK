// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.TextButton
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class TextButton : ButtonBase
  {
    private static readonly Microsoft.Band.Portable.BandColor DefaultPressedColor = Microsoft.Band.Portable.BandColor.Empty;

    public TextButton() => this.PressedColor = TextButton.DefaultPressedColor;

    public TextButton(Microsoft.Band.Portable.BandColor pressedColor) => this.PressedColor = pressedColor;

    public Microsoft.Band.Portable.BandColor PressedColor { get; set; }

    internal TextButton(Microsoft.Band.Tiles.Pages.TextButton native)
      : base((PageElement) native)
    {
      this.PressedColor = native.PressedColor.FromNative();
    }

    internal override PageElement ToNative(PageElement element)
    {
      Microsoft.Band.Tiles.Pages.TextButton element1 = this.EnsureDerived<Microsoft.Band.Tiles.Pages.TextButton>(element) ?? new Microsoft.Band.Tiles.Pages.TextButton();
      if (this.PressedColor != Microsoft.Band.Portable.BandColor.Empty)
        element1.PressedColor = this.PressedColor.ToNative();
      return base.ToNative((PageElement) element1);
    }
  }
}
