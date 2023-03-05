// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.PageLayout
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class PageLayout
  {
    public PageLayout() => this.Root = (Panel) null;

    public PageLayout(Panel root) => this.Root = root;

    public Panel Root { get; set; }

    internal PageLayout(Microsoft.Band.Tiles.Pages.PageLayout native) => this.Root = PageExtensions.FromNative(native.Root);

    internal Microsoft.Band.Tiles.Pages.PageLayout ToNative() => new Microsoft.Band.Tiles.Pages.PageLayout((PagePanel) this.Root.ToNative());
  }
}
