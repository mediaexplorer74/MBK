// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Data.BarcodeData
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages.Data
{
  public class BarcodeData : ElementData
  {
    public BarcodeData()
    {
    }

    public Microsoft.Band.Portable.Tiles.Pages.BarcodeType BarcodeType { get; set; }

    public string BarcodeValue { get; set; }

    internal BarcodeData(Microsoft.Band.Tiles.Pages.BarcodeData native)
      : base((PageElementData) native)
    {
      this.BarcodeType = native.BarcodeType.FromNative();
      this.BarcodeValue = native.Barcode;
    }

    internal override PageElementData ToNative() => (PageElementData) new Microsoft.Band.Tiles.Pages.BarcodeData(this.BarcodeType.ToNative(), this.ElementId, this.BarcodeValue);
  }
}
