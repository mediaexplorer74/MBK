﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.ICargoStream
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System;
using System.Threading;

namespace Microsoft.Band
{
  public interface ICargoStream : IDisposable
  {
    int ReadTimeout { get; set; }

    int WriteTimeout { get; set; }

    CancellationToken Cancel { get; set; }

    int Read(byte[] buffer, int offset, int count);

    void Write(byte[] buffer, int offset, int count);

    void Flush();
  }
}
