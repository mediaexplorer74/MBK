// Decompiled with JetBrains decompiler
// Type: MobileBandSync.MobileBandSync_XamlTypeInfo.XamlTypeInfoProvider
// Assembly: MobileBandSync, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AE79C20-CD20-4792-8F76-8817DEB4DE21
// Assembly location: C:\Users\Admin\Desktop\re\mobile\MobileBandSync.exe

using MobileBandSync.Common;
using MobileBandSync.Data;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace MobileBandSync.MobileBandSync_XamlTypeInfo
{
  [GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class XamlTypeInfoProvider
  {
    private Dictionary<string, IXamlType> _xamlTypeCacheByName = new Dictionary<string, IXamlType>();
    private Dictionary<Type, IXamlType> _xamlTypeCacheByType = new Dictionary<Type, IXamlType>();
    private Dictionary<string, IXamlMember> _xamlMembers = new Dictionary<string, IXamlMember>();
    private string[] _typeNameTable;
    private Type[] _typeTable;
    private List<IXamlMetadataProvider> _otherProviders;

    public IXamlType GetXamlTypeByType(Type type)
    {
      IXamlType xamlTypeByType;
      if (this._xamlTypeCacheByType.TryGetValue(type, out xamlTypeByType))
        return xamlTypeByType;
      int typeIndex = this.LookupTypeIndexByType(type);
      if (typeIndex != -1)
        xamlTypeByType = this.CreateXamlType(typeIndex);
      XamlUserType xamlUserType = xamlTypeByType as XamlUserType;
      if (xamlTypeByType == null || xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType)
      {
        IXamlType ixamlType = this.CheckOtherMetadataProvidersForType(type);
        if (ixamlType != null && (ixamlType.IsConstructible || xamlTypeByType == null))
          xamlTypeByType = ixamlType;
      }
      if (xamlTypeByType != null)
      {
        this._xamlTypeCacheByName.Add(xamlTypeByType.FullName, xamlTypeByType);
        this._xamlTypeCacheByType.Add(xamlTypeByType.UnderlyingType, xamlTypeByType);
      }
      return xamlTypeByType;
    }

    public IXamlType GetXamlTypeByName(string typeName)
    {
      if (string.IsNullOrEmpty(typeName))
        return (IXamlType) null;
      IXamlType xamlTypeByName;
      if (this._xamlTypeCacheByName.TryGetValue(typeName, out xamlTypeByName))
        return xamlTypeByName;
      int typeIndex = this.LookupTypeIndexByName(typeName);
      if (typeIndex != -1)
        xamlTypeByName = this.CreateXamlType(typeIndex);
      XamlUserType xamlUserType = xamlTypeByName as XamlUserType;
      if (xamlTypeByName == null || xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType)
      {
        IXamlType ixamlType = this.CheckOtherMetadataProvidersForName(typeName);
        if (ixamlType != null && (ixamlType.IsConstructible || xamlTypeByName == null))
          xamlTypeByName = ixamlType;
      }
      if (xamlTypeByName != null)
      {
        this._xamlTypeCacheByName.Add(xamlTypeByName.FullName, xamlTypeByName);
        this._xamlTypeCacheByType.Add(xamlTypeByName.UnderlyingType, xamlTypeByName);
      }
      return xamlTypeByName;
    }

    public IXamlMember GetMemberByLongName(string longMemberName)
    {
      if (string.IsNullOrEmpty(longMemberName))
        return (IXamlMember) null;
      IXamlMember memberByLongName;
      if (this._xamlMembers.TryGetValue(longMemberName, out memberByLongName))
        return memberByLongName;
      IXamlMember xamlMember = this.CreateXamlMember(longMemberName);
      if (xamlMember != null)
        this._xamlMembers.Add(longMemberName, xamlMember);
      return xamlMember;
    }

    private void InitTypeTables()
    {
      this._typeNameTable = new string[59];
      this._typeNameTable[0] = "MobileBandSync.HubPage";
      this._typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
      this._typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
      this._typeNameTable[3] = "MobileBandSync.Common.NavigationHelper";
      this._typeNameTable[4] = "Windows.UI.Xaml.DependencyObject";
      this._typeNameTable[5] = "MobileBandSync.Common.ObservableDictionary";
      this._typeNameTable[6] = "Object";
      this._typeNameTable[7] = "String";
      this._typeNameTable[8] = "MobileBandSync.Common.SyncViewModel";
      this._typeNameTable[9] = "Windows.UI.Xaml.DispatcherTimer";
      this._typeNameTable[10] = "Boolean";
      this._typeNameTable[11] = "Windows.UI.Xaml.Controls.Primitives.ToggleButton";
      this._typeNameTable[12] = "MobileBandSync.ItemPage";
      this._typeNameTable[13] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart";
      this._typeNameTable[14] = "Windows.UI.Xaml.Controls.Control";
      this._typeNameTable[15] = "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries>";
      this._typeNameTable[16] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries";
      this._typeNameTable[17] = "System.Collections.ObjectModel.ObservableCollection`1<Object>";
      this._typeNameTable[18] = "System.Collections.ObjectModel.Collection`1<Object>";
      this._typeNameTable[19] = "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>";
      this._typeNameTable[20] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis";
      this._typeNameTable[21] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.AxisOrientation";
      this._typeNameTable[22] = "System.Enum";
      this._typeNameTable[23] = "System.ValueType";
      this._typeNameTable[24] = "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>";
      this._typeNameTable[25] = "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>";
      this._typeNameTable[26] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener";
      this._typeNameTable[27] = "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>";
      this._typeNameTable[28] = "System.Collections.ObjectModel.ReadOnlyCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>";
      this._typeNameTable[29] = "Windows.UI.Xaml.Style";
      this._typeNameTable[30] = "System.Collections.ObjectModel.Collection`1<Windows.UI.Xaml.ResourceDictionary>";
      this._typeNameTable[31] = "Windows.UI.Xaml.ResourceDictionary";
      this._typeNameTable[32] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries";
      this._typeNameTable[33] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>";
      this._typeNameTable[34] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes";
      this._typeNameTable[35] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeriesWithAxes";
      this._typeNameTable[36] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries";
      this._typeNameTable[37] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series";
      this._typeNameTable[38] = "Windows.UI.Xaml.Data.Binding";
      this._typeNameTable[39] = "Windows.UI.Xaml.Media.PointCollection";
      this._typeNameTable[40] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.IRangeAxis";
      this._typeNameTable[41] = "System.Nullable`1<Int32>";
      this._typeNameTable[42] = "System.Collections.IEnumerable";
      this._typeNameTable[43] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.AnimationSequence";
      this._typeNameTable[44] = "Windows.UI.Xaml.Media.Animation.EasingFunctionBase";
      this._typeNameTable[45] = "TimeSpan";
      this._typeNameTable[46] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeriesHost";
      this._typeNameTable[47] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint";
      this._typeNameTable[48] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint";
      this._typeNameTable[49] = "Double";
      this._typeNameTable[50] = "MobileBandSync.SectionPage";
      this._typeNameTable[51] = "Int32";
      this._typeNameTable[52] = "Windows.Devices.Geolocation.GeoboundingBox";
      this._typeNameTable[53] = "System.Threading.CancellationTokenSource";
      this._typeNameTable[54] = "MobileBandSync.Data.WorkoutItem";
      this._typeNameTable[55] = "Windows.UI.Xaml.Shapes.Line";
      this._typeNameTable[56] = "Windows.UI.Xaml.Controls.Maps.MapIcon";
      this._typeNameTable[57] = "MobileBandSync.SleepPage";
      this._typeNameTable[58] = "Windows.Foundation.Size";
      this._typeTable = new Type[59];
      this._typeTable[0] = typeof (HubPage);
      this._typeTable[1] = typeof (Page);
      this._typeTable[2] = typeof (UserControl);
      this._typeTable[3] = typeof (NavigationHelper);
      this._typeTable[4] = typeof (DependencyObject);
      this._typeTable[5] = typeof (ObservableDictionary);
      this._typeTable[6] = typeof (object);
      this._typeTable[7] = typeof (string);
      this._typeTable[8] = typeof (SyncViewModel);
      this._typeTable[9] = typeof (DispatcherTimer);
      this._typeTable[10] = typeof (bool);
      this._typeTable[11] = typeof (ToggleButton);
      this._typeTable[12] = typeof (ItemPage);
      this._typeTable[13] = typeof (Chart);
      this._typeTable[14] = typeof (Control);
      this._typeTable[15] = typeof (Collection<ISeries>);
      this._typeTable[16] = typeof (ISeries);
      this._typeTable[17] = typeof (ObservableCollection<object>);
      this._typeTable[18] = typeof (Collection<object>);
      this._typeTable[19] = typeof (Collection<IAxis>);
      this._typeTable[20] = typeof (IAxis);
      this._typeTable[21] = typeof (AxisOrientation);
      this._typeTable[22] = typeof (Enum);
      this._typeTable[23] = typeof (ValueType);
      this._typeTable[24] = typeof (ObservableCollection<IAxisListener>);
      this._typeTable[25] = typeof (Collection<IAxisListener>);
      this._typeTable[26] = typeof (IAxisListener);
      this._typeTable[27] = typeof (ObservableCollection<IAxis>);
      this._typeTable[28] = typeof (ReadOnlyCollection<IAxis>);
      this._typeTable[29] = typeof (Style);
      this._typeTable[30] = typeof (Collection<ResourceDictionary>);
      this._typeTable[31] = typeof (ResourceDictionary);
      this._typeTable[32] = typeof (LineSeries);
      this._typeTable[33] = typeof (LineAreaBaseSeries<LineDataPoint>);
      this._typeTable[34] = typeof (DataPointSingleSeriesWithAxes);
      this._typeTable[35] = typeof (DataPointSeriesWithAxes);
      this._typeTable[36] = typeof (DataPointSeries);
      this._typeTable[37] = typeof (Series);
      this._typeTable[38] = typeof (Binding);
      this._typeTable[39] = typeof (PointCollection);
      this._typeTable[40] = typeof (IRangeAxis);
      this._typeTable[41] = typeof (int?);
      this._typeTable[42] = typeof (IEnumerable);
      this._typeTable[43] = typeof (AnimationSequence);
      this._typeTable[44] = typeof (EasingFunctionBase);
      this._typeTable[45] = typeof (TimeSpan);
      this._typeTable[46] = typeof (ISeriesHost);
      this._typeTable[47] = typeof (LineDataPoint);
      this._typeTable[48] = typeof (DataPoint);
      this._typeTable[49] = typeof (double);
      this._typeTable[50] = typeof (SectionPage);
      this._typeTable[51] = typeof (int);
      this._typeTable[52] = typeof (GeoboundingBox);
      this._typeTable[53] = typeof (CancellationTokenSource);
      this._typeTable[54] = typeof (WorkoutItem);
      this._typeTable[55] = typeof (Line);
      this._typeTable[56] = typeof (MapIcon);
      this._typeTable[57] = typeof (SleepPage);
      this._typeTable[58] = typeof (Size);
    }

    private int LookupTypeIndexByName(string typeName)
    {
      if (this._typeNameTable == null)
        this.InitTypeTables();
      for (int index = 0; index < this._typeNameTable.Length; ++index)
      {
        if (string.CompareOrdinal(this._typeNameTable[index], typeName) == 0)
          return index;
      }
      return -1;
    }

    private int LookupTypeIndexByType(Type type)
    {
      if (this._typeTable == null)
        this.InitTypeTables();
      for (int index = 0; index < this._typeTable.Length; ++index)
      {
        if (type == this._typeTable[index])
          return index;
      }
      return -1;
    }

    private object Activate_0_HubPage() => (object) new HubPage();

    private object Activate_5_ObservableDictionary() => (object) new ObservableDictionary();

    private object Activate_8_SyncViewModel() => (object) new SyncViewModel();

    private object Activate_12_ItemPage() => (object) new ItemPage();

    private object Activate_13_Chart() => (object) new Chart();

    private object Activate_15_Collection() => (object) new Collection<ISeries>();

    private object Activate_17_ObservableCollection() => (object) new ObservableCollection<object>();

    private object Activate_18_Collection() => (object) new Collection<object>();

    private object Activate_19_Collection() => (object) new Collection<IAxis>();

    private object Activate_24_ObservableCollection() => (object) new ObservableCollection<IAxisListener>();

    private object Activate_25_Collection() => (object) new Collection<IAxisListener>();

    private object Activate_27_ObservableCollection() => (object) new ObservableCollection<IAxis>();

    private object Activate_30_Collection() => (object) new Collection<ResourceDictionary>();

    private object Activate_32_LineSeries() => (object) new LineSeries();

    private object Activate_47_LineDataPoint() => (object) new LineDataPoint();

    private object Activate_50_SectionPage() => (object) new SectionPage();

    private object Activate_53_CancellationTokenSource() => (object) new CancellationTokenSource();

    private object Activate_54_WorkoutItem() => (object) new WorkoutItem();

    private object Activate_57_SleepPage() => (object) new SleepPage();

    private void MapAdd_5_ObservableDictionary(object instance, object key, object item)
    {
      IDictionary<string, object> dictionary = (IDictionary<string, object>) instance;
      string str = (string) key;
      object obj1 = item;
      string key1 = str;
      object obj2 = obj1;
      dictionary.Add(key1, obj2);
    }

    private void VectorAdd_15_Collection(object instance, object item) => ((ICollection<ISeries>) instance).Add((ISeries) item);

    private void VectorAdd_17_ObservableCollection(object instance, object item) => ((ICollection<object>) instance).Add(item);

    private void VectorAdd_18_Collection(object instance, object item) => ((ICollection<object>) instance).Add(item);

    private void VectorAdd_19_Collection(object instance, object item) => ((ICollection<IAxis>) instance).Add((IAxis) item);

    private void VectorAdd_24_ObservableCollection(object instance, object item) => ((ICollection<IAxisListener>) instance).Add((IAxisListener) item);

    private void VectorAdd_25_Collection(object instance, object item) => ((ICollection<IAxisListener>) instance).Add((IAxisListener) item);

    private void VectorAdd_27_ObservableCollection(object instance, object item) => ((ICollection<IAxis>) instance).Add((IAxis) item);

    private void VectorAdd_28_ReadOnlyCollection(object instance, object item) => ((ICollection<IAxis>) instance).Add((IAxis) item);

    private void VectorAdd_30_Collection(object instance, object item) => ((ICollection<ResourceDictionary>) instance).Add((ResourceDictionary) item);

    private IXamlType CreateXamlType(int typeIndex)
    {
      XamlSystemBaseType xamlType = (XamlSystemBaseType) null;
      string fullName = this._typeNameTable[typeIndex];
      Type type = this._typeTable[typeIndex];
      switch (typeIndex)
      {
        case 0:
          XamlUserType xamlUserType1 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType1.Activator = new Activator(this.Activate_0_HubPage);
          xamlUserType1.AddMemberName("NavigationHelper");
          xamlUserType1.AddMemberName("DefaultViewModel");
          xamlUserType1.AddMemberName("SyncView");
          xamlUserType1.AddMemberName("DeviceTimer");
          xamlUserType1.AddMemberName("MapServiceToken");
          xamlUserType1.AddMemberName("FilterAccepted");
          xamlUserType1.AddMemberName("MapPickerInitialized");
          xamlUserType1.AddMemberName("ToggleFilter");
          xamlUserType1.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType1;
          break;
        case 1:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 2:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 3:
          XamlUserType xamlUserType2 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.DependencyObject"));
          xamlUserType2.SetIsReturnTypeStub();
          xamlUserType2.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType2;
          break;
        case 4:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 5:
          XamlUserType xamlUserType3 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType3.DictionaryAdd = new AddToDictionary(this.MapAdd_5_ObservableDictionary);
          xamlUserType3.SetIsReturnTypeStub();
          xamlUserType3.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType3;
          break;
        case 6:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 7:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 8:
          XamlUserType xamlUserType4 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType4.SetIsReturnTypeStub();
          xamlUserType4.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType4;
          break;
        case 9:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 10:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 11:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 12:
          XamlUserType xamlUserType5 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType5.Activator = new Activator(this.Activate_12_ItemPage);
          xamlUserType5.AddMemberName("NavigationHelper");
          xamlUserType5.AddMemberName("DefaultViewModel");
          xamlUserType5.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType5;
          break;
        case 13:
          XamlUserType xamlUserType6 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType6.Activator = new Activator(this.Activate_13_Chart);
          xamlUserType6.SetContentPropertyName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Series");
          xamlUserType6.AddMemberName("Series");
          xamlUserType6.AddMemberName("Axes");
          xamlUserType6.AddMemberName("ActualAxes");
          xamlUserType6.AddMemberName("ChartAreaStyle");
          xamlUserType6.AddMemberName("LegendItems");
          xamlUserType6.AddMemberName("LegendStyle");
          xamlUserType6.AddMemberName("LegendTitle");
          xamlUserType6.AddMemberName("PlotAreaStyle");
          xamlUserType6.AddMemberName("Palette");
          xamlUserType6.AddMemberName("Title");
          xamlUserType6.AddMemberName("TitleStyle");
          xamlType = (XamlSystemBaseType) xamlUserType6;
          break;
        case 14:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 15:
          XamlUserType xamlUserType7 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType7.CollectionAdd = new AddToCollection(this.VectorAdd_15_Collection);
          xamlUserType7.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType7;
          break;
        case 16:
          XamlUserType xamlUserType8 = new XamlUserType(this, fullName, type, (IXamlType) null);
          xamlUserType8.AddMemberName("LegendItems");
          xamlType = (XamlSystemBaseType) xamlUserType8;
          break;
        case 17:
          XamlUserType xamlUserType9 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<Object>"));
          xamlUserType9.CollectionAdd = new AddToCollection(this.VectorAdd_17_ObservableCollection);
          xamlUserType9.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType9;
          break;
        case 18:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"))
          {
            Activator = new Activator(this.Activate_18_Collection),
            CollectionAdd = new AddToCollection(this.VectorAdd_18_Collection)
          };
          break;
        case 19:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"))
          {
            Activator = new Activator(this.Activate_19_Collection),
            CollectionAdd = new AddToCollection(this.VectorAdd_19_Collection)
          };
          break;
        case 20:
          XamlUserType xamlUserType10 = new XamlUserType(this, fullName, type, (IXamlType) null);
          xamlUserType10.AddMemberName("Orientation");
          xamlUserType10.AddMemberName("RegisteredListeners");
          xamlUserType10.AddMemberName("DependentAxes");
          xamlType = (XamlSystemBaseType) xamlUserType10;
          break;
        case 21:
          XamlUserType xamlUserType11 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Enum"));
          xamlUserType11.AddEnumValue("None", (object) AxisOrientation.None);
          xamlUserType11.AddEnumValue("X", (object) AxisOrientation.X);
          xamlUserType11.AddEnumValue("Y", (object) AxisOrientation.Y);
          xamlType = (XamlSystemBaseType) xamlUserType11;
          break;
        case 22:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
          break;
        case 23:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          break;
        case 24:
          XamlUserType xamlUserType12 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>"));
          xamlUserType12.CollectionAdd = new AddToCollection(this.VectorAdd_24_ObservableCollection);
          xamlUserType12.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType12;
          break;
        case 25:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"))
          {
            Activator = new Activator(this.Activate_25_Collection),
            CollectionAdd = new AddToCollection(this.VectorAdd_25_Collection)
          };
          break;
        case 26:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, (IXamlType) null);
          break;
        case 27:
          XamlUserType xamlUserType13 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>"));
          xamlUserType13.CollectionAdd = new AddToCollection(this.VectorAdd_27_ObservableCollection);
          xamlUserType13.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType13;
          break;
        case 28:
          XamlUserType xamlUserType14 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType14.CollectionAdd = new AddToCollection(this.VectorAdd_28_ReadOnlyCollection);
          xamlUserType14.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType14;
          break;
        case 29:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 30:
          XamlUserType xamlUserType15 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType15.CollectionAdd = new AddToCollection(this.VectorAdd_30_Collection);
          xamlUserType15.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType15;
          break;
        case 31:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 32:
          XamlUserType xamlUserType16 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>"));
          xamlUserType16.Activator = new Activator(this.Activate_32_LineSeries);
          xamlUserType16.AddMemberName("Points");
          xamlUserType16.AddMemberName("PolylineStyle");
          xamlType = (XamlSystemBaseType) xamlUserType16;
          break;
        case 33:
          XamlUserType xamlUserType17 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes"));
          xamlUserType17.AddMemberName("DependentRangeAxis");
          xamlUserType17.AddMemberName("IndependentAxis");
          xamlUserType17.AddMemberName("ActualIndependentAxis");
          xamlUserType17.AddMemberName("ActualDependentRangeAxis");
          xamlType = (XamlSystemBaseType) xamlUserType17;
          break;
        case 34:
          XamlUserType xamlUserType18 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeriesWithAxes"));
          xamlUserType18.AddMemberName("GlobalSeriesIndex");
          xamlType = (XamlSystemBaseType) xamlUserType18;
          break;
        case 35:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries"));
          break;
        case 36:
          XamlUserType xamlUserType19 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series"));
          xamlUserType19.AddMemberName("IndependentValueBinding");
          xamlUserType19.AddMemberName("DependentValueBinding");
          xamlUserType19.AddMemberName("IsSelectionEnabled");
          xamlUserType19.AddMemberName("DataPointStyle");
          xamlUserType19.AddMemberName("DependentValuePath");
          xamlUserType19.AddMemberName("IndependentValuePath");
          xamlUserType19.AddMemberName("ItemsSource");
          xamlUserType19.AddMemberName("AnimationSequence");
          xamlUserType19.AddMemberName("TransitionEasingFunction");
          xamlUserType19.AddMemberName("SelectedItem");
          xamlUserType19.AddMemberName("LegendItemStyle");
          xamlUserType19.AddMemberName("TransitionDuration");
          xamlType = (XamlSystemBaseType) xamlUserType19;
          break;
        case 37:
          XamlUserType xamlUserType20 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType20.AddMemberName("Title");
          xamlUserType20.AddMemberName("SeriesHost");
          xamlUserType20.AddMemberName("LegendItems");
          xamlType = (XamlSystemBaseType) xamlUserType20;
          break;
        case 38:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 39:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 40:
          XamlUserType xamlUserType21 = new XamlUserType(this, fullName, type, (IXamlType) null);
          xamlUserType21.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType21;
          break;
        case 41:
          XamlUserType xamlUserType22 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
          xamlUserType22.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType22;
          break;
        case 42:
          XamlUserType xamlUserType23 = new XamlUserType(this, fullName, type, (IXamlType) null);
          xamlUserType23.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType23;
          break;
        case 43:
          XamlUserType xamlUserType24 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Enum"));
          xamlUserType24.AddEnumValue("Simultaneous", (object) AnimationSequence.Simultaneous);
          xamlUserType24.AddEnumValue("FirstToLast", (object) AnimationSequence.FirstToLast);
          xamlUserType24.AddEnumValue("LastToFirst", (object) AnimationSequence.LastToFirst);
          xamlType = (XamlSystemBaseType) xamlUserType24;
          break;
        case 44:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 45:
          XamlUserType xamlUserType25 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
          xamlUserType25.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType25;
          break;
        case 46:
          XamlUserType xamlUserType26 = new XamlUserType(this, fullName, type, (IXamlType) null);
          xamlUserType26.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType26;
          break;
        case 47:
          xamlType = (XamlSystemBaseType) new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint"))
          {
            Activator = new Activator(this.Activate_47_LineDataPoint)
          };
          break;
        case 48:
          XamlUserType xamlUserType27 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
          xamlUserType27.AddMemberName("IsSelectionEnabled");
          xamlUserType27.AddMemberName("ActualDependentValue");
          xamlUserType27.AddMemberName("DependentValue");
          xamlUserType27.AddMemberName("DependentValueStringFormat");
          xamlUserType27.AddMemberName("FormattedDependentValue");
          xamlUserType27.AddMemberName("FormattedIndependentValue");
          xamlUserType27.AddMemberName("IndependentValue");
          xamlUserType27.AddMemberName("IndependentValueStringFormat");
          xamlUserType27.AddMemberName("ActualIndependentValue");
          xamlType = (XamlSystemBaseType) xamlUserType27;
          break;
        case 49:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 50:
          XamlUserType xamlUserType28 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType28.Activator = new Activator(this.Activate_50_SectionPage);
          xamlUserType28.AddMemberName("NavigationHelper");
          xamlUserType28.AddMemberName("DefaultViewModel");
          xamlUserType28.AddMemberName("currentWorkoutId");
          xamlUserType28.AddMemberName("Viewport");
          xamlUserType28.AddMemberName("MapInitialized");
          xamlUserType28.AddMemberName("CancelTokenSource");
          xamlUserType28.AddMemberName("CurrentWorkout");
          xamlUserType28.AddMemberName("ViewInitialized");
          xamlUserType28.AddMemberName("chartLine");
          xamlUserType28.AddMemberName("PosNeedleIcon");
          xamlUserType28.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType28;
          break;
        case 51:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 52:
          XamlUserType xamlUserType29 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType29.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType29;
          break;
        case 53:
          XamlUserType xamlUserType30 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType30.SetIsReturnTypeStub();
          xamlType = (XamlSystemBaseType) xamlUserType30;
          break;
        case 54:
          XamlUserType xamlUserType31 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
          xamlUserType31.SetIsReturnTypeStub();
          xamlUserType31.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType31;
          break;
        case 55:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 56:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
        case 57:
          XamlUserType xamlUserType32 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
          xamlUserType32.Activator = new Activator(this.Activate_57_SleepPage);
          xamlUserType32.AddMemberName("NavigationHelper");
          xamlUserType32.AddMemberName("DefaultViewModel");
          xamlUserType32.AddMemberName("currentWorkoutId");
          xamlUserType32.AddMemberName("CancelTokenSource");
          xamlUserType32.AddMemberName("CurrentWorkout");
          xamlUserType32.AddMemberName("CanvasSize");
          xamlUserType32.SetIsLocalType();
          xamlType = (XamlSystemBaseType) xamlUserType32;
          break;
        case 58:
          xamlType = new XamlSystemBaseType(fullName, type);
          break;
      }
      return (IXamlType) xamlType;
    }

    private List<IXamlMetadataProvider> OtherProviders
    {
      get
      {
        if (this._otherProviders == null)
        {
          this._otherProviders = new List<IXamlMetadataProvider>();
          this._otherProviders.Add((IXamlMetadataProvider) new WinRTXamlToolkit.Controls.DataVisualization.WinRTXamlToolkit_Controls_DataVisualization_WindowsPhone_XamlTypeInfo.XamlMetaDataProvider());
          this._otherProviders.Add((IXamlMetadataProvider) new WinRTXamlToolkit.WinRTXamlToolkit_WindowsPhone_XamlTypeInfo.XamlMetaDataProvider());
        }
        return this._otherProviders;
      }
    }

    private IXamlType CheckOtherMetadataProvidersForName(string typeName)
    {
      IXamlType ixamlType = (IXamlType) null;
      foreach (IXamlMetadataProvider otherProvider in this.OtherProviders)
      {
        IXamlType xamlType = otherProvider.GetXamlType(typeName);
        if (xamlType != null)
        {
          if (xamlType.IsConstructible)
            return xamlType;
          ixamlType = xamlType;
        }
      }
      return ixamlType;
    }

    private IXamlType CheckOtherMetadataProvidersForType(Type type)
    {
      IXamlType ixamlType = (IXamlType) null;
      foreach (IXamlMetadataProvider otherProvider in this.OtherProviders)
      {
        IXamlType xamlType = otherProvider.GetXamlType(type);
        if (xamlType != null)
        {
          if (xamlType.IsConstructible)
            return xamlType;
          ixamlType = xamlType;
        }
      }
      return ixamlType;
    }

    private object get_0_HubPage_NavigationHelper(object instance) => (object) ((HubPage) instance).NavigationHelper;

    private object get_1_HubPage_DefaultViewModel(object instance) => (object) ((HubPage) instance).DefaultViewModel;

    private object get_2_HubPage_SyncView(object instance) => (object) ((HubPage) instance).SyncView;

    private void set_2_HubPage_SyncView(object instance, object Value) => ((HubPage) instance).SyncView = (SyncViewModel) Value;

    private object get_3_HubPage_DeviceTimer(object instance) => (object) ((HubPage) instance).DeviceTimer;

    private object get_4_HubPage_MapServiceToken(object instance) => (object) ((HubPage) instance).MapServiceToken;

    private object get_5_HubPage_FilterAccepted(object instance) => (object) ((HubPage) instance).FilterAccepted;

    private object get_6_HubPage_MapPickerInitialized(object instance) => (object) ((HubPage) instance).MapPickerInitialized;

    private object get_7_HubPage_ToggleFilter(object instance) => (object) ((HubPage) instance).ToggleFilter;

    private object get_8_ItemPage_NavigationHelper(object instance) => (object) ((ItemPage) instance).NavigationHelper;

    private object get_9_ItemPage_DefaultViewModel(object instance) => (object) ((ItemPage) instance).DefaultViewModel;

    private object get_10_Chart_Series(object instance) => (object) ((Chart) instance).Series;

    private void set_10_Chart_Series(object instance, object Value) => ((Chart) instance).Series = (Collection<ISeries>) Value;

    private object get_11_ISeries_LegendItems(object instance) => (object) ((ISeries) instance).LegendItems;

    private object get_12_Chart_Axes(object instance) => (object) ((Chart) instance).Axes;

    private void set_12_Chart_Axes(object instance, object Value) => ((Chart) instance).Axes = (Collection<IAxis>) Value;

    private object get_13_IAxis_Orientation(object instance) => (object) ((IAxis) instance).Orientation;

    private void set_13_IAxis_Orientation(object instance, object Value) => ((IAxis) instance).Orientation = (AxisOrientation) Value;

    private object get_14_IAxis_RegisteredListeners(object instance) => (object) ((IAxis) instance).RegisteredListeners;

    private object get_15_IAxis_DependentAxes(object instance) => (object) ((IAxis) instance).DependentAxes;

    private object get_16_Chart_ActualAxes(object instance) => (object) ((Chart) instance).ActualAxes;

    private object get_17_Chart_ChartAreaStyle(object instance) => (object) ((Chart) instance).ChartAreaStyle;

    private void set_17_Chart_ChartAreaStyle(object instance, object Value) => ((Chart) instance).ChartAreaStyle = (Style) Value;

    private object get_18_Chart_LegendItems(object instance) => (object) ((Chart) instance).LegendItems;

    private object get_19_Chart_LegendStyle(object instance) => (object) ((Chart) instance).LegendStyle;

    private void set_19_Chart_LegendStyle(object instance, object Value) => ((Chart) instance).LegendStyle = (Style) Value;

    private object get_20_Chart_LegendTitle(object instance) => ((Chart) instance).LegendTitle;

    private void set_20_Chart_LegendTitle(object instance, object Value) => ((Chart) instance).LegendTitle = Value;

    private object get_21_Chart_PlotAreaStyle(object instance) => (object) ((Chart) instance).PlotAreaStyle;

    private void set_21_Chart_PlotAreaStyle(object instance, object Value) => ((Chart) instance).PlotAreaStyle = (Style) Value;

    private object get_22_Chart_Palette(object instance) => (object) ((Chart) instance).Palette;

    private void set_22_Chart_Palette(object instance, object Value) => ((Chart) instance).Palette = (Collection<ResourceDictionary>) Value;

    private object get_23_Chart_Title(object instance) => ((Chart) instance).Title;

    private void set_23_Chart_Title(object instance, object Value) => ((Chart) instance).Title = Value;

    private object get_24_Chart_TitleStyle(object instance) => (object) ((Chart) instance).TitleStyle;

    private void set_24_Chart_TitleStyle(object instance, object Value) => ((Chart) instance).TitleStyle = (Style) Value;

    private object get_25_Series_Title(object instance) => ((Series) instance).Title;

    private void set_25_Series_Title(object instance, object Value) => ((Series) instance).Title = Value;

    private object get_26_DataPointSeries_IndependentValueBinding(object instance) => (object) ((DataPointSeries) instance).IndependentValueBinding;

    private void set_26_DataPointSeries_IndependentValueBinding(object instance, object Value) => ((DataPointSeries) instance).IndependentValueBinding = (Binding) Value;

    private object get_27_DataPointSeries_DependentValueBinding(object instance) => (object) ((DataPointSeries) instance).DependentValueBinding;

    private void set_27_DataPointSeries_DependentValueBinding(object instance, object Value) => ((DataPointSeries) instance).DependentValueBinding = (Binding) Value;

    private object get_28_DataPointSeries_IsSelectionEnabled(object instance) => (object) ((DataPointSeries) instance).IsSelectionEnabled;

    private void set_28_DataPointSeries_IsSelectionEnabled(object instance, object Value) => ((DataPointSeries) instance).IsSelectionEnabled = (bool) Value;

    private object get_29_DataPointSeries_DataPointStyle(object instance) => (object) ((DataPointSeries) instance).DataPointStyle;

    private void set_29_DataPointSeries_DataPointStyle(object instance, object Value) => ((DataPointSeries) instance).DataPointStyle = (Style) Value;

    private object get_30_LineSeries_Points(object instance) => (object) ((LineSeries) instance).Points;

    private object get_31_LineSeries_PolylineStyle(object instance) => (object) ((LineSeries) instance).PolylineStyle;

    private void set_31_LineSeries_PolylineStyle(object instance, object Value) => ((LineSeries) instance).PolylineStyle = (Style) Value;

    private object get_32_LineAreaBaseSeries_DependentRangeAxis(object instance) => (object) ((LineAreaBaseSeries<LineDataPoint>) instance).DependentRangeAxis;

    private void set_32_LineAreaBaseSeries_DependentRangeAxis(object instance, object Value) => ((LineAreaBaseSeries<LineDataPoint>) instance).DependentRangeAxis = (IRangeAxis) Value;

    private object get_33_LineAreaBaseSeries_IndependentAxis(object instance) => (object) ((LineAreaBaseSeries<LineDataPoint>) instance).IndependentAxis;

    private void set_33_LineAreaBaseSeries_IndependentAxis(object instance, object Value) => ((LineAreaBaseSeries<LineDataPoint>) instance).IndependentAxis = (IAxis) Value;

    private object get_34_LineAreaBaseSeries_ActualIndependentAxis(object instance) => (object) ((LineAreaBaseSeries<LineDataPoint>) instance).ActualIndependentAxis;

    private object get_35_LineAreaBaseSeries_ActualDependentRangeAxis(object instance) => (object) ((LineAreaBaseSeries<LineDataPoint>) instance).ActualDependentRangeAxis;

    private object get_36_DataPointSingleSeriesWithAxes_GlobalSeriesIndex(object instance) => (object) ((DataPointSingleSeriesWithAxes) instance).GlobalSeriesIndex;

    private object get_37_DataPointSeries_DependentValuePath(object instance) => (object) ((DataPointSeries) instance).DependentValuePath;

    private void set_37_DataPointSeries_DependentValuePath(object instance, object Value) => ((DataPointSeries) instance).DependentValuePath = (string) Value;

    private object get_38_DataPointSeries_IndependentValuePath(object instance) => (object) ((DataPointSeries) instance).IndependentValuePath;

    private void set_38_DataPointSeries_IndependentValuePath(object instance, object Value) => ((DataPointSeries) instance).IndependentValuePath = (string) Value;

    private object get_39_DataPointSeries_ItemsSource(object instance) => (object) ((DataPointSeries) instance).ItemsSource;

    private void set_39_DataPointSeries_ItemsSource(object instance, object Value) => ((DataPointSeries) instance).ItemsSource = (IEnumerable) Value;

    private object get_40_DataPointSeries_AnimationSequence(object instance) => (object) ((DataPointSeries) instance).AnimationSequence;

    private void set_40_DataPointSeries_AnimationSequence(object instance, object Value) => ((DataPointSeries) instance).AnimationSequence = (AnimationSequence) Value;

    private object get_41_DataPointSeries_TransitionEasingFunction(object instance) => (object) ((DataPointSeries) instance).TransitionEasingFunction;

    private void set_41_DataPointSeries_TransitionEasingFunction(object instance, object Value) => ((DataPointSeries) instance).TransitionEasingFunction = (EasingFunctionBase) Value;

    private object get_42_DataPointSeries_SelectedItem(object instance) => ((DataPointSeries) instance).SelectedItem;

    private void set_42_DataPointSeries_SelectedItem(object instance, object Value) => ((DataPointSeries) instance).SelectedItem = Value;

    private object get_43_DataPointSeries_LegendItemStyle(object instance) => (object) ((DataPointSeries) instance).LegendItemStyle;

    private void set_43_DataPointSeries_LegendItemStyle(object instance, object Value) => ((DataPointSeries) instance).LegendItemStyle = (Style) Value;

    private object get_44_DataPointSeries_TransitionDuration(object instance) => (object) ((DataPointSeries) instance).TransitionDuration;

    private void set_44_DataPointSeries_TransitionDuration(object instance, object Value) => ((DataPointSeries) instance).TransitionDuration = (TimeSpan) Value;

    private object get_45_Series_SeriesHost(object instance) => (object) ((Series) instance).SeriesHost;

    private void set_45_Series_SeriesHost(object instance, object Value) => ((Series) instance).SeriesHost = (ISeriesHost) Value;

    private object get_46_Series_LegendItems(object instance) => (object) ((Series) instance).LegendItems;

    private object get_47_DataPoint_IsSelectionEnabled(object instance) => (object) ((DataPoint) instance).IsSelectionEnabled;

    private void set_47_DataPoint_IsSelectionEnabled(object instance, object Value) => ((DataPoint) instance).IsSelectionEnabled = (bool) Value;

    private object get_48_DataPoint_ActualDependentValue(object instance) => (object) ((DataPoint) instance).ActualDependentValue;

    private void set_48_DataPoint_ActualDependentValue(object instance, object Value) => ((DataPoint) instance).ActualDependentValue = (double) Value;

    private object get_49_DataPoint_DependentValue(object instance) => (object) ((DataPoint) instance).DependentValue;

    private void set_49_DataPoint_DependentValue(object instance, object Value) => ((DataPoint) instance).DependentValue = (double) Value;

    private object get_50_DataPoint_DependentValueStringFormat(object instance) => (object) ((DataPoint) instance).DependentValueStringFormat;

    private void set_50_DataPoint_DependentValueStringFormat(object instance, object Value) => ((DataPoint) instance).DependentValueStringFormat = (string) Value;

    private object get_51_DataPoint_FormattedDependentValue(object instance) => (object) ((DataPoint) instance).FormattedDependentValue;

    private object get_52_DataPoint_FormattedIndependentValue(object instance) => (object) ((DataPoint) instance).FormattedIndependentValue;

    private object get_53_DataPoint_IndependentValue(object instance) => ((DataPoint) instance).IndependentValue;

    private void set_53_DataPoint_IndependentValue(object instance, object Value) => ((DataPoint) instance).IndependentValue = Value;

    private object get_54_DataPoint_IndependentValueStringFormat(object instance) => (object) ((DataPoint) instance).IndependentValueStringFormat;

    private void set_54_DataPoint_IndependentValueStringFormat(object instance, object Value) => ((DataPoint) instance).IndependentValueStringFormat = (string) Value;

    private object get_55_DataPoint_ActualIndependentValue(object instance) => ((DataPoint) instance).ActualIndependentValue;

    private void set_55_DataPoint_ActualIndependentValue(object instance, object Value) => ((DataPoint) instance).ActualIndependentValue = Value;

    private object get_56_SectionPage_NavigationHelper(object instance) => (object) ((SectionPage) instance).NavigationHelper;

    private object get_57_SectionPage_DefaultViewModel(object instance) => (object) ((SectionPage) instance).DefaultViewModel;

    private object get_58_SectionPage_currentWorkoutId(object instance) => (object) ((SectionPage) instance).currentWorkoutId;

    private object get_59_SectionPage_Viewport(object instance) => (object) ((SectionPage) instance).Viewport;

    private object get_60_SectionPage_MapInitialized(object instance) => (object) ((SectionPage) instance).MapInitialized;

    private object get_61_SectionPage_CancelTokenSource(object instance) => (object) ((SectionPage) instance).CancelTokenSource;

    private object get_62_SectionPage_CurrentWorkout(object instance) => (object) ((SectionPage) instance).CurrentWorkout;

    private object get_63_SectionPage_ViewInitialized(object instance) => (object) ((SectionPage) instance).ViewInitialized;

    private object get_64_SectionPage_chartLine(object instance) => (object) ((SectionPage) instance).chartLine;

    private object get_65_SectionPage_PosNeedleIcon(object instance) => (object) ((SectionPage) instance).PosNeedleIcon;

    private object get_66_SleepPage_NavigationHelper(object instance) => (object) ((SleepPage) instance).NavigationHelper;

    private object get_67_SleepPage_DefaultViewModel(object instance) => (object) ((SleepPage) instance).DefaultViewModel;

    private object get_68_SleepPage_currentWorkoutId(object instance) => (object) ((SleepPage) instance).currentWorkoutId;

    private object get_69_SleepPage_CancelTokenSource(object instance) => (object) ((SleepPage) instance).CancelTokenSource;

    private object get_70_SleepPage_CurrentWorkout(object instance) => (object) ((SleepPage) instance).CurrentWorkout;

    private object get_71_SleepPage_CanvasSize(object instance) => (object) ((SleepPage) instance).CanvasSize;

    private IXamlMember CreateXamlMember(string longMemberName)
    {
      XamlMember xamlMember = (XamlMember) null;
      switch (longMemberName)
      {
        case "MobileBandSync.HubPage.DefaultViewModel":
          XamlUserType xamlTypeByName1 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.HubPage");
          xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
          xamlMember.Getter = new Getter(this.get_1_HubPage_DefaultViewModel);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.HubPage.DeviceTimer":
          XamlUserType xamlTypeByName2 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.HubPage");
          xamlMember = new XamlMember(this, "DeviceTimer", "Windows.UI.Xaml.DispatcherTimer");
          xamlMember.Getter = new Getter(this.get_3_HubPage_DeviceTimer);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.HubPage.FilterAccepted":
          XamlUserType xamlTypeByName3 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.HubPage");
          xamlMember = new XamlMember(this, "FilterAccepted", "Boolean");
          xamlMember.Getter = new Getter(this.get_5_HubPage_FilterAccepted);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.HubPage.MapPickerInitialized":
          XamlUserType xamlTypeByName4 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.HubPage");
          xamlMember = new XamlMember(this, "MapPickerInitialized", "Boolean");
          xamlMember.Getter = new Getter(this.get_6_HubPage_MapPickerInitialized);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.HubPage.MapServiceToken":
          XamlUserType xamlTypeByName5 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.HubPage");
          xamlMember = new XamlMember(this, "MapServiceToken", "String");
          xamlMember.Getter = new Getter(this.get_4_HubPage_MapServiceToken);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.HubPage.NavigationHelper":
          XamlUserType xamlTypeByName6 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.HubPage");
          xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
          xamlMember.Getter = new Getter(this.get_0_HubPage_NavigationHelper);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.HubPage.SyncView":
          XamlUserType xamlTypeByName7 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.HubPage");
          xamlMember = new XamlMember(this, "SyncView", "MobileBandSync.Common.SyncViewModel");
          xamlMember.Getter = new Getter(this.get_2_HubPage_SyncView);
          xamlMember.Setter = new Setter(this.set_2_HubPage_SyncView);
          break;
        case "MobileBandSync.HubPage.ToggleFilter":
          XamlUserType xamlTypeByName8 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.HubPage");
          xamlMember = new XamlMember(this, "ToggleFilter", "Windows.UI.Xaml.Controls.Primitives.ToggleButton");
          xamlMember.Getter = new Getter(this.get_7_HubPage_ToggleFilter);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.ItemPage.DefaultViewModel":
          XamlUserType xamlTypeByName9 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.ItemPage");
          xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
          xamlMember.Getter = new Getter(this.get_9_ItemPage_DefaultViewModel);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.ItemPage.NavigationHelper":
          XamlUserType xamlTypeByName10 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.ItemPage");
          xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
          xamlMember.Getter = new Getter(this.get_8_ItemPage_NavigationHelper);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.CancelTokenSource":
          XamlUserType xamlTypeByName11 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "CancelTokenSource", "System.Threading.CancellationTokenSource");
          xamlMember.Getter = new Getter(this.get_61_SectionPage_CancelTokenSource);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.CurrentWorkout":
          XamlUserType xamlTypeByName12 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "CurrentWorkout", "MobileBandSync.Data.WorkoutItem");
          xamlMember.Getter = new Getter(this.get_62_SectionPage_CurrentWorkout);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.DefaultViewModel":
          XamlUserType xamlTypeByName13 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
          xamlMember.Getter = new Getter(this.get_57_SectionPage_DefaultViewModel);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.MapInitialized":
          XamlUserType xamlTypeByName14 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "MapInitialized", "Boolean");
          xamlMember.Getter = new Getter(this.get_60_SectionPage_MapInitialized);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.NavigationHelper":
          XamlUserType xamlTypeByName15 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
          xamlMember.Getter = new Getter(this.get_56_SectionPage_NavigationHelper);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.PosNeedleIcon":
          XamlUserType xamlTypeByName16 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "PosNeedleIcon", "Windows.UI.Xaml.Controls.Maps.MapIcon");
          xamlMember.Getter = new Getter(this.get_65_SectionPage_PosNeedleIcon);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.ViewInitialized":
          XamlUserType xamlTypeByName17 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "ViewInitialized", "Boolean");
          xamlMember.Getter = new Getter(this.get_63_SectionPage_ViewInitialized);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.Viewport":
          XamlUserType xamlTypeByName18 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "Viewport", "Windows.Devices.Geolocation.GeoboundingBox");
          xamlMember.Getter = new Getter(this.get_59_SectionPage_Viewport);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.chartLine":
          XamlUserType xamlTypeByName19 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "chartLine", "Windows.UI.Xaml.Shapes.Line");
          xamlMember.Getter = new Getter(this.get_64_SectionPage_chartLine);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SectionPage.currentWorkoutId":
          XamlUserType xamlTypeByName20 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SectionPage");
          xamlMember = new XamlMember(this, "currentWorkoutId", "Int32");
          xamlMember.Getter = new Getter(this.get_58_SectionPage_currentWorkoutId);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SleepPage.CancelTokenSource":
          XamlUserType xamlTypeByName21 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SleepPage");
          xamlMember = new XamlMember(this, "CancelTokenSource", "System.Threading.CancellationTokenSource");
          xamlMember.Getter = new Getter(this.get_69_SleepPage_CancelTokenSource);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SleepPage.CanvasSize":
          XamlUserType xamlTypeByName22 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SleepPage");
          xamlMember = new XamlMember(this, "CanvasSize", "Windows.Foundation.Size");
          xamlMember.Getter = new Getter(this.get_71_SleepPage_CanvasSize);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SleepPage.CurrentWorkout":
          XamlUserType xamlTypeByName23 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SleepPage");
          xamlMember = new XamlMember(this, "CurrentWorkout", "MobileBandSync.Data.WorkoutItem");
          xamlMember.Getter = new Getter(this.get_70_SleepPage_CurrentWorkout);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SleepPage.DefaultViewModel":
          XamlUserType xamlTypeByName24 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SleepPage");
          xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
          xamlMember.Getter = new Getter(this.get_67_SleepPage_DefaultViewModel);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SleepPage.NavigationHelper":
          XamlUserType xamlTypeByName25 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SleepPage");
          xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
          xamlMember.Getter = new Getter(this.get_66_SleepPage_NavigationHelper);
          xamlMember.SetIsReadOnly();
          break;
        case "MobileBandSync.SleepPage.currentWorkoutId":
          XamlUserType xamlTypeByName26 = (XamlUserType) this.GetXamlTypeByName("MobileBandSync.SleepPage");
          xamlMember = new XamlMember(this, "currentWorkoutId", "Int32");
          xamlMember.Getter = new Getter(this.get_68_SleepPage_currentWorkoutId);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.ActualAxes":
          XamlUserType xamlTypeByName27 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "ActualAxes", "System.Collections.ObjectModel.ReadOnlyCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
          xamlMember.Getter = new Getter(this.get_16_Chart_ActualAxes);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Axes":
          XamlUserType xamlTypeByName28 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "Axes", "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
          xamlMember.Getter = new Getter(this.get_12_Chart_Axes);
          xamlMember.Setter = new Setter(this.set_12_Chart_Axes);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.ChartAreaStyle":
          XamlUserType xamlTypeByName29 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "ChartAreaStyle", "Windows.UI.Xaml.Style");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_17_Chart_ChartAreaStyle);
          xamlMember.Setter = new Setter(this.set_17_Chart_ChartAreaStyle);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendItems":
          XamlUserType xamlTypeByName30 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.Collection`1<Object>");
          xamlMember.Getter = new Getter(this.get_18_Chart_LegendItems);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendStyle":
          XamlUserType xamlTypeByName31 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "LegendStyle", "Windows.UI.Xaml.Style");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_19_Chart_LegendStyle);
          xamlMember.Setter = new Setter(this.set_19_Chart_LegendStyle);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendTitle":
          XamlUserType xamlTypeByName32 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "LegendTitle", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_20_Chart_LegendTitle);
          xamlMember.Setter = new Setter(this.set_20_Chart_LegendTitle);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Palette":
          XamlUserType xamlTypeByName33 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "Palette", "System.Collections.ObjectModel.Collection`1<Windows.UI.Xaml.ResourceDictionary>");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_22_Chart_Palette);
          xamlMember.Setter = new Setter(this.set_22_Chart_Palette);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.PlotAreaStyle":
          XamlUserType xamlTypeByName34 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "PlotAreaStyle", "Windows.UI.Xaml.Style");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_21_Chart_PlotAreaStyle);
          xamlMember.Setter = new Setter(this.set_21_Chart_PlotAreaStyle);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Series":
          XamlUserType xamlTypeByName35 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "Series", "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries>");
          xamlMember.Getter = new Getter(this.get_10_Chart_Series);
          xamlMember.Setter = new Setter(this.set_10_Chart_Series);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Title":
          XamlUserType xamlTypeByName36 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "Title", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_23_Chart_Title);
          xamlMember.Setter = new Setter(this.set_23_Chart_Title);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.TitleStyle":
          XamlUserType xamlTypeByName37 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
          xamlMember = new XamlMember(this, "TitleStyle", "Windows.UI.Xaml.Style");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_24_Chart_TitleStyle);
          xamlMember.Setter = new Setter(this.set_24_Chart_TitleStyle);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.ActualDependentValue":
          XamlUserType xamlTypeByName38 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "ActualDependentValue", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_48_DataPoint_ActualDependentValue);
          xamlMember.Setter = new Setter(this.set_48_DataPoint_ActualDependentValue);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.ActualIndependentValue":
          XamlUserType xamlTypeByName39 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "ActualIndependentValue", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_55_DataPoint_ActualIndependentValue);
          xamlMember.Setter = new Setter(this.set_55_DataPoint_ActualIndependentValue);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.DependentValue":
          XamlUserType xamlTypeByName40 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "DependentValue", "Double");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_49_DataPoint_DependentValue);
          xamlMember.Setter = new Setter(this.set_49_DataPoint_DependentValue);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.DependentValueStringFormat":
          XamlUserType xamlTypeByName41 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "DependentValueStringFormat", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_50_DataPoint_DependentValueStringFormat);
          xamlMember.Setter = new Setter(this.set_50_DataPoint_DependentValueStringFormat);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.FormattedDependentValue":
          XamlUserType xamlTypeByName42 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "FormattedDependentValue", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_51_DataPoint_FormattedDependentValue);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.FormattedIndependentValue":
          XamlUserType xamlTypeByName43 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "FormattedIndependentValue", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_52_DataPoint_FormattedIndependentValue);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IndependentValue":
          XamlUserType xamlTypeByName44 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "IndependentValue", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_53_DataPoint_IndependentValue);
          xamlMember.Setter = new Setter(this.set_53_DataPoint_IndependentValue);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IndependentValueStringFormat":
          XamlUserType xamlTypeByName45 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "IndependentValueStringFormat", "String");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_54_DataPoint_IndependentValueStringFormat);
          xamlMember.Setter = new Setter(this.set_54_DataPoint_IndependentValueStringFormat);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IsSelectionEnabled":
          XamlUserType xamlTypeByName46 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
          xamlMember = new XamlMember(this, "IsSelectionEnabled", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_47_DataPoint_IsSelectionEnabled);
          xamlMember.Setter = new Setter(this.set_47_DataPoint_IsSelectionEnabled);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.AnimationSequence":
          XamlUserType xamlTypeByName47 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "AnimationSequence", "WinRTXamlToolkit.Controls.DataVisualization.Charting.AnimationSequence");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_40_DataPointSeries_AnimationSequence);
          xamlMember.Setter = new Setter(this.set_40_DataPointSeries_AnimationSequence);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DataPointStyle":
          XamlUserType xamlTypeByName48 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "DataPointStyle", "Windows.UI.Xaml.Style");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_29_DataPointSeries_DataPointStyle);
          xamlMember.Setter = new Setter(this.set_29_DataPointSeries_DataPointStyle);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DependentValueBinding":
          XamlUserType xamlTypeByName49 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "DependentValueBinding", "Windows.UI.Xaml.Data.Binding");
          xamlMember.Getter = new Getter(this.get_27_DataPointSeries_DependentValueBinding);
          xamlMember.Setter = new Setter(this.set_27_DataPointSeries_DependentValueBinding);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DependentValuePath":
          XamlUserType xamlTypeByName50 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "DependentValuePath", "String");
          xamlMember.Getter = new Getter(this.get_37_DataPointSeries_DependentValuePath);
          xamlMember.Setter = new Setter(this.set_37_DataPointSeries_DependentValuePath);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IndependentValueBinding":
          XamlUserType xamlTypeByName51 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "IndependentValueBinding", "Windows.UI.Xaml.Data.Binding");
          xamlMember.Getter = new Getter(this.get_26_DataPointSeries_IndependentValueBinding);
          xamlMember.Setter = new Setter(this.set_26_DataPointSeries_IndependentValueBinding);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IndependentValuePath":
          XamlUserType xamlTypeByName52 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "IndependentValuePath", "String");
          xamlMember.Getter = new Getter(this.get_38_DataPointSeries_IndependentValuePath);
          xamlMember.Setter = new Setter(this.set_38_DataPointSeries_IndependentValuePath);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IsSelectionEnabled":
          XamlUserType xamlTypeByName53 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "IsSelectionEnabled", "Boolean");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_28_DataPointSeries_IsSelectionEnabled);
          xamlMember.Setter = new Setter(this.set_28_DataPointSeries_IsSelectionEnabled);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.ItemsSource":
          XamlUserType xamlTypeByName54 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "ItemsSource", "System.Collections.IEnumerable");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_39_DataPointSeries_ItemsSource);
          xamlMember.Setter = new Setter(this.set_39_DataPointSeries_ItemsSource);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.LegendItemStyle":
          XamlUserType xamlTypeByName55 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "LegendItemStyle", "Windows.UI.Xaml.Style");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_43_DataPointSeries_LegendItemStyle);
          xamlMember.Setter = new Setter(this.set_43_DataPointSeries_LegendItemStyle);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.SelectedItem":
          XamlUserType xamlTypeByName56 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "SelectedItem", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_42_DataPointSeries_SelectedItem);
          xamlMember.Setter = new Setter(this.set_42_DataPointSeries_SelectedItem);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.TransitionDuration":
          XamlUserType xamlTypeByName57 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "TransitionDuration", "TimeSpan");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_44_DataPointSeries_TransitionDuration);
          xamlMember.Setter = new Setter(this.set_44_DataPointSeries_TransitionDuration);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.TransitionEasingFunction":
          XamlUserType xamlTypeByName58 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
          xamlMember = new XamlMember(this, "TransitionEasingFunction", "Windows.UI.Xaml.Media.Animation.EasingFunctionBase");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_41_DataPointSeries_TransitionEasingFunction);
          xamlMember.Setter = new Setter(this.set_41_DataPointSeries_TransitionEasingFunction);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes.GlobalSeriesIndex":
          XamlUserType xamlTypeByName59 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes");
          xamlMember = new XamlMember(this, "GlobalSeriesIndex", "System.Nullable`1<Int32>");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_36_DataPointSingleSeriesWithAxes_GlobalSeriesIndex);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.DependentAxes":
          XamlUserType xamlTypeByName60 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
          xamlMember = new XamlMember(this, "DependentAxes", "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
          xamlMember.Getter = new Getter(this.get_15_IAxis_DependentAxes);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.Orientation":
          XamlUserType xamlTypeByName61 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
          xamlMember = new XamlMember(this, "Orientation", "WinRTXamlToolkit.Controls.DataVisualization.Charting.AxisOrientation");
          xamlMember.Getter = new Getter(this.get_13_IAxis_Orientation);
          xamlMember.Setter = new Setter(this.set_13_IAxis_Orientation);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.RegisteredListeners":
          XamlUserType xamlTypeByName62 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
          xamlMember = new XamlMember(this, "RegisteredListeners", "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>");
          xamlMember.Getter = new Getter(this.get_14_IAxis_RegisteredListeners);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries.LegendItems":
          XamlUserType xamlTypeByName63 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries");
          xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.ObservableCollection`1<Object>");
          xamlMember.Getter = new Getter(this.get_11_ISeries_LegendItems);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.ActualDependentRangeAxis":
          XamlUserType xamlTypeByName64 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
          xamlMember = new XamlMember(this, "ActualDependentRangeAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IRangeAxis");
          xamlMember.Getter = new Getter(this.get_35_LineAreaBaseSeries_ActualDependentRangeAxis);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.ActualIndependentAxis":
          XamlUserType xamlTypeByName65 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
          xamlMember = new XamlMember(this, "ActualIndependentAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
          xamlMember.Getter = new Getter(this.get_34_LineAreaBaseSeries_ActualIndependentAxis);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.DependentRangeAxis":
          XamlUserType xamlTypeByName66 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
          xamlMember = new XamlMember(this, "DependentRangeAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IRangeAxis");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_32_LineAreaBaseSeries_DependentRangeAxis);
          xamlMember.Setter = new Setter(this.set_32_LineAreaBaseSeries_DependentRangeAxis);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.IndependentAxis":
          XamlUserType xamlTypeByName67 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
          xamlMember = new XamlMember(this, "IndependentAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_33_LineAreaBaseSeries_IndependentAxis);
          xamlMember.Setter = new Setter(this.set_33_LineAreaBaseSeries_IndependentAxis);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries.Points":
          XamlUserType xamlTypeByName68 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries");
          xamlMember = new XamlMember(this, "Points", "Windows.UI.Xaml.Media.PointCollection");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_30_LineSeries_Points);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries.PolylineStyle":
          XamlUserType xamlTypeByName69 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries");
          xamlMember = new XamlMember(this, "PolylineStyle", "Windows.UI.Xaml.Style");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_31_LineSeries_PolylineStyle);
          xamlMember.Setter = new Setter(this.set_31_LineSeries_PolylineStyle);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.LegendItems":
          XamlUserType xamlTypeByName70 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
          xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.ObservableCollection`1<Object>");
          xamlMember.Getter = new Getter(this.get_46_Series_LegendItems);
          xamlMember.SetIsReadOnly();
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.SeriesHost":
          XamlUserType xamlTypeByName71 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
          xamlMember = new XamlMember(this, "SeriesHost", "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeriesHost");
          xamlMember.Getter = new Getter(this.get_45_Series_SeriesHost);
          xamlMember.Setter = new Setter(this.set_45_Series_SeriesHost);
          break;
        case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.Title":
          XamlUserType xamlTypeByName72 = (XamlUserType) this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
          xamlMember = new XamlMember(this, "Title", "Object");
          xamlMember.SetIsDependencyProperty();
          xamlMember.Getter = new Getter(this.get_25_Series_Title);
          xamlMember.Setter = new Setter(this.set_25_Series_Title);
          break;
      }
      return (IXamlMember) xamlMember;
    }
  }
}
