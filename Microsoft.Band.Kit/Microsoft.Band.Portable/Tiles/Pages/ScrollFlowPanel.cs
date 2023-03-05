// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.ScrollFlowPanel
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;
using System;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class ScrollFlowPanel : FlowPanel
  {
    private static readonly Microsoft.Band.Portable.BandColor DefaultScrollBarColor = Microsoft.Band.Portable.BandColor.Empty;
    private static readonly ElementColorSource DefaultScrollBarColorSource = ElementColorSource.Custom;

    public ScrollFlowPanel()
    {
      this.ScrollBarColor = ScrollFlowPanel.DefaultScrollBarColor;
      this.ScrollBarColorSource = ScrollFlowPanel.DefaultScrollBarColorSource;
    }

    public ScrollFlowPanel(Microsoft.Band.Portable.BandColor scrollBarColor)
    {
      this.ScrollBarColor = scrollBarColor;
      this.ScrollBarColorSource = ScrollFlowPanel.DefaultScrollBarColorSource;
    }

    public ScrollFlowPanel(ElementColorSource scrollBarColorSource)
    {
      this.ScrollBarColor = ScrollFlowPanel.DefaultScrollBarColor;
      this.ScrollBarColorSource = scrollBarColorSource;
    }

    public Microsoft.Band.Portable.BandColor ScrollBarColor { get; set; }

    public ElementColorSource ScrollBarColorSource { get; set; }

    internal ScrollFlowPanel(Microsoft.Band.Tiles.Pages.ScrollFlowPanel native)
      : base((Microsoft.Band.Tiles.Pages.FlowPanel) native)
    {
      this.ScrollBarColor = native.ScrollBarColor.FromNative();
      this.ScrollBarColorSource = native.ScrollBarColorSource.FromNative();
    }

    internal override PageElement ToNative(PageElement element)
    {
      Microsoft.Band.Tiles.Pages.ScrollFlowPanel element1 = this.EnsureDerived<Microsoft.Band.Tiles.Pages.ScrollFlowPanel>(element) ?? new Microsoft.Band.Tiles.Pages.ScrollFlowPanel(Array.Empty<PageElement>());
      if (this.ScrollBarColor != Microsoft.Band.Portable.BandColor.Empty)
        element1.ScrollBarColor = this.ScrollBarColor.ToNative();
      element1.ScrollBarColorSource = this.ScrollBarColorSource.ToNative();
      return base.ToNative((PageElement) element1);
    }
  }
}
