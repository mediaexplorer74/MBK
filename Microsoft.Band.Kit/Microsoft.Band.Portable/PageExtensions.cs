// Decompiled with JetBrains decompiler
// Type: Microsoft.Band.Portable.PageExtensions
// Assembly: Microsoft.Band.Portable, Version=1.3.10.0, Culture=neutral, PublicKeyToken=null
// MVID: A51E1408-DB61-4D77-A9F3-731453DAB8E2
// Assembly location: C:\Users\Admin\Desktop\!\Microsoft.Band.Portable.dll

using Microsoft.Band.Portable.Tiles.Pages;
using Microsoft.Band.Portable.Tiles.Pages.Data;
using Microsoft.Band.Tiles.Pages;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace Microsoft.Band.Portable
{
  internal static class PageExtensions
  {
    private static readonly ConcurrentDictionary<Type, ConstructorInfo> elementConstructors = new ConcurrentDictionary<Type, ConstructorInfo>();
    private static readonly ConcurrentDictionary<Type, ConstructorInfo> dataConstructors = new ConcurrentDictionary<Type, ConstructorInfo>();
    private static readonly TypeInfo[] elementTypes;
    private static readonly TypeInfo[] elementDataTypes;

    static PageExtensions()
    {
      Assembly assembly = typeof (PageExtensions).GetTypeInfo().Assembly;
      TypeInfo elementType = typeof (Element).GetTypeInfo();
      PageExtensions.elementTypes = assembly.DefinedTypes.Where<TypeInfo>((Func<TypeInfo, bool>) (t => !t.IsAbstract && elementType.IsAssignableFrom(t))).ToArray<TypeInfo>();
      TypeInfo elementDataType = typeof (ElementData).GetTypeInfo();
      PageExtensions.elementDataTypes = assembly.DefinedTypes.Where<TypeInfo>((Func<TypeInfo, bool>) (t => !t.IsAbstract && elementDataType.IsAssignableFrom(t))).ToArray<TypeInfo>();
    }

    internal static Microsoft.Band.Tiles.Pages.BarcodeType ToNative(
      this Microsoft.Band.Portable.Tiles.Pages.BarcodeType barcodeType)
    {
      if (barcodeType == Microsoft.Band.Portable.Tiles.Pages.BarcodeType.Code39)
        return Microsoft.Band.Tiles.Pages.BarcodeType.Code39;
      if (barcodeType == Microsoft.Band.Portable.Tiles.Pages.BarcodeType.Pdf417)
        return Microsoft.Band.Tiles.Pages.BarcodeType.Pdf417;
      throw new ArgumentOutOfRangeException(nameof (barcodeType), "Invalid BarcodeType specified.");
    }

    internal static Microsoft.Band.Portable.Tiles.Pages.BarcodeType FromNative(
      this Microsoft.Band.Tiles.Pages.BarcodeType barcodeType)
    {
      if (barcodeType == Microsoft.Band.Tiles.Pages.BarcodeType.Code39)
        return Microsoft.Band.Portable.Tiles.Pages.BarcodeType.Code39;
      if (barcodeType == Microsoft.Band.Tiles.Pages.BarcodeType.Pdf417)
        return Microsoft.Band.Portable.Tiles.Pages.BarcodeType.Pdf417;
      throw new ArgumentOutOfRangeException(nameof (barcodeType), "Invalid BarcodeType specified.");
    }

    internal static Microsoft.Band.Tiles.Pages.FlowPanelOrientation ToNative(
      this Microsoft.Band.Portable.Tiles.Pages.FlowPanelOrientation orientation)
    {
      if (orientation == Microsoft.Band.Portable.Tiles.Pages.FlowPanelOrientation.Horizontal)
        return Microsoft.Band.Tiles.Pages.FlowPanelOrientation.Horizontal;
      if (orientation == Microsoft.Band.Portable.Tiles.Pages.FlowPanelOrientation.Vertical)
        return Microsoft.Band.Tiles.Pages.FlowPanelOrientation.Vertical;
      throw new ArgumentOutOfRangeException(nameof (orientation), "Invalid Orientation specified.");
    }

    internal static Microsoft.Band.Portable.Tiles.Pages.FlowPanelOrientation FromNative(
      this Microsoft.Band.Tiles.Pages.FlowPanelOrientation orientation)
    {
      if (orientation == Microsoft.Band.Tiles.Pages.FlowPanelOrientation.Horizontal)
        return Microsoft.Band.Portable.Tiles.Pages.FlowPanelOrientation.Horizontal;
      if (orientation == Microsoft.Band.Tiles.Pages.FlowPanelOrientation.Vertical)
        return Microsoft.Band.Portable.Tiles.Pages.FlowPanelOrientation.Vertical;
      throw new ArgumentOutOfRangeException(nameof (orientation), "Invalid FlowPanelOrientation specified.");
    }

    internal static Microsoft.Band.Tiles.Pages.ElementColorSource ToNative(
      this Microsoft.Band.Portable.Tiles.Pages.ElementColorSource elementColorSource)
    {
      switch (elementColorSource)
      {
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.Custom:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.Custom;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandBase:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.BandBase;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandHighlight:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.BandHighlight;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandLowlight:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.BandLowlight;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandSecondaryText:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.BandSecondaryText;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandHighContrast:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.BandHighContrast;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandMuted:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.BandMuted;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileBase:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.TileBase;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileHighlight:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.TileHighlight;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileLowlight:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.TileLowlight;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileSecondaryText:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.TileSecondaryText;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileHighContrast:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.TileHighContrast;
        case Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileMuted:
          return Microsoft.Band.Tiles.Pages.ElementColorSource.TileMuted;
        default:
          throw new ArgumentOutOfRangeException(nameof (elementColorSource), "Invalid ElementColorSource specified.");
      }
    }

    internal static Microsoft.Band.Portable.Tiles.Pages.ElementColorSource FromNative(
      this Microsoft.Band.Tiles.Pages.ElementColorSource elementColorSource)
    {
      switch (elementColorSource)
      {
        case Microsoft.Band.Tiles.Pages.ElementColorSource.Custom:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.Custom;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.BandBase:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandBase;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.BandHighlight:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandHighlight;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.BandLowlight:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandLowlight;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.BandSecondaryText:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandSecondaryText;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.BandHighContrast:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandHighContrast;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.BandMuted:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.BandMuted;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.TileBase:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileBase;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.TileHighlight:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileHighlight;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.TileLowlight:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileLowlight;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.TileSecondaryText:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileSecondaryText;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.TileHighContrast:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileHighContrast;
        case Microsoft.Band.Tiles.Pages.ElementColorSource.TileMuted:
          return Microsoft.Band.Portable.Tiles.Pages.ElementColorSource.TileMuted;
        default:
          throw new ArgumentOutOfRangeException(nameof (elementColorSource), "Invalid ElementColorSource specified.");
      }
    }

    internal static Microsoft.Band.Tiles.Pages.PageRect ToNative(this Microsoft.Band.Portable.Tiles.Pages.PageRect rectangle) => new Microsoft.Band.Tiles.Pages.PageRect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

    internal static Microsoft.Band.Portable.Tiles.Pages.PageRect FromNative(
      this Microsoft.Band.Tiles.Pages.PageRect rectangle)
    {
      return new Microsoft.Band.Portable.Tiles.Pages.PageRect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
    }

    internal static Microsoft.Band.Tiles.Pages.Margins ToNative(this Microsoft.Band.Portable.Tiles.Pages.Margins margins) => new Microsoft.Band.Tiles.Pages.Margins(margins.Left, margins.Top, margins.Right, margins.Bottom);

    internal static Microsoft.Band.Portable.Tiles.Pages.Margins FromNative(
      this Microsoft.Band.Tiles.Pages.Margins margins)
    {
      return new Microsoft.Band.Portable.Tiles.Pages.Margins(margins.Left, margins.Top, margins.Right, margins.Bottom);
    }

    internal static Microsoft.Band.Tiles.Pages.TextBlockBaselineAlignment ToNative(
      this Microsoft.Band.Portable.Tiles.Pages.TextBlockBaselineAlignment baselineAlignment)
    {
      if (baselineAlignment == Microsoft.Band.Portable.Tiles.Pages.TextBlockBaselineAlignment.Absolute)
        return Microsoft.Band.Tiles.Pages.TextBlockBaselineAlignment.Absolute;
      return baselineAlignment == Microsoft.Band.Portable.Tiles.Pages.TextBlockBaselineAlignment.Relative ? Microsoft.Band.Tiles.Pages.TextBlockBaselineAlignment.Relative : Microsoft.Band.Tiles.Pages.TextBlockBaselineAlignment.Automatic;
    }

    internal static Microsoft.Band.Portable.Tiles.Pages.TextBlockBaselineAlignment FromNative(
      this Microsoft.Band.Tiles.Pages.TextBlockBaselineAlignment baselineAlignment)
    {
      if (baselineAlignment == Microsoft.Band.Tiles.Pages.TextBlockBaselineAlignment.Absolute)
        return Microsoft.Band.Portable.Tiles.Pages.TextBlockBaselineAlignment.Absolute;
      return baselineAlignment == Microsoft.Band.Tiles.Pages.TextBlockBaselineAlignment.Relative ? Microsoft.Band.Portable.Tiles.Pages.TextBlockBaselineAlignment.Relative : Microsoft.Band.Portable.Tiles.Pages.TextBlockBaselineAlignment.Automatic;
    }

    internal static Microsoft.Band.Tiles.Pages.TextBlockFont ToNative(
      this Microsoft.Band.Portable.Tiles.Pages.TextBlockFont font)
    {
      switch (font)
      {
        case Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.Small:
          return Microsoft.Band.Tiles.Pages.TextBlockFont.Small;
        case Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.Medium:
          return Microsoft.Band.Tiles.Pages.TextBlockFont.Medium;
        case Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.Large:
          return Microsoft.Band.Tiles.Pages.TextBlockFont.Large;
        case Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.ExtraLargeNumbers:
          return Microsoft.Band.Tiles.Pages.TextBlockFont.ExtraLargeNumbers;
        case Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.ExtraLargeNumbersBold:
          return Microsoft.Band.Tiles.Pages.TextBlockFont.ExtraLargeNumbersBold;
        default:
          throw new ArgumentOutOfRangeException(nameof (font), "Invalid TextBlockFont specified.");
      }
    }

    internal static Microsoft.Band.Portable.Tiles.Pages.TextBlockFont FromNative(
      this Microsoft.Band.Tiles.Pages.TextBlockFont font)
    {
      switch (font)
      {
        case Microsoft.Band.Tiles.Pages.TextBlockFont.Small:
          return Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.Small;
        case Microsoft.Band.Tiles.Pages.TextBlockFont.Medium:
          return Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.Medium;
        case Microsoft.Band.Tiles.Pages.TextBlockFont.Large:
          return Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.Large;
        case Microsoft.Band.Tiles.Pages.TextBlockFont.ExtraLargeNumbers:
          return Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.ExtraLargeNumbers;
        case Microsoft.Band.Tiles.Pages.TextBlockFont.ExtraLargeNumbersBold:
          return Microsoft.Band.Portable.Tiles.Pages.TextBlockFont.ExtraLargeNumbersBold;
        default:
          throw new ArgumentOutOfRangeException(nameof (font), "Invalid TextBlockFont specified.");
      }
    }

    internal static Microsoft.Band.Tiles.Pages.WrappedTextBlockFont ToNative(
      this Microsoft.Band.Portable.Tiles.Pages.WrappedTextBlockFont font)
    {
      if (font == Microsoft.Band.Portable.Tiles.Pages.WrappedTextBlockFont.Small)
        return Microsoft.Band.Tiles.Pages.WrappedTextBlockFont.Small;
      if (font == Microsoft.Band.Portable.Tiles.Pages.WrappedTextBlockFont.Medium)
        return Microsoft.Band.Tiles.Pages.WrappedTextBlockFont.Medium;
      throw new ArgumentOutOfRangeException(nameof (font), "Invalid WrappedTextBlockFont specified.");
    }

    internal static Microsoft.Band.Portable.Tiles.Pages.WrappedTextBlockFont FromNative(
      this Microsoft.Band.Tiles.Pages.WrappedTextBlockFont font)
    {
      if (font == Microsoft.Band.Tiles.Pages.WrappedTextBlockFont.Small)
        return Microsoft.Band.Portable.Tiles.Pages.WrappedTextBlockFont.Small;
      if (font == Microsoft.Band.Tiles.Pages.WrappedTextBlockFont.Medium)
        return Microsoft.Band.Portable.Tiles.Pages.WrappedTextBlockFont.Medium;
      throw new ArgumentOutOfRangeException(nameof (font), "Invalid WrappedTextBlockFont specified.");
    }

    internal static Microsoft.Band.Tiles.Pages.HorizontalAlignment ToNative(
      this Microsoft.Band.Portable.Tiles.Pages.HorizontalAlignment horizontalAlignment)
    {
      if (horizontalAlignment == Microsoft.Band.Portable.Tiles.Pages.HorizontalAlignment.Center)
        return Microsoft.Band.Tiles.Pages.HorizontalAlignment.Center;
      if (horizontalAlignment == Microsoft.Band.Portable.Tiles.Pages.HorizontalAlignment.Left)
        return Microsoft.Band.Tiles.Pages.HorizontalAlignment.Left;
      if (horizontalAlignment == Microsoft.Band.Portable.Tiles.Pages.HorizontalAlignment.Right)
        return Microsoft.Band.Tiles.Pages.HorizontalAlignment.Right;
      throw new ArgumentOutOfRangeException(nameof (horizontalAlignment), "Invalid HorizontalAlignment specified.");
    }

    internal static Microsoft.Band.Portable.Tiles.Pages.HorizontalAlignment FromNative(
      this Microsoft.Band.Tiles.Pages.HorizontalAlignment horizontalAlignment)
    {
      if (horizontalAlignment == Microsoft.Band.Tiles.Pages.HorizontalAlignment.Center)
        return Microsoft.Band.Portable.Tiles.Pages.HorizontalAlignment.Center;
      if (horizontalAlignment == Microsoft.Band.Tiles.Pages.HorizontalAlignment.Left)
        return Microsoft.Band.Portable.Tiles.Pages.HorizontalAlignment.Left;
      if (horizontalAlignment == Microsoft.Band.Tiles.Pages.HorizontalAlignment.Right)
        return Microsoft.Band.Portable.Tiles.Pages.HorizontalAlignment.Right;
      throw new ArgumentOutOfRangeException(nameof (horizontalAlignment), "Invalid HorizontalAlignment specified.");
    }

    internal static Microsoft.Band.Tiles.Pages.VerticalAlignment ToNative(
      this Microsoft.Band.Portable.Tiles.Pages.VerticalAlignment verticalAlignment)
    {
      if (verticalAlignment == Microsoft.Band.Portable.Tiles.Pages.VerticalAlignment.Center)
        return Microsoft.Band.Tiles.Pages.VerticalAlignment.Center;
      if (verticalAlignment == Microsoft.Band.Portable.Tiles.Pages.VerticalAlignment.Top)
        return Microsoft.Band.Tiles.Pages.VerticalAlignment.Top;
      if (verticalAlignment == Microsoft.Band.Portable.Tiles.Pages.VerticalAlignment.Bottom)
        return Microsoft.Band.Tiles.Pages.VerticalAlignment.Bottom;
      throw new ArgumentOutOfRangeException(nameof (verticalAlignment), "Invalid VerticalAlignment specified.");
    }

    internal static Microsoft.Band.Portable.Tiles.Pages.VerticalAlignment FromNative(
      this Microsoft.Band.Tiles.Pages.VerticalAlignment verticalAlignment)
    {
      if (verticalAlignment == Microsoft.Band.Tiles.Pages.VerticalAlignment.Center)
        return Microsoft.Band.Portable.Tiles.Pages.VerticalAlignment.Center;
      if (verticalAlignment == Microsoft.Band.Tiles.Pages.VerticalAlignment.Top)
        return Microsoft.Band.Portable.Tiles.Pages.VerticalAlignment.Top;
      if (verticalAlignment == Microsoft.Band.Tiles.Pages.VerticalAlignment.Bottom)
        return Microsoft.Band.Portable.Tiles.Pages.VerticalAlignment.Bottom;
      throw new ArgumentOutOfRangeException(nameof (verticalAlignment), "Invalid VerticalAlignment specified.");
    }

    private static TPortable FromNative<TPortable, TNative>(
      this TNative native,
      ConcurrentDictionary<Type, ConstructorInfo> constructors,
      TypeInfo[] types)
      where TPortable : class
      where TNative : class
    {
      Type type = native.GetType();
      return (TPortable) (constructors.GetOrAdd(type, (Func<Type, ConstructorInfo>) (t => PageExtensions.GetConstructor(types, t))) ?? throw new ArgumentException(string.Format("No matching portable type was found for {0}", (object) type.FullName), nameof (native))).Invoke((object[]) new TNative[1]
      {
        native
      });
    }

    private static ConstructorInfo GetConstructor(
      TypeInfo[] types,
      Type nativeParameterType)
    {
      foreach (TypeInfo type in types)
      {
        foreach (ConstructorInfo declaredConstructor in type.DeclaredConstructors)
        {
          ParameterInfo[] parameters = declaredConstructor.GetParameters();
          if (parameters.Length == 1 && (object) parameters[0].ParameterType == (object) nativeParameterType)
            return declaredConstructor;
        }
      }
      return (ConstructorInfo) null;
    }

    public static ElementData FromNative(this PageElementData native) => native.FromNative<ElementData, PageElementData>(PageExtensions.dataConstructors, PageExtensions.elementDataTypes);

    public static Element FromNative(this PageElement native) => native.FromNative<Element, PageElement>(PageExtensions.elementConstructors, PageExtensions.elementTypes);

    public static Panel FromNative(this PagePanel native) => native.FromNative<Panel, PagePanel>(PageExtensions.elementConstructors, PageExtensions.elementTypes);
  }
}
