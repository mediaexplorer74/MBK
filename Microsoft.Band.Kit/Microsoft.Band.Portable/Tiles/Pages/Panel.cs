// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Panel
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public abstract class Panel : Element
  {
    public Panel() => this.Elements = new List<Element>();

    public Panel(IEnumerable<Element> elements) => this.Elements = new List<Element>(elements);

    public List<Element> Elements { get; private set; }

    internal Panel(PagePanel native)
      : base((PageElement) native)
    {
      this.Elements = native.Elements.Select<PageElement, Element>((Func<PageElement, Element>) (e => e.FromNative())).ToList<Element>();
    }

    internal override PageElement ToNative(PageElement element)
    {
      PagePanel element1 = this.EnsureDerived<PagePanel>(element, false);
      foreach (Element element2 in this.Elements)
        element1.Elements.Add(element2.ToNative());
      return base.ToNative((PageElement) element1);
    }
  }
}
