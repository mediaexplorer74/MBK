using System;

namespace MobileBandSync.MSFTBandLib.Facility
{
	// Token: 0x0200006D RID: 109
	public enum FacilityEnum
	{
		// Token: 0x0400022B RID: 555
		Invalid,
		// Token: 0x0400022C RID: 556
		ReservedBase,
		// Token: 0x0400022D RID: 557
		ReservedEnd = 31,
		// Token: 0x0400022E RID: 558
		DriverDma,
		// Token: 0x0400022F RID: 559
		DriverBtle,
		// Token: 0x04000230 RID: 560
		DriverPdb,
		// Token: 0x04000231 RID: 561
		DriverI2c,
		// Token: 0x04000232 RID: 562
		DriverAdc,
		// Token: 0x04000233 RID: 563
		DriverGpio,
		// Token: 0x04000234 RID: 564
		DriverDac,
		// Token: 0x04000235 RID: 565
		DriverAnalogMgr,
		// Token: 0x04000236 RID: 566
		DriverRtc,
		// Token: 0x04000237 RID: 567
		DriverMotor,
		// Token: 0x04000238 RID: 568
		DriverDisplay = 43,
		// Token: 0x04000239 RID: 569
		DriverUartAsync,
		// Token: 0x0400023A RID: 570
		DriverPmu,
		// Token: 0x0400023B RID: 571
		DriverExternalRam,
		// Token: 0x0400023C RID: 572
		DriverAls,
		// Token: 0x0400023D RID: 573
		DriverTimers,
		// Token: 0x0400023E RID: 574
		DriverFlexBus,
		// Token: 0x0400023F RID: 575
		DriverSpi,
		// Token: 0x04000240 RID: 576
		DriverEFlash,
		// Token: 0x04000241 RID: 577
		DriverPwm,
		// Token: 0x04000242 RID: 578
		DriverCrc,
		// Token: 0x04000243 RID: 579
		DriverPFlash,
		// Token: 0x04000244 RID: 580
		DriverFpu,
		// Token: 0x04000245 RID: 581
		DriverCoreModule,
		// Token: 0x04000246 RID: 582
		DriverCrashDump,
		// Token: 0x04000247 RID: 583
		DriverUsb,
		// Token: 0x04000248 RID: 584
		DriverMmcau,
		// Token: 0x04000249 RID: 585
		DriversEnd = 111,
		// Token: 0x0400024A RID: 586
		LibraryDebug,
		// Token: 0x0400024B RID: 587
		LibraryRuntime,
		// Token: 0x0400024C RID: 588
		LibraryUsbCmdProtocol,
		// Token: 0x0400024D RID: 589
		LibraryBTPS,
		// Token: 0x0400024E RID: 590
		LibraryTouch,
		// Token: 0x0400024F RID: 591
		LibraryTime,
		// Token: 0x04000250 RID: 592
		LibraryJutil,
		// Token: 0x04000251 RID: 593
		LibraryHRManager,
		// Token: 0x04000252 RID: 594
		LibraryConfiguration,
		// Token: 0x04000253 RID: 595
		LibraryButton,
		// Token: 0x04000254 RID: 596
		LibraryBacklight,
		// Token: 0x04000255 RID: 597
		LibraryMotion,
		// Token: 0x04000256 RID: 598
		LibraryActMon,
		// Token: 0x04000257 RID: 599
		LibraryBattery,
		// Token: 0x04000258 RID: 600
		LibraryGps,
		// Token: 0x04000259 RID: 601
		LibraryHRLed,
		// Token: 0x0400025A RID: 602
		LibraryDfu,
		// Token: 0x0400025B RID: 603
		LibraryHeartRate,
		// Token: 0x0400025C RID: 604
		LibraryMicrophone = 131,
		// Token: 0x0400025D RID: 605
		LibraryGsr,
		// Token: 0x0400025E RID: 606
		LibraryUV,
		// Token: 0x0400025F RID: 607
		LibrarySkinTemp,
		// Token: 0x04000260 RID: 608
		LibraryAmbTemp,
		// Token: 0x04000261 RID: 609
		LibraryPedometer,
		// Token: 0x04000262 RID: 610
		LibraryCalories,
		// Token: 0x04000263 RID: 611
		LibraryDistance,
		// Token: 0x04000264 RID: 612
		LibraryAlgoMath,
		// Token: 0x04000265 RID: 613
		LibraryLogger,
		// Token: 0x04000266 RID: 614
		LibraryPeg,
		// Token: 0x04000267 RID: 615
		LibraryFile,
		// Token: 0x04000268 RID: 616
		LibraryRemoteSubscription,
		// Token: 0x04000269 RID: 617
		LibraryPower,
		// Token: 0x0400026A RID: 618
		LibraryUVExposure,
		// Token: 0x0400026B RID: 619
		LibraryMinuteTimer,
		// Token: 0x0400026C RID: 620
		LibraryRecovery,
		// Token: 0x0400026D RID: 621
		LibrarySubscriptionBase,
		// Token: 0x0400026E RID: 622
		LibraryDateChangeSubscription,
		// Token: 0x0400026F RID: 623
		LibraryHREstimator,
		// Token: 0x04000270 RID: 624
		LibraryUSBConnection,
		// Token: 0x04000271 RID: 625
		LibrarySRAMFWUpdate,
		// Token: 0x04000272 RID: 626
		LibraryAutoBrightness,
		// Token: 0x04000273 RID: 627
		LibraryHaptic,
		// Token: 0x04000274 RID: 628
		LibraryFitnessPlans,
		// Token: 0x04000275 RID: 629
		LibrarySleepRecovery,
		// Token: 0x04000276 RID: 630
		LibraryFirstBeat,
		// Token: 0x04000277 RID: 631
		LibraryAncsNotificationCache,
		// Token: 0x04000278 RID: 632
		LibraryKeyboard,
		// Token: 0x04000279 RID: 633
		LibraryHrAccelSync,
		// Token: 0x0400027A RID: 634
		LibraryGolf,
		// Token: 0x0400027B RID: 635
		ModuleOobe = 173,
		// Token: 0x0400027C RID: 636
		LibrariesEnd = 191,
		// Token: 0x0400027D RID: 637
		ModuleMain,
		// Token: 0x0400027E RID: 638
		ModuleBehavior,
		// Token: 0x0400027F RID: 639
		ModuleFireballTransportLayer,
		// Token: 0x04000280 RID: 640
		ModuleFireballUI,
		// Token: 0x04000281 RID: 641
		ModuleFireballUtilities,
		// Token: 0x04000282 RID: 642
		ModuleProfile,
		// Token: 0x04000283 RID: 643
		ModuleLoggerSubscriptions,
		// Token: 0x04000284 RID: 644
		ModuleFireballTilesModels,
		// Token: 0x04000285 RID: 645
		ModulePowerManager,
		// Token: 0x04000286 RID: 646
		ModuleHrPowerManager,
		// Token: 0x04000287 RID: 647
		ModuleSystemSettings,
		// Token: 0x04000288 RID: 648
		ModuleFireballHardwareManager,
		// Token: 0x04000289 RID: 649
		ModuleNotification,
		// Token: 0x0400028A RID: 650
		ModuleFtlTouchManager,
		// Token: 0x0400028B RID: 651
		ModulePersistedStatistics,
		// Token: 0x0400028C RID: 652
		ModuleAlgorithms,
		// Token: 0x0400028D RID: 653
		ModulePersistedApplicationData,
		// Token: 0x0400028E RID: 654
		ModuleDeviceContact,
		// Token: 0x0400028F RID: 655
		ModuleInstrumentation,
		// Token: 0x04000290 RID: 656
		ModuleFireballAppsManagement,
		// Token: 0x04000291 RID: 657
		ModuleInstalledAppList,
		// Token: 0x04000292 RID: 658
		ModuleFireballPageManagement,
		// Token: 0x04000293 RID: 659
		ModuleUnitTests,
		// Token: 0x04000294 RID: 660
		ModuleBatteryGauge,
		// Token: 0x04000295 RID: 661
		ModuleThemeColor,
		// Token: 0x04000296 RID: 662
		ModuleGoalTracker,
		// Token: 0x04000297 RID: 663
		ModuleKfrost,
		// Token: 0x04000298 RID: 664
		ModulePal,
		// Token: 0x04000299 RID: 665
		ModuleGestures,
		// Token: 0x0400029A RID: 666
		ModuleCortana,
		// Token: 0x0400029B RID: 667
		ModuleVoicePush,
		// Token: 0x0400029C RID: 668
		ModulesEnd,
		// Token: 0x0400029D RID: 669
		ApplicationMain,
		// Token: 0x0400029E RID: 670
		Application1BL,
		// Token: 0x0400029F RID: 671
		Application2UP,
		// Token: 0x040002A0 RID: 672
		ApplicationsEnd = 239,
		// Token: 0x040002A1 RID: 673
		Reserved2Base,
		// Token: 0x040002A2 RID: 674
		Reserved2End = 255
	}
}
