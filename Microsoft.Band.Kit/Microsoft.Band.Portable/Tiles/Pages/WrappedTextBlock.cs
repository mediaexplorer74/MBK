// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.WrappedTextBlock
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class WrappedTextBlock : TextBlockBase
  {
    private static readonly bool DefaultAutoHeight = true;
    private static readonly Microsoft.Band.Portable.BandColor DefaultColor = Microsoft.Band.Portable.BandColor.Empty;
    private static readonly ElementColorSource DefaultColorSource = ElementColorSource.Custom;
    private static readonly WrappedTextBlockFont DefaultFont = WrappedTextBlockFont.Small;

    public WrappedTextBlock()
    {
      this.AutoHeight = WrappedTextBlock.DefaultAutoHeight;
      this.Color = WrappedTextBlock.DefaultColor;
      this.ColorSource = WrappedTextBlock.DefaultColorSource;
      this.Font = WrappedTextBlock.DefaultFont;
    }

    public WrappedTextBlock(Microsoft.Band.Portable.BandColor color)
    {
      this.AutoHeight = WrappedTextBlock.DefaultAutoHeight;
      this.Color = color;
      this.ColorSource = WrappedTextBlock.DefaultColorSource;
      this.Font = WrappedTextBlock.DefaultFont;
    }

    public WrappedTextBlock(ElementColorSource colorSource)
    {
      this.AutoHeight = WrappedTextBlock.DefaultAutoHeight;
      this.Color = WrappedTextBlock.DefaultColor;
      this.ColorSource = colorSource;
      this.Font = WrappedTextBlock.DefaultFont;
    }

    public bool AutoHeight { get; set; }

    public override Microsoft.Band.Portable.BandColor Color { get; set; }

    public override ElementColorSource ColorSource { get; set; }

    public WrappedTextBlockFont Font { get; set; }

    internal WrappedTextBlock(Microsoft.Band.Tiles.Pages.WrappedTextBlock native)
      : base((PageElement) native)
    {
      this.AutoHeight = native.AutoHeight;
      this.Color = native.Color.FromNative();
      this.ColorSource = native.ColorSource.FromNative();
      this.Font = native.Font.FromNative();
    }

    internal override PageElement ToNative(PageElement element)
    {
      Microsoft.Band.Tiles.Pages.WrappedTextBlock element1 = this.EnsureDerived<Microsoft.Band.Tiles.Pages.WrappedTextBlock>(element);
      if (element1 == null)
      {
        element1 = new Microsoft.Band.Tiles.Pages.WrappedTextBlock();
        element1.Font = this.Font.ToNative();
      }
      element1.AutoHeight = this.AutoHeight;
      if (this.Color != Microsoft.Band.Portable.BandColor.Empty)
        element1.Color = this.Color.ToNative();
      element1.ColorSource = this.ColorSource.ToNative();
      return base.ToNative((PageElement) element1);
    }
  }
}
