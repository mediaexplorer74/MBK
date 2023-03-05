// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.BufferPool
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System;
using System.Collections.Generic;

namespace Microsoft.Band
{
  public sealed class BufferPool
  {
    private Queue<PooledBuffer> pool;

    internal BufferPool(int bufferSize, int maxBuffers)
    {
      if (bufferSize < 2)
        throw new ArgumentOutOfRangeException(nameof (bufferSize));
      if (maxBuffers < 1)
        throw new ArgumentOutOfRangeException(nameof (maxBuffers));
      this.BufferSize = bufferSize;
      this.MaxBuffers = maxBuffers;
      this.pool = new Queue<PooledBuffer>();
    }

    internal int BufferSize { get; private set; }

    internal int MaxBuffers { get; private set; }

    internal int Count => this.pool.Count;

    internal PooledBuffer GetBuffer(bool zero = false) => this.GetBuffer(this.BufferSize);

    internal PooledBuffer GetBuffer(int size, bool zero = false)
    {
      if (size < 0 || size > this.BufferSize)
        throw new ArgumentOutOfRangeException(nameof (size));
      PooledBuffer buffer = (PooledBuffer) null;
      if (this.pool.Count == 0)
      {
        buffer = new PooledBuffer(this, new byte[this.BufferSize], size);
      }
      else
      {
        lock (this.pool)
        {
          if (this.pool.Count == 0)
          {
            buffer = new PooledBuffer(this, new byte[this.BufferSize], size);
          }
          else
          {
            buffer = this.pool.Dequeue();
            buffer.Undispose(size);
            if (zero)
              Array.Clear((Array) buffer.Buffer, 0, buffer.Buffer.Length);
          }
        }
      }
      return buffer;
    }

    internal void ReleaseBuffer(PooledBuffer buffer)
    {
      if (buffer.Buffer.Length != this.BufferSize)
        throw new ArgumentException("The provided buffer does not belong to this pool", nameof (buffer));
      lock (this.pool)
      {
        if (this.pool.Count >= this.MaxBuffers)
          return;
        this.pool.Enqueue(buffer);
      }
    }
  }
}
