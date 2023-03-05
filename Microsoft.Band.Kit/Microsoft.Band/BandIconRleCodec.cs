﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.BandIconRleCodec
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using Microsoft.Band.Tiles;

namespace Microsoft.Band
{
  internal static class BandIconRleCodec
  {
    public static PooledBuffer EncodeTileIconRle(BandIcon icon)
    {
      BandIconRleCodec.ValidateIconSize(icon);
      PooledBuffer buffer = BufferServer.GetBuffer(1024);
      try
      {
        BandIconRleCodec.EncodeTileIconRle(icon, buffer.Buffer);
      }
      catch
      {
        buffer.Dispose();
        throw;
      }
      return buffer;
    }

    public static byte[] EncodeTileIconRleToArray(BandIcon icon)
    {
      BandIconRleCodec.ValidateIconSize(icon);
      byte[] rleArray = new byte[1024];
      BandIconRleCodec.EncodeTileIconRle(icon, rleArray);
      return rleArray;
    }

    private static void ValidateIconSize(BandIcon icon)
    {
      if (icon.Width * icon.Height > 15270)
        throw new BandException("Input icon has too many pixels for Run Length Encoding.");
    }

    private static void EncodeTileIconRle(BandIcon icon, byte[] rleArray)
    {
      byte[] iconData = icon.IconData;
      int num1 = 0;
      int rleIndex = 6;
      rleArray[0] = (byte) (icon.Width >> 8);
      rleArray[1] = (byte) icon.Width;
      rleArray[2] = (byte) (icon.Height >> 8);
      rleArray[3] = (byte) icon.Height;
      for (int index1 = 0; index1 < icon.Height; ++index1)
      {
        byte num2 = 0;
        int num3 = 0;
        switch (num1 % 2)
        {
          case 0:
            num2 = (byte) ((int) iconData[num1++ / 2] >> 4 & 15);
            break;
          case 1:
            num2 = (byte) ((uint) iconData[num1++ / 2] & 15U);
            break;
        }
        int num4 = num3 + 1;
        for (int index2 = 1; index2 < icon.Width; ++index2)
        {
          BandIconRleCodec.RleLengthCheck(rleIndex);
          byte num5 = 0;
          switch (num1 % 2)
          {
            case 0:
              num5 = (byte) ((int) iconData[num1++ / 2] >> 4 & 15);
              break;
            case 1:
              num5 = (byte) ((uint) iconData[num1++ / 2] & 15U);
              break;
          }
          if ((int) num2 != (int) num5)
          {
            if (num4 > 0)
              rleArray[rleIndex++] = (byte) ((uint) (num4 << 4) | (uint) num2);
            num2 = num5;
            num4 = 0;
          }
          ++num4;
          if (num4 == 15)
          {
            BandIconRleCodec.RleLengthCheck(rleIndex);
            rleArray[rleIndex++] = (byte) ((uint) (num4 << 4) | (uint) num2);
            num4 = 0;
          }
        }
        if (num4 > 0)
        {
          BandIconRleCodec.RleLengthCheck(rleIndex);
          rleArray[rleIndex++] = (byte) ((uint) (num4 << 4) | (uint) num2);
        }
      }
      rleArray[4] = (byte) (rleIndex >> 8);
      rleArray[5] = (byte) rleIndex;
    }

    private static void RleLengthCheck(int rleIndex)
    {
      if (rleIndex >= 1024)
        throw new BandException("Run Length Encoding Failure.");
    }

    public static BandIcon DecodeTileIconRle(PooledBuffer rleIcon) => BandIconRleCodec.DecodeTileIconRle(rleIcon.Buffer);

    public static BandIcon DecodeTileIconRle(byte[] rleArray)
    {
      ushort width = (ushort) ((uint) rleArray[0] << 8 | (uint) rleArray[1]);
      ushort height = (ushort) ((uint) rleArray[2] << 8 | (uint) rleArray[3]);
      if (width == (ushort) 0 || height == (ushort) 0 || (uint) width * (uint) height > 15270U)
        return new BandIcon(0, 0, new byte[0]);
      int num1 = (int) width * (int) height;
      byte[] iconData = new byte[num1 / 2 + num1 % 2];
      int num2 = 0;
      ushort num3 = (ushort) ((uint) rleArray[4] << 8 | (uint) rleArray[5]);
      for (int index = 6; index < (int) num3; ++index)
      {
        byte num4 = (byte) ((uint) rleArray[index] >> 4);
        byte num5 = (byte) ((uint) rleArray[index] & 15U);
        if (num5 == (byte) 0)
        {
          num2 += (int) num4;
        }
        else
        {
          byte num6 = 0;
          while ((int) num6 < (int) num4)
          {
            switch (num2 % 2)
            {
              case 0:
                iconData[num2 / 2] = (byte) ((uint) num5 << 4);
                break;
              case 1:
                iconData[num2 / 2] |= num5;
                break;
            }
            ++num6;
            ++num2;
          }
        }
      }
      return new BandIcon((int) width, (int) height, iconData);
    }
  }
}
