// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.PageRect
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public struct PageRect
  {
    public static readonly PageRect Empty;

    public PageRect(PagePoint location, PageSize size)
      : this()
    {
      this.X = location.X;
      this.Y = location.Y;
      this.Width = size.Width;
      this.Height = size.Height;
    }

    public PageRect(short x, short y, short width, short height)
      : this()
    {
      this.X = x;
      this.Y = y;
      this.Width = width;
      this.Height = height;
    }

    public short Y { get; set; }

    public short X { get; set; }

    public short Width { get; set; }

    public short Height { get; set; }

    public PagePoint Location
    {
      get => new PagePoint(this.X, this.Y);
      set
      {
        this.X = value.X;
        this.Y = value.Y;
      }
    }

    public PageSize Size
    {
      get => new PageSize(this.Width, this.Height);
      set
      {
        this.Width = value.Width;
        this.Height = value.Height;
      }
    }

    public bool IsEmpty => this.X == (short) 0 && this.Y == (short) 0 && this.Width == (short) 0 && this.Height == (short) 0;

    public override bool Equals(object obj) => obj is PageRect pageRect && pageRect == this;

    public override int GetHashCode() => (int) this.X ^ (int) this.Y ^ (int) this.Width ^ (int) this.Height;

    public override string ToString() => string.Format("[X={0}, Y={1}, Width={2}, Height={3}]", (object) this.X, (object) this.Y, (object) this.Width, (object) this.Height);

    public static bool operator ==(PageRect left, PageRect right) => (int) left.X == (int) right.X && (int) left.Y == (int) right.Y && (int) left.Width == (int) right.Width && (int) left.Height == (int) right.Height;

    public static bool operator !=(PageRect left, PageRect right) => !(left == right);
  }
}
