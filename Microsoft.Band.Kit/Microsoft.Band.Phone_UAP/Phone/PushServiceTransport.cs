// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Phone.PushServiceTransport
// Assembly: Microsoft.Band.Phone_UAP, Version=1.3.20628.2, Culture=neutral, PublicKeyToken=608d7da3159f502b
// MVID: 29D5BD9B-4535-4F2F-BDC5-1BF47D7C3CF4
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Phone_UAP.dll

//using Microsoft.Band.Store;
using System;
using System.Collections.Generic;
using Windows.Devices.Bluetooth.Rfcomm;

namespace Microsoft.Band.Phone
{
  internal sealed class PushServiceTransport : 
    BluetoothTransportBase,
    IReadableTransport,
    IDisposable
  {
    private readonly BluetoothDeviceInfo associatedBand;

    public PushServiceTransport(BluetoothDeviceInfo deviceInfo, ILoggerProvider loggerProvider)
      : base(loggerProvider)
    {
      this.associatedBand = deviceInfo;
    }

        public ICargoStream CargoStream => throw new NotImplementedException();

        public CargoStreamReader CargoReader => throw new NotImplementedException();

        public BandConnectionType ConnectionType => throw new NotImplementedException();

        public bool IsConnected => throw new NotImplementedException();

        public event EventHandler<TransportDisconnectedEventArgs> Disconnected;

        public void Connect(ushort maxConnectAttempts = 1)
    {
      Guid guid = new Guid("{C742E1A2-6320-5ABC-9643-D206C677E580}");
      foreach (RfcommDeviceService rfcommService 
                in (IEnumerable<RfcommDeviceService>) WindowsRuntimeSystemExtensions.AsTask<RfcommDeviceService>(
                    RfcommDeviceService.FromIdAsync(this.associatedBand.Peer.Id)).Result.Device.RfcommServices)
      {
        if (rfcommService.ServiceId.Uuid == guid)
        {
          this.Connect(rfcommService, maxConnectAttempts);
          this.CargoStream.ReadTimeout = int.MaxValue;
          return;
        }
      }
      throw new BandIOException(StoreResources.PushServiceNotFound);
    }

        private void Connect(RfcommDeviceService rfcommService, ushort maxConnectAttempts)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
