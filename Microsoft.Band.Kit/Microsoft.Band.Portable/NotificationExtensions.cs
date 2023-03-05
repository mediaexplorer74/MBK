// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.NotificationExtensions
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using System;

namespace Microsoft.Band.Portable
{
  internal static class NotificationExtensions
  {
    internal static Guid ToNative(this Guid guid) => guid;

    internal static Guid FromNative(this Guid guid) => guid;

    internal static Microsoft.Band.Notifications.MessageFlags ToNative(
      this Microsoft.Band.Portable.Notifications.MessageFlags messageFlags)
    {
      return messageFlags == Microsoft.Band.Portable.Notifications.MessageFlags.ShowDialog ? Microsoft.Band.Notifications.MessageFlags.ShowDialog : Microsoft.Band.Notifications.MessageFlags.None;
    }

    internal static Microsoft.Band.Notifications.VibrationType ToNative(
      this Microsoft.Band.Portable.Notifications.VibrationType vibrationType)
    {
      switch (vibrationType)
      {
        case Microsoft.Band.Portable.Notifications.VibrationType.RampDown:
          return Microsoft.Band.Notifications.VibrationType.RampDown;
        case Microsoft.Band.Portable.Notifications.VibrationType.RampUp:
          return Microsoft.Band.Notifications.VibrationType.RampUp;
        case Microsoft.Band.Portable.Notifications.VibrationType.NotificationOneTone:
          return Microsoft.Band.Notifications.VibrationType.NotificationOneTone;
        case Microsoft.Band.Portable.Notifications.VibrationType.NotificationTwoTone:
          return Microsoft.Band.Notifications.VibrationType.NotificationTwoTone;
        case Microsoft.Band.Portable.Notifications.VibrationType.NotificationAlarm:
          return Microsoft.Band.Notifications.VibrationType.NotificationAlarm;
        case Microsoft.Band.Portable.Notifications.VibrationType.NotificationTimer:
          return Microsoft.Band.Notifications.VibrationType.NotificationTimer;
        case Microsoft.Band.Portable.Notifications.VibrationType.OneToneHigh:
          return Microsoft.Band.Notifications.VibrationType.OneToneHigh;
        case Microsoft.Band.Portable.Notifications.VibrationType.ThreeToneHigh:
          return Microsoft.Band.Notifications.VibrationType.ThreeToneHigh;
        case Microsoft.Band.Portable.Notifications.VibrationType.TwoToneHigh:
          return Microsoft.Band.Notifications.VibrationType.TwoToneHigh;
        default:
          throw new ArgumentOutOfRangeException(nameof (vibrationType), "Invalid VibrationType specified.");
      }
    }
  }
}
