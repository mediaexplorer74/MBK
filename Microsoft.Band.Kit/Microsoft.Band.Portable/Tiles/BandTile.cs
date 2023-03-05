// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.BandTile
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Portable.Tiles.Pages;
using System;
using System.Collections.Generic;

namespace Microsoft.Band.Portable.Tiles
{
  public class BandTile
  {
    public BandTile(Guid tileId)
    {
      this.Id = tileId;
      this.PageLayouts = new List<PageLayout>();
      this.PageImages = new List<BandImage>();
    }

    public BandTile(Guid tileId, string name, BandImage icon)
      : this(tileId)
    {
      this.Name = name;
      this.Icon = icon;
    }

    public BandTile(Guid tileId, string name, BandImage icon, BandImage smallIcon)
      : this(tileId, name, icon)
    {
      this.SmallIcon = smallIcon;
    }

    public Guid Id { get; private set; }

    public string Name { get; set; }

    public BandImage Icon { get; set; }

    public BandImage SmallIcon { get; set; }

    public Microsoft.Band.Portable.BandTheme Theme { get; set; }

    public List<PageLayout> PageLayouts { get; private set; }

    public List<BandImage> PageImages { get; private set; }

    public bool IsScreenTimeoutDisabled { get; set; }

    public bool IsCustomThemeEnabled => this.Theme != Microsoft.Band.Portable.BandTheme.Empty;
  }
}
