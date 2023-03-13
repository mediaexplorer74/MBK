namespace MobileBandSync.MSFTBandLib.Command
{
    using System;

    public enum CommandEnum : ushort
    {
        public const CommandEnum ChunkCounts = CommandEnum.ChunkCounts;,
        public const CommandEnum ChunkRangeDelete = CommandEnum.ChunkRangeDelete;,
        public const CommandEnum ChunkRangeGetData = CommandEnum.ChunkRangeGetData;,
        public const CommandEnum ChunkRangeGetMetadata = CommandEnum.ChunkRangeGetMetadata;,
        public const CommandEnum FlushLog = CommandEnum.FlushLog;,
        public const CommandEnum GetApiVersion = CommandEnum.GetApiVersion;,
        public const CommandEnum GetDeviceName = CommandEnum.GetDeviceName;,
        [CommandDataSize(0x10)]
        public const CommandEnum GetDeviceTime = CommandEnum.GetDeviceTime;,
        public const CommandEnum GetLogVersion = CommandEnum.GetLogVersion;,
        public const CommandEnum GetMaxTileCount = CommandEnum.GetMaxTileCount;,
        public const CommandEnum GetMaxTileCountAllocated = CommandEnum.GetMaxTileCountAllocated;,
        public const CommandEnum GetMeTileImage = CommandEnum.GetMeTileImage;,
        public const CommandEnum GetMeTileImageId = CommandEnum.GetMeTileImageId;,
        public const CommandEnum GetSdkVersion = CommandEnum.GetSdkVersion;,
        [CommandDataSize(12)]
        public const CommandEnum GetSerialNumber = CommandEnum.GetSerialNumber;,
        public const CommandEnum GetSettingsMask = CommandEnum.GetSettingsMask;,
        public const CommandEnum GetStatisticsRun = CommandEnum.GetStatisticsRun;,
        [CommandDataSize(0x36)]
        public const CommandEnum GetStatisticsSleep = CommandEnum.GetStatisticsSleep;,
        public const CommandEnum GetStatisticsWorkout = CommandEnum.GetStatisticsWorkout;,
        public const CommandEnum GetStatisticsWorkoutGuided = CommandEnum.GetStatisticsWorkoutGuided;,
        public const CommandEnum GetTile = CommandEnum.GetTile;,
        public const CommandEnum GetTiles = CommandEnum.GetTiles;,
        public const CommandEnum GetTilesDefaults = CommandEnum.GetTilesDefaults;,
        public const CommandEnum GetTilesNoImages = CommandEnum.GetTilesNoImages;,
        public const CommandEnum GetUniqueId = CommandEnum.GetUniqueId;,
        public const CommandEnum Notification = CommandEnum.Notification;,
        public const CommandEnum OobeFinalise = CommandEnum.OobeFinalise;,
        public const CommandEnum OobeGetComplete = CommandEnum.OobeGetComplete;,
        public const CommandEnum OobeSetComplete = CommandEnum.OobeSetComplete;,
        public const CommandEnum OobeGetStage = CommandEnum.OobeGetStage;,
        public const CommandEnum OobeSetStage = CommandEnum.OobeSetStage;,
        public const CommandEnum ProfileGetDataApp = CommandEnum.ProfileGetDataApp;,
        public const CommandEnum ProfileGetDataFw = CommandEnum.ProfileGetDataFw;,
        public const CommandEnum ProfileSetDataApp = CommandEnum.ProfileSetDataApp;,
        public const CommandEnum ProfileSetDataFw = CommandEnum.ProfileSetDataFw;,
        public const CommandEnum SetDeviceTime = CommandEnum.SetDeviceTime;,
        public const CommandEnum SetMeTileImage = CommandEnum.SetMeTileImage;,
        public const CommandEnum SetSettingsMask = CommandEnum.SetSettingsMask;,
        public const CommandEnum SetThemeColor = CommandEnum.SetThemeColor;,
        public const CommandEnum SetTile = CommandEnum.SetTile;,
        public const CommandEnum SetTiles = CommandEnum.SetTiles;,
        public const CommandEnum StartStripSyncEnd = CommandEnum.StartStripSyncEnd;,
        public const CommandEnum StartStripSyncStart = CommandEnum.StartStripSyncStart;,
        public const CommandEnum Subscribe = CommandEnum.Subscribe;,
        public const CommandEnum SubscriptionGetData = CommandEnum.SubscriptionGetData;,
        public const CommandEnum SubscriptionGetDataLength = CommandEnum.SubscriptionGetDataLength;,
        public const CommandEnum SubscriptionSubscribeId = CommandEnum.SubscriptionSubscribeId;,
        public const CommandEnum SubscriptionUnsubscribeId = CommandEnum.SubscriptionUnsubscribeId;,
        public const CommandEnum TilesDisableSetting = CommandEnum.TilesDisableSetting;,
        public const CommandEnum TilesEnableSetting = CommandEnum.TilesEnableSetting;,
        public const CommandEnum UINavigateScreen = CommandEnum.UINavigateScreen;,
        public const CommandEnum Unsubscribe = CommandEnum.Unsubscribe;
    }
}

