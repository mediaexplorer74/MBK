// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.TextBlock
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles.Pages;

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public class TextBlock : TextBlockBase
  {
    private static readonly bool DefaultAutoWidth = true;
    private static readonly short DefaultBaseline = 0;
    private static readonly TextBlockBaselineAlignment DefaultBaselineAlignment = TextBlockBaselineAlignment.Automatic;
    private static readonly Microsoft.Band.Portable.BandColor DefaultColor = Microsoft.Band.Portable.BandColor.Empty;
    private static readonly ElementColorSource DefaultColorSource = ElementColorSource.Custom;
    private static readonly TextBlockFont DefaultFont = TextBlockFont.Small;

    public TextBlock()
    {
      this.AutoWidth = TextBlock.DefaultAutoWidth;
      this.Baseline = TextBlock.DefaultBaseline;
      this.BaselineAlignment = TextBlock.DefaultBaselineAlignment;
      this.Color = TextBlock.DefaultColor;
      this.ColorSource = TextBlock.DefaultColorSource;
      this.Font = TextBlock.DefaultFont;
    }

    public TextBlock(Microsoft.Band.Portable.BandColor color)
    {
      this.AutoWidth = TextBlock.DefaultAutoWidth;
      this.Baseline = TextBlock.DefaultBaseline;
      this.BaselineAlignment = TextBlock.DefaultBaselineAlignment;
      this.Color = color;
      this.ColorSource = TextBlock.DefaultColorSource;
      this.Font = TextBlock.DefaultFont;
    }

    public TextBlock(ElementColorSource colorSource)
    {
      this.AutoWidth = TextBlock.DefaultAutoWidth;
      this.Baseline = TextBlock.DefaultBaseline;
      this.BaselineAlignment = TextBlock.DefaultBaselineAlignment;
      this.Color = TextBlock.DefaultColor;
      this.ColorSource = colorSource;
      this.Font = TextBlock.DefaultFont;
    }

    public bool AutoWidth { get; set; }

    public short Baseline { get; set; }

    public TextBlockBaselineAlignment BaselineAlignment { get; set; }

    public override Microsoft.Band.Portable.BandColor Color { get; set; }

    public override ElementColorSource ColorSource { get; set; }

    public TextBlockFont Font { get; set; }

    internal TextBlock(Microsoft.Band.Tiles.Pages.TextBlock native)
      : base((PageElement) native)
    {
      this.AutoWidth = native.AutoWidth;
      this.Baseline = native.Baseline;
      this.BaselineAlignment = native.BaselineAlignment.FromNative();
      this.Color = native.Color.FromNative();
      this.ColorSource = native.ColorSource.FromNative();
      this.Font = native.Font.FromNative();
    }

    internal override PageElement ToNative(PageElement element)
    {
      Microsoft.Band.Tiles.Pages.TextBlock element1 = this.EnsureDerived<Microsoft.Band.Tiles.Pages.TextBlock>(element);
      if (element1 == null)
      {
        element1 = new Microsoft.Band.Tiles.Pages.TextBlock();
        element1.Font = this.Font.ToNative();
        element1.Baseline = this.Baseline;
      }
      element1.AutoWidth = this.AutoWidth;
      element1.BaselineAlignment = this.BaselineAlignment.ToNative();
      if (this.Color != Microsoft.Band.Portable.BandColor.Empty)
        element1.Color = this.Color.ToNative();
      element1.ColorSource = this.ColorSource.ToNative();
      return base.ToNative((PageElement) element1);
    }
  }
}
