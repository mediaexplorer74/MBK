using MobileBandSync.MSFTBandLib.Facility;

namespace MobileBandSync.MSFTBandLib;

internal static class DeviceCommands
{
	internal const ushort IndexShift = 0;

	internal const ushort IndexBits = 7;

	internal const ushort IndexMask = 127;

	internal const ushort TXShift = 7;

	internal const ushort TXBits = 1;

	internal const ushort TXMask = 128;

	internal const ushort CategoryShift = 8;

	internal const ushort CategoryBits = 8;

	internal const ushort CategoryMask = 65280;

	internal static ushort CargoCoreModuleGetVersion = MakeCommand(FacilityEnum.LibraryJutil, TX.True, 1);

	internal static ushort CargoCoreModuleGetUniqueID = MakeCommand(FacilityEnum.LibraryJutil, TX.True, 2);

	internal static ushort CargoCoreModuleWhoAmI = MakeCommand(FacilityEnum.LibraryJutil, TX.True, 3);

	internal static ushort CargoCoreModuleGetLogVersion = MakeCommand(FacilityEnum.LibraryJutil, TX.True, 5);

	internal static ushort CargoCoreModuleGetApiVersion = MakeCommand(FacilityEnum.LibraryJutil, TX.True, 6);

	internal static ushort CargoCoreModuleSdkCheck = MakeCommand(FacilityEnum.LibraryJutil, TX.False, 7);

	internal static ushort CargoTimeGetUtcTime = MakeCommand(FacilityEnum.LibraryTime, TX.True, 0);

	internal static ushort CargoTimeSetUtcTime = MakeCommand(FacilityEnum.LibraryTime, TX.False, 1);

	internal static ushort CargoTimeGetLocalTime = MakeCommand(FacilityEnum.LibraryTime, TX.True, 2);

	internal static ushort CargoTimeSetTimeZoneFile = MakeCommand(FacilityEnum.LibraryTime, TX.False, 4);

	internal static ushort CargoTimeZoneFileGetVersion = MakeCommand(FacilityEnum.LibraryTime, TX.True, 6);

	internal static ushort CargoLoggerGetChunkData = MakeCommand(FacilityEnum.LibraryLogger, TX.True, 1);

	internal static ushort CargoLoggerEnableLogging = MakeCommand(FacilityEnum.LibraryLogger, TX.False, 3);

	internal static ushort CargoLoggerDisableLogging = MakeCommand(FacilityEnum.LibraryLogger, TX.False, 4);

	internal static ushort CargoLoggerGetChunkCounts = MakeCommand(FacilityEnum.LibraryLogger, TX.True, 9);

	internal static ushort CargoLoggerFlush = MakeCommand(FacilityEnum.LibraryLogger, TX.False, 13);

	internal static ushort CargoLoggerGetChunkRangeMetadata = MakeCommand(FacilityEnum.LibraryLogger, TX.True, 14);

	internal static ushort CargoLoggerGetChunkRangeData = MakeCommand(FacilityEnum.LibraryLogger, TX.True, 15);

	internal static ushort CargoLoggerDeleteChunkRange = MakeCommand(FacilityEnum.LibraryLogger, TX.False, 16);

	internal static ushort CargoProfileGetDataApp = MakeCommand(FacilityEnum.ModuleProfile, TX.True, 6);

	internal static ushort CargoProfileSetDataApp = MakeCommand(FacilityEnum.ModuleProfile, TX.False, 7);

	internal static ushort CargoProfileGetDataFW = MakeCommand(FacilityEnum.ModuleProfile, TX.True, 8);

	internal static ushort CargoProfileSetDataFW = MakeCommand(FacilityEnum.ModuleProfile, TX.False, 9);

	internal static ushort CargoRemoteSubscriptionSubscribe = MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.False, 0);

	internal static ushort CargoRemoteSubscriptionUnsubscribe = MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.False, 1);

	internal static ushort CargoRemoteSubscriptionGetDataLength = MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.True, 2);

	internal static ushort CargoRemoteSubscriptionGetData = MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.True, 3);

	internal static ushort CargoRemoteSubscriptionSubscribeId = MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.False, 7);

	internal static ushort CargoRemoteSubscriptionUnsubscribeId = MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.False, 8);

	internal static ushort CargoNotification = MakeCommand(FacilityEnum.ModuleNotification, TX.False, 0);

	internal static ushort CargoNotificationProtoBuf = MakeCommand(FacilityEnum.ModuleNotification, TX.False, 5);

	internal static ushort CargoDynamicAppRegisterApp = MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 0);

	internal static ushort CargoDynamicAppRemoveApp = MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 1);

	internal static ushort CargoDynamicAppRegisterAppIcons = MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 2);

	internal static ushort CargoDynamicAppSetAppTileIndex = MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 3);

	internal static ushort CargoDynamicAppSetAppBadgeTileIndex = MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 5);

	internal static ushort CargoDynamicAppSetAppNotificationTileIndex = MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 11);

	internal static ushort CargoDynamicPageLayoutSet = MakeCommand(FacilityEnum.ModuleFireballPageManagement, TX.False, 0);

	internal static ushort CargoDynamicPageLayoutRemove = MakeCommand(FacilityEnum.ModuleFireballPageManagement, TX.False, 1);

	internal static ushort CargoDynamicPageLayoutGet = MakeCommand(FacilityEnum.ModuleFireballPageManagement, TX.True, 2);

	internal static ushort CargoInstalledAppListGet = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 0);

	internal static ushort CargoInstalledAppListSet = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 1);

	internal static ushort CargoInstalledAppListStartStripSyncStart = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 2);

	internal static ushort CargoInstalledAppListStartStripSyncEnd = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 3);

	internal static ushort CargoInstalledAppListGetDefaults = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 4);

	internal static ushort CargoInstalledAppListSetTile = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 6);

	internal static ushort CargoInstalledAppListGetTile = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 7);

	internal static ushort CargoInstalledAppListGetSettingsMask = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 13);

	internal static ushort CargoInstalledAppListSetSettingsMask = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 14);

	internal static ushort CargoInstalledAppListEnableSetting = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 15);

	internal static ushort CargoInstalledAppListDisableSetting = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 16);

	internal static ushort CargoInstalledAppListGetNoImages = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 18);

	internal static ushort CargoInstalledAppListGetDefaultsNoImages = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 19);

	internal static ushort CargoInstalledAppListGetMaxTileCount = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 21);

	internal static ushort CargoInstalledAppListGetMaxTileAllocatedCount = MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 22);

	internal static ushort CargoSystemSettingsOobeCompleteClear = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 0);

	internal static ushort CargoSystemSettingsOobeCompleteSet = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 1);

	internal static ushort CargoSystemSettingsFactoryReset = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.True, 7);

	internal static ushort CargoSystemSettingsGetTimeZone = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.True, 10);

	internal static ushort CargoSystemSettingsSetTimeZone = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 11);

	internal static ushort CargoSystemSettingsSetEphemerisFile = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 15);

	internal static ushort CargoSystemSettingsGetMeTileImageID = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.True, 18);

	internal static ushort CargoSystemSettingsOobeCompleteGet = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.True, 19);

	internal static ushort CargoSystemSettingsEnableDemoMode = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 25);

	internal static ushort CargoSystemSettingsDisableDemoMode = MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 26);

	internal static ushort CargoSRAMFWUpdateLoadData = MakeCommand(FacilityEnum.LibrarySRAMFWUpdate, TX.False, 0);

	internal static ushort CargoSRAMFWUpdateBootIntoUpdateMode = MakeCommand(FacilityEnum.LibrarySRAMFWUpdate, TX.False, 1);

	internal static ushort CargoSRAMFWUpdateValidateAssets = MakeCommand(FacilityEnum.LibrarySRAMFWUpdate, TX.True, 2);

	internal static ushort CargoEFlashRead = MakeCommand(FacilityEnum.DriverEFlash, TX.True, 1);

	internal static ushort CargoGpsIsEnabled = MakeCommand(FacilityEnum.LibraryGps, TX.True, 6);

	internal static ushort CargoGpsEphemerisCoverageDates = MakeCommand(FacilityEnum.LibraryGps, TX.True, 13);

	internal static ushort CargoFireballUINavigateToScreen = MakeCommand(FacilityEnum.ModuleFireballUI, TX.False, 0);

	internal static ushort CargoFireballUIClearMeTileImage = MakeCommand(FacilityEnum.ModuleFireballUI, TX.False, 6);

	internal static ushort CargoFireballUISetSmsResponse = MakeCommand(FacilityEnum.ModuleFireballUI, TX.False, 7);

	internal static ushort CargoFireballUIGetAllSmsResponse = MakeCommand(FacilityEnum.ModuleFireballUI, TX.True, 11);

	internal static ushort CargoFireballUIReadMeTileImage = MakeCommand(FacilityEnum.ModuleFireballUI, TX.True, 14);

	internal static ushort CargoFireballUIWriteMeTileImageWithID = MakeCommand(FacilityEnum.ModuleFireballUI, TX.False, 17);

	internal static ushort CargoThemeColorSetFirstPartyTheme = MakeCommand(FacilityEnum.ModuleThemeColor, TX.False, 0);

	internal static ushort CargoThemeColorGetFirstPartyTheme = MakeCommand(FacilityEnum.ModuleThemeColor, TX.True, 1);

	internal static ushort CargoThemeColorSetCustomTheme = MakeCommand(FacilityEnum.ModuleThemeColor, TX.False, 2);

	internal static ushort CargoThemeColorReset = MakeCommand(FacilityEnum.ModuleThemeColor, TX.False, 4);

	internal static ushort CargoHapticPlayVibrationStream = MakeCommand(FacilityEnum.LibraryHaptic, TX.False, 0);

	internal static ushort CargoGoalTrackerSet = MakeCommand(FacilityEnum.ModuleGoalTracker, TX.False, 0);

	internal static ushort CargoFitnessPlansWriteFile = MakeCommand(FacilityEnum.LibraryFitnessPlans, TX.False, 4);

	internal static ushort CargoGolfCourseFileWrite = MakeCommand(FacilityEnum.LibraryGolf, TX.False, 0);

	internal static ushort CargoGolfCourseFileGetMaxSize = MakeCommand(FacilityEnum.LibraryGolf, TX.True, 1);

	internal static ushort CargoOobeSetStage = MakeCommand(FacilityEnum.ModuleOobe, TX.False, 0);

	internal static ushort CargoOobeGetStage = MakeCommand(FacilityEnum.ModuleOobe, TX.True, 1);

	internal static ushort CargoOobeFinalize = MakeCommand(FacilityEnum.ModuleOobe, TX.False, 2);

	internal static ushort CargoCortanaNotification = MakeCommand(FacilityEnum.ModuleCortana, TX.False, 0);

	internal static ushort CargoCortanaStart = MakeCommand(FacilityEnum.ModuleCortana, TX.False, 1);

	internal static ushort CargoCortanaStop = MakeCommand(FacilityEnum.ModuleCortana, TX.False, 2);

	internal static ushort CargoCortanaCancel = MakeCommand(FacilityEnum.ModuleCortana, TX.False, 3);

	internal static ushort CargoPersistedAppDataSetRunMetrics = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 0);

	internal static ushort CargoPersistedAppDataGetRunMetrics = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 1);

	internal static ushort CargoPersistedAppDataSetBikeMetrics = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 2);

	internal static ushort CargoPersistedAppDataGetBikeMetrics = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 3);

	internal static ushort CargoPersistedAppDataSetBikeSplitMult = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 4);

	internal static ushort CargoPersistedAppDataGetBikeSplitMult = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 5);

	internal static ushort CargoPersistedAppDataSetWorkoutActivities = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 9);

	internal static ushort CargoPersistedAppDataGetWorkoutActivities = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 16);

	internal static ushort CargoPersistedAppDataSetSleepNotification = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 17);

	internal static ushort CargoPersistedAppDataGetSleepNotification = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 18);

	internal static ushort CargoPersistedAppDataDisableSleepNotification = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 19);

	internal static ushort CargoPersistedAppDataSetLightExposureNotification = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 21);

	internal static ushort CargoPersistedAppDataGetLightExposureNotification = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 22);

	internal static ushort CargoPersistedAppDataDisableLightExposureNotification = MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 23);

	internal static ushort CargoGetProductSerialNumber = MakeCommand(FacilityEnum.LibraryConfiguration, TX.True, 8);

	internal static ushort CargoKeyboardCmd = MakeCommand(FacilityEnum.LibraryKeyboard, TX.False, 0);

	internal static ushort CargoSubscriptionLoggerSubscribe = MakeCommand(FacilityEnum.ModuleLoggerSubscriptions, TX.False, 0);

	internal static ushort CargoSubscriptionLoggerUnsubscribe = MakeCommand(FacilityEnum.ModuleLoggerSubscriptions, TX.False, 1);

	internal static ushort CargoCrashDumpGetFileSize = MakeCommand(FacilityEnum.DriverCrashDump, TX.True, 1);

	internal static ushort CargoCrashDumpGetAndDeleteFile = MakeCommand(FacilityEnum.DriverCrashDump, TX.True, 2);

	internal static ushort CargoInstrumentationGetFileSize = MakeCommand(FacilityEnum.ModuleInstrumentation, TX.True, 4);

	internal static ushort CargoInstrumentationGetFile = MakeCommand(FacilityEnum.ModuleInstrumentation, TX.True, 5);

	internal static ushort CargoPersistedStatisticsRunGet = MakeCommand(FacilityEnum.ModulePersistedStatistics, TX.True, 2);

	internal static ushort CargoPersistedStatisticsWorkoutGet = MakeCommand(FacilityEnum.ModulePersistedStatistics, TX.True, 3);

	internal static ushort CargoPersistedStatisticsSleepGet = MakeCommand(FacilityEnum.ModulePersistedStatistics, TX.True, 4);

	internal static ushort CargoPersistedStatisticsGuidedWorkoutGet = MakeCommand(FacilityEnum.ModulePersistedStatistics, TX.True, 5);

	internal static ushort MakeCommand(FacilityEnum category, TX isTXCommand, byte index)
	{
		ushort num = (ushort)((ushort)category << 8);
		ushort num2 = (ushort)((uint)isTXCommand << 7);
		return (ushort)(num | num2 | index);
	}

	internal static void LookupCommand(ushort commandId, out FacilityEnum category, out TX isTXCommand, out byte index)
	{
		category = (FacilityEnum)((commandId & 0xFF00) >> 8);
		isTXCommand = (TX)((commandId & 0x80) >> 7);
		index = (byte)(commandId & 0x7Fu);
	}
}
