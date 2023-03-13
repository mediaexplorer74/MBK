namespace MobileBandSync.MSFTBandLib.Notifications
{
    using System;

    public enum NotificationsEnum : ushort
    {
        public const NotificationsEnum SMS = NotificationsEnum.SMS;,
        public const NotificationsEnum Email = NotificationsEnum.Email;,
        public const NotificationsEnum CalendarAddEvent = NotificationsEnum.CalendarAddEvent;,
        public const NotificationsEnum CalendarClear = NotificationsEnum.CalendarClear;,
        public const NotificationsEnum CallAnswered = NotificationsEnum.CallAnswered;,
        public const NotificationsEnum CallHangup = NotificationsEnum.CallHangup;,
        public const NotificationsEnum CallIncoming = NotificationsEnum.CallIncoming;,
        public const NotificationsEnum CallMissed = NotificationsEnum.CallMissed;,
        public const NotificationsEnum GenericDialog = NotificationsEnum.GenericDialog;,
        public const NotificationsEnum GenericPageClear = NotificationsEnum.GenericPageClear;,
        public const NotificationsEnum GenericTileClear = NotificationsEnum.GenericTileClear;,
        public const NotificationsEnum GenericUpdate = NotificationsEnum.GenericUpdate;,
        public const NotificationsEnum Messaging = NotificationsEnum.Messaging;,
        public const NotificationsEnum Voicemail = NotificationsEnum.Voicemail;
    }
}

