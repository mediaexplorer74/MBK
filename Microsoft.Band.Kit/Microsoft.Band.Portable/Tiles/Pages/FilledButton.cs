// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.FilledButton
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class FilledButton : ButtonBase
  {
    private static readonly Microsoft.Band.Portable.BandColor DefaultBackgroundColor = Microsoft.Band.Portable.BandColor.Empty;

    public FilledButton() => this.BackgroundColor = FilledButton.DefaultBackgroundColor;

    public FilledButton(Microsoft.Band.Portable.BandColor backgroundColor) => this.BackgroundColor = backgroundColor;

    public Microsoft.Band.Portable.BandColor BackgroundColor { get; set; }

    internal FilledButton(Microsoft.Band.Tiles.Pages.FilledButton native)
      : base((PageElement) native)
    {
      this.BackgroundColor = native.BackgroundColor.FromNative();
    }

    internal override PageElement ToNative(PageElement element)
    {
      Microsoft.Band.Tiles.Pages.FilledButton element1 = this.EnsureDerived<Microsoft.Band.Tiles.Pages.FilledButton>(element) ?? new Microsoft.Band.Tiles.Pages.FilledButton();
      if (this.BackgroundColor != Microsoft.Band.Portable.BandColor.Empty)
        element1.BackgroundColor = this.BackgroundColor.ToNative();
      return base.ToNative((PageElement) element1);
    }
  }
}
