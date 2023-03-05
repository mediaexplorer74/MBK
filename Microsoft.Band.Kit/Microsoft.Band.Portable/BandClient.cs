// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.BandClient
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Portable.Notifications;
using Microsoft.Band.Portable.Personalization;
using Microsoft.Band.Portable.Sensors;
using Microsoft.Band.Portable.Tiles;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable
{
  public class BandClient
  {
    private readonly Lazy<BandSensorManager> sensors;
    private readonly Lazy<BandTileManager> tiles;
    private readonly Lazy<BandNotificationManager> notifications;
    private readonly Lazy<BandPersonalizationManager> personalization;
    internal IBandClient Native;

    private BandClient()
    {
    }

    internal BandClient(IBandClient client)
    {
      this.Native = client;
      this.sensors = new Lazy<BandSensorManager>((Func<BandSensorManager>) (() => new BandSensorManager(this, this.Native.SensorManager)));
      this.tiles = new Lazy<BandTileManager>((Func<BandTileManager>) (() => new BandTileManager(this, this.Native.TileManager)));
      this.notifications = new Lazy<BandNotificationManager>((Func<BandNotificationManager>) (() => new BandNotificationManager(this, this.Native.NotificationManager)));
      this.personalization = new Lazy<BandPersonalizationManager>((Func<BandPersonalizationManager>) (() => new BandPersonalizationManager(this, this.Native.PersonalizationManager)));
    }

    public BandSensorManager SensorManager
    {
      get
      {
        this.CheckDisposed();
        return this.sensors.Value;
      }
    }

    public BandNotificationManager NotificationManager
    {
      get
      {
        this.CheckDisposed();
        return this.notifications.Value;
      }
    }

    public BandTileManager TileManager
    {
      get
      {
        this.CheckDisposed();
        return this.tiles.Value;
      }
    }

    public BandPersonalizationManager PersonalizationManager
    {
      get
      {
        this.CheckDisposed();
        return this.personalization.Value;
      }
    }

    public bool IsConnected
    {
      get
      {
        this.CheckDisposed();
        return true;
      }
    }

    public async Task<string> GetFirmwareVersionAsync()
    {
      this.CheckDisposed();
      return await this.Native.GetFirmwareVersionAsync();
    }

    public async Task<string> GetHardwareVersionAsync()
    {
      this.CheckDisposed();
      return await this.Native.GetHardwareVersionAsync();
    }

    public async Task DisconnectAsync()
    {
      this.CheckDisposed();
      IBandClient native = this.Native;
      this.Native = (IBandClient) null;
      native.Dispose();
    }

    private void CheckDisposed()
    {
      if (this.Native == null)
        throw new ObjectDisposedException((string) null);
    }
  }
}
