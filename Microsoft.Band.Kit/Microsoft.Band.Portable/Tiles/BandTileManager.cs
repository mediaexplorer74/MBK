// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.BandTileManager
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Tiles
{
  public class BandTileManager
  {
    private readonly Microsoft.Band.Portable.BandClient client;
    private readonly object subscribedLock = new object();
    internal readonly IBandTileManager Native;

    internal BandTileManager(Microsoft.Band.Portable.BandClient client, IBandTileManager tileManager)
    {
      this.Native = tileManager;
      this.client = client;
      this.Native.TileButtonPressed += new EventHandler<BandTileEventArgs<IBandTileButtonPressedEvent>>(this.OnNativeTileButtonPressed);
      this.Native.TileOpened += new EventHandler<BandTileEventArgs<IBandTileOpenedEvent>>(this.OnNativeTileOpened);
      this.Native.TileClosed += new EventHandler<BandTileEventArgs<IBandTileClosedEvent>>(this.OnNativeTileClosed);
    }

    public async Task<bool> AddTileAsync(BandTile tile) => await this.Native.AddTileAsync(tile.ToNative());

    public async Task<int> GetRemainingTileCapacityAsync() => await this.Native.GetRemainingTileCapacityAsync();

    public async Task<IEnumerable<BandTile>> GetTilesAsync() => (await this.Native.GetTilesAsync()).Select<Microsoft.Band.Tiles.BandTile, BandTile>((Func<Microsoft.Band.Tiles.BandTile, BandTile>) (x => x.FromNative()));

    public async Task RemoveTileAsync(Guid tileId)
    {
      int num = await this.Native.RemoveTileAsync(tileId.ToNative()) ? 1 : 0;
    }

    public async Task RemoveTilePagesAsync(Guid tileId)
    {
      int num = await this.Native.RemovePagesAsync(tileId.ToNative()) ? 1 : 0;
    }

    public async Task SetTilePageDataAsync(Guid tileId, IEnumerable<Microsoft.Band.Portable.Tiles.Pages.Data.PageData> pageData)
    {
      int num = await this.Native.SetPagesAsync(tileId.ToNative(), pageData.Select<Microsoft.Band.Portable.Tiles.Pages.Data.PageData, Microsoft.Band.Tiles.Pages.PageData>((Func<Microsoft.Band.Portable.Tiles.Pages.Data.PageData, Microsoft.Band.Tiles.Pages.PageData>) (pd => pd.ToNative())).ToArray<Microsoft.Band.Tiles.Pages.PageData>()) ? 1 : 0;
    }

    public Task SetTilePageDataAsync(Guid tileId, params Microsoft.Band.Portable.Tiles.Pages.Data.PageData[] pageData) => this.SetTilePageDataAsync(tileId, (IEnumerable<Microsoft.Band.Portable.Tiles.Pages.Data.PageData>) pageData);

    public async Task StartEventListenersAsync() => await this.Native.StartReadingsAsync();

    public async Task StopEventListenersAsync() => await this.Native.StopReadingsAsync();

    protected virtual void OnTileButtonPressed(BandTileButtonPressedEventArgs e)
    {
      EventHandler<BandTileButtonPressedEventArgs> tileButtonPressed = this.TileButtonPressed;
      if (tileButtonPressed == null)
        return;
      tileButtonPressed((object) this, e);
    }

    protected virtual void OnTileOpened(BandTileOpenedEventArgs e)
    {
      EventHandler<BandTileOpenedEventArgs> tileOpened = this.TileOpened;
      if (tileOpened == null)
        return;
      tileOpened((object) this, e);
    }

    protected virtual void OnTileClosed(BandTileClosedEventArgs e)
    {
      EventHandler<BandTileClosedEventArgs> tileClosed = this.TileClosed;
      if (tileClosed == null)
        return;
      tileClosed((object) this, e);
    }

    public event EventHandler<BandTileOpenedEventArgs> TileOpened;

    public event EventHandler<BandTileClosedEventArgs> TileClosed;

    public event EventHandler<BandTileButtonPressedEventArgs> TileButtonPressed;

    private void OnNativeTileButtonPressed(
      object sender,
      BandTileEventArgs<IBandTileButtonPressedEvent> e)
    {
      this.OnTileButtonPressed(new BandTileButtonPressedEventArgs(e.TileEvent));
    }

    private void OnNativeTileOpened(object sender, BandTileEventArgs<IBandTileOpenedEvent> e) => this.OnTileOpened(new BandTileOpenedEventArgs((IBandTileEvent) e.TileEvent));

    private void OnNativeTileClosed(object sender, BandTileEventArgs<IBandTileClosedEvent> e) => this.OnTileClosed(new BandTileClosedEventArgs((IBandTileEvent) e.TileEvent));
  }
}
