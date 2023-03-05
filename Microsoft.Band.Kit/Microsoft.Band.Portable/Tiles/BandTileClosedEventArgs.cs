// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.BandTileClosedEventArgs
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles;
using System;

namespace Microsoft.Band.Portable.Tiles
{
  public class BandTileClosedEventArgs : BandTileEventArgs
  {
    internal BandTileClosedEventArgs(IBandTileEvent tileEvent)
      : this(tileEvent.TileId.FromNative())
    {
    }

    public BandTileClosedEventArgs(Guid tileId)
      : base(TileActionType.TileClosed, tileId)
    {
    }
  }
}
