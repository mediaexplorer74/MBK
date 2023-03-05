﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.UnicodeExtensions
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System.Text;

namespace Microsoft.Band
{
  internal static class UnicodeExtensions
  {
    public static int GetBytesTrimDanglingHighSurrogate(
      this Encoding encoding,
      string s,
      int charCount,
      byte[] bytes,
      int byteIndex)
    {
      charCount = s.LengthTruncatedTrimDanglingHighSurrogate(charCount);
      return encoding.GetBytes(s, 0, charCount, bytes, byteIndex);
    }
  }
}
