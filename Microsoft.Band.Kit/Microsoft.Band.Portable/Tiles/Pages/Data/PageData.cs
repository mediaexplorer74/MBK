// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Data.PageData
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Band.Portable.Tiles.Pages.Data
{
  public class PageData
  {
    public PageData() => this.Data = new List<ElementData>();

    public Guid PageId { get; set; }

    public int PageLayoutIndex { get; set; }

    public List<ElementData> Data { get; private set; }

    internal PageData(Microsoft.Band.Tiles.Pages.PageData native)
    {
      this.PageId = native.PageId.FromNative();
      this.PageLayoutIndex = this.PageLayoutIndex;
      this.Data = native.Values.Select<PageElementData, ElementData>((Func<PageElementData, ElementData>) (e => e.FromNative())).ToList<ElementData>();
    }

    internal Microsoft.Band.Tiles.Pages.PageData ToNative() => new Microsoft.Band.Tiles.Pages.PageData(this.PageId.ToNative(), this.PageLayoutIndex, this.Data.Select<ElementData, PageElementData>((Func<ElementData, PageElementData>) (d => d.ToNative())).ToArray<PageElementData>());
  }
}
