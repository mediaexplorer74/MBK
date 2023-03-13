using System;
using MobileBandSync.MSFTBandLib.Facility;

namespace MobileBandSync.MSFTBandLib
{
	// Token: 0x0200005C RID: 92
	internal static class DeviceCommands
	{
		// Token: 0x06000351 RID: 849 RVA: 0x0000A918 File Offset: 0x00008B18
		internal static ushort MakeCommand(FacilityEnum category, TX isTXCommand, byte index)
		{
			ushort num = (ushort)((ushort)category << 8);
			ushort num2 = (ushort)(isTXCommand << 7);
			return num | num2 | (ushort)index;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000A934 File Offset: 0x00008B34
		internal static void LookupCommand(ushort commandId, out FacilityEnum category, out TX isTXCommand, out byte index)
		{
			category = (FacilityEnum)((commandId & 65280) >> 8);
			isTXCommand = (TX)((commandId & 128) >> 7);
			index = (byte)(commandId & 127);
		}

		// Token: 0x0400015F RID: 351
		internal const ushort IndexShift = 0;

		// Token: 0x04000160 RID: 352
		internal const ushort IndexBits = 7;

		// Token: 0x04000161 RID: 353
		internal const ushort IndexMask = 127;

		// Token: 0x04000162 RID: 354
		internal const ushort TXShift = 7;

		// Token: 0x04000163 RID: 355
		internal const ushort TXBits = 1;

		// Token: 0x04000164 RID: 356
		internal const ushort TXMask = 128;

		// Token: 0x04000165 RID: 357
		internal const ushort CategoryShift = 8;

		// Token: 0x04000166 RID: 358
		internal const ushort CategoryBits = 8;

		// Token: 0x04000167 RID: 359
		internal const ushort CategoryMask = 65280;

		// Token: 0x04000168 RID: 360
		internal static ushort CargoCoreModuleGetVersion = DeviceCommands.MakeCommand(FacilityEnum.LibraryJutil, TX.True, 1);

		// Token: 0x04000169 RID: 361
		internal static ushort CargoCoreModuleGetUniqueID = DeviceCommands.MakeCommand(FacilityEnum.LibraryJutil, TX.True, 2);

		// Token: 0x0400016A RID: 362
		internal static ushort CargoCoreModuleWhoAmI = DeviceCommands.MakeCommand(FacilityEnum.LibraryJutil, TX.True, 3);

		// Token: 0x0400016B RID: 363
		internal static ushort CargoCoreModuleGetLogVersion = DeviceCommands.MakeCommand(FacilityEnum.LibraryJutil, TX.True, 5);

		// Token: 0x0400016C RID: 364
		internal static ushort CargoCoreModuleGetApiVersion = DeviceCommands.MakeCommand(FacilityEnum.LibraryJutil, TX.True, 6);

		// Token: 0x0400016D RID: 365
		internal static ushort CargoCoreModuleSdkCheck = DeviceCommands.MakeCommand(FacilityEnum.LibraryJutil, TX.False, 7);

		// Token: 0x0400016E RID: 366
		internal static ushort CargoTimeGetUtcTime = DeviceCommands.MakeCommand(FacilityEnum.LibraryTime, TX.True, 0);

		// Token: 0x0400016F RID: 367
		internal static ushort CargoTimeSetUtcTime = DeviceCommands.MakeCommand(FacilityEnum.LibraryTime, TX.False, 1);

		// Token: 0x04000170 RID: 368
		internal static ushort CargoTimeGetLocalTime = DeviceCommands.MakeCommand(FacilityEnum.LibraryTime, TX.True, 2);

		// Token: 0x04000171 RID: 369
		internal static ushort CargoTimeSetTimeZoneFile = DeviceCommands.MakeCommand(FacilityEnum.LibraryTime, TX.False, 4);

		// Token: 0x04000172 RID: 370
		internal static ushort CargoTimeZoneFileGetVersion = DeviceCommands.MakeCommand(FacilityEnum.LibraryTime, TX.True, 6);

		// Token: 0x04000173 RID: 371
		internal static ushort CargoLoggerGetChunkData = DeviceCommands.MakeCommand(FacilityEnum.LibraryLogger, TX.True, 1);

		// Token: 0x04000174 RID: 372
		internal static ushort CargoLoggerEnableLogging = DeviceCommands.MakeCommand(FacilityEnum.LibraryLogger, TX.False, 3);

		// Token: 0x04000175 RID: 373
		internal static ushort CargoLoggerDisableLogging = DeviceCommands.MakeCommand(FacilityEnum.LibraryLogger, TX.False, 4);

		// Token: 0x04000176 RID: 374
		internal static ushort CargoLoggerGetChunkCounts = DeviceCommands.MakeCommand(FacilityEnum.LibraryLogger, TX.True, 9);

		// Token: 0x04000177 RID: 375
		internal static ushort CargoLoggerFlush = DeviceCommands.MakeCommand(FacilityEnum.LibraryLogger, TX.False, 13);

		// Token: 0x04000178 RID: 376
		internal static ushort CargoLoggerGetChunkRangeMetadata = DeviceCommands.MakeCommand(FacilityEnum.LibraryLogger, TX.True, 14);

		// Token: 0x04000179 RID: 377
		internal static ushort CargoLoggerGetChunkRangeData = DeviceCommands.MakeCommand(FacilityEnum.LibraryLogger, TX.True, 15);

		// Token: 0x0400017A RID: 378
		internal static ushort CargoLoggerDeleteChunkRange = DeviceCommands.MakeCommand(FacilityEnum.LibraryLogger, TX.False, 16);

		// Token: 0x0400017B RID: 379
		internal static ushort CargoProfileGetDataApp = DeviceCommands.MakeCommand(FacilityEnum.ModuleProfile, TX.True, 6);

		// Token: 0x0400017C RID: 380
		internal static ushort CargoProfileSetDataApp = DeviceCommands.MakeCommand(FacilityEnum.ModuleProfile, TX.False, 7);

		// Token: 0x0400017D RID: 381
		internal static ushort CargoProfileGetDataFW = DeviceCommands.MakeCommand(FacilityEnum.ModuleProfile, TX.True, 8);

		// Token: 0x0400017E RID: 382
		internal static ushort CargoProfileSetDataFW = DeviceCommands.MakeCommand(FacilityEnum.ModuleProfile, TX.False, 9);

		// Token: 0x0400017F RID: 383
		internal static ushort CargoRemoteSubscriptionSubscribe = DeviceCommands.MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.False, 0);

		// Token: 0x04000180 RID: 384
		internal static ushort CargoRemoteSubscriptionUnsubscribe = DeviceCommands.MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.False, 1);

		// Token: 0x04000181 RID: 385
		internal static ushort CargoRemoteSubscriptionGetDataLength = DeviceCommands.MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.True, 2);

		// Token: 0x04000182 RID: 386
		internal static ushort CargoRemoteSubscriptionGetData = DeviceCommands.MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.True, 3);

		// Token: 0x04000183 RID: 387
		internal static ushort CargoRemoteSubscriptionSubscribeId = DeviceCommands.MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.False, 7);

		// Token: 0x04000184 RID: 388
		internal static ushort CargoRemoteSubscriptionUnsubscribeId = DeviceCommands.MakeCommand(FacilityEnum.LibraryRemoteSubscription, TX.False, 8);

		// Token: 0x04000185 RID: 389
		internal static ushort CargoNotification = DeviceCommands.MakeCommand(FacilityEnum.ModuleNotification, TX.False, 0);

		// Token: 0x04000186 RID: 390
		internal static ushort CargoNotificationProtoBuf = DeviceCommands.MakeCommand(FacilityEnum.ModuleNotification, TX.False, 5);

		// Token: 0x04000187 RID: 391
		internal static ushort CargoDynamicAppRegisterApp = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 0);

		// Token: 0x04000188 RID: 392
		internal static ushort CargoDynamicAppRemoveApp = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 1);

		// Token: 0x04000189 RID: 393
		internal static ushort CargoDynamicAppRegisterAppIcons = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 2);

		// Token: 0x0400018A RID: 394
		internal static ushort CargoDynamicAppSetAppTileIndex = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 3);

		// Token: 0x0400018B RID: 395
		internal static ushort CargoDynamicAppSetAppBadgeTileIndex = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 5);

		// Token: 0x0400018C RID: 396
		internal static ushort CargoDynamicAppSetAppNotificationTileIndex = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballAppsManagement, TX.False, 11);

		// Token: 0x0400018D RID: 397
		internal static ushort CargoDynamicPageLayoutSet = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballPageManagement, TX.False, 0);

		// Token: 0x0400018E RID: 398
		internal static ushort CargoDynamicPageLayoutRemove = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballPageManagement, TX.False, 1);

		// Token: 0x0400018F RID: 399
		internal static ushort CargoDynamicPageLayoutGet = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballPageManagement, TX.True, 2);

		// Token: 0x04000190 RID: 400
		internal static ushort CargoInstalledAppListGet = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 0);

		// Token: 0x04000191 RID: 401
		internal static ushort CargoInstalledAppListSet = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 1);

		// Token: 0x04000192 RID: 402
		internal static ushort CargoInstalledAppListStartStripSyncStart = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 2);

		// Token: 0x04000193 RID: 403
		internal static ushort CargoInstalledAppListStartStripSyncEnd = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 3);

		// Token: 0x04000194 RID: 404
		internal static ushort CargoInstalledAppListGetDefaults = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 4);

		// Token: 0x04000195 RID: 405
		internal static ushort CargoInstalledAppListSetTile = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 6);

		// Token: 0x04000196 RID: 406
		internal static ushort CargoInstalledAppListGetTile = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 7);

		// Token: 0x04000197 RID: 407
		internal static ushort CargoInstalledAppListGetSettingsMask = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 13);

		// Token: 0x04000198 RID: 408
		internal static ushort CargoInstalledAppListSetSettingsMask = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 14);

		// Token: 0x04000199 RID: 409
		internal static ushort CargoInstalledAppListEnableSetting = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 15);

		// Token: 0x0400019A RID: 410
		internal static ushort CargoInstalledAppListDisableSetting = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.False, 16);

		// Token: 0x0400019B RID: 411
		internal static ushort CargoInstalledAppListGetNoImages = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 18);

		// Token: 0x0400019C RID: 412
		internal static ushort CargoInstalledAppListGetDefaultsNoImages = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 19);

		// Token: 0x0400019D RID: 413
		internal static ushort CargoInstalledAppListGetMaxTileCount = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 21);

		// Token: 0x0400019E RID: 414
		internal static ushort CargoInstalledAppListGetMaxTileAllocatedCount = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstalledAppList, TX.True, 22);

		// Token: 0x0400019F RID: 415
		internal static ushort CargoSystemSettingsOobeCompleteClear = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 0);

		// Token: 0x040001A0 RID: 416
		internal static ushort CargoSystemSettingsOobeCompleteSet = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 1);

		// Token: 0x040001A1 RID: 417
		internal static ushort CargoSystemSettingsFactoryReset = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.True, 7);

		// Token: 0x040001A2 RID: 418
		internal static ushort CargoSystemSettingsGetTimeZone = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.True, 10);

		// Token: 0x040001A3 RID: 419
		internal static ushort CargoSystemSettingsSetTimeZone = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 11);

		// Token: 0x040001A4 RID: 420
		internal static ushort CargoSystemSettingsSetEphemerisFile = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 15);

		// Token: 0x040001A5 RID: 421
		internal static ushort CargoSystemSettingsGetMeTileImageID = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.True, 18);

		// Token: 0x040001A6 RID: 422
		internal static ushort CargoSystemSettingsOobeCompleteGet = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.True, 19);

		// Token: 0x040001A7 RID: 423
		internal static ushort CargoSystemSettingsEnableDemoMode = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 25);

		// Token: 0x040001A8 RID: 424
		internal static ushort CargoSystemSettingsDisableDemoMode = DeviceCommands.MakeCommand(FacilityEnum.ModuleSystemSettings, TX.False, 26);

		// Token: 0x040001A9 RID: 425
		internal static ushort CargoSRAMFWUpdateLoadData = DeviceCommands.MakeCommand(FacilityEnum.LibrarySRAMFWUpdate, TX.False, 0);

		// Token: 0x040001AA RID: 426
		internal static ushort CargoSRAMFWUpdateBootIntoUpdateMode = DeviceCommands.MakeCommand(FacilityEnum.LibrarySRAMFWUpdate, TX.False, 1);

		// Token: 0x040001AB RID: 427
		internal static ushort CargoSRAMFWUpdateValidateAssets = DeviceCommands.MakeCommand(FacilityEnum.LibrarySRAMFWUpdate, TX.True, 2);

		// Token: 0x040001AC RID: 428
		internal static ushort CargoEFlashRead = DeviceCommands.MakeCommand(FacilityEnum.DriverEFlash, TX.True, 1);

		// Token: 0x040001AD RID: 429
		internal static ushort CargoGpsIsEnabled = DeviceCommands.MakeCommand(FacilityEnum.LibraryGps, TX.True, 6);

		// Token: 0x040001AE RID: 430
		internal static ushort CargoGpsEphemerisCoverageDates = DeviceCommands.MakeCommand(FacilityEnum.LibraryGps, TX.True, 13);

		// Token: 0x040001AF RID: 431
		internal static ushort CargoFireballUINavigateToScreen = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballUI, TX.False, 0);

		// Token: 0x040001B0 RID: 432
		internal static ushort CargoFireballUIClearMeTileImage = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballUI, TX.False, 6);

		// Token: 0x040001B1 RID: 433
		internal static ushort CargoFireballUISetSmsResponse = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballUI, TX.False, 7);

		// Token: 0x040001B2 RID: 434
		internal static ushort CargoFireballUIGetAllSmsResponse = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballUI, TX.True, 11);

		// Token: 0x040001B3 RID: 435
		internal static ushort CargoFireballUIReadMeTileImage = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballUI, TX.True, 14);

		// Token: 0x040001B4 RID: 436
		internal static ushort CargoFireballUIWriteMeTileImageWithID = DeviceCommands.MakeCommand(FacilityEnum.ModuleFireballUI, TX.False, 17);

		// Token: 0x040001B5 RID: 437
		internal static ushort CargoThemeColorSetFirstPartyTheme = DeviceCommands.MakeCommand(FacilityEnum.ModuleThemeColor, TX.False, 0);

		// Token: 0x040001B6 RID: 438
		internal static ushort CargoThemeColorGetFirstPartyTheme = DeviceCommands.MakeCommand(FacilityEnum.ModuleThemeColor, TX.True, 1);

		// Token: 0x040001B7 RID: 439
		internal static ushort CargoThemeColorSetCustomTheme = DeviceCommands.MakeCommand(FacilityEnum.ModuleThemeColor, TX.False, 2);

		// Token: 0x040001B8 RID: 440
		internal static ushort CargoThemeColorReset = DeviceCommands.MakeCommand(FacilityEnum.ModuleThemeColor, TX.False, 4);

		// Token: 0x040001B9 RID: 441
		internal static ushort CargoHapticPlayVibrationStream = DeviceCommands.MakeCommand(FacilityEnum.LibraryHaptic, TX.False, 0);

		// Token: 0x040001BA RID: 442
		internal static ushort CargoGoalTrackerSet = DeviceCommands.MakeCommand(FacilityEnum.ModuleGoalTracker, TX.False, 0);

		// Token: 0x040001BB RID: 443
		internal static ushort CargoFitnessPlansWriteFile = DeviceCommands.MakeCommand(FacilityEnum.LibraryFitnessPlans, TX.False, 4);

		// Token: 0x040001BC RID: 444
		internal static ushort CargoGolfCourseFileWrite = DeviceCommands.MakeCommand(FacilityEnum.LibraryGolf, TX.False, 0);

		// Token: 0x040001BD RID: 445
		internal static ushort CargoGolfCourseFileGetMaxSize = DeviceCommands.MakeCommand(FacilityEnum.LibraryGolf, TX.True, 1);

		// Token: 0x040001BE RID: 446
		internal static ushort CargoOobeSetStage = DeviceCommands.MakeCommand(FacilityEnum.ModuleOobe, TX.False, 0);

		// Token: 0x040001BF RID: 447
		internal static ushort CargoOobeGetStage = DeviceCommands.MakeCommand(FacilityEnum.ModuleOobe, TX.True, 1);

		// Token: 0x040001C0 RID: 448
		internal static ushort CargoOobeFinalize = DeviceCommands.MakeCommand(FacilityEnum.ModuleOobe, TX.False, 2);

		// Token: 0x040001C1 RID: 449
		internal static ushort CargoCortanaNotification = DeviceCommands.MakeCommand(FacilityEnum.ModuleCortana, TX.False, 0);

		// Token: 0x040001C2 RID: 450
		internal static ushort CargoCortanaStart = DeviceCommands.MakeCommand(FacilityEnum.ModuleCortana, TX.False, 1);

		// Token: 0x040001C3 RID: 451
		internal static ushort CargoCortanaStop = DeviceCommands.MakeCommand(FacilityEnum.ModuleCortana, TX.False, 2);

		// Token: 0x040001C4 RID: 452
		internal static ushort CargoCortanaCancel = DeviceCommands.MakeCommand(FacilityEnum.ModuleCortana, TX.False, 3);

		// Token: 0x040001C5 RID: 453
		internal static ushort CargoPersistedAppDataSetRunMetrics = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 0);

		// Token: 0x040001C6 RID: 454
		internal static ushort CargoPersistedAppDataGetRunMetrics = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 1);

		// Token: 0x040001C7 RID: 455
		internal static ushort CargoPersistedAppDataSetBikeMetrics = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 2);

		// Token: 0x040001C8 RID: 456
		internal static ushort CargoPersistedAppDataGetBikeMetrics = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 3);

		// Token: 0x040001C9 RID: 457
		internal static ushort CargoPersistedAppDataSetBikeSplitMult = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 4);

		// Token: 0x040001CA RID: 458
		internal static ushort CargoPersistedAppDataGetBikeSplitMult = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 5);

		// Token: 0x040001CB RID: 459
		internal static ushort CargoPersistedAppDataSetWorkoutActivities = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 9);

		// Token: 0x040001CC RID: 460
		internal static ushort CargoPersistedAppDataGetWorkoutActivities = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 16);

		// Token: 0x040001CD RID: 461
		internal static ushort CargoPersistedAppDataSetSleepNotification = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 17);

		// Token: 0x040001CE RID: 462
		internal static ushort CargoPersistedAppDataGetSleepNotification = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 18);

		// Token: 0x040001CF RID: 463
		internal static ushort CargoPersistedAppDataDisableSleepNotification = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 19);

		// Token: 0x040001D0 RID: 464
		internal static ushort CargoPersistedAppDataSetLightExposureNotification = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 21);

		// Token: 0x040001D1 RID: 465
		internal static ushort CargoPersistedAppDataGetLightExposureNotification = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.True, 22);

		// Token: 0x040001D2 RID: 466
		internal static ushort CargoPersistedAppDataDisableLightExposureNotification = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedApplicationData, TX.False, 23);

		// Token: 0x040001D3 RID: 467
		internal static ushort CargoGetProductSerialNumber = DeviceCommands.MakeCommand(FacilityEnum.LibraryConfiguration, TX.True, 8);

		// Token: 0x040001D4 RID: 468
		internal static ushort CargoKeyboardCmd = DeviceCommands.MakeCommand(FacilityEnum.LibraryKeyboard, TX.False, 0);

		// Token: 0x040001D5 RID: 469
		internal static ushort CargoSubscriptionLoggerSubscribe = DeviceCommands.MakeCommand(FacilityEnum.ModuleLoggerSubscriptions, TX.False, 0);

		// Token: 0x040001D6 RID: 470
		internal static ushort CargoSubscriptionLoggerUnsubscribe = DeviceCommands.MakeCommand(FacilityEnum.ModuleLoggerSubscriptions, TX.False, 1);

		// Token: 0x040001D7 RID: 471
		internal static ushort CargoCrashDumpGetFileSize = DeviceCommands.MakeCommand(FacilityEnum.DriverCrashDump, TX.True, 1);

		// Token: 0x040001D8 RID: 472
		internal static ushort CargoCrashDumpGetAndDeleteFile = DeviceCommands.MakeCommand(FacilityEnum.DriverCrashDump, TX.True, 2);

		// Token: 0x040001D9 RID: 473
		internal static ushort CargoInstrumentationGetFileSize = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstrumentation, TX.True, 4);

		// Token: 0x040001DA RID: 474
		internal static ushort CargoInstrumentationGetFile = DeviceCommands.MakeCommand(FacilityEnum.ModuleInstrumentation, TX.True, 5);

		// Token: 0x040001DB RID: 475
		internal static ushort CargoPersistedStatisticsRunGet = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedStatistics, TX.True, 2);

		// Token: 0x040001DC RID: 476
		internal static ushort CargoPersistedStatisticsWorkoutGet = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedStatistics, TX.True, 3);

		// Token: 0x040001DD RID: 477
		internal static ushort CargoPersistedStatisticsSleepGet = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedStatistics, TX.True, 4);

		// Token: 0x040001DE RID: 478
		internal static ushort CargoPersistedStatisticsGuidedWorkoutGet = DeviceCommands.MakeCommand(FacilityEnum.ModulePersistedStatistics, TX.True, 5);
	}
}
