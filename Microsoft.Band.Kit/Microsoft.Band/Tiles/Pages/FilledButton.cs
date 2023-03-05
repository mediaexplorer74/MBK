﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Tiles.Pages.FilledButton
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

namespace Microsoft.Band.Tiles.Pages
{
  public sealed class FilledButton : PageElement
  {
    public FilledButton()
      : base(CommonElementColors.White)
    {
    }

    public BandColor BackgroundColor
    {
      get => this.Color;
      set => this.Color = value;
    }

    internal override PageElementType TypeId => PageElementType.InteractiveButtonWithBorder;

    protected override uint AttributesToCustomStyleMask() => 1073741824;
  }
}