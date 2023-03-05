// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.BandIOException
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System;

namespace Microsoft.Band
{
  public class BandIOException : BandException
  {
        public BandIOException()
    {
    }

        public BandIOException(string message)
      : base(message)
    {
    }

        public BandIOException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
