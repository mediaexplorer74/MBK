﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.BandAccessDeniedException
// Assembly: Microsoft.Band.Store_UAP, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 018DB8C7-131F-4953-86CB-5B9FE6B445B8
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Store_UAP.dll

using System;

namespace Microsoft.Band
{
  public class BandAccessDeniedException : BandIOException
  {
    internal BandAccessDeniedException()
    {
    }

    internal BandAccessDeniedException(string message)
      : base(message)
    {
    }

    internal BandAccessDeniedException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
