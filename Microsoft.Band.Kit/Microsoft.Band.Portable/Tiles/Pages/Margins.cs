// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Tiles.Pages.Margins
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable.Tiles.Pages
{
  public struct Margins
  {
    public static Margins Empty;

    public Margins(short all)
      : this()
    {
      this.Left = all;
      this.Top = all;
      this.Right = all;
      this.Bottom = all;
    }

    public Margins(short horizontal, short vertical)
      : this()
    {
      this.Left = horizontal;
      this.Top = vertical;
      this.Right = horizontal;
      this.Bottom = vertical;
    }

    public Margins(short left, short top, short right, short bottom)
      : this()
    {
      this.Left = left;
      this.Top = top;
      this.Right = right;
      this.Bottom = bottom;
    }

    public short Left { get; set; }

    public short Top { get; set; }

    public short Right { get; set; }

    public short Bottom { get; set; }

    public int Horizontal => (int) this.Left + (int) this.Right;

    public int Vertical => (int) this.Top + (int) this.Bottom;

    public override bool Equals(object obj) => obj is Margins margins && margins == this;

    public override int GetHashCode() => (int) this.Left ^ (int) this.Top ^ (int) this.Right ^ (int) this.Bottom;

    public override string ToString() => string.Format("[Left={0}, Top={1}, Right={2}, Bottom={3}]", (object) this.Left, (object) this.Top, (object) this.Right, (object) this.Bottom);

    public static bool operator ==(Margins left, Margins right) => (int) left.Left == (int) right.Left && (int) left.Top == (int) right.Top && (int) left.Right == (int) right.Right && (int) left.Bottom == (int) right.Bottom;

    public static bool operator !=(Margins left, Margins right) => !(left == right);
  }
}
