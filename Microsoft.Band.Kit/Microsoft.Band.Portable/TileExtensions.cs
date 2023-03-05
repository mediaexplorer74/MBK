// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.TileExtensions
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles;
using System;
using System.Linq;

namespace Microsoft.Band.Portable
{
  internal static class TileExtensions
  {
    public static Microsoft.Band.Tiles.BandTile ToNative(this Microsoft.Band.Portable.Tiles.BandTile tile)
    {
      Microsoft.Band.Tiles.BandTile native = new Microsoft.Band.Tiles.BandTile(tile.Id.ToNative())
      {
        Name = tile.Name,
        TileIcon = default,//WriteableBitmapExtensions.ToBandIcon(tile.Icon.ToWriteableBitmap()),
        SmallIcon = default,//WriteableBitmapExtensions.ToBandIcon(tile.SmallIcon.ToWriteableBitmap()),
        IsBadgingEnabled = true
      };
      foreach (BandImage pageImage in tile.PageImages)
        native.AdditionalIcons.Add(/*WriteableBitmapExtensions.ToBandIcon(pageImage.ToWriteableBitmap())*/default);
      foreach (Microsoft.Band.Portable.Tiles.Pages.PageLayout pageLayout in tile.PageLayouts)
        native.PageLayouts.Add(pageLayout.ToNative());
      if (tile.IsCustomThemeEnabled)
        native.Theme = tile.Theme.ToNative();
      native.IsScreenTimeoutDisabled = tile.IsScreenTimeoutDisabled;
      return native;
    }

    public static Microsoft.Band.Portable.Tiles.BandTile FromNative(this Microsoft.Band.Tiles.BandTile tile)
    {
      Microsoft.Band.Portable.Tiles.BandTile bandTile = new Microsoft.Band.Portable.Tiles.BandTile(tile.TileId.FromNative())
      {
        Name = tile.Name,
        Icon = BandImage.FromWriteableBitmap(/*BandIconExtensions.ToWriteableBitmap(tile.TileIcon)*/default)
      };
      if (tile.AdditionalIcons != null)
        bandTile.PageImages.AddRange(tile.AdditionalIcons.Select<BandIcon, BandImage>((Func<BandIcon, BandImage>)
            (pi => /*BandImage.FromWriteableBitmap(BandIconExtensions.ToWriteableBitmap(pi))*/default)));
      if (tile.PageLayouts != null)
        bandTile.PageLayouts.AddRange(tile.PageLayouts.Select<Microsoft.Band.Tiles.Pages.PageLayout, Microsoft.Band.Portable.Tiles.Pages.PageLayout>((Func<Microsoft.Band.Tiles.Pages.PageLayout, Microsoft.Band.Portable.Tiles.Pages.PageLayout>) (pl => new Microsoft.Band.Portable.Tiles.Pages.PageLayout(pl))));
      if (tile.SmallIcon != null)
        bandTile.SmallIcon = BandImage.FromWriteableBitmap(/*BandIconExtensions.ToWriteableBitmap(tile.SmallIcon)*/default);
      if (tile.Theme != null)
        bandTile.Theme = tile.Theme.FromNative();
      bandTile.IsScreenTimeoutDisabled = tile.IsScreenTimeoutDisabled;
      return bandTile;
    }
  }
}
