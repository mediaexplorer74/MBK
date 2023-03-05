// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.FilledPanel
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;
using System;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class FilledPanel : Panel
  {
    private static readonly Microsoft.Band.Portable.BandColor DefaultBackgroundColor = Microsoft.Band.Portable.BandColor.Empty;
    private static readonly ElementColorSource DefaultBackgroundColorSource = ElementColorSource.Custom;

    public FilledPanel()
    {
      this.BackgroundColor = FilledPanel.DefaultBackgroundColor;
      this.BackgroundColorSource = FilledPanel.DefaultBackgroundColorSource;
    }

    public FilledPanel(Microsoft.Band.Portable.BandColor backgroundColor)
    {
      this.BackgroundColor = backgroundColor;
      this.BackgroundColorSource = FilledPanel.DefaultBackgroundColorSource;
    }

    public FilledPanel(ElementColorSource backgroundColorSource)
    {
      this.BackgroundColor = FilledPanel.DefaultBackgroundColor;
      this.BackgroundColorSource = backgroundColorSource;
    }

    public Microsoft.Band.Portable.BandColor BackgroundColor { get; set; }

    public ElementColorSource BackgroundColorSource { get; set; }

    internal FilledPanel(Microsoft.Band.Tiles.Pages.FilledPanel native)
      : base((PagePanel) native)
    {
      this.BackgroundColor = native.BackgroundColor.FromNative();
      this.BackgroundColorSource = native.BackgroundColorSource.FromNative();
    }

    internal override PageElement ToNative(PageElement element)
    {
      Microsoft.Band.Tiles.Pages.FilledPanel element1 = this.EnsureDerived<Microsoft.Band.Tiles.Pages.FilledPanel>(element) ?? new Microsoft.Band.Tiles.Pages.FilledPanel(Array.Empty<PageElement>());
      if (this.BackgroundColor != Microsoft.Band.Portable.BandColor.Empty)
        element1.BackgroundColor = this.BackgroundColor.ToNative();
      element1.BackgroundColorSource = this.BackgroundColorSource.ToNative();
      return base.ToNative((PageElement) element1);
    }
  }
}
