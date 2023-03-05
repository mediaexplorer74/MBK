// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Barcode
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class Barcode : Element
  {
    private static readonly BarcodeType DefaultBarcodeType;

    public Barcode() => this.BarcodeType = Barcode.DefaultBarcodeType;

    public Barcode(BarcodeType barcodeType) => this.BarcodeType = barcodeType;

    public BarcodeType BarcodeType { get; set; }

    internal Barcode(Microsoft.Band.Tiles.Pages.Barcode native)
      : base((PageElement) native)
    {
      this.BarcodeType = native.BarcodeType.FromNative();
    }

    internal override PageElement ToNative(PageElement element) => base.ToNative((PageElement) (this.EnsureDerived<Microsoft.Band.Tiles.Pages.Barcode>(element) ?? new Microsoft.Band.Tiles.Pages.Barcode(this.BarcodeType.ToNative())));
  }
}
