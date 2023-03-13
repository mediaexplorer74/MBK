using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using MobileBandSync.Common;
using MobileBandSync.Data;
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
using WinRTXamlToolkit.Controls.DataVisualization.WinRTXamlToolkit_Controls_DataVisualization_WindowsPhone_XamlTypeInfo;
using WinRTXamlToolkit.WinRTXamlToolkit_WindowsPhone_XamlTypeInfo;

namespace MobileBandSync.MobileBandSync_XamlTypeInfo;

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

	private List<IXamlMetadataProvider> OtherProviders
	{
		get
		{
			if (_otherProviders == null)
			{
				_otherProviders = new List<IXamlMetadataProvider>();
				IXamlMetadataProvider item = (IXamlMetadataProvider)(object)new WinRTXamlToolkit.Controls.DataVisualization.WinRTXamlToolkit_Controls_DataVisualization_WindowsPhone_XamlTypeInfo.XamlMetaDataProvider();
				_otherProviders.Add(item);
				item = (IXamlMetadataProvider)(object)new WinRTXamlToolkit.WinRTXamlToolkit_WindowsPhone_XamlTypeInfo.XamlMetaDataProvider();
				_otherProviders.Add(item);
			}
			return _otherProviders;
		}
	}

	public IXamlType GetXamlTypeByType(Type type)
	{
		if (_xamlTypeCacheByType.TryGetValue(type, out var value))
		{
			return value;
		}
		int num = LookupTypeIndexByType(type);
		if (num != -1)
		{
			value = CreateXamlType(num);
		}
		XamlUserType xamlUserType = value as XamlUserType;
		if (value == null || (xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType))
		{
			IXamlType val = CheckOtherMetadataProvidersForType(type);
			if (val != null && (val.IsConstructible || value == null))
			{
				value = val;
			}
		}
		if (value != null)
		{
			_xamlTypeCacheByName.Add(value.FullName, value);
			_xamlTypeCacheByType.Add(value.UnderlyingType, value);
		}
		return value;
	}

	public IXamlType GetXamlTypeByName(string typeName)
	{
		if (string.IsNullOrEmpty(typeName))
		{
			return null;
		}
		if (_xamlTypeCacheByName.TryGetValue(typeName, out var value))
		{
			return value;
		}
		int num = LookupTypeIndexByName(typeName);
		if (num != -1)
		{
			value = CreateXamlType(num);
		}
		XamlUserType xamlUserType = value as XamlUserType;
		if (value == null || (xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType))
		{
			IXamlType val = CheckOtherMetadataProvidersForName(typeName);
			if (val != null && (val.IsConstructible || value == null))
			{
				value = val;
			}
		}
		if (value != null)
		{
			_xamlTypeCacheByName.Add(value.FullName, value);
			_xamlTypeCacheByType.Add(value.UnderlyingType, value);
		}
		return value;
	}

	public IXamlMember GetMemberByLongName(string longMemberName)
	{
		if (string.IsNullOrEmpty(longMemberName))
		{
			return null;
		}
		if (_xamlMembers.TryGetValue(longMemberName, out var value))
		{
			return value;
		}
		value = CreateXamlMember(longMemberName);
		if (value != null)
		{
			_xamlMembers.Add(longMemberName, value);
		}
		return value;
	}

	private void InitTypeTables()
	{
		_typeNameTable = new string[59];
		_typeNameTable[0] = "MobileBandSync.HubPage";
		_typeNameTable[1] = "Windows.UI.Xaml.Controls.Page";
		_typeNameTable[2] = "Windows.UI.Xaml.Controls.UserControl";
		_typeNameTable[3] = "MobileBandSync.Common.NavigationHelper";
		_typeNameTable[4] = "Windows.UI.Xaml.DependencyObject";
		_typeNameTable[5] = "MobileBandSync.Common.ObservableDictionary";
		_typeNameTable[6] = "Object";
		_typeNameTable[7] = "String";
		_typeNameTable[8] = "MobileBandSync.Common.SyncViewModel";
		_typeNameTable[9] = "Windows.UI.Xaml.DispatcherTimer";
		_typeNameTable[10] = "Boolean";
		_typeNameTable[11] = "Windows.UI.Xaml.Controls.Primitives.ToggleButton";
		_typeNameTable[12] = "MobileBandSync.ItemPage";
		_typeNameTable[13] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart";
		_typeNameTable[14] = "Windows.UI.Xaml.Controls.Control";
		_typeNameTable[15] = "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries>";
		_typeNameTable[16] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries";
		_typeNameTable[17] = "System.Collections.ObjectModel.ObservableCollection`1<Object>";
		_typeNameTable[18] = "System.Collections.ObjectModel.Collection`1<Object>";
		_typeNameTable[19] = "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>";
		_typeNameTable[20] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis";
		_typeNameTable[21] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.AxisOrientation";
		_typeNameTable[22] = "System.Enum";
		_typeNameTable[23] = "System.ValueType";
		_typeNameTable[24] = "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>";
		_typeNameTable[25] = "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>";
		_typeNameTable[26] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener";
		_typeNameTable[27] = "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>";
		_typeNameTable[28] = "System.Collections.ObjectModel.ReadOnlyCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>";
		_typeNameTable[29] = "Windows.UI.Xaml.Style";
		_typeNameTable[30] = "System.Collections.ObjectModel.Collection`1<Windows.UI.Xaml.ResourceDictionary>";
		_typeNameTable[31] = "Windows.UI.Xaml.ResourceDictionary";
		_typeNameTable[32] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries";
		_typeNameTable[33] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>";
		_typeNameTable[34] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes";
		_typeNameTable[35] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeriesWithAxes";
		_typeNameTable[36] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries";
		_typeNameTable[37] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series";
		_typeNameTable[38] = "Windows.UI.Xaml.Data.Binding";
		_typeNameTable[39] = "Windows.UI.Xaml.Media.PointCollection";
		_typeNameTable[40] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.IRangeAxis";
		_typeNameTable[41] = "System.Nullable`1<Int32>";
		_typeNameTable[42] = "System.Collections.IEnumerable";
		_typeNameTable[43] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.AnimationSequence";
		_typeNameTable[44] = "Windows.UI.Xaml.Media.Animation.EasingFunctionBase";
		_typeNameTable[45] = "TimeSpan";
		_typeNameTable[46] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeriesHost";
		_typeNameTable[47] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint";
		_typeNameTable[48] = "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint";
		_typeNameTable[49] = "Double";
		_typeNameTable[50] = "MobileBandSync.SectionPage";
		_typeNameTable[51] = "Int32";
		_typeNameTable[52] = "Windows.Devices.Geolocation.GeoboundingBox";
		_typeNameTable[53] = "System.Threading.CancellationTokenSource";
		_typeNameTable[54] = "MobileBandSync.Data.WorkoutItem";
		_typeNameTable[55] = "Windows.UI.Xaml.Shapes.Line";
		_typeNameTable[56] = "Windows.UI.Xaml.Controls.Maps.MapIcon";
		_typeNameTable[57] = "MobileBandSync.SleepPage";
		_typeNameTable[58] = "Windows.Foundation.Size";
		_typeTable = new Type[59];
		_typeTable[0] = typeof(HubPage);
		_typeTable[1] = typeof(Page);
		_typeTable[2] = typeof(UserControl);
		_typeTable[3] = typeof(NavigationHelper);
		_typeTable[4] = typeof(DependencyObject);
		_typeTable[5] = typeof(ObservableDictionary);
		_typeTable[6] = typeof(object);
		_typeTable[7] = typeof(string);
		_typeTable[8] = typeof(SyncViewModel);
		_typeTable[9] = typeof(DispatcherTimer);
		_typeTable[10] = typeof(bool);
		_typeTable[11] = typeof(ToggleButton);
		_typeTable[12] = typeof(ItemPage);
		_typeTable[13] = typeof(Chart);
		_typeTable[14] = typeof(Control);
		_typeTable[15] = typeof(Collection<ISeries>);
		_typeTable[16] = typeof(ISeries);
		_typeTable[17] = typeof(ObservableCollection<object>);
		_typeTable[18] = typeof(Collection<object>);
		_typeTable[19] = typeof(Collection<IAxis>);
		_typeTable[20] = typeof(IAxis);
		_typeTable[21] = typeof(AxisOrientation);
		_typeTable[22] = typeof(Enum);
		_typeTable[23] = typeof(ValueType);
		_typeTable[24] = typeof(ObservableCollection<IAxisListener>);
		_typeTable[25] = typeof(Collection<IAxisListener>);
		_typeTable[26] = typeof(IAxisListener);
		_typeTable[27] = typeof(ObservableCollection<IAxis>);
		_typeTable[28] = typeof(ReadOnlyCollection<IAxis>);
		_typeTable[29] = typeof(Style);
		_typeTable[30] = typeof(Collection<ResourceDictionary>);
		_typeTable[31] = typeof(ResourceDictionary);
		_typeTable[32] = typeof(LineSeries);
		_typeTable[33] = typeof(LineAreaBaseSeries<LineDataPoint>);
		_typeTable[34] = typeof(DataPointSingleSeriesWithAxes);
		_typeTable[35] = typeof(DataPointSeriesWithAxes);
		_typeTable[36] = typeof(DataPointSeries);
		_typeTable[37] = typeof(Series);
		_typeTable[38] = typeof(Binding);
		_typeTable[39] = typeof(PointCollection);
		_typeTable[40] = typeof(IRangeAxis);
		_typeTable[41] = typeof(int?);
		_typeTable[42] = typeof(IEnumerable);
		_typeTable[43] = typeof(AnimationSequence);
		_typeTable[44] = typeof(EasingFunctionBase);
		_typeTable[45] = typeof(TimeSpan);
		_typeTable[46] = typeof(ISeriesHost);
		_typeTable[47] = typeof(LineDataPoint);
		_typeTable[48] = typeof(DataPoint);
		_typeTable[49] = typeof(double);
		_typeTable[50] = typeof(SectionPage);
		_typeTable[51] = typeof(int);
		_typeTable[52] = typeof(GeoboundingBox);
		_typeTable[53] = typeof(CancellationTokenSource);
		_typeTable[54] = typeof(WorkoutItem);
		_typeTable[55] = typeof(Line);
		_typeTable[56] = typeof(MapIcon);
		_typeTable[57] = typeof(SleepPage);
		_typeTable[58] = typeof(Size);
	}

	private int LookupTypeIndexByName(string typeName)
	{
		if (_typeNameTable == null)
		{
			InitTypeTables();
		}
		for (int i = 0; i < _typeNameTable.Length; i++)
		{
			if (string.CompareOrdinal(_typeNameTable[i], typeName) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	private int LookupTypeIndexByType(Type type)
	{
		if (_typeTable == null)
		{
			InitTypeTables();
		}
		for (int i = 0; i < _typeTable.Length; i++)
		{
			if ((object)type == _typeTable[i])
			{
				return i;
			}
		}
		return -1;
	}

	private object Activate_0_HubPage()
	{
		return new HubPage();
	}

	private object Activate_5_ObservableDictionary()
	{
		return new ObservableDictionary();
	}

	private object Activate_8_SyncViewModel()
	{
		return new SyncViewModel();
	}

	private object Activate_12_ItemPage()
	{
		return new ItemPage();
	}

	private object Activate_13_Chart()
	{
		return new Chart();
	}

	private object Activate_15_Collection()
	{
		return new Collection<ISeries>();
	}

	private object Activate_17_ObservableCollection()
	{
		return new ObservableCollection<object>();
	}

	private object Activate_18_Collection()
	{
		return new Collection<object>();
	}

	private object Activate_19_Collection()
	{
		return new Collection<IAxis>();
	}

	private object Activate_24_ObservableCollection()
	{
		return new ObservableCollection<IAxisListener>();
	}

	private object Activate_25_Collection()
	{
		return new Collection<IAxisListener>();
	}

	private object Activate_27_ObservableCollection()
	{
		return new ObservableCollection<IAxis>();
	}

	private object Activate_30_Collection()
	{
		return new Collection<ResourceDictionary>();
	}

	private object Activate_32_LineSeries()
	{
		return new LineSeries();
	}

	private object Activate_47_LineDataPoint()
	{
		return new LineDataPoint();
	}

	private object Activate_50_SectionPage()
	{
		return new SectionPage();
	}

	private object Activate_53_CancellationTokenSource()
	{
		return new CancellationTokenSource();
	}

	private object Activate_54_WorkoutItem()
	{
		return new WorkoutItem();
	}

	private object Activate_57_SleepPage()
	{
		return new SleepPage();
	}

	private void MapAdd_5_ObservableDictionary(object instance, object key, object item)
	{
		IDictionary<string, object> obj = (IDictionary<string, object>)instance;
		string key2 = (string)key;
		obj.Add(key2, item);
	}

	private void VectorAdd_15_Collection(object instance, object item)
	{
		ICollection<ISeries> obj = (ICollection<ISeries>)instance;
		ISeries item2 = (ISeries)item;
		obj.Add(item2);
	}

	private void VectorAdd_17_ObservableCollection(object instance, object item)
	{
		((ICollection<object>)instance).Add(item);
	}

	private void VectorAdd_18_Collection(object instance, object item)
	{
		((ICollection<object>)instance).Add(item);
	}

	private void VectorAdd_19_Collection(object instance, object item)
	{
		ICollection<IAxis> obj = (ICollection<IAxis>)instance;
		IAxis item2 = (IAxis)item;
		obj.Add(item2);
	}

	private void VectorAdd_24_ObservableCollection(object instance, object item)
	{
		ICollection<IAxisListener> obj = (ICollection<IAxisListener>)instance;
		IAxisListener item2 = (IAxisListener)item;
		obj.Add(item2);
	}

	private void VectorAdd_25_Collection(object instance, object item)
	{
		ICollection<IAxisListener> obj = (ICollection<IAxisListener>)instance;
		IAxisListener item2 = (IAxisListener)item;
		obj.Add(item2);
	}

	private void VectorAdd_27_ObservableCollection(object instance, object item)
	{
		ICollection<IAxis> obj = (ICollection<IAxis>)instance;
		IAxis item2 = (IAxis)item;
		obj.Add(item2);
	}

	private void VectorAdd_28_ReadOnlyCollection(object instance, object item)
	{
		ICollection<IAxis> obj = (ICollection<IAxis>)instance;
		IAxis item2 = (IAxis)item;
		obj.Add(item2);
	}

	private void VectorAdd_30_Collection(object instance, object item)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		ICollection<ResourceDictionary> obj = (ICollection<ResourceDictionary>)instance;
		ResourceDictionary item2 = (ResourceDictionary)item;
		obj.Add(item2);
	}

	private IXamlType CreateXamlType(int typeIndex)
	{
		XamlSystemBaseType result = null;
		string fullName = _typeNameTable[typeIndex];
		Type type = _typeTable[typeIndex];
		switch (typeIndex)
		{
		case 0:
		{
			XamlUserType xamlUserType32 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
			xamlUserType32.Activator = Activate_0_HubPage;
			xamlUserType32.AddMemberName("NavigationHelper");
			xamlUserType32.AddMemberName("DefaultViewModel");
			xamlUserType32.AddMemberName("SyncView");
			xamlUserType32.AddMemberName("DeviceTimer");
			xamlUserType32.AddMemberName("MapServiceToken");
			xamlUserType32.AddMemberName("FilterAccepted");
			xamlUserType32.AddMemberName("MapPickerInitialized");
			xamlUserType32.AddMemberName("ToggleFilter");
			xamlUserType32.SetIsLocalType();
			result = xamlUserType32;
			break;
		}
		case 1:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 2:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 3:
		{
			XamlUserType xamlUserType31 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Windows.UI.Xaml.DependencyObject"));
			xamlUserType31.SetIsReturnTypeStub();
			xamlUserType31.SetIsLocalType();
			result = xamlUserType31;
			break;
		}
		case 4:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 5:
		{
			XamlUserType xamlUserType30 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			xamlUserType30.DictionaryAdd = MapAdd_5_ObservableDictionary;
			xamlUserType30.SetIsReturnTypeStub();
			xamlUserType30.SetIsLocalType();
			result = xamlUserType30;
			break;
		}
		case 6:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 7:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 8:
		{
			XamlUserType xamlUserType29 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			xamlUserType29.SetIsReturnTypeStub();
			xamlUserType29.SetIsLocalType();
			result = xamlUserType29;
			break;
		}
		case 9:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 10:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 11:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 12:
		{
			XamlUserType xamlUserType28 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
			xamlUserType28.Activator = Activate_12_ItemPage;
			xamlUserType28.AddMemberName("NavigationHelper");
			xamlUserType28.AddMemberName("DefaultViewModel");
			xamlUserType28.SetIsLocalType();
			result = xamlUserType28;
			break;
		}
		case 13:
		{
			XamlUserType xamlUserType27 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
			xamlUserType27.Activator = Activate_13_Chart;
			xamlUserType27.SetContentPropertyName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Series");
			xamlUserType27.AddMemberName("Series");
			xamlUserType27.AddMemberName("Axes");
			xamlUserType27.AddMemberName("ActualAxes");
			xamlUserType27.AddMemberName("ChartAreaStyle");
			xamlUserType27.AddMemberName("LegendItems");
			xamlUserType27.AddMemberName("LegendStyle");
			xamlUserType27.AddMemberName("LegendTitle");
			xamlUserType27.AddMemberName("PlotAreaStyle");
			xamlUserType27.AddMemberName("Palette");
			xamlUserType27.AddMemberName("Title");
			xamlUserType27.AddMemberName("TitleStyle");
			result = xamlUserType27;
			break;
		}
		case 14:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 15:
		{
			XamlUserType xamlUserType26 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			xamlUserType26.CollectionAdd = VectorAdd_15_Collection;
			xamlUserType26.SetIsReturnTypeStub();
			result = xamlUserType26;
			break;
		}
		case 16:
		{
			XamlUserType xamlUserType25 = new XamlUserType(this, fullName, type, null);
			xamlUserType25.AddMemberName("LegendItems");
			result = xamlUserType25;
			break;
		}
		case 17:
		{
			XamlUserType xamlUserType24 = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<Object>"));
			xamlUserType24.CollectionAdd = VectorAdd_17_ObservableCollection;
			xamlUserType24.SetIsReturnTypeStub();
			result = xamlUserType24;
			break;
		}
		case 18:
			result = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"))
			{
				Activator = Activate_18_Collection,
				CollectionAdd = VectorAdd_18_Collection
			};
			break;
		case 19:
			result = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"))
			{
				Activator = Activate_19_Collection,
				CollectionAdd = VectorAdd_19_Collection
			};
			break;
		case 20:
		{
			XamlUserType xamlUserType23 = new XamlUserType(this, fullName, type, null);
			xamlUserType23.AddMemberName("Orientation");
			xamlUserType23.AddMemberName("RegisteredListeners");
			xamlUserType23.AddMemberName("DependentAxes");
			result = xamlUserType23;
			break;
		}
		case 21:
		{
			XamlUserType xamlUserType22 = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.Enum"));
			xamlUserType22.AddEnumValue("None", AxisOrientation.None);
			xamlUserType22.AddEnumValue("X", AxisOrientation.X);
			xamlUserType22.AddEnumValue("Y", AxisOrientation.Y);
			result = xamlUserType22;
			break;
		}
		case 22:
			result = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.ValueType"));
			break;
		case 23:
			result = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			break;
		case 24:
		{
			XamlUserType xamlUserType21 = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>"));
			xamlUserType21.CollectionAdd = VectorAdd_24_ObservableCollection;
			xamlUserType21.SetIsReturnTypeStub();
			result = xamlUserType21;
			break;
		}
		case 25:
			result = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"))
			{
				Activator = Activate_25_Collection,
				CollectionAdd = VectorAdd_25_Collection
			};
			break;
		case 26:
			result = new XamlUserType(this, fullName, type, null);
			break;
		case 27:
		{
			XamlUserType xamlUserType20 = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>"));
			xamlUserType20.CollectionAdd = VectorAdd_27_ObservableCollection;
			xamlUserType20.SetIsReturnTypeStub();
			result = xamlUserType20;
			break;
		}
		case 28:
		{
			XamlUserType xamlUserType19 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			xamlUserType19.CollectionAdd = VectorAdd_28_ReadOnlyCollection;
			xamlUserType19.SetIsReturnTypeStub();
			result = xamlUserType19;
			break;
		}
		case 29:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 30:
		{
			XamlUserType xamlUserType18 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			xamlUserType18.CollectionAdd = VectorAdd_30_Collection;
			xamlUserType18.SetIsReturnTypeStub();
			result = xamlUserType18;
			break;
		}
		case 31:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 32:
		{
			XamlUserType xamlUserType17 = new XamlUserType(this, fullName, type, GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>"));
			xamlUserType17.Activator = Activate_32_LineSeries;
			xamlUserType17.AddMemberName("Points");
			xamlUserType17.AddMemberName("PolylineStyle");
			result = xamlUserType17;
			break;
		}
		case 33:
		{
			XamlUserType xamlUserType16 = new XamlUserType(this, fullName, type, GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes"));
			xamlUserType16.AddMemberName("DependentRangeAxis");
			xamlUserType16.AddMemberName("IndependentAxis");
			xamlUserType16.AddMemberName("ActualIndependentAxis");
			xamlUserType16.AddMemberName("ActualDependentRangeAxis");
			result = xamlUserType16;
			break;
		}
		case 34:
		{
			XamlUserType xamlUserType15 = new XamlUserType(this, fullName, type, GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeriesWithAxes"));
			xamlUserType15.AddMemberName("GlobalSeriesIndex");
			result = xamlUserType15;
			break;
		}
		case 35:
			result = new XamlUserType(this, fullName, type, GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries"));
			break;
		case 36:
		{
			XamlUserType xamlUserType14 = new XamlUserType(this, fullName, type, GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series"));
			xamlUserType14.AddMemberName("IndependentValueBinding");
			xamlUserType14.AddMemberName("DependentValueBinding");
			xamlUserType14.AddMemberName("IsSelectionEnabled");
			xamlUserType14.AddMemberName("DataPointStyle");
			xamlUserType14.AddMemberName("DependentValuePath");
			xamlUserType14.AddMemberName("IndependentValuePath");
			xamlUserType14.AddMemberName("ItemsSource");
			xamlUserType14.AddMemberName("AnimationSequence");
			xamlUserType14.AddMemberName("TransitionEasingFunction");
			xamlUserType14.AddMemberName("SelectedItem");
			xamlUserType14.AddMemberName("LegendItemStyle");
			xamlUserType14.AddMemberName("TransitionDuration");
			result = xamlUserType14;
			break;
		}
		case 37:
		{
			XamlUserType xamlUserType13 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
			xamlUserType13.AddMemberName("Title");
			xamlUserType13.AddMemberName("SeriesHost");
			xamlUserType13.AddMemberName("LegendItems");
			result = xamlUserType13;
			break;
		}
		case 38:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 39:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 40:
		{
			XamlUserType xamlUserType12 = new XamlUserType(this, fullName, type, null);
			xamlUserType12.SetIsReturnTypeStub();
			result = xamlUserType12;
			break;
		}
		case 41:
		{
			XamlUserType xamlUserType11 = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.ValueType"));
			xamlUserType11.SetIsReturnTypeStub();
			result = xamlUserType11;
			break;
		}
		case 42:
		{
			XamlUserType xamlUserType10 = new XamlUserType(this, fullName, type, null);
			xamlUserType10.SetIsReturnTypeStub();
			result = xamlUserType10;
			break;
		}
		case 43:
		{
			XamlUserType xamlUserType9 = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.Enum"));
			xamlUserType9.AddEnumValue("Simultaneous", AnimationSequence.Simultaneous);
			xamlUserType9.AddEnumValue("FirstToLast", AnimationSequence.FirstToLast);
			xamlUserType9.AddEnumValue("LastToFirst", AnimationSequence.LastToFirst);
			result = xamlUserType9;
			break;
		}
		case 44:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 45:
		{
			XamlUserType xamlUserType8 = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.ValueType"));
			xamlUserType8.SetIsReturnTypeStub();
			result = xamlUserType8;
			break;
		}
		case 46:
		{
			XamlUserType xamlUserType7 = new XamlUserType(this, fullName, type, null);
			xamlUserType7.SetIsReturnTypeStub();
			result = xamlUserType7;
			break;
		}
		case 47:
			result = new XamlUserType(this, fullName, type, GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint"))
			{
				Activator = Activate_47_LineDataPoint
			};
			break;
		case 48:
		{
			XamlUserType xamlUserType6 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
			xamlUserType6.AddMemberName("IsSelectionEnabled");
			xamlUserType6.AddMemberName("ActualDependentValue");
			xamlUserType6.AddMemberName("DependentValue");
			xamlUserType6.AddMemberName("DependentValueStringFormat");
			xamlUserType6.AddMemberName("FormattedDependentValue");
			xamlUserType6.AddMemberName("FormattedIndependentValue");
			xamlUserType6.AddMemberName("IndependentValue");
			xamlUserType6.AddMemberName("IndependentValueStringFormat");
			xamlUserType6.AddMemberName("ActualIndependentValue");
			result = xamlUserType6;
			break;
		}
		case 49:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 50:
		{
			XamlUserType xamlUserType5 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
			xamlUserType5.Activator = Activate_50_SectionPage;
			xamlUserType5.AddMemberName("NavigationHelper");
			xamlUserType5.AddMemberName("DefaultViewModel");
			xamlUserType5.AddMemberName("currentWorkoutId");
			xamlUserType5.AddMemberName("Viewport");
			xamlUserType5.AddMemberName("MapInitialized");
			xamlUserType5.AddMemberName("CancelTokenSource");
			xamlUserType5.AddMemberName("CurrentWorkout");
			xamlUserType5.AddMemberName("ViewInitialized");
			xamlUserType5.AddMemberName("chartLine");
			xamlUserType5.AddMemberName("PosNeedleIcon");
			xamlUserType5.SetIsLocalType();
			result = xamlUserType5;
			break;
		}
		case 51:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 52:
		{
			XamlUserType xamlUserType4 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			xamlUserType4.SetIsReturnTypeStub();
			result = xamlUserType4;
			break;
		}
		case 53:
		{
			XamlUserType xamlUserType3 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			xamlUserType3.SetIsReturnTypeStub();
			result = xamlUserType3;
			break;
		}
		case 54:
		{
			XamlUserType xamlUserType2 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"));
			xamlUserType2.SetIsReturnTypeStub();
			xamlUserType2.SetIsLocalType();
			result = xamlUserType2;
			break;
		}
		case 55:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 56:
			result = new XamlSystemBaseType(fullName, type);
			break;
		case 57:
		{
			XamlUserType xamlUserType = new XamlUserType(this, fullName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
			xamlUserType.Activator = Activate_57_SleepPage;
			xamlUserType.AddMemberName("NavigationHelper");
			xamlUserType.AddMemberName("DefaultViewModel");
			xamlUserType.AddMemberName("currentWorkoutId");
			xamlUserType.AddMemberName("CancelTokenSource");
			xamlUserType.AddMemberName("CurrentWorkout");
			xamlUserType.AddMemberName("CanvasSize");
			xamlUserType.SetIsLocalType();
			result = xamlUserType;
			break;
		}
		case 58:
			result = new XamlSystemBaseType(fullName, type);
			break;
		}
		return (IXamlType)(object)result;
	}

	private IXamlType CheckOtherMetadataProvidersForName(string typeName)
	{
		IXamlType val = null;
		IXamlType result = null;
		foreach (IXamlMetadataProvider otherProvider in OtherProviders)
		{
			val = otherProvider.GetXamlType(typeName);
			if (val != null)
			{
				if (val.IsConstructible)
				{
					return val;
				}
				result = val;
			}
		}
		return result;
	}

	private IXamlType CheckOtherMetadataProvidersForType(Type type)
	{
		IXamlType val = null;
		IXamlType result = null;
		foreach (IXamlMetadataProvider otherProvider in OtherProviders)
		{
			val = otherProvider.GetXamlType(type);
			if (val != null)
			{
				if (val.IsConstructible)
				{
					return val;
				}
				result = val;
			}
		}
		return result;
	}

	private object get_0_HubPage_NavigationHelper(object instance)
	{
		return ((HubPage)instance).NavigationHelper;
	}

	private object get_1_HubPage_DefaultViewModel(object instance)
	{
		return ((HubPage)instance).DefaultViewModel;
	}

	private object get_2_HubPage_SyncView(object instance)
	{
		return ((HubPage)instance).SyncView;
	}

	private void set_2_HubPage_SyncView(object instance, object Value)
	{
		((HubPage)instance).SyncView = (SyncViewModel)Value;
	}

	private object get_3_HubPage_DeviceTimer(object instance)
	{
		return ((HubPage)instance).DeviceTimer;
	}

	private object get_4_HubPage_MapServiceToken(object instance)
	{
		return ((HubPage)instance).MapServiceToken;
	}

	private object get_5_HubPage_FilterAccepted(object instance)
	{
		return ((HubPage)instance).FilterAccepted;
	}

	private object get_6_HubPage_MapPickerInitialized(object instance)
	{
		return ((HubPage)instance).MapPickerInitialized;
	}

	private object get_7_HubPage_ToggleFilter(object instance)
	{
		return ((HubPage)instance).ToggleFilter;
	}

	private object get_8_ItemPage_NavigationHelper(object instance)
	{
		return ((ItemPage)instance).NavigationHelper;
	}

	private object get_9_ItemPage_DefaultViewModel(object instance)
	{
		return ((ItemPage)instance).DefaultViewModel;
	}

	private object get_10_Chart_Series(object instance)
	{
		return ((Chart)instance).Series;
	}

	private void set_10_Chart_Series(object instance, object Value)
	{
		((Chart)instance).Series = (Collection<ISeries>)Value;
	}

	private object get_11_ISeries_LegendItems(object instance)
	{
		return ((ISeries)instance).LegendItems;
	}

	private object get_12_Chart_Axes(object instance)
	{
		return ((Chart)instance).Axes;
	}

	private void set_12_Chart_Axes(object instance, object Value)
	{
		((Chart)instance).Axes = (Collection<IAxis>)Value;
	}

	private object get_13_IAxis_Orientation(object instance)
	{
		return ((IAxis)instance).Orientation;
	}

	private void set_13_IAxis_Orientation(object instance, object Value)
	{
		((IAxis)instance).Orientation = (AxisOrientation)Value;
	}

	private object get_14_IAxis_RegisteredListeners(object instance)
	{
		return ((IAxis)instance).RegisteredListeners;
	}

	private object get_15_IAxis_DependentAxes(object instance)
	{
		return ((IAxis)instance).DependentAxes;
	}

	private object get_16_Chart_ActualAxes(object instance)
	{
		return ((Chart)instance).ActualAxes;
	}

	private object get_17_Chart_ChartAreaStyle(object instance)
	{
		return ((Chart)instance).ChartAreaStyle;
	}

	private void set_17_Chart_ChartAreaStyle(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((Chart)instance).ChartAreaStyle = (Style)Value;
	}

	private object get_18_Chart_LegendItems(object instance)
	{
		return ((Chart)instance).LegendItems;
	}

	private object get_19_Chart_LegendStyle(object instance)
	{
		return ((Chart)instance).LegendStyle;
	}

	private void set_19_Chart_LegendStyle(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((Chart)instance).LegendStyle = (Style)Value;
	}

	private object get_20_Chart_LegendTitle(object instance)
	{
		return ((Chart)instance).LegendTitle;
	}

	private void set_20_Chart_LegendTitle(object instance, object Value)
	{
		((Chart)instance).LegendTitle = Value;
	}

	private object get_21_Chart_PlotAreaStyle(object instance)
	{
		return ((Chart)instance).PlotAreaStyle;
	}

	private void set_21_Chart_PlotAreaStyle(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((Chart)instance).PlotAreaStyle = (Style)Value;
	}

	private object get_22_Chart_Palette(object instance)
	{
		return ((Chart)instance).Palette;
	}

	private void set_22_Chart_Palette(object instance, object Value)
	{
		((Chart)instance).Palette = (Collection<ResourceDictionary>)Value;
	}

	private object get_23_Chart_Title(object instance)
	{
		return ((Chart)instance).Title;
	}

	private void set_23_Chart_Title(object instance, object Value)
	{
		((Chart)instance).Title = Value;
	}

	private object get_24_Chart_TitleStyle(object instance)
	{
		return ((Chart)instance).TitleStyle;
	}

	private void set_24_Chart_TitleStyle(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((Chart)instance).TitleStyle = (Style)Value;
	}

	private object get_25_Series_Title(object instance)
	{
		return ((Series)instance).Title;
	}

	private void set_25_Series_Title(object instance, object Value)
	{
		((Series)instance).Title = Value;
	}

	private object get_26_DataPointSeries_IndependentValueBinding(object instance)
	{
		return ((DataPointSeries)instance).IndependentValueBinding;
	}

	private void set_26_DataPointSeries_IndependentValueBinding(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((DataPointSeries)instance).IndependentValueBinding = (Binding)Value;
	}

	private object get_27_DataPointSeries_DependentValueBinding(object instance)
	{
		return ((DataPointSeries)instance).DependentValueBinding;
	}

	private void set_27_DataPointSeries_DependentValueBinding(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((DataPointSeries)instance).DependentValueBinding = (Binding)Value;
	}

	private object get_28_DataPointSeries_IsSelectionEnabled(object instance)
	{
		return ((DataPointSeries)instance).IsSelectionEnabled;
	}

	private void set_28_DataPointSeries_IsSelectionEnabled(object instance, object Value)
	{
		((DataPointSeries)instance).IsSelectionEnabled = (bool)Value;
	}

	private object get_29_DataPointSeries_DataPointStyle(object instance)
	{
		return ((DataPointSeries)instance).DataPointStyle;
	}

	private void set_29_DataPointSeries_DataPointStyle(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((DataPointSeries)instance).DataPointStyle = (Style)Value;
	}

	private object get_30_LineSeries_Points(object instance)
	{
		return ((LineSeries)instance).Points;
	}

	private object get_31_LineSeries_PolylineStyle(object instance)
	{
		return ((LineSeries)instance).PolylineStyle;
	}

	private void set_31_LineSeries_PolylineStyle(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((LineSeries)instance).PolylineStyle = (Style)Value;
	}

	private object get_32_LineAreaBaseSeries_DependentRangeAxis(object instance)
	{
		return ((LineAreaBaseSeries<LineDataPoint>)instance).DependentRangeAxis;
	}

	private void set_32_LineAreaBaseSeries_DependentRangeAxis(object instance, object Value)
	{
		((LineAreaBaseSeries<LineDataPoint>)instance).DependentRangeAxis = (IRangeAxis)Value;
	}

	private object get_33_LineAreaBaseSeries_IndependentAxis(object instance)
	{
		return ((LineAreaBaseSeries<LineDataPoint>)instance).IndependentAxis;
	}

	private void set_33_LineAreaBaseSeries_IndependentAxis(object instance, object Value)
	{
		((LineAreaBaseSeries<LineDataPoint>)instance).IndependentAxis = (IAxis)Value;
	}

	private object get_34_LineAreaBaseSeries_ActualIndependentAxis(object instance)
	{
		return ((LineAreaBaseSeries<LineDataPoint>)instance).ActualIndependentAxis;
	}

	private object get_35_LineAreaBaseSeries_ActualDependentRangeAxis(object instance)
	{
		return ((LineAreaBaseSeries<LineDataPoint>)instance).ActualDependentRangeAxis;
	}

	private object get_36_DataPointSingleSeriesWithAxes_GlobalSeriesIndex(object instance)
	{
		return ((DataPointSingleSeriesWithAxes)instance).GlobalSeriesIndex;
	}

	private object get_37_DataPointSeries_DependentValuePath(object instance)
	{
		return ((DataPointSeries)instance).DependentValuePath;
	}

	private void set_37_DataPointSeries_DependentValuePath(object instance, object Value)
	{
		((DataPointSeries)instance).DependentValuePath = (string)Value;
	}

	private object get_38_DataPointSeries_IndependentValuePath(object instance)
	{
		return ((DataPointSeries)instance).IndependentValuePath;
	}

	private void set_38_DataPointSeries_IndependentValuePath(object instance, object Value)
	{
		((DataPointSeries)instance).IndependentValuePath = (string)Value;
	}

	private object get_39_DataPointSeries_ItemsSource(object instance)
	{
		return ((DataPointSeries)instance).ItemsSource;
	}

	private void set_39_DataPointSeries_ItemsSource(object instance, object Value)
	{
		((DataPointSeries)instance).ItemsSource = (IEnumerable)Value;
	}

	private object get_40_DataPointSeries_AnimationSequence(object instance)
	{
		return ((DataPointSeries)instance).AnimationSequence;
	}

	private void set_40_DataPointSeries_AnimationSequence(object instance, object Value)
	{
		((DataPointSeries)instance).AnimationSequence = (AnimationSequence)Value;
	}

	private object get_41_DataPointSeries_TransitionEasingFunction(object instance)
	{
		return ((DataPointSeries)instance).TransitionEasingFunction;
	}

	private void set_41_DataPointSeries_TransitionEasingFunction(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((DataPointSeries)instance).TransitionEasingFunction = (EasingFunctionBase)Value;
	}

	private object get_42_DataPointSeries_SelectedItem(object instance)
	{
		return ((DataPointSeries)instance).SelectedItem;
	}

	private void set_42_DataPointSeries_SelectedItem(object instance, object Value)
	{
		((DataPointSeries)instance).SelectedItem = Value;
	}

	private object get_43_DataPointSeries_LegendItemStyle(object instance)
	{
		return ((DataPointSeries)instance).LegendItemStyle;
	}

	private void set_43_DataPointSeries_LegendItemStyle(object instance, object Value)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		((DataPointSeries)instance).LegendItemStyle = (Style)Value;
	}

	private object get_44_DataPointSeries_TransitionDuration(object instance)
	{
		return ((DataPointSeries)instance).TransitionDuration;
	}

	private void set_44_DataPointSeries_TransitionDuration(object instance, object Value)
	{
		((DataPointSeries)instance).TransitionDuration = (TimeSpan)Value;
	}

	private object get_45_Series_SeriesHost(object instance)
	{
		return ((Series)instance).SeriesHost;
	}

	private void set_45_Series_SeriesHost(object instance, object Value)
	{
		((Series)instance).SeriesHost = (ISeriesHost)Value;
	}

	private object get_46_Series_LegendItems(object instance)
	{
		return ((Series)instance).LegendItems;
	}

	private object get_47_DataPoint_IsSelectionEnabled(object instance)
	{
		return ((DataPoint)instance).IsSelectionEnabled;
	}

	private void set_47_DataPoint_IsSelectionEnabled(object instance, object Value)
	{
		((DataPoint)instance).IsSelectionEnabled = (bool)Value;
	}

	private object get_48_DataPoint_ActualDependentValue(object instance)
	{
		return ((DataPoint)instance).ActualDependentValue;
	}

	private void set_48_DataPoint_ActualDependentValue(object instance, object Value)
	{
		((DataPoint)instance).ActualDependentValue = (double)Value;
	}

	private object get_49_DataPoint_DependentValue(object instance)
	{
		return ((DataPoint)instance).DependentValue;
	}

	private void set_49_DataPoint_DependentValue(object instance, object Value)
	{
		((DataPoint)instance).DependentValue = (double)Value;
	}

	private object get_50_DataPoint_DependentValueStringFormat(object instance)
	{
		return ((DataPoint)instance).DependentValueStringFormat;
	}

	private void set_50_DataPoint_DependentValueStringFormat(object instance, object Value)
	{
		((DataPoint)instance).DependentValueStringFormat = (string)Value;
	}

	private object get_51_DataPoint_FormattedDependentValue(object instance)
	{
		return ((DataPoint)instance).FormattedDependentValue;
	}

	private object get_52_DataPoint_FormattedIndependentValue(object instance)
	{
		return ((DataPoint)instance).FormattedIndependentValue;
	}

	private object get_53_DataPoint_IndependentValue(object instance)
	{
		return ((DataPoint)instance).IndependentValue;
	}

	private void set_53_DataPoint_IndependentValue(object instance, object Value)
	{
		((DataPoint)instance).IndependentValue = Value;
	}

	private object get_54_DataPoint_IndependentValueStringFormat(object instance)
	{
		return ((DataPoint)instance).IndependentValueStringFormat;
	}

	private void set_54_DataPoint_IndependentValueStringFormat(object instance, object Value)
	{
		((DataPoint)instance).IndependentValueStringFormat = (string)Value;
	}

	private object get_55_DataPoint_ActualIndependentValue(object instance)
	{
		return ((DataPoint)instance).ActualIndependentValue;
	}

	private void set_55_DataPoint_ActualIndependentValue(object instance, object Value)
	{
		((DataPoint)instance).ActualIndependentValue = Value;
	}

	private object get_56_SectionPage_NavigationHelper(object instance)
	{
		return ((SectionPage)instance).NavigationHelper;
	}

	private object get_57_SectionPage_DefaultViewModel(object instance)
	{
		return ((SectionPage)instance).DefaultViewModel;
	}

	private object get_58_SectionPage_currentWorkoutId(object instance)
	{
		return ((SectionPage)instance).currentWorkoutId;
	}

	private object get_59_SectionPage_Viewport(object instance)
	{
		return ((SectionPage)instance).Viewport;
	}

	private object get_60_SectionPage_MapInitialized(object instance)
	{
		return ((SectionPage)instance).MapInitialized;
	}

	private object get_61_SectionPage_CancelTokenSource(object instance)
	{
		return ((SectionPage)instance).CancelTokenSource;
	}

	private object get_62_SectionPage_CurrentWorkout(object instance)
	{
		return ((SectionPage)instance).CurrentWorkout;
	}

	private object get_63_SectionPage_ViewInitialized(object instance)
	{
		return ((SectionPage)instance).ViewInitialized;
	}

	private object get_64_SectionPage_chartLine(object instance)
	{
		return ((SectionPage)instance).chartLine;
	}

	private object get_65_SectionPage_PosNeedleIcon(object instance)
	{
		return ((SectionPage)instance).PosNeedleIcon;
	}

	private object get_66_SleepPage_NavigationHelper(object instance)
	{
		return ((SleepPage)instance).NavigationHelper;
	}

	private object get_67_SleepPage_DefaultViewModel(object instance)
	{
		return ((SleepPage)instance).DefaultViewModel;
	}

	private object get_68_SleepPage_currentWorkoutId(object instance)
	{
		return ((SleepPage)instance).currentWorkoutId;
	}

	private object get_69_SleepPage_CancelTokenSource(object instance)
	{
		return ((SleepPage)instance).CancelTokenSource;
	}

	private object get_70_SleepPage_CurrentWorkout(object instance)
	{
		return ((SleepPage)instance).CurrentWorkout;
	}

	private object get_71_SleepPage_CanvasSize(object instance)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((SleepPage)instance).CanvasSize;
	}

	private IXamlMember CreateXamlMember(string longMemberName)
	{
		XamlMember xamlMember = null;
		switch (longMemberName)
		{
		case "MobileBandSync.HubPage.NavigationHelper":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.HubPage");
			xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
			xamlMember.Getter = get_0_HubPage_NavigationHelper;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.HubPage.DefaultViewModel":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.HubPage");
			xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
			xamlMember.Getter = get_1_HubPage_DefaultViewModel;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.HubPage.SyncView":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.HubPage");
			xamlMember = new XamlMember(this, "SyncView", "MobileBandSync.Common.SyncViewModel");
			xamlMember.Getter = get_2_HubPage_SyncView;
			xamlMember.Setter = set_2_HubPage_SyncView;
			break;
		case "MobileBandSync.HubPage.DeviceTimer":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.HubPage");
			xamlMember = new XamlMember(this, "DeviceTimer", "Windows.UI.Xaml.DispatcherTimer");
			xamlMember.Getter = get_3_HubPage_DeviceTimer;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.HubPage.MapServiceToken":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.HubPage");
			xamlMember = new XamlMember(this, "MapServiceToken", "String");
			xamlMember.Getter = get_4_HubPage_MapServiceToken;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.HubPage.FilterAccepted":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.HubPage");
			xamlMember = new XamlMember(this, "FilterAccepted", "Boolean");
			xamlMember.Getter = get_5_HubPage_FilterAccepted;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.HubPage.MapPickerInitialized":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.HubPage");
			xamlMember = new XamlMember(this, "MapPickerInitialized", "Boolean");
			xamlMember.Getter = get_6_HubPage_MapPickerInitialized;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.HubPage.ToggleFilter":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.HubPage");
			xamlMember = new XamlMember(this, "ToggleFilter", "Windows.UI.Xaml.Controls.Primitives.ToggleButton");
			xamlMember.Getter = get_7_HubPage_ToggleFilter;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.ItemPage.NavigationHelper":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.ItemPage");
			xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
			xamlMember.Getter = get_8_ItemPage_NavigationHelper;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.ItemPage.DefaultViewModel":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.ItemPage");
			xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
			xamlMember.Getter = get_9_ItemPage_DefaultViewModel;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Series":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "Series", "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries>");
			xamlMember.Getter = get_10_Chart_Series;
			xamlMember.Setter = set_10_Chart_Series;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries.LegendItems":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries");
			xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.ObservableCollection`1<Object>");
			xamlMember.Getter = get_11_ISeries_LegendItems;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Axes":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "Axes", "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
			xamlMember.Getter = get_12_Chart_Axes;
			xamlMember.Setter = set_12_Chart_Axes;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.Orientation":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
			xamlMember = new XamlMember(this, "Orientation", "WinRTXamlToolkit.Controls.DataVisualization.Charting.AxisOrientation");
			xamlMember.Getter = get_13_IAxis_Orientation;
			xamlMember.Setter = set_13_IAxis_Orientation;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.RegisteredListeners":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
			xamlMember = new XamlMember(this, "RegisteredListeners", "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>");
			xamlMember.Getter = get_14_IAxis_RegisteredListeners;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.DependentAxes":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
			xamlMember = new XamlMember(this, "DependentAxes", "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
			xamlMember.Getter = get_15_IAxis_DependentAxes;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.ActualAxes":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "ActualAxes", "System.Collections.ObjectModel.ReadOnlyCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
			xamlMember.Getter = get_16_Chart_ActualAxes;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.ChartAreaStyle":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "ChartAreaStyle", "Windows.UI.Xaml.Style");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_17_Chart_ChartAreaStyle;
			xamlMember.Setter = set_17_Chart_ChartAreaStyle;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendItems":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.Collection`1<Object>");
			xamlMember.Getter = get_18_Chart_LegendItems;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendStyle":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "LegendStyle", "Windows.UI.Xaml.Style");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_19_Chart_LegendStyle;
			xamlMember.Setter = set_19_Chart_LegendStyle;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendTitle":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "LegendTitle", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_20_Chart_LegendTitle;
			xamlMember.Setter = set_20_Chart_LegendTitle;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.PlotAreaStyle":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "PlotAreaStyle", "Windows.UI.Xaml.Style");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_21_Chart_PlotAreaStyle;
			xamlMember.Setter = set_21_Chart_PlotAreaStyle;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Palette":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "Palette", "System.Collections.ObjectModel.Collection`1<Windows.UI.Xaml.ResourceDictionary>");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_22_Chart_Palette;
			xamlMember.Setter = set_22_Chart_Palette;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Title":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "Title", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_23_Chart_Title;
			xamlMember.Setter = set_23_Chart_Title;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.TitleStyle":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
			xamlMember = new XamlMember(this, "TitleStyle", "Windows.UI.Xaml.Style");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_24_Chart_TitleStyle;
			xamlMember.Setter = set_24_Chart_TitleStyle;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.Title":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
			xamlMember = new XamlMember(this, "Title", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_25_Series_Title;
			xamlMember.Setter = set_25_Series_Title;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IndependentValueBinding":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "IndependentValueBinding", "Windows.UI.Xaml.Data.Binding");
			xamlMember.Getter = get_26_DataPointSeries_IndependentValueBinding;
			xamlMember.Setter = set_26_DataPointSeries_IndependentValueBinding;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DependentValueBinding":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "DependentValueBinding", "Windows.UI.Xaml.Data.Binding");
			xamlMember.Getter = get_27_DataPointSeries_DependentValueBinding;
			xamlMember.Setter = set_27_DataPointSeries_DependentValueBinding;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IsSelectionEnabled":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "IsSelectionEnabled", "Boolean");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_28_DataPointSeries_IsSelectionEnabled;
			xamlMember.Setter = set_28_DataPointSeries_IsSelectionEnabled;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DataPointStyle":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "DataPointStyle", "Windows.UI.Xaml.Style");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_29_DataPointSeries_DataPointStyle;
			xamlMember.Setter = set_29_DataPointSeries_DataPointStyle;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries.Points":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries");
			xamlMember = new XamlMember(this, "Points", "Windows.UI.Xaml.Media.PointCollection");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_30_LineSeries_Points;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries.PolylineStyle":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries");
			xamlMember = new XamlMember(this, "PolylineStyle", "Windows.UI.Xaml.Style");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_31_LineSeries_PolylineStyle;
			xamlMember.Setter = set_31_LineSeries_PolylineStyle;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.DependentRangeAxis":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
			xamlMember = new XamlMember(this, "DependentRangeAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IRangeAxis");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_32_LineAreaBaseSeries_DependentRangeAxis;
			xamlMember.Setter = set_32_LineAreaBaseSeries_DependentRangeAxis;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.IndependentAxis":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
			xamlMember = new XamlMember(this, "IndependentAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_33_LineAreaBaseSeries_IndependentAxis;
			xamlMember.Setter = set_33_LineAreaBaseSeries_IndependentAxis;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.ActualIndependentAxis":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
			xamlMember = new XamlMember(this, "ActualIndependentAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
			xamlMember.Getter = get_34_LineAreaBaseSeries_ActualIndependentAxis;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.ActualDependentRangeAxis":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
			xamlMember = new XamlMember(this, "ActualDependentRangeAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IRangeAxis");
			xamlMember.Getter = get_35_LineAreaBaseSeries_ActualDependentRangeAxis;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes.GlobalSeriesIndex":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes");
			xamlMember = new XamlMember(this, "GlobalSeriesIndex", "System.Nullable`1<Int32>");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_36_DataPointSingleSeriesWithAxes_GlobalSeriesIndex;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DependentValuePath":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "DependentValuePath", "String");
			xamlMember.Getter = get_37_DataPointSeries_DependentValuePath;
			xamlMember.Setter = set_37_DataPointSeries_DependentValuePath;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IndependentValuePath":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "IndependentValuePath", "String");
			xamlMember.Getter = get_38_DataPointSeries_IndependentValuePath;
			xamlMember.Setter = set_38_DataPointSeries_IndependentValuePath;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.ItemsSource":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "ItemsSource", "System.Collections.IEnumerable");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_39_DataPointSeries_ItemsSource;
			xamlMember.Setter = set_39_DataPointSeries_ItemsSource;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.AnimationSequence":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "AnimationSequence", "WinRTXamlToolkit.Controls.DataVisualization.Charting.AnimationSequence");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_40_DataPointSeries_AnimationSequence;
			xamlMember.Setter = set_40_DataPointSeries_AnimationSequence;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.TransitionEasingFunction":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "TransitionEasingFunction", "Windows.UI.Xaml.Media.Animation.EasingFunctionBase");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_41_DataPointSeries_TransitionEasingFunction;
			xamlMember.Setter = set_41_DataPointSeries_TransitionEasingFunction;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.SelectedItem":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "SelectedItem", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_42_DataPointSeries_SelectedItem;
			xamlMember.Setter = set_42_DataPointSeries_SelectedItem;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.LegendItemStyle":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "LegendItemStyle", "Windows.UI.Xaml.Style");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_43_DataPointSeries_LegendItemStyle;
			xamlMember.Setter = set_43_DataPointSeries_LegendItemStyle;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.TransitionDuration":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
			xamlMember = new XamlMember(this, "TransitionDuration", "TimeSpan");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_44_DataPointSeries_TransitionDuration;
			xamlMember.Setter = set_44_DataPointSeries_TransitionDuration;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.SeriesHost":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
			xamlMember = new XamlMember(this, "SeriesHost", "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeriesHost");
			xamlMember.Getter = get_45_Series_SeriesHost;
			xamlMember.Setter = set_45_Series_SeriesHost;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.LegendItems":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
			xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.ObservableCollection`1<Object>");
			xamlMember.Getter = get_46_Series_LegendItems;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IsSelectionEnabled":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "IsSelectionEnabled", "Boolean");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_47_DataPoint_IsSelectionEnabled;
			xamlMember.Setter = set_47_DataPoint_IsSelectionEnabled;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.ActualDependentValue":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "ActualDependentValue", "Double");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_48_DataPoint_ActualDependentValue;
			xamlMember.Setter = set_48_DataPoint_ActualDependentValue;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.DependentValue":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "DependentValue", "Double");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_49_DataPoint_DependentValue;
			xamlMember.Setter = set_49_DataPoint_DependentValue;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.DependentValueStringFormat":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "DependentValueStringFormat", "String");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_50_DataPoint_DependentValueStringFormat;
			xamlMember.Setter = set_50_DataPoint_DependentValueStringFormat;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.FormattedDependentValue":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "FormattedDependentValue", "String");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_51_DataPoint_FormattedDependentValue;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.FormattedIndependentValue":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "FormattedIndependentValue", "String");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_52_DataPoint_FormattedIndependentValue;
			xamlMember.SetIsReadOnly();
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IndependentValue":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "IndependentValue", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_53_DataPoint_IndependentValue;
			xamlMember.Setter = set_53_DataPoint_IndependentValue;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IndependentValueStringFormat":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "IndependentValueStringFormat", "String");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_54_DataPoint_IndependentValueStringFormat;
			xamlMember.Setter = set_54_DataPoint_IndependentValueStringFormat;
			break;
		case "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.ActualIndependentValue":
			_ = (XamlUserType)(object)GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
			xamlMember = new XamlMember(this, "ActualIndependentValue", "Object");
			xamlMember.SetIsDependencyProperty();
			xamlMember.Getter = get_55_DataPoint_ActualIndependentValue;
			xamlMember.Setter = set_55_DataPoint_ActualIndependentValue;
			break;
		case "MobileBandSync.SectionPage.NavigationHelper":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
			xamlMember.Getter = get_56_SectionPage_NavigationHelper;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.DefaultViewModel":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
			xamlMember.Getter = get_57_SectionPage_DefaultViewModel;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.currentWorkoutId":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "currentWorkoutId", "Int32");
			xamlMember.Getter = get_58_SectionPage_currentWorkoutId;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.Viewport":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "Viewport", "Windows.Devices.Geolocation.GeoboundingBox");
			xamlMember.Getter = get_59_SectionPage_Viewport;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.MapInitialized":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "MapInitialized", "Boolean");
			xamlMember.Getter = get_60_SectionPage_MapInitialized;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.CancelTokenSource":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "CancelTokenSource", "System.Threading.CancellationTokenSource");
			xamlMember.Getter = get_61_SectionPage_CancelTokenSource;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.CurrentWorkout":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "CurrentWorkout", "MobileBandSync.Data.WorkoutItem");
			xamlMember.Getter = get_62_SectionPage_CurrentWorkout;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.ViewInitialized":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "ViewInitialized", "Boolean");
			xamlMember.Getter = get_63_SectionPage_ViewInitialized;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.chartLine":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "chartLine", "Windows.UI.Xaml.Shapes.Line");
			xamlMember.Getter = get_64_SectionPage_chartLine;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SectionPage.PosNeedleIcon":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SectionPage");
			xamlMember = new XamlMember(this, "PosNeedleIcon", "Windows.UI.Xaml.Controls.Maps.MapIcon");
			xamlMember.Getter = get_65_SectionPage_PosNeedleIcon;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SleepPage.NavigationHelper":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SleepPage");
			xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
			xamlMember.Getter = get_66_SleepPage_NavigationHelper;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SleepPage.DefaultViewModel":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SleepPage");
			xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
			xamlMember.Getter = get_67_SleepPage_DefaultViewModel;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SleepPage.currentWorkoutId":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SleepPage");
			xamlMember = new XamlMember(this, "currentWorkoutId", "Int32");
			xamlMember.Getter = get_68_SleepPage_currentWorkoutId;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SleepPage.CancelTokenSource":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SleepPage");
			xamlMember = new XamlMember(this, "CancelTokenSource", "System.Threading.CancellationTokenSource");
			xamlMember.Getter = get_69_SleepPage_CancelTokenSource;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SleepPage.CurrentWorkout":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SleepPage");
			xamlMember = new XamlMember(this, "CurrentWorkout", "MobileBandSync.Data.WorkoutItem");
			xamlMember.Getter = get_70_SleepPage_CurrentWorkout;
			xamlMember.SetIsReadOnly();
			break;
		case "MobileBandSync.SleepPage.CanvasSize":
			_ = (XamlUserType)(object)GetXamlTypeByName("MobileBandSync.SleepPage");
			xamlMember = new XamlMember(this, "CanvasSize", "Windows.Foundation.Size");
			xamlMember.Getter = get_71_SleepPage_CanvasSize;
			xamlMember.SetIsReadOnly();
			break;
		}
		return (IXamlMember)(object)xamlMember;
	}
}
