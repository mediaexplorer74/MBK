// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.PagePoint
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public struct PagePoint
  {
    public static readonly PagePoint Empty;

    public PagePoint(short x, short y)
      : this()
    {
      this.X = x;
      this.Y = y;
    }

    public short X { get; set; }

    public short Y { get; set; }

    public bool IsEmpty => this.X == (short) 0 && this.Y == (short) 0;

    public override bool Equals(object obj) => obj is PagePoint pagePoint && pagePoint == this;

    public override int GetHashCode() => (int) this.X ^ (int) this.Y;

    public override string ToString() => string.Format("[X={0}, Y={1}]", (object) this.X, (object) this.Y);

    public static bool operator ==(PagePoint left, PagePoint right) => (int) left.X == (int) right.X && (int) left.Y == (int) right.Y;

    public static bool operator !=(PagePoint left, PagePoint right) => !(left == right);
  }
}
