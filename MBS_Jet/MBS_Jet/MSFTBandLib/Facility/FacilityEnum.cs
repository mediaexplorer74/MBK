﻿// Decompiled with JetBrains decompiler
// Type: MobileBandSync.MSFTBandLib.Facility.FacilityEnum
// Assembly: MobileBandSync, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AE79C20-CD20-4792-8F76-8817DEB4DE21
// Assembly location: C:\Users\Admin\Desktop\re\mobile\MobileBandSync.exe

namespace MobileBandSync.MSFTBandLib.Facility
{
  public enum FacilityEnum
  {
    Invalid = 0,
    ReservedBase = 1,
    ReservedEnd = 31, // 0x0000001F
    DriverDma = 32, // 0x00000020
    DriverBtle = 33, // 0x00000021
    DriverPdb = 34, // 0x00000022
    DriverI2c = 35, // 0x00000023
    DriverAdc = 36, // 0x00000024
    DriverGpio = 37, // 0x00000025
    DriverDac = 38, // 0x00000026
    DriverAnalogMgr = 39, // 0x00000027
    DriverRtc = 40, // 0x00000028
    DriverMotor = 41, // 0x00000029
    DriverDisplay = 43, // 0x0000002B
    DriverUartAsync = 44, // 0x0000002C
    DriverPmu = 45, // 0x0000002D
    DriverExternalRam = 46, // 0x0000002E
    DriverAls = 47, // 0x0000002F
    DriverTimers = 48, // 0x00000030
    DriverFlexBus = 49, // 0x00000031
    DriverSpi = 50, // 0x00000032
    DriverEFlash = 51, // 0x00000033
    DriverPwm = 52, // 0x00000034
    DriverCrc = 53, // 0x00000035
    DriverPFlash = 54, // 0x00000036
    DriverFpu = 55, // 0x00000037
    DriverCoreModule = 56, // 0x00000038
    DriverCrashDump = 57, // 0x00000039
    DriverUsb = 58, // 0x0000003A
    DriverMmcau = 59, // 0x0000003B
    DriversEnd = 111, // 0x0000006F
    LibraryDebug = 112, // 0x00000070
    LibraryRuntime = 113, // 0x00000071
    LibraryUsbCmdProtocol = 114, // 0x00000072
    LibraryBTPS = 115, // 0x00000073
    LibraryTouch = 116, // 0x00000074
    LibraryTime = 117, // 0x00000075
    LibraryJutil = 118, // 0x00000076
    LibraryHRManager = 119, // 0x00000077
    LibraryConfiguration = 120, // 0x00000078
    LibraryButton = 121, // 0x00000079
    LibraryBacklight = 122, // 0x0000007A
    LibraryMotion = 123, // 0x0000007B
    LibraryActMon = 124, // 0x0000007C
    LibraryBattery = 125, // 0x0000007D
    LibraryGps = 126, // 0x0000007E
    LibraryHRLed = 127, // 0x0000007F
    LibraryDfu = 128, // 0x00000080
    LibraryHeartRate = 129, // 0x00000081
    LibraryMicrophone = 131, // 0x00000083
    LibraryGsr = 132, // 0x00000084
    LibraryUV = 133, // 0x00000085
    LibrarySkinTemp = 134, // 0x00000086
    LibraryAmbTemp = 135, // 0x00000087
    LibraryPedometer = 136, // 0x00000088
    LibraryCalories = 137, // 0x00000089
    LibraryDistance = 138, // 0x0000008A
    LibraryAlgoMath = 139, // 0x0000008B
    LibraryLogger = 140, // 0x0000008C
    LibraryPeg = 141, // 0x0000008D
    LibraryFile = 142, // 0x0000008E
    LibraryRemoteSubscription = 143, // 0x0000008F
    LibraryPower = 144, // 0x00000090
    LibraryUVExposure = 145, // 0x00000091
    LibraryMinuteTimer = 146, // 0x00000092
    LibraryRecovery = 147, // 0x00000093
    LibrarySubscriptionBase = 148, // 0x00000094
    LibraryDateChangeSubscription = 149, // 0x00000095
    LibraryHREstimator = 150, // 0x00000096
    LibraryUSBConnection = 151, // 0x00000097
    LibrarySRAMFWUpdate = 152, // 0x00000098
    LibraryAutoBrightness = 153, // 0x00000099
    LibraryHaptic = 154, // 0x0000009A
    LibraryFitnessPlans = 155, // 0x0000009B
    LibrarySleepRecovery = 156, // 0x0000009C
    LibraryFirstBeat = 157, // 0x0000009D
    LibraryAncsNotificationCache = 158, // 0x0000009E
    LibraryKeyboard = 159, // 0x0000009F
    LibraryHrAccelSync = 160, // 0x000000A0
    LibraryGolf = 161, // 0x000000A1
    ModuleOobe = 173, // 0x000000AD
    LibrariesEnd = 191, // 0x000000BF
    ModuleMain = 192, // 0x000000C0
    ModuleBehavior = 193, // 0x000000C1
    ModuleFireballTransportLayer = 194, // 0x000000C2
    ModuleFireballUI = 195, // 0x000000C3
    ModuleFireballUtilities = 196, // 0x000000C4
    ModuleProfile = 197, // 0x000000C5
    ModuleLoggerSubscriptions = 198, // 0x000000C6
    ModuleFireballTilesModels = 199, // 0x000000C7
    ModulePowerManager = 200, // 0x000000C8
    ModuleHrPowerManager = 201, // 0x000000C9
    ModuleSystemSettings = 202, // 0x000000CA
    ModuleFireballHardwareManager = 203, // 0x000000CB
    ModuleNotification = 204, // 0x000000CC
    ModuleFtlTouchManager = 205, // 0x000000CD
    ModulePersistedStatistics = 206, // 0x000000CE
    ModuleAlgorithms = 207, // 0x000000CF
    ModulePersistedApplicationData = 208, // 0x000000D0
    ModuleDeviceContact = 209, // 0x000000D1
    ModuleInstrumentation = 210, // 0x000000D2
    ModuleFireballAppsManagement = 211, // 0x000000D3
    ModuleInstalledAppList = 212, // 0x000000D4
    ModuleFireballPageManagement = 213, // 0x000000D5
    ModuleUnitTests = 214, // 0x000000D6
    ModuleBatteryGauge = 215, // 0x000000D7
    ModuleThemeColor = 216, // 0x000000D8
    ModuleGoalTracker = 217, // 0x000000D9
    ModuleKfrost = 218, // 0x000000DA
    ModulePal = 219, // 0x000000DB
    ModuleGestures = 220, // 0x000000DC
    ModuleCortana = 221, // 0x000000DD
    ModuleVoicePush = 222, // 0x000000DE
    ModulesEnd = 223, // 0x000000DF
    ApplicationMain = 224, // 0x000000E0
    Application1BL = 225, // 0x000000E1
    Application2UP = 226, // 0x000000E2
    ApplicationsEnd = 239, // 0x000000EF
    Reserved2Base = 240, // 0x000000F0
    Reserved2End = 255, // 0x000000FF
  }
}