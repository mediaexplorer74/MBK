// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Data.ImageData
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages.Data
{
  public class ImageData : ElementData
  {
    public ImageData()
    {
    }

    public ushort ImageIndex { get; set; }

    internal ImageData(IconData native)
      : base((PageElementData) native)
    {
      this.ImageIndex = native.IconIndex;
    }

    internal override PageElementData ToNative() => (PageElementData) new IconData(this.ElementId, this.ImageIndex);
  }
}
