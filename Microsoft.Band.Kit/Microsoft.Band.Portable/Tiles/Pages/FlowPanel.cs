// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.FlowPanel
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;
using System;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class FlowPanel : Panel
  {
    private static readonly FlowPanelOrientation DefaultOrientation = FlowPanelOrientation.Vertical;

    public FlowPanel() => this.Orientation = FlowPanel.DefaultOrientation;

    public FlowPanel(FlowPanelOrientation orientation) => this.Orientation = orientation;

    public FlowPanelOrientation Orientation { get; set; }

    internal FlowPanel(Microsoft.Band.Tiles.Pages.FlowPanel native)
      : base((PagePanel) native)
    {
      this.Orientation = native.Orientation.FromNative();
    }

    internal override PageElement ToNative(PageElement element)
    {
      Microsoft.Band.Tiles.Pages.FlowPanel element1 = this.EnsureDerived<Microsoft.Band.Tiles.Pages.FlowPanel>(element) ?? new Microsoft.Band.Tiles.Pages.FlowPanel(Array.Empty<PageElement>());
      element1.Orientation = this.Orientation.ToNative();
      return base.ToNative((PageElement) element1);
    }
  }
}
