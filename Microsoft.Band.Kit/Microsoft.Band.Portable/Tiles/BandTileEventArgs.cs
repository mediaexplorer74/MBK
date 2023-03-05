// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.BandTileEventArgs
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using System;

namespace Microsoft.Band.Portable.Tiles
{
  public class BandTileEventArgs : EventArgs
  {
    public BandTileEventArgs(TileActionType actionType, Guid tileId)
    {
      this.ActionType = actionType;
      this.TileId = tileId;
    }

    public TileActionType ActionType { get; private set; }

    public Guid TileId { get; private set; }
  }
}
