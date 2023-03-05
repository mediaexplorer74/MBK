// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Data.FilledButtonData
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages.Data
{
  public class FilledButtonData : ButtonBaseData
  {
    public FilledButtonData()
    {
    }

    public Microsoft.Band.Portable.BandColor PressedColor { get; set; }

    internal FilledButtonData(Microsoft.Band.Tiles.Pages.FilledButtonData native)
      : base((PageElementData) native)
    {
      this.PressedColor = native.PressedColor.FromNative();
    }

    internal override PageElementData ToNative() => (PageElementData) new Microsoft.Band.Tiles.Pages.FilledButtonData(this.ElementId, this.PressedColor.ToNative());
  }
}
