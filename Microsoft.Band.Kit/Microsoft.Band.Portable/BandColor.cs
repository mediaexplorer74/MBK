// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.BandColor
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using System;
using System.Globalization;

namespace Microsoft.Band.Portable
{
  public struct BandColor
  {
    private bool isInitialized;
    private byte r;
    private byte g;
    private byte b;
    public static readonly BandColor Empty;

    public BandColor(byte r, byte g, byte b)
      : this()
    {
      this.isInitialized = true;
      this.r = r;
      this.g = g;
      this.b = b;
    }

    public bool IsEmpty => !this.isInitialized;

    public byte R
    {
      get => this.r;
      set
      {
        this.r = value;
        this.isInitialized = true;
      }
    }

    public byte G
    {
      get => this.g;
      set
      {
        this.g = value;
        this.isInitialized = true;
      }
    }

    public byte B
    {
      get => this.b;
      set
      {
        this.b = value;
        this.isInitialized = true;
      }
    }

    public string Hex => string.Format("#{0:X2}{1:X2}{2:X2}", (object) this.R, (object) this.G, (object) this.B);

    public static BandColor FromHex(string hex)
    {
      hex = hex.Replace("#", "");
      if (hex.Length != 3 && hex.Length != 6)
        throw new ArgumentException(string.Format("'{0}' is not a valid RGB hex color.", (object) hex), nameof (hex));
      int num1 = hex.Length == 3 ? 1 : 2;
      int r = (int) byte.Parse(hex.Substring(0, num1), NumberStyles.HexNumber);
      byte num2 = byte.Parse(hex.Substring(num1, num1), NumberStyles.HexNumber);
      byte num3 = byte.Parse(hex.Substring(num1 + num1, num1), NumberStyles.HexNumber);
      int g = (int) num2;
      int b = (int) num3;
      return new BandColor((byte) r, (byte) g, (byte) b);
    }

    public static bool operator ==(BandColor color1, BandColor color2) => color1.Equals((object) color2);

    public static bool operator !=(BandColor color1, BandColor color2) => !color1.Equals((object) color2);

    public override bool Equals(object obj)
    {
      if (!(obj is BandColor bandColor1))
        return this.Equals(obj);
      BandColor bandColor2 = this;
      return bandColor2.isInitialized == bandColor1.isInitialized && (int) bandColor2.r == (int) bandColor1.r && (int) bandColor2.g == (int) bandColor1.g && (int) bandColor2.b == (int) bandColor1.b;
    }

    public override string ToString() => this.isInitialized ? string.Format("[R={0}, G={1}, B={2}]", (object) this.r, (object) this.g, (object) this.b) : "[Empty]";
  }
}
