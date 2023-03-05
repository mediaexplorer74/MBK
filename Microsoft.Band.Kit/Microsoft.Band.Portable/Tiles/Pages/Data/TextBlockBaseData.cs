// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Data.TextBlockBaseData
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages.Data
{
  public abstract class TextBlockBaseData : ElementData
  {
    public TextBlockBaseData()
    {
    }

    public abstract string Text { get; set; }

    internal TextBlockBaseData(PageElementData native)
      : base(native)
    {
    }
  }
}
