// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.PageSize
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public struct PageSize
  {
    public static readonly PageSize Empty;

    public PageSize(short width, short height)
      : this()
    {
      this.Width = width;
      this.Height = height;
    }

    public short Width { get; set; }

    public short Height { get; set; }

    public bool IsEmpty => this.Width == (short) 0 && this.Height == (short) 0;

    public override bool Equals(object obj) => obj is PageSize pageSize && pageSize == this;

    public override int GetHashCode() => (int) this.Width ^ (int) this.Height;

    public override string ToString() => string.Format("[Width={0}, Height={1}]", (object) this.Width, (object) this.Height);

    public static bool operator ==(PageSize left, PageSize right) => (int) left.Width == (int) right.Width && (int) left.Height == (int) right.Height;

    public static bool operator !=(PageSize left, PageSize right) => !(left == right);
  }
}
