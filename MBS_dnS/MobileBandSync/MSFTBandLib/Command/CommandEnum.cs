using System;

namespace MobileBandSync.MSFTBandLib.Command
{
	// Token: 0x02000075 RID: 117
	public enum CommandEnum : ushort
	{
		// Token: 0x040002A5 RID: 677
		ChunkCounts = 35977,
		// Token: 0x040002A6 RID: 678
		ChunkRangeDelete = 35856,
		// Token: 0x040002A7 RID: 679
		ChunkRangeGetData = 35983,
		// Token: 0x040002A8 RID: 680
		ChunkRangeGetMetadata = 35982,
		// Token: 0x040002A9 RID: 681
		FlushLog = 35853,
		// Token: 0x040002AA RID: 682
		GetApiVersion = 30342,
		// Token: 0x040002AB RID: 683
		GetDeviceName = 30339,
		// Token: 0x040002AC RID: 684
		[CommandDataSize(16)]
		GetDeviceTime = 30082,
		// Token: 0x040002AD RID: 685
		GetLogVersion = 30341,
		// Token: 0x040002AE RID: 686
		GetMaxTileCount = 54421,
		// Token: 0x040002AF RID: 687
		GetMaxTileCountAllocated,
		// Token: 0x040002B0 RID: 688
		GetMeTileImage = 50062,
		// Token: 0x040002B1 RID: 689
		GetMeTileImageId = 51858,
		// Token: 0x040002B2 RID: 690
		GetSdkVersion = 30215,
		// Token: 0x040002B3 RID: 691
		[CommandDataSize(12)]
		GetSerialNumber = 30856,
		// Token: 0x040002B4 RID: 692
		GetSettingsMask = 54413,
		// Token: 0x040002B5 RID: 693
		GetStatisticsRun = 52866,
		// Token: 0x040002B6 RID: 694
		[CommandDataSize(54)]
		GetStatisticsSleep = 52868,
		// Token: 0x040002B7 RID: 695
		GetStatisticsWorkout = 52867,
		// Token: 0x040002B8 RID: 696
		GetStatisticsWorkoutGuided = 52869,
		// Token: 0x040002B9 RID: 697
		GetTile = 54407,
		// Token: 0x040002BA RID: 698
		GetTiles = 54400,
		// Token: 0x040002BB RID: 699
		GetTilesDefaults = 54404,
		// Token: 0x040002BC RID: 700
		GetTilesNoImages = 54418,
		// Token: 0x040002BD RID: 701
		GetUniqueId = 30337,
		// Token: 0x040002BE RID: 702
		Notification = 52224,
		// Token: 0x040002BF RID: 703
		OobeFinalise = 44290,
		// Token: 0x040002C0 RID: 704
		OobeGetComplete = 51859,
		// Token: 0x040002C1 RID: 705
		OobeSetComplete = 51713,
		// Token: 0x040002C2 RID: 706
		OobeGetStage = 44417,
		// Token: 0x040002C3 RID: 707
		OobeSetStage = 44288,
		// Token: 0x040002C4 RID: 708
		ProfileGetDataApp = 50566,
		// Token: 0x040002C5 RID: 709
		ProfileGetDataFw = 50568,
		// Token: 0x040002C6 RID: 710
		ProfileSetDataApp = 50439,
		// Token: 0x040002C7 RID: 711
		ProfileSetDataFw = 50441,
		// Token: 0x040002C8 RID: 712
		SetDeviceTime = 29953,
		// Token: 0x040002C9 RID: 713
		SetMeTileImage = 49937,
		// Token: 0x040002CA RID: 714
		SetSettingsMask = 54286,
		// Token: 0x040002CB RID: 715
		SetThemeColor = 55296,
		// Token: 0x040002CC RID: 716
		SetTile = 54278,
		// Token: 0x040002CD RID: 717
		SetTiles = 54273,
		// Token: 0x040002CE RID: 718
		StartStripSyncEnd = 54275,
		// Token: 0x040002CF RID: 719
		StartStripSyncStart = 54274,
		// Token: 0x040002D0 RID: 720
		Subscribe = 36608,
		// Token: 0x040002D1 RID: 721
		SubscriptionGetData = 36739,
		// Token: 0x040002D2 RID: 722
		SubscriptionGetDataLength = 36738,
		// Token: 0x040002D3 RID: 723
		SubscriptionSubscribeId = 36615,
		// Token: 0x040002D4 RID: 724
		SubscriptionUnsubscribeId,
		// Token: 0x040002D5 RID: 725
		TilesDisableSetting = 54288,
		// Token: 0x040002D6 RID: 726
		TilesEnableSetting = 54287,
		// Token: 0x040002D7 RID: 727
		UINavigateScreen = 49920,
		// Token: 0x040002D8 RID: 728
		Unsubscribe = 36609
	}
}
