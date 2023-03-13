using System;

namespace MobileBandSync.MSFTBandLib.Notifications
{
	// Token: 0x02000065 RID: 101
	public enum NotificationsEnum : ushort
	{
		// Token: 0x040001EA RID: 490
		SMS = 1,
		// Token: 0x040001EB RID: 491
		Email,
		// Token: 0x040001EC RID: 492
		CalendarAddEvent = 16,
		// Token: 0x040001ED RID: 493
		CalendarClear,
		// Token: 0x040001EE RID: 494
		CallAnswered = 12,
		// Token: 0x040001EF RID: 495
		CallHangup = 14,
		// Token: 0x040001F0 RID: 496
		CallIncoming = 11,
		// Token: 0x040001F1 RID: 497
		CallMissed = 13,
		// Token: 0x040001F2 RID: 498
		GenericDialog = 100,
		// Token: 0x040001F3 RID: 499
		GenericPageClear = 103,
		// Token: 0x040001F4 RID: 500
		GenericTileClear = 102,
		// Token: 0x040001F5 RID: 501
		GenericUpdate = 101,
		// Token: 0x040001F6 RID: 502
		Messaging = 8,
		// Token: 0x040001F7 RID: 503
		Voicemail = 15
	}
}
