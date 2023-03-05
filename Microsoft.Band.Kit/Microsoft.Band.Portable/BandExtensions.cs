// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.BandExtensions
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

namespace Microsoft.Band.Portable
{
  internal static class BandExtensions
  {
    internal static Microsoft.Band.UserConsent ToNative(this UserConsent consent)
    {
      if (consent == UserConsent.Granted)
        return Microsoft.Band.UserConsent.Granted;
      return consent == UserConsent.Declined ? Microsoft.Band.UserConsent.Declined : Microsoft.Band.UserConsent.NotSpecified;
    }

    internal static UserConsent FromNative(this Microsoft.Band.UserConsent consent)
    {
      if (consent == Microsoft.Band.UserConsent.Granted)
        return UserConsent.Granted;
      return consent == Microsoft.Band.UserConsent.Declined ? UserConsent.Declined : UserConsent.Unspecified;
    }
  }
}
