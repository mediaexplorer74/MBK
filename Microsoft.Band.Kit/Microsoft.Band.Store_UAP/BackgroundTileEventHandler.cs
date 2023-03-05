// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.BackgroundTileEventHandler
// Assembly: Microsoft.Band.Store_UAP, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 018DB8C7-131F-4953-86CB-5B9FE6B445B8
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Store_UAP.dll

using Microsoft.Band.Tiles;
using System;
using System.Collections.Generic;
using Windows.Foundation.Collections;

namespace Microsoft.Band
{
  public class BackgroundTileEventHandler
  {
    private static BackgroundTileEventHandler instance;
    private static readonly object syncLock = new object();

    public static BackgroundTileEventHandler Instance
    {
      get
      {
        lock (BackgroundTileEventHandler.syncLock)
        {
          if (BackgroundTileEventHandler.instance == null)
            BackgroundTileEventHandler.instance = new BackgroundTileEventHandler();
          return BackgroundTileEventHandler.instance;
        }
      }
    }

    public event EventHandler<BandTileEventArgs<IBandTileOpenedEvent>> TileOpened;

    public event EventHandler<BandTileEventArgs<IBandTileButtonPressedEvent>> TileButtonPressed;

    public event EventHandler<BandTileEventArgs<IBandTileClosedEvent>> TileClosed;

    public bool HandleTileEvent(ValueSet message)
    {
      BandTileEventBase tileEvent = BandTileEventBase.ConstructFromDictionary((IDictionary<string, object>) message);
      bool flag;
      if (tileEvent == null)
      {
        flag = false;
      }
      else
      {
        flag = true;
        try
        {
          switch (tileEvent)
          {
            case IBandTileOpenedEvent _:
              if (this.TileOpened != null)
              {
                this.TileOpened((object) this, new BandTileEventArgs<IBandTileOpenedEvent>((IBandTileOpenedEvent) tileEvent));
                break;
              }
              break;
            case IBandTileButtonPressedEvent _:
              if (this.TileButtonPressed != null)
              {
                this.TileButtonPressed((object) this, new BandTileEventArgs<IBandTileButtonPressedEvent>((IBandTileButtonPressedEvent) tileEvent));
                break;
              }
              break;
            case IBandTileClosedEvent _:
              if (this.TileClosed != null)
              {
                this.TileClosed((object) this, new BandTileEventArgs<IBandTileClosedEvent>((IBandTileClosedEvent) tileEvent));
                break;
              }
              break;
          }
        }
        catch
        {
          throw;
        }
      }
      return flag;
    }
  }
}
