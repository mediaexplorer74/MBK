﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.CancellationTokenExtension
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System;
using System.Threading;

namespace Microsoft.Band
{
  internal static class CancellationTokenExtension
  {
    public static void WaitAndThrowIfCancellationRequested(
      this CancellationToken token,
      TimeSpan timeout)
    {
      token.WaitHandle.WaitOne(timeout);
      token.ThrowIfCancellationRequested();
    }

    public static void WaitAndThrowIfCancellationRequested(
      this CancellationToken token,
      int timeout)
    {
      token.WaitHandle.WaitOne(timeout);
      token.ThrowIfCancellationRequested();
    }
  }
}
