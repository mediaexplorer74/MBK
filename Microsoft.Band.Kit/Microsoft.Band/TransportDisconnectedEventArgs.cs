// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.TransportDisconnectedEventArgs
// Assembly: Microsoft.Band, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 224A5D14-177F-4224-A6AA-76F665C6D960
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.dll

using System;

namespace Microsoft.Band
{
  public class TransportDisconnectedEventArgs : EventArgs
  {
    public TransportDisconnectedEventArgs(TransportDisconnectedReason reason) => this.Reason = reason;

    public TransportDisconnectedReason Reason { get; private set; }
  }
}
