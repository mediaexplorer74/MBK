// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.Notifications.BandNotificationManager
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Notifications;
using System;
using System.Threading.Tasks;

namespace Microsoft.Band.Portable.Notifications
{
  public class BandNotificationManager
  {
    private readonly Microsoft.Band.Portable.BandClient client;
    internal readonly IBandNotificationManager Native;

    internal BandNotificationManager(
      Microsoft.Band.Portable.BandClient client,
      IBandNotificationManager notificationManager)
    {
      this.Native = notificationManager;
      this.client = client;
    }

    public async Task SendMessageAsync(
      Guid tileId,
      string title,
      string body,
      DateTime timestamp)
    {
      await this.SendMessageAsync(tileId, title, body, timestamp, false);
    }

    public async Task SendMessageAsync(
      Guid tileId,
      string title,
      string body,
      DateTime timestamp,
      bool showDialog)
    {
      await this.SendMessageAsync(tileId, title, body, timestamp, showDialog ? MessageFlags.ShowDialog : MessageFlags.None);
    }

    public async Task SendMessageAsync(
      Guid tileId,
      string title,
      string body,
      DateTime timestamp,
      MessageFlags messageFlags)
    {
      await this.Native.SendMessageAsync(tileId.ToNative(), title, body, (DateTimeOffset) timestamp, messageFlags.ToNative());
    }

    public async Task ShowDialogAsync(Guid tileId, string title, string body) => await this.Native.ShowDialogAsync(tileId.ToNative(), title, body);

    public async Task VibrateAsync(VibrationType vibrationType) => await this.Native.VibrateAsync(vibrationType.ToNative());
  }
}
