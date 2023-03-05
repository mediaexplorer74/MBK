// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.BandTileButtonPressedEventArgs
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Tiles;
using System;

namespace Microsoft.Band.Portable.Tiles
{
  public class BandTileButtonPressedEventArgs : BandTileEventArgs
  {
    internal BandTileButtonPressedEventArgs(IBandTileButtonPressedEvent tileButtonEvent)
      : this((int) tileButtonEvent.ElementId, tileButtonEvent.PageId.FromNative(), tileButtonEvent.TileId.FromNative())
    {
    }

    public BandTileButtonPressedEventArgs(int elementId, Guid pageId, Guid tileId)
      : base(TileActionType.ButtonPressed, tileId)
    {
      this.ElementId = elementId;
      this.PageId = pageId;
    }

    public int ElementId { get; private set; }

    public Guid PageId { get; private set; }
  }
}
