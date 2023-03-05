// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Data.TextButtonData
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages.Data
{
  public class TextButtonData : ButtonBaseData
  {
    public TextButtonData()
    {
    }

    public string Text { get; set; }

    internal TextButtonData(Microsoft.Band.Tiles.Pages.TextButtonData native)
      : base((PageElementData) native)
    {
    }

    internal override PageElementData ToNative() => (PageElementData) new Microsoft.Band.Tiles.Pages.TextButtonData(this.ElementId, this.Text);
  }
}
