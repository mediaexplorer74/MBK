// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Data.ElementData
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages.Data
{
  public abstract class ElementData
  {
    public ElementData()
    {
    }

    public short ElementId { get; set; }

    internal ElementData(PageElementData native) => this.ElementId = native.ElementId;

    internal abstract PageElementData ToNative();
  }
}
