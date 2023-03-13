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

namespace MobileBandSync.MobileBandSync_XamlTypeInfo
{
	// Token: 0x02000008 RID: 8
	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class XamlTypeInfoProvider
	{
		// Token: 0x06000084 RID: 132 RVA: 0x00004BC4 File Offset: 0x00002DC4
		public IXamlType GetXamlTypeByType(Type type)
		{
			IXamlType xamlType;
			if (this._xamlTypeCacheByType.TryGetValue(type, out xamlType))
			{
				return xamlType;
			}
			int num = this.LookupTypeIndexByType(type);
			if (num != -1)
			{
				xamlType = this.CreateXamlType(num);
			}
			XamlUserType xamlUserType = xamlType as XamlUserType;
			if (xamlType == null || (xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType))
			{
				IXamlType xamlType2 = this.CheckOtherMetadataProvidersForType(type);
				if (xamlType2 != null && (xamlType2.IsConstructible || xamlType == null))
				{
					xamlType = xamlType2;
				}
			}
			if (xamlType != null)
			{
				this._xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
				this._xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
			}
			return xamlType;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004C54 File Offset: 0x00002E54
		public IXamlType GetXamlTypeByName(string typeName)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				return null;
			}
			IXamlType xamlType;
			if (this._xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
			{
				return xamlType;
			}
			int num = this.LookupTypeIndexByName(typeName);
			if (num != -1)
			{
				xamlType = this.CreateXamlType(num);
			}
			XamlUserType xamlUserType = xamlType as XamlUserType;
			if (xamlType == null || (xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType))
			{
				IXamlType xamlType2 = this.CheckOtherMetadataProvidersForName(typeName);
				if (xamlType2 != null && (xamlType2.IsConstructible || xamlType == null))
				{
					xamlType = xamlType2;
				}
			}
			if (xamlType != null)
			{
				this._xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
				this._xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
			}
			return xamlType;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004CF0 File Offset: 0x00002EF0
		public IXamlMember GetMemberByLongName(string longMemberName)
		{
			if (string.IsNullOrEmpty(longMemberName))
			{
				return null;
			}
			IXamlMember xamlMember;
			if (this._xamlMembers.TryGetValue(longMemberName, out xamlMember))
			{
				return xamlMember;
			}
			xamlMember = this.CreateXamlMember(longMemberName);
			if (xamlMember != null)
			{
				this._xamlMembers.Add(longMemberName, xamlMember);
			}
			return xamlMember;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004D34 File Offset: 0x00002F34
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
			this._typeTable[0] = typeof(HubPage);
			this._typeTable[1] = typeof(Page);
			this._typeTable[2] = typeof(UserControl);
			this._typeTable[3] = typeof(NavigationHelper);
			this._typeTable[4] = typeof(DependencyObject);
			this._typeTable[5] = typeof(ObservableDictionary);
			this._typeTable[6] = typeof(object);
			this._typeTable[7] = typeof(string);
			this._typeTable[8] = typeof(SyncViewModel);
			this._typeTable[9] = typeof(DispatcherTimer);
			this._typeTable[10] = typeof(bool);
			this._typeTable[11] = typeof(ToggleButton);
			this._typeTable[12] = typeof(ItemPage);
			this._typeTable[13] = typeof(Chart);
			this._typeTable[14] = typeof(Control);
			this._typeTable[15] = typeof(Collection<ISeries>);
			this._typeTable[16] = typeof(ISeries);
			this._typeTable[17] = typeof(ObservableCollection<object>);
			this._typeTable[18] = typeof(Collection<object>);
			this._typeTable[19] = typeof(Collection<IAxis>);
			this._typeTable[20] = typeof(IAxis);
			this._typeTable[21] = typeof(AxisOrientation);
			this._typeTable[22] = typeof(Enum);
			this._typeTable[23] = typeof(ValueType);
			this._typeTable[24] = typeof(ObservableCollection<IAxisListener>);
			this._typeTable[25] = typeof(Collection<IAxisListener>);
			this._typeTable[26] = typeof(IAxisListener);
			this._typeTable[27] = typeof(ObservableCollection<IAxis>);
			this._typeTable[28] = typeof(ReadOnlyCollection<IAxis>);
			this._typeTable[29] = typeof(Style);
			this._typeTable[30] = typeof(Collection<ResourceDictionary>);
			this._typeTable[31] = typeof(ResourceDictionary);
			this._typeTable[32] = typeof(LineSeries);
			this._typeTable[33] = typeof(LineAreaBaseSeries<LineDataPoint>);
			this._typeTable[34] = typeof(DataPointSingleSeriesWithAxes);
			this._typeTable[35] = typeof(DataPointSeriesWithAxes);
			this._typeTable[36] = typeof(DataPointSeries);
			this._typeTable[37] = typeof(Series);
			this._typeTable[38] = typeof(Binding);
			this._typeTable[39] = typeof(PointCollection);
			this._typeTable[40] = typeof(IRangeAxis);
			this._typeTable[41] = typeof(int?);
			this._typeTable[42] = typeof(IEnumerable);
			this._typeTable[43] = typeof(AnimationSequence);
			this._typeTable[44] = typeof(EasingFunctionBase);
			this._typeTable[45] = typeof(TimeSpan);
			this._typeTable[46] = typeof(ISeriesHost);
			this._typeTable[47] = typeof(LineDataPoint);
			this._typeTable[48] = typeof(DataPoint);
			this._typeTable[49] = typeof(double);
			this._typeTable[50] = typeof(SectionPage);
			this._typeTable[51] = typeof(int);
			this._typeTable[52] = typeof(GeoboundingBox);
			this._typeTable[53] = typeof(CancellationTokenSource);
			this._typeTable[54] = typeof(WorkoutItem);
			this._typeTable[55] = typeof(Line);
			this._typeTable[56] = typeof(MapIcon);
			this._typeTable[57] = typeof(SleepPage);
			this._typeTable[58] = typeof(Size);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000054E4 File Offset: 0x000036E4
		private int LookupTypeIndexByName(string typeName)
		{
			if (this._typeNameTable == null)
			{
				this.InitTypeTables();
			}
			for (int i = 0; i < this._typeNameTable.Length; i++)
			{
				if (string.CompareOrdinal(this._typeNameTable[i], typeName) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005528 File Offset: 0x00003728
		private int LookupTypeIndexByType(Type type)
		{
			if (this._typeTable == null)
			{
				this.InitTypeTables();
			}
			for (int i = 0; i < this._typeTable.Length; i++)
			{
				if (type == this._typeTable[i])
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005564 File Offset: 0x00003764
		private object Activate_0_HubPage()
		{
			return new HubPage();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000556B File Offset: 0x0000376B
		private object Activate_5_ObservableDictionary()
		{
			return new ObservableDictionary();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005572 File Offset: 0x00003772
		private object Activate_8_SyncViewModel()
		{
			return new SyncViewModel();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005579 File Offset: 0x00003779
		private object Activate_12_ItemPage()
		{
			return new ItemPage();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00005580 File Offset: 0x00003780
		private object Activate_13_Chart()
		{
			return new Chart();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00005587 File Offset: 0x00003787
		private object Activate_15_Collection()
		{
			return new Collection<ISeries>();
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000558E File Offset: 0x0000378E
		private object Activate_17_ObservableCollection()
		{
			return new ObservableCollection<object>();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00005595 File Offset: 0x00003795
		private object Activate_18_Collection()
		{
			return new Collection<object>();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000559C File Offset: 0x0000379C
		private object Activate_19_Collection()
		{
			return new Collection<IAxis>();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000055A3 File Offset: 0x000037A3
		private object Activate_24_ObservableCollection()
		{
			return new ObservableCollection<IAxisListener>();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000055AA File Offset: 0x000037AA
		private object Activate_25_Collection()
		{
			return new Collection<IAxisListener>();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000055B1 File Offset: 0x000037B1
		private object Activate_27_ObservableCollection()
		{
			return new ObservableCollection<IAxis>();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000055B8 File Offset: 0x000037B8
		private object Activate_30_Collection()
		{
			return new Collection<ResourceDictionary>();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000055BF File Offset: 0x000037BF
		private object Activate_32_LineSeries()
		{
			return new LineSeries();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000055C6 File Offset: 0x000037C6
		private object Activate_47_LineDataPoint()
		{
			return new LineDataPoint();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000055CD File Offset: 0x000037CD
		private object Activate_50_SectionPage()
		{
			return new SectionPage();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000055D4 File Offset: 0x000037D4
		private object Activate_53_CancellationTokenSource()
		{
			return new CancellationTokenSource();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000055DB File Offset: 0x000037DB
		private object Activate_54_WorkoutItem()
		{
			return new WorkoutItem();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000055E2 File Offset: 0x000037E2
		private object Activate_57_SleepPage()
		{
			return new SleepPage();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000055EC File Offset: 0x000037EC
		private void MapAdd_5_ObservableDictionary(object instance, object key, object item)
		{
			IDictionary<string, object> dictionary = (IDictionary<string, object>)instance;
			string key2 = (string)key;
			dictionary.Add(key2, item);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00005610 File Offset: 0x00003810
		private void VectorAdd_15_Collection(object instance, object item)
		{
			ICollection<ISeries> collection = (ICollection<ISeries>)instance;
			ISeries item2 = (ISeries)item;
			collection.Add(item2);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00005630 File Offset: 0x00003830
		private void VectorAdd_17_ObservableCollection(object instance, object item)
		{
			((ICollection<object>)instance).Add(item);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000564C File Offset: 0x0000384C
		private void VectorAdd_18_Collection(object instance, object item)
		{
			((ICollection<object>)instance).Add(item);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00005668 File Offset: 0x00003868
		private void VectorAdd_19_Collection(object instance, object item)
		{
			ICollection<IAxis> collection = (ICollection<IAxis>)instance;
			IAxis item2 = (IAxis)item;
			collection.Add(item2);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00005688 File Offset: 0x00003888
		private void VectorAdd_24_ObservableCollection(object instance, object item)
		{
			ICollection<IAxisListener> collection = (ICollection<IAxisListener>)instance;
			IAxisListener item2 = (IAxisListener)item;
			collection.Add(item2);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000056A8 File Offset: 0x000038A8
		private void VectorAdd_25_Collection(object instance, object item)
		{
			ICollection<IAxisListener> collection = (ICollection<IAxisListener>)instance;
			IAxisListener item2 = (IAxisListener)item;
			collection.Add(item2);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000056C8 File Offset: 0x000038C8
		private void VectorAdd_27_ObservableCollection(object instance, object item)
		{
			ICollection<IAxis> collection = (ICollection<IAxis>)instance;
			IAxis item2 = (IAxis)item;
			collection.Add(item2);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000056E8 File Offset: 0x000038E8
		private void VectorAdd_28_ReadOnlyCollection(object instance, object item)
		{
			ICollection<IAxis> collection = (ICollection<IAxis>)instance;
			IAxis item2 = (IAxis)item;
			collection.Add(item2);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005708 File Offset: 0x00003908
		private void VectorAdd_30_Collection(object instance, object item)
		{
			ICollection<ResourceDictionary> collection = (ICollection<ResourceDictionary>)instance;
			ResourceDictionary item2 = (ResourceDictionary)item;
			collection.Add(item2);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00005728 File Offset: 0x00003928
		private IXamlType CreateXamlType(int typeIndex)
		{
			XamlSystemBaseType result = null;
			string fullName = this._typeNameTable[typeIndex];
			Type type = this._typeTable[typeIndex];
			switch (typeIndex)
			{
			case 0:
			{
				XamlUserType xamlUserType = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
				xamlUserType.Activator = new Activator(this.Activate_0_HubPage);
				xamlUserType.AddMemberName("NavigationHelper");
				xamlUserType.AddMemberName("DefaultViewModel");
				xamlUserType.AddMemberName("SyncView");
				xamlUserType.AddMemberName("DeviceTimer");
				xamlUserType.AddMemberName("MapServiceToken");
				xamlUserType.AddMemberName("FilterAccepted");
				xamlUserType.AddMemberName("MapPickerInitialized");
				xamlUserType.AddMemberName("ToggleFilter");
				xamlUserType.SetIsLocalType();
				result = xamlUserType;
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
				XamlUserType xamlUserType2 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.DependencyObject"));
				xamlUserType2.SetIsReturnTypeStub();
				xamlUserType2.SetIsLocalType();
				result = xamlUserType2;
				break;
			}
			case 4:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 5:
			{
				XamlUserType xamlUserType3 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				xamlUserType3.DictionaryAdd = new AddToDictionary(this.MapAdd_5_ObservableDictionary);
				xamlUserType3.SetIsReturnTypeStub();
				xamlUserType3.SetIsLocalType();
				result = xamlUserType3;
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
				XamlUserType xamlUserType4 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				xamlUserType4.SetIsReturnTypeStub();
				xamlUserType4.SetIsLocalType();
				result = xamlUserType4;
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
				XamlUserType xamlUserType5 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
				xamlUserType5.Activator = new Activator(this.Activate_12_ItemPage);
				xamlUserType5.AddMemberName("NavigationHelper");
				xamlUserType5.AddMemberName("DefaultViewModel");
				xamlUserType5.SetIsLocalType();
				result = xamlUserType5;
				break;
			}
			case 13:
			{
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
				result = xamlUserType6;
				break;
			}
			case 14:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 15:
			{
				XamlUserType xamlUserType7 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				xamlUserType7.CollectionAdd = new AddToCollection(this.VectorAdd_15_Collection);
				xamlUserType7.SetIsReturnTypeStub();
				result = xamlUserType7;
				break;
			}
			case 16:
			{
				XamlUserType xamlUserType8 = new XamlUserType(this, fullName, type, null);
				xamlUserType8.AddMemberName("LegendItems");
				result = xamlUserType8;
				break;
			}
			case 17:
			{
				XamlUserType xamlUserType9 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<Object>"));
				xamlUserType9.CollectionAdd = new AddToCollection(this.VectorAdd_17_ObservableCollection);
				xamlUserType9.SetIsReturnTypeStub();
				result = xamlUserType9;
				break;
			}
			case 18:
				result = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"))
				{
					Activator = new Activator(this.Activate_18_Collection),
					CollectionAdd = new AddToCollection(this.VectorAdd_18_Collection)
				};
				break;
			case 19:
				result = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"))
				{
					Activator = new Activator(this.Activate_19_Collection),
					CollectionAdd = new AddToCollection(this.VectorAdd_19_Collection)
				};
				break;
			case 20:
			{
				XamlUserType xamlUserType10 = new XamlUserType(this, fullName, type, null);
				xamlUserType10.AddMemberName("Orientation");
				xamlUserType10.AddMemberName("RegisteredListeners");
				xamlUserType10.AddMemberName("DependentAxes");
				result = xamlUserType10;
				break;
			}
			case 21:
			{
				XamlUserType xamlUserType11 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Enum"));
				xamlUserType11.AddEnumValue("None", AxisOrientation.None);
				xamlUserType11.AddEnumValue("X", AxisOrientation.X);
				xamlUserType11.AddEnumValue("Y", AxisOrientation.Y);
				result = xamlUserType11;
				break;
			}
			case 22:
				result = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
				break;
			case 23:
				result = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				break;
			case 24:
			{
				XamlUserType xamlUserType12 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>"));
				xamlUserType12.CollectionAdd = new AddToCollection(this.VectorAdd_24_ObservableCollection);
				xamlUserType12.SetIsReturnTypeStub();
				result = xamlUserType12;
				break;
			}
			case 25:
				result = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"))
				{
					Activator = new Activator(this.Activate_25_Collection),
					CollectionAdd = new AddToCollection(this.VectorAdd_25_Collection)
				};
				break;
			case 26:
				result = new XamlUserType(this, fullName, type, null);
				break;
			case 27:
			{
				XamlUserType xamlUserType13 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>"));
				xamlUserType13.CollectionAdd = new AddToCollection(this.VectorAdd_27_ObservableCollection);
				xamlUserType13.SetIsReturnTypeStub();
				result = xamlUserType13;
				break;
			}
			case 28:
			{
				XamlUserType xamlUserType14 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				xamlUserType14.CollectionAdd = new AddToCollection(this.VectorAdd_28_ReadOnlyCollection);
				xamlUserType14.SetIsReturnTypeStub();
				result = xamlUserType14;
				break;
			}
			case 29:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 30:
			{
				XamlUserType xamlUserType15 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				xamlUserType15.CollectionAdd = new AddToCollection(this.VectorAdd_30_Collection);
				xamlUserType15.SetIsReturnTypeStub();
				result = xamlUserType15;
				break;
			}
			case 31:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 32:
			{
				XamlUserType xamlUserType16 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>"));
				xamlUserType16.Activator = new Activator(this.Activate_32_LineSeries);
				xamlUserType16.AddMemberName("Points");
				xamlUserType16.AddMemberName("PolylineStyle");
				result = xamlUserType16;
				break;
			}
			case 33:
			{
				XamlUserType xamlUserType17 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes"));
				xamlUserType17.AddMemberName("DependentRangeAxis");
				xamlUserType17.AddMemberName("IndependentAxis");
				xamlUserType17.AddMemberName("ActualIndependentAxis");
				xamlUserType17.AddMemberName("ActualDependentRangeAxis");
				result = xamlUserType17;
				break;
			}
			case 34:
			{
				XamlUserType xamlUserType18 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeriesWithAxes"));
				xamlUserType18.AddMemberName("GlobalSeriesIndex");
				result = xamlUserType18;
				break;
			}
			case 35:
				result = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries"));
				break;
			case 36:
			{
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
				result = xamlUserType19;
				break;
			}
			case 37:
			{
				XamlUserType xamlUserType20 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Control"));
				xamlUserType20.AddMemberName("Title");
				xamlUserType20.AddMemberName("SeriesHost");
				xamlUserType20.AddMemberName("LegendItems");
				result = xamlUserType20;
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
				XamlUserType xamlUserType21 = new XamlUserType(this, fullName, type, null);
				xamlUserType21.SetIsReturnTypeStub();
				result = xamlUserType21;
				break;
			}
			case 41:
			{
				XamlUserType xamlUserType22 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
				xamlUserType22.SetIsReturnTypeStub();
				result = xamlUserType22;
				break;
			}
			case 42:
			{
				XamlUserType xamlUserType23 = new XamlUserType(this, fullName, type, null);
				xamlUserType23.SetIsReturnTypeStub();
				result = xamlUserType23;
				break;
			}
			case 43:
			{
				XamlUserType xamlUserType24 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.Enum"));
				xamlUserType24.AddEnumValue("Simultaneous", AnimationSequence.Simultaneous);
				xamlUserType24.AddEnumValue("FirstToLast", AnimationSequence.FirstToLast);
				xamlUserType24.AddEnumValue("LastToFirst", AnimationSequence.LastToFirst);
				result = xamlUserType24;
				break;
			}
			case 44:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 45:
			{
				XamlUserType xamlUserType25 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("System.ValueType"));
				xamlUserType25.SetIsReturnTypeStub();
				result = xamlUserType25;
				break;
			}
			case 46:
			{
				XamlUserType xamlUserType26 = new XamlUserType(this, fullName, type, null);
				xamlUserType26.SetIsReturnTypeStub();
				result = xamlUserType26;
				break;
			}
			case 47:
				result = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint"))
				{
					Activator = new Activator(this.Activate_47_LineDataPoint)
				};
				break;
			case 48:
			{
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
				result = xamlUserType27;
				break;
			}
			case 49:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 50:
			{
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
				result = xamlUserType28;
				break;
			}
			case 51:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 52:
			{
				XamlUserType xamlUserType29 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				xamlUserType29.SetIsReturnTypeStub();
				result = xamlUserType29;
				break;
			}
			case 53:
			{
				XamlUserType xamlUserType30 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				xamlUserType30.SetIsReturnTypeStub();
				result = xamlUserType30;
				break;
			}
			case 54:
			{
				XamlUserType xamlUserType31 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Object"));
				xamlUserType31.SetIsReturnTypeStub();
				xamlUserType31.SetIsLocalType();
				result = xamlUserType31;
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
				XamlUserType xamlUserType32 = new XamlUserType(this, fullName, type, this.GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
				xamlUserType32.Activator = new Activator(this.Activate_57_SleepPage);
				xamlUserType32.AddMemberName("NavigationHelper");
				xamlUserType32.AddMemberName("DefaultViewModel");
				xamlUserType32.AddMemberName("currentWorkoutId");
				xamlUserType32.AddMemberName("CancelTokenSource");
				xamlUserType32.AddMemberName("CurrentWorkout");
				xamlUserType32.AddMemberName("CanvasSize");
				xamlUserType32.SetIsLocalType();
				result = xamlUserType32;
				break;
			}
			case 58:
				result = new XamlSystemBaseType(fullName, type);
				break;
			}
			return result;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00006260 File Offset: 0x00004460
		private List<IXamlMetadataProvider> OtherProviders
		{
			get
			{
				if (this._otherProviders == null)
				{
					this._otherProviders = new List<IXamlMetadataProvider>();
					IXamlMetadataProvider item = new WinRTXamlToolkit.Controls.DataVisualization.WinRTXamlToolkit_Controls_DataVisualization_WindowsPhone_XamlTypeInfo.XamlMetaDataProvider();
					this._otherProviders.Add(item);
					item = new WinRTXamlToolkit.WinRTXamlToolkit_WindowsPhone_XamlTypeInfo.XamlMetaDataProvider();
					this._otherProviders.Add(item);
				}
				return this._otherProviders;
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000062AC File Offset: 0x000044AC
		private IXamlType CheckOtherMetadataProvidersForName(string typeName)
		{
			IXamlType result = null;
			foreach (IXamlMetadataProvider xamlMetadataProvider in this.OtherProviders)
			{
				IXamlType xamlType = xamlMetadataProvider.GetXamlType(typeName);
				if (xamlType != null)
				{
					if (xamlType.IsConstructible)
					{
						return xamlType;
					}
					result = xamlType;
				}
			}
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00006318 File Offset: 0x00004518
		private IXamlType CheckOtherMetadataProvidersForType(Type type)
		{
			IXamlType result = null;
			foreach (IXamlMetadataProvider xamlMetadataProvider in this.OtherProviders)
			{
				IXamlType xamlType = xamlMetadataProvider.GetXamlType(type);
				if (xamlType != null)
				{
					if (xamlType.IsConstructible)
					{
						return xamlType;
					}
					result = xamlType;
				}
			}
			return result;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00006384 File Offset: 0x00004584
		private object get_0_HubPage_NavigationHelper(object instance)
		{
			return ((HubPage)instance).NavigationHelper;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00006391 File Offset: 0x00004591
		private object get_1_HubPage_DefaultViewModel(object instance)
		{
			return ((HubPage)instance).DefaultViewModel;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000639E File Offset: 0x0000459E
		private object get_2_HubPage_SyncView(object instance)
		{
			return ((HubPage)instance).SyncView;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000063AB File Offset: 0x000045AB
		private void set_2_HubPage_SyncView(object instance, object Value)
		{
			((HubPage)instance).SyncView = (SyncViewModel)Value;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000063BE File Offset: 0x000045BE
		private object get_3_HubPage_DeviceTimer(object instance)
		{
			return ((HubPage)instance).DeviceTimer;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000063CB File Offset: 0x000045CB
		private object get_4_HubPage_MapServiceToken(object instance)
		{
			return ((HubPage)instance).MapServiceToken;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000063D8 File Offset: 0x000045D8
		private object get_5_HubPage_FilterAccepted(object instance)
		{
			return ((HubPage)instance).FilterAccepted;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x000063EA File Offset: 0x000045EA
		private object get_6_HubPage_MapPickerInitialized(object instance)
		{
			return ((HubPage)instance).MapPickerInitialized;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000063FC File Offset: 0x000045FC
		private object get_7_HubPage_ToggleFilter(object instance)
		{
			return ((HubPage)instance).ToggleFilter;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00006409 File Offset: 0x00004609
		private object get_8_ItemPage_NavigationHelper(object instance)
		{
			return ((ItemPage)instance).NavigationHelper;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00006416 File Offset: 0x00004616
		private object get_9_ItemPage_DefaultViewModel(object instance)
		{
			return ((ItemPage)instance).DefaultViewModel;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006423 File Offset: 0x00004623
		private object get_10_Chart_Series(object instance)
		{
			return ((Chart)instance).Series;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00006430 File Offset: 0x00004630
		private void set_10_Chart_Series(object instance, object Value)
		{
			((Chart)instance).Series = (Collection<ISeries>)Value;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006443 File Offset: 0x00004643
		private object get_11_ISeries_LegendItems(object instance)
		{
			return ((ISeries)instance).LegendItems;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006450 File Offset: 0x00004650
		private object get_12_Chart_Axes(object instance)
		{
			return ((Chart)instance).Axes;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000645D File Offset: 0x0000465D
		private void set_12_Chart_Axes(object instance, object Value)
		{
			((Chart)instance).Axes = (Collection<IAxis>)Value;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00006470 File Offset: 0x00004670
		private object get_13_IAxis_Orientation(object instance)
		{
			return ((IAxis)instance).Orientation;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00006482 File Offset: 0x00004682
		private void set_13_IAxis_Orientation(object instance, object Value)
		{
			((IAxis)instance).Orientation = (AxisOrientation)Value;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006495 File Offset: 0x00004695
		private object get_14_IAxis_RegisteredListeners(object instance)
		{
			return ((IAxis)instance).RegisteredListeners;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000064A2 File Offset: 0x000046A2
		private object get_15_IAxis_DependentAxes(object instance)
		{
			return ((IAxis)instance).DependentAxes;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000064AF File Offset: 0x000046AF
		private object get_16_Chart_ActualAxes(object instance)
		{
			return ((Chart)instance).ActualAxes;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000064BC File Offset: 0x000046BC
		private object get_17_Chart_ChartAreaStyle(object instance)
		{
			return ((Chart)instance).ChartAreaStyle;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000064C9 File Offset: 0x000046C9
		private void set_17_Chart_ChartAreaStyle(object instance, object Value)
		{
			((Chart)instance).ChartAreaStyle = (Style)Value;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000064DC File Offset: 0x000046DC
		private object get_18_Chart_LegendItems(object instance)
		{
			return ((Chart)instance).LegendItems;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000064E9 File Offset: 0x000046E9
		private object get_19_Chart_LegendStyle(object instance)
		{
			return ((Chart)instance).LegendStyle;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000064F6 File Offset: 0x000046F6
		private void set_19_Chart_LegendStyle(object instance, object Value)
		{
			((Chart)instance).LegendStyle = (Style)Value;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00006509 File Offset: 0x00004709
		private object get_20_Chart_LegendTitle(object instance)
		{
			return ((Chart)instance).LegendTitle;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00006516 File Offset: 0x00004716
		private void set_20_Chart_LegendTitle(object instance, object Value)
		{
			((Chart)instance).LegendTitle = Value;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00006524 File Offset: 0x00004724
		private object get_21_Chart_PlotAreaStyle(object instance)
		{
			return ((Chart)instance).PlotAreaStyle;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00006531 File Offset: 0x00004731
		private void set_21_Chart_PlotAreaStyle(object instance, object Value)
		{
			((Chart)instance).PlotAreaStyle = (Style)Value;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00006544 File Offset: 0x00004744
		private object get_22_Chart_Palette(object instance)
		{
			return ((Chart)instance).Palette;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00006551 File Offset: 0x00004751
		private void set_22_Chart_Palette(object instance, object Value)
		{
			((Chart)instance).Palette = (Collection<ResourceDictionary>)Value;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00006564 File Offset: 0x00004764
		private object get_23_Chart_Title(object instance)
		{
			return ((Chart)instance).Title;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00006571 File Offset: 0x00004771
		private void set_23_Chart_Title(object instance, object Value)
		{
			((Chart)instance).Title = Value;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000657F File Offset: 0x0000477F
		private object get_24_Chart_TitleStyle(object instance)
		{
			return ((Chart)instance).TitleStyle;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000658C File Offset: 0x0000478C
		private void set_24_Chart_TitleStyle(object instance, object Value)
		{
			((Chart)instance).TitleStyle = (Style)Value;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000659F File Offset: 0x0000479F
		private object get_25_Series_Title(object instance)
		{
			return ((Series)instance).Title;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000065AC File Offset: 0x000047AC
		private void set_25_Series_Title(object instance, object Value)
		{
			((Series)instance).Title = Value;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000065BA File Offset: 0x000047BA
		private object get_26_DataPointSeries_IndependentValueBinding(object instance)
		{
			return ((DataPointSeries)instance).IndependentValueBinding;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000065C7 File Offset: 0x000047C7
		private void set_26_DataPointSeries_IndependentValueBinding(object instance, object Value)
		{
			((DataPointSeries)instance).IndependentValueBinding = (Binding)Value;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000065DA File Offset: 0x000047DA
		private object get_27_DataPointSeries_DependentValueBinding(object instance)
		{
			return ((DataPointSeries)instance).DependentValueBinding;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000065E7 File Offset: 0x000047E7
		private void set_27_DataPointSeries_DependentValueBinding(object instance, object Value)
		{
			((DataPointSeries)instance).DependentValueBinding = (Binding)Value;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000065FA File Offset: 0x000047FA
		private object get_28_DataPointSeries_IsSelectionEnabled(object instance)
		{
			return ((DataPointSeries)instance).IsSelectionEnabled;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000660C File Offset: 0x0000480C
		private void set_28_DataPointSeries_IsSelectionEnabled(object instance, object Value)
		{
			((DataPointSeries)instance).IsSelectionEnabled = (bool)Value;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000661F File Offset: 0x0000481F
		private object get_29_DataPointSeries_DataPointStyle(object instance)
		{
			return ((DataPointSeries)instance).DataPointStyle;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000662C File Offset: 0x0000482C
		private void set_29_DataPointSeries_DataPointStyle(object instance, object Value)
		{
			((DataPointSeries)instance).DataPointStyle = (Style)Value;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000663F File Offset: 0x0000483F
		private object get_30_LineSeries_Points(object instance)
		{
			return ((LineSeries)instance).Points;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000664C File Offset: 0x0000484C
		private object get_31_LineSeries_PolylineStyle(object instance)
		{
			return ((LineSeries)instance).PolylineStyle;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00006659 File Offset: 0x00004859
		private void set_31_LineSeries_PolylineStyle(object instance, object Value)
		{
			((LineSeries)instance).PolylineStyle = (Style)Value;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000666C File Offset: 0x0000486C
		private object get_32_LineAreaBaseSeries_DependentRangeAxis(object instance)
		{
			return ((LineAreaBaseSeries<LineDataPoint>)instance).DependentRangeAxis;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00006679 File Offset: 0x00004879
		private void set_32_LineAreaBaseSeries_DependentRangeAxis(object instance, object Value)
		{
			((LineAreaBaseSeries<LineDataPoint>)instance).DependentRangeAxis = (IRangeAxis)Value;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000668C File Offset: 0x0000488C
		private object get_33_LineAreaBaseSeries_IndependentAxis(object instance)
		{
			return ((LineAreaBaseSeries<LineDataPoint>)instance).IndependentAxis;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00006699 File Offset: 0x00004899
		private void set_33_LineAreaBaseSeries_IndependentAxis(object instance, object Value)
		{
			((LineAreaBaseSeries<LineDataPoint>)instance).IndependentAxis = (IAxis)Value;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000066AC File Offset: 0x000048AC
		private object get_34_LineAreaBaseSeries_ActualIndependentAxis(object instance)
		{
			return ((LineAreaBaseSeries<LineDataPoint>)instance).ActualIndependentAxis;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x000066B9 File Offset: 0x000048B9
		private object get_35_LineAreaBaseSeries_ActualDependentRangeAxis(object instance)
		{
			return ((LineAreaBaseSeries<LineDataPoint>)instance).ActualDependentRangeAxis;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000066C6 File Offset: 0x000048C6
		private object get_36_DataPointSingleSeriesWithAxes_GlobalSeriesIndex(object instance)
		{
			return ((DataPointSingleSeriesWithAxes)instance).GlobalSeriesIndex;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000066D8 File Offset: 0x000048D8
		private object get_37_DataPointSeries_DependentValuePath(object instance)
		{
			return ((DataPointSeries)instance).DependentValuePath;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000066E5 File Offset: 0x000048E5
		private void set_37_DataPointSeries_DependentValuePath(object instance, object Value)
		{
			((DataPointSeries)instance).DependentValuePath = (string)Value;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000066F8 File Offset: 0x000048F8
		private object get_38_DataPointSeries_IndependentValuePath(object instance)
		{
			return ((DataPointSeries)instance).IndependentValuePath;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006705 File Offset: 0x00004905
		private void set_38_DataPointSeries_IndependentValuePath(object instance, object Value)
		{
			((DataPointSeries)instance).IndependentValuePath = (string)Value;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00006718 File Offset: 0x00004918
		private object get_39_DataPointSeries_ItemsSource(object instance)
		{
			return ((DataPointSeries)instance).ItemsSource;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00006725 File Offset: 0x00004925
		private void set_39_DataPointSeries_ItemsSource(object instance, object Value)
		{
			((DataPointSeries)instance).ItemsSource = (IEnumerable)Value;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00006738 File Offset: 0x00004938
		private object get_40_DataPointSeries_AnimationSequence(object instance)
		{
			return ((DataPointSeries)instance).AnimationSequence;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000674A File Offset: 0x0000494A
		private void set_40_DataPointSeries_AnimationSequence(object instance, object Value)
		{
			((DataPointSeries)instance).AnimationSequence = (AnimationSequence)Value;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000675D File Offset: 0x0000495D
		private object get_41_DataPointSeries_TransitionEasingFunction(object instance)
		{
			return ((DataPointSeries)instance).TransitionEasingFunction;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000676A File Offset: 0x0000496A
		private void set_41_DataPointSeries_TransitionEasingFunction(object instance, object Value)
		{
			((DataPointSeries)instance).TransitionEasingFunction = (EasingFunctionBase)Value;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000677D File Offset: 0x0000497D
		private object get_42_DataPointSeries_SelectedItem(object instance)
		{
			return ((DataPointSeries)instance).SelectedItem;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000678A File Offset: 0x0000498A
		private void set_42_DataPointSeries_SelectedItem(object instance, object Value)
		{
			((DataPointSeries)instance).SelectedItem = Value;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00006798 File Offset: 0x00004998
		private object get_43_DataPointSeries_LegendItemStyle(object instance)
		{
			return ((DataPointSeries)instance).LegendItemStyle;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000067A5 File Offset: 0x000049A5
		private void set_43_DataPointSeries_LegendItemStyle(object instance, object Value)
		{
			((DataPointSeries)instance).LegendItemStyle = (Style)Value;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000067B8 File Offset: 0x000049B8
		private object get_44_DataPointSeries_TransitionDuration(object instance)
		{
			return ((DataPointSeries)instance).TransitionDuration;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000067CA File Offset: 0x000049CA
		private void set_44_DataPointSeries_TransitionDuration(object instance, object Value)
		{
			((DataPointSeries)instance).TransitionDuration = (TimeSpan)Value;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000067DD File Offset: 0x000049DD
		private object get_45_Series_SeriesHost(object instance)
		{
			return ((Series)instance).SeriesHost;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000067EA File Offset: 0x000049EA
		private void set_45_Series_SeriesHost(object instance, object Value)
		{
			((Series)instance).SeriesHost = (ISeriesHost)Value;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x000067FD File Offset: 0x000049FD
		private object get_46_Series_LegendItems(object instance)
		{
			return ((Series)instance).LegendItems;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000680A File Offset: 0x00004A0A
		private object get_47_DataPoint_IsSelectionEnabled(object instance)
		{
			return ((DataPoint)instance).IsSelectionEnabled;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000681C File Offset: 0x00004A1C
		private void set_47_DataPoint_IsSelectionEnabled(object instance, object Value)
		{
			((DataPoint)instance).IsSelectionEnabled = (bool)Value;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000682F File Offset: 0x00004A2F
		private object get_48_DataPoint_ActualDependentValue(object instance)
		{
			return ((DataPoint)instance).ActualDependentValue;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006841 File Offset: 0x00004A41
		private void set_48_DataPoint_ActualDependentValue(object instance, object Value)
		{
			((DataPoint)instance).ActualDependentValue = (double)Value;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00006854 File Offset: 0x00004A54
		private object get_49_DataPoint_DependentValue(object instance)
		{
			return ((DataPoint)instance).DependentValue;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00006866 File Offset: 0x00004A66
		private void set_49_DataPoint_DependentValue(object instance, object Value)
		{
			((DataPoint)instance).DependentValue = (double)Value;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00006879 File Offset: 0x00004A79
		private object get_50_DataPoint_DependentValueStringFormat(object instance)
		{
			return ((DataPoint)instance).DependentValueStringFormat;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00006886 File Offset: 0x00004A86
		private void set_50_DataPoint_DependentValueStringFormat(object instance, object Value)
		{
			((DataPoint)instance).DependentValueStringFormat = (string)Value;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00006899 File Offset: 0x00004A99
		private object get_51_DataPoint_FormattedDependentValue(object instance)
		{
			return ((DataPoint)instance).FormattedDependentValue;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000068A6 File Offset: 0x00004AA6
		private object get_52_DataPoint_FormattedIndependentValue(object instance)
		{
			return ((DataPoint)instance).FormattedIndependentValue;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000068B3 File Offset: 0x00004AB3
		private object get_53_DataPoint_IndependentValue(object instance)
		{
			return ((DataPoint)instance).IndependentValue;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000068C0 File Offset: 0x00004AC0
		private void set_53_DataPoint_IndependentValue(object instance, object Value)
		{
			((DataPoint)instance).IndependentValue = Value;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000068CE File Offset: 0x00004ACE
		private object get_54_DataPoint_IndependentValueStringFormat(object instance)
		{
			return ((DataPoint)instance).IndependentValueStringFormat;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000068DB File Offset: 0x00004ADB
		private void set_54_DataPoint_IndependentValueStringFormat(object instance, object Value)
		{
			((DataPoint)instance).IndependentValueStringFormat = (string)Value;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000068EE File Offset: 0x00004AEE
		private object get_55_DataPoint_ActualIndependentValue(object instance)
		{
			return ((DataPoint)instance).ActualIndependentValue;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000068FB File Offset: 0x00004AFB
		private void set_55_DataPoint_ActualIndependentValue(object instance, object Value)
		{
			((DataPoint)instance).ActualIndependentValue = Value;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00006909 File Offset: 0x00004B09
		private object get_56_SectionPage_NavigationHelper(object instance)
		{
			return ((SectionPage)instance).NavigationHelper;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00006916 File Offset: 0x00004B16
		private object get_57_SectionPage_DefaultViewModel(object instance)
		{
			return ((SectionPage)instance).DefaultViewModel;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00006923 File Offset: 0x00004B23
		private object get_58_SectionPage_currentWorkoutId(object instance)
		{
			return ((SectionPage)instance).currentWorkoutId;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00006935 File Offset: 0x00004B35
		private object get_59_SectionPage_Viewport(object instance)
		{
			return ((SectionPage)instance).Viewport;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00006942 File Offset: 0x00004B42
		private object get_60_SectionPage_MapInitialized(object instance)
		{
			return ((SectionPage)instance).MapInitialized;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00006954 File Offset: 0x00004B54
		private object get_61_SectionPage_CancelTokenSource(object instance)
		{
			return ((SectionPage)instance).CancelTokenSource;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00006961 File Offset: 0x00004B61
		private object get_62_SectionPage_CurrentWorkout(object instance)
		{
			return ((SectionPage)instance).CurrentWorkout;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000696E File Offset: 0x00004B6E
		private object get_63_SectionPage_ViewInitialized(object instance)
		{
			return ((SectionPage)instance).ViewInitialized;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00006980 File Offset: 0x00004B80
		private object get_64_SectionPage_chartLine(object instance)
		{
			return ((SectionPage)instance).chartLine;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000698D File Offset: 0x00004B8D
		private object get_65_SectionPage_PosNeedleIcon(object instance)
		{
			return ((SectionPage)instance).PosNeedleIcon;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000699A File Offset: 0x00004B9A
		private object get_66_SleepPage_NavigationHelper(object instance)
		{
			return ((SleepPage)instance).NavigationHelper;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000069A7 File Offset: 0x00004BA7
		private object get_67_SleepPage_DefaultViewModel(object instance)
		{
			return ((SleepPage)instance).DefaultViewModel;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000069B4 File Offset: 0x00004BB4
		private object get_68_SleepPage_currentWorkoutId(object instance)
		{
			return ((SleepPage)instance).currentWorkoutId;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000069C6 File Offset: 0x00004BC6
		private object get_69_SleepPage_CancelTokenSource(object instance)
		{
			return ((SleepPage)instance).CancelTokenSource;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000069D3 File Offset: 0x00004BD3
		private object get_70_SleepPage_CurrentWorkout(object instance)
		{
			return ((SleepPage)instance).CurrentWorkout;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000069E0 File Offset: 0x00004BE0
		private object get_71_SleepPage_CanvasSize(object instance)
		{
			return ((SleepPage)instance).CanvasSize;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000069F4 File Offset: 0x00004BF4
		private IXamlMember CreateXamlMember(string longMemberName)
		{
			XamlMember xamlMember = null;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(longMemberName);
			if (num <= 2207772367U)
			{
				if (num <= 1296461789U)
				{
					if (num <= 631857235U)
					{
						if (num <= 121862125U)
						{
							if (num <= 23055767U)
							{
								if (num != 20475164U)
								{
									if (num == 23055767U)
									{
										if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Title")
										{
											XamlUserType xamlUserType = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
											xamlMember = new XamlMember(this, "Title", "Object");
											xamlMember.SetIsDependencyProperty();
											xamlMember.Getter = new Getter(this.get_23_Chart_Title);
											xamlMember.Setter = new Setter(this.set_23_Chart_Title);
										}
									}
								}
								else if (longMemberName == "MobileBandSync.SectionPage.DefaultViewModel")
								{
									XamlUserType xamlUserType2 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
									xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
									xamlMember.Getter = new Getter(this.get_57_SectionPage_DefaultViewModel);
									xamlMember.SetIsReadOnly();
								}
							}
							else if (num != 62774821U)
							{
								if (num == 121862125U)
								{
									if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.LegendItemStyle")
									{
										XamlUserType xamlUserType3 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
										xamlMember = new XamlMember(this, "LegendItemStyle", "Windows.UI.Xaml.Style");
										xamlMember.SetIsDependencyProperty();
										xamlMember.Getter = new Getter(this.get_43_DataPointSeries_LegendItemStyle);
										xamlMember.Setter = new Setter(this.set_43_DataPointSeries_LegendItemStyle);
									}
								}
							}
							else if (longMemberName == "MobileBandSync.SleepPage.CancelTokenSource")
							{
								XamlUserType xamlUserType4 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SleepPage");
								xamlMember = new XamlMember(this, "CancelTokenSource", "System.Threading.CancellationTokenSource");
								xamlMember.Getter = new Getter(this.get_69_SleepPage_CancelTokenSource);
								xamlMember.SetIsReadOnly();
							}
						}
						else if (num <= 328487702U)
						{
							if (num != 237178436U)
							{
								if (num == 328487702U)
								{
									if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IsSelectionEnabled")
									{
										XamlUserType xamlUserType5 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
										xamlMember = new XamlMember(this, "IsSelectionEnabled", "Boolean");
										xamlMember.SetIsDependencyProperty();
										xamlMember.Getter = new Getter(this.get_47_DataPoint_IsSelectionEnabled);
										xamlMember.Setter = new Setter(this.set_47_DataPoint_IsSelectionEnabled);
									}
								}
							}
							else if (longMemberName == "MobileBandSync.HubPage.DeviceTimer")
							{
								XamlUserType xamlUserType6 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.HubPage");
								xamlMember = new XamlMember(this, "DeviceTimer", "Windows.UI.Xaml.DispatcherTimer");
								xamlMember.Getter = new Getter(this.get_3_HubPage_DeviceTimer);
								xamlMember.SetIsReadOnly();
							}
						}
						else if (num != 451756451U)
						{
							if (num != 542613414U)
							{
								if (num == 631857235U)
								{
									if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendStyle")
									{
										XamlUserType xamlUserType7 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
										xamlMember = new XamlMember(this, "LegendStyle", "Windows.UI.Xaml.Style");
										xamlMember.SetIsDependencyProperty();
										xamlMember.Getter = new Getter(this.get_19_Chart_LegendStyle);
										xamlMember.Setter = new Setter(this.set_19_Chart_LegendStyle);
									}
								}
							}
							else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Series")
							{
								XamlUserType xamlUserType8 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
								xamlMember = new XamlMember(this, "Series", "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries>");
								xamlMember.Getter = new Getter(this.get_10_Chart_Series);
								xamlMember.Setter = new Setter(this.set_10_Chart_Series);
							}
						}
						else if (longMemberName == "MobileBandSync.SectionPage.Viewport")
						{
							XamlUserType xamlUserType9 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
							xamlMember = new XamlMember(this, "Viewport", "Windows.Devices.Geolocation.GeoboundingBox");
							xamlMember.Getter = new Getter(this.get_59_SectionPage_Viewport);
							xamlMember.SetIsReadOnly();
						}
					}
					else if (num <= 1003070753U)
					{
						if (num <= 981982925U)
						{
							if (num != 649236845U)
							{
								if (num == 981982925U)
								{
									if (longMemberName == "MobileBandSync.SectionPage.CancelTokenSource")
									{
										XamlUserType xamlUserType10 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
										xamlMember = new XamlMember(this, "CancelTokenSource", "System.Threading.CancellationTokenSource");
										xamlMember.Getter = new Getter(this.get_61_SectionPage_CancelTokenSource);
										xamlMember.SetIsReadOnly();
									}
								}
							}
							else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DataPointStyle")
							{
								XamlUserType xamlUserType11 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
								xamlMember = new XamlMember(this, "DataPointStyle", "Windows.UI.Xaml.Style");
								xamlMember.SetIsDependencyProperty();
								xamlMember.Getter = new Getter(this.get_29_DataPointSeries_DataPointStyle);
								xamlMember.Setter = new Setter(this.set_29_DataPointSeries_DataPointStyle);
							}
						}
						else if (num != 985118486U)
						{
							if (num == 1003070753U)
							{
								if (longMemberName == "MobileBandSync.SectionPage.chartLine")
								{
									XamlUserType xamlUserType12 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
									xamlMember = new XamlMember(this, "chartLine", "Windows.UI.Xaml.Shapes.Line");
									xamlMember.Getter = new Getter(this.get_64_SectionPage_chartLine);
									xamlMember.SetIsReadOnly();
								}
							}
						}
						else if (longMemberName == "MobileBandSync.HubPage.FilterAccepted")
						{
							XamlUserType xamlUserType13 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.HubPage");
							xamlMember = new XamlMember(this, "FilterAccepted", "Boolean");
							xamlMember.Getter = new Getter(this.get_5_HubPage_FilterAccepted);
							xamlMember.SetIsReadOnly();
						}
					}
					else if (num <= 1055521539U)
					{
						if (num != 1024076487U)
						{
							if (num == 1055521539U)
							{
								if (longMemberName == "MobileBandSync.SectionPage.PosNeedleIcon")
								{
									XamlUserType xamlUserType14 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
									xamlMember = new XamlMember(this, "PosNeedleIcon", "Windows.UI.Xaml.Controls.Maps.MapIcon");
									xamlMember.Getter = new Getter(this.get_65_SectionPage_PosNeedleIcon);
									xamlMember.SetIsReadOnly();
								}
							}
						}
						else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.DependentValueStringFormat")
						{
							XamlUserType xamlUserType15 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
							xamlMember = new XamlMember(this, "DependentValueStringFormat", "String");
							xamlMember.SetIsDependencyProperty();
							xamlMember.Getter = new Getter(this.get_50_DataPoint_DependentValueStringFormat);
							xamlMember.Setter = new Setter(this.set_50_DataPoint_DependentValueStringFormat);
						}
					}
					else if (num != 1267035029U)
					{
						if (num != 1277923893U)
						{
							if (num == 1296461789U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.Orientation")
								{
									XamlUserType xamlUserType16 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
									xamlMember = new XamlMember(this, "Orientation", "WinRTXamlToolkit.Controls.DataVisualization.Charting.AxisOrientation");
									xamlMember.Getter = new Getter(this.get_13_IAxis_Orientation);
									xamlMember.Setter = new Setter(this.set_13_IAxis_Orientation);
								}
							}
						}
						else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.TransitionDuration")
						{
							XamlUserType xamlUserType17 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
							xamlMember = new XamlMember(this, "TransitionDuration", "TimeSpan");
							xamlMember.SetIsDependencyProperty();
							xamlMember.Getter = new Getter(this.get_44_DataPointSeries_TransitionDuration);
							xamlMember.Setter = new Setter(this.set_44_DataPointSeries_TransitionDuration);
						}
					}
					else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.LegendItems")
					{
						XamlUserType xamlUserType18 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
						xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.ObservableCollection`1<Object>");
						xamlMember.Getter = new Getter(this.get_46_Series_LegendItems);
						xamlMember.SetIsReadOnly();
					}
				}
				else if (num <= 1808004601U)
				{
					if (num <= 1439678720U)
					{
						if (num <= 1337567926U)
						{
							if (num != 1307181161U)
							{
								if (num == 1337567926U)
								{
									if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.ActualIndependentAxis")
									{
										XamlUserType xamlUserType19 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
										xamlMember = new XamlMember(this, "ActualIndependentAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
										xamlMember.Getter = new Getter(this.get_34_LineAreaBaseSeries_ActualIndependentAxis);
										xamlMember.SetIsReadOnly();
									}
								}
							}
							else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries.PolylineStyle")
							{
								XamlUserType xamlUserType20 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries");
								xamlMember = new XamlMember(this, "PolylineStyle", "Windows.UI.Xaml.Style");
								xamlMember.SetIsDependencyProperty();
								xamlMember.Getter = new Getter(this.get_31_LineSeries_PolylineStyle);
								xamlMember.Setter = new Setter(this.set_31_LineSeries_PolylineStyle);
							}
						}
						else if (num != 1412666686U)
						{
							if (num == 1439678720U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries.LegendItems")
								{
									XamlUserType xamlUserType21 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeries");
									xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.ObservableCollection`1<Object>");
									xamlMember.Getter = new Getter(this.get_11_ISeries_LegendItems);
									xamlMember.SetIsReadOnly();
								}
							}
						}
						else if (longMemberName == "MobileBandSync.SectionPage.ViewInitialized")
						{
							XamlUserType xamlUserType22 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
							xamlMember = new XamlMember(this, "ViewInitialized", "Boolean");
							xamlMember.Getter = new Getter(this.get_63_SectionPage_ViewInitialized);
							xamlMember.SetIsReadOnly();
						}
					}
					else if (num <= 1593664280U)
					{
						if (num != 1502159000U)
						{
							if (num == 1593664280U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.SelectedItem")
								{
									XamlUserType xamlUserType23 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
									xamlMember = new XamlMember(this, "SelectedItem", "Object");
									xamlMember.SetIsDependencyProperty();
									xamlMember.Getter = new Getter(this.get_42_DataPointSeries_SelectedItem);
									xamlMember.Setter = new Setter(this.set_42_DataPointSeries_SelectedItem);
								}
							}
						}
						else if (longMemberName == "MobileBandSync.HubPage.DefaultViewModel")
						{
							XamlUserType xamlUserType24 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.HubPage");
							xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
							xamlMember.Getter = new Getter(this.get_1_HubPage_DefaultViewModel);
							xamlMember.SetIsReadOnly();
						}
					}
					else if (num != 1610096747U)
					{
						if (num != 1763365800U)
						{
							if (num == 1808004601U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.AnimationSequence")
								{
									XamlUserType xamlUserType25 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
									xamlMember = new XamlMember(this, "AnimationSequence", "WinRTXamlToolkit.Controls.DataVisualization.Charting.AnimationSequence");
									xamlMember.SetIsDependencyProperty();
									xamlMember.Getter = new Getter(this.get_40_DataPointSeries_AnimationSequence);
									xamlMember.Setter = new Setter(this.set_40_DataPointSeries_AnimationSequence);
								}
							}
						}
						else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.FormattedIndependentValue")
						{
							XamlUserType xamlUserType26 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
							xamlMember = new XamlMember(this, "FormattedIndependentValue", "String");
							xamlMember.SetIsDependencyProperty();
							xamlMember.Getter = new Getter(this.get_52_DataPoint_FormattedIndependentValue);
							xamlMember.SetIsReadOnly();
						}
					}
					else if (longMemberName == "MobileBandSync.HubPage.MapPickerInitialized")
					{
						XamlUserType xamlUserType27 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.HubPage");
						xamlMember = new XamlMember(this, "MapPickerInitialized", "Boolean");
						xamlMember.Getter = new Getter(this.get_6_HubPage_MapPickerInitialized);
						xamlMember.SetIsReadOnly();
					}
				}
				else if (num <= 2023240023U)
				{
					if (num <= 1860542974U)
					{
						if (num != 1857699913U)
						{
							if (num == 1860542974U)
							{
								if (longMemberName == "MobileBandSync.ItemPage.DefaultViewModel")
								{
									XamlUserType xamlUserType28 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.ItemPage");
									xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
									xamlMember.Getter = new Getter(this.get_9_ItemPage_DefaultViewModel);
									xamlMember.SetIsReadOnly();
								}
							}
						}
						else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.DependentAxes")
						{
							XamlUserType xamlUserType29 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
							xamlMember = new XamlMember(this, "DependentAxes", "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
							xamlMember.Getter = new Getter(this.get_15_IAxis_DependentAxes);
							xamlMember.SetIsReadOnly();
						}
					}
					else if (num != 1966185167U)
					{
						if (num == 2023240023U)
						{
							if (longMemberName == "MobileBandSync.SectionPage.NavigationHelper")
							{
								XamlUserType xamlUserType30 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
								xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
								xamlMember.Getter = new Getter(this.get_56_SectionPage_NavigationHelper);
								xamlMember.SetIsReadOnly();
							}
						}
					}
					else if (longMemberName == "MobileBandSync.SleepPage.NavigationHelper")
					{
						XamlUserType xamlUserType31 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SleepPage");
						xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
						xamlMember.Getter = new Getter(this.get_66_SleepPage_NavigationHelper);
						xamlMember.SetIsReadOnly();
					}
				}
				else if (num <= 2111996191U)
				{
					if (num != 2096469992U)
					{
						if (num == 2111996191U)
						{
							if (longMemberName == "MobileBandSync.HubPage.SyncView")
							{
								XamlUserType xamlUserType32 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.HubPage");
								xamlMember = new XamlMember(this, "SyncView", "MobileBandSync.Common.SyncViewModel");
								xamlMember.Getter = new Getter(this.get_2_HubPage_SyncView);
								xamlMember.Setter = new Setter(this.set_2_HubPage_SyncView);
							}
						}
					}
					else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.TransitionEasingFunction")
					{
						XamlUserType xamlUserType33 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
						xamlMember = new XamlMember(this, "TransitionEasingFunction", "Windows.UI.Xaml.Media.Animation.EasingFunctionBase");
						xamlMember.SetIsDependencyProperty();
						xamlMember.Getter = new Getter(this.get_41_DataPointSeries_TransitionEasingFunction);
						xamlMember.Setter = new Setter(this.set_41_DataPointSeries_TransitionEasingFunction);
					}
				}
				else if (num != 2124814250U)
				{
					if (num != 2204283136U)
					{
						if (num == 2207772367U)
						{
							if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries.Points")
							{
								XamlUserType xamlUserType34 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineSeries");
								xamlMember = new XamlMember(this, "Points", "Windows.UI.Xaml.Media.PointCollection");
								xamlMember.SetIsDependencyProperty();
								xamlMember.Getter = new Getter(this.get_30_LineSeries_Points);
								xamlMember.SetIsReadOnly();
							}
						}
					}
					else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.IndependentAxis")
					{
						XamlUserType xamlUserType35 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
						xamlMember = new XamlMember(this, "IndependentAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
						xamlMember.SetIsDependencyProperty();
						xamlMember.Getter = new Getter(this.get_33_LineAreaBaseSeries_IndependentAxis);
						xamlMember.Setter = new Setter(this.set_33_LineAreaBaseSeries_IndependentAxis);
					}
				}
				else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendItems")
				{
					XamlUserType xamlUserType36 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
					xamlMember = new XamlMember(this, "LegendItems", "System.Collections.ObjectModel.Collection`1<Object>");
					xamlMember.Getter = new Getter(this.get_18_Chart_LegendItems);
					xamlMember.SetIsReadOnly();
				}
			}
			else if (num <= 3139154834U)
			{
				if (num <= 2725052100U)
				{
					if (num <= 2439665275U)
					{
						if (num <= 2337656234U)
						{
							if (num != 2247661000U)
							{
								if (num == 2337656234U)
								{
									if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.ActualDependentRangeAxis")
									{
										XamlUserType xamlUserType37 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
										xamlMember = new XamlMember(this, "ActualDependentRangeAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IRangeAxis");
										xamlMember.Getter = new Getter(this.get_35_LineAreaBaseSeries_ActualDependentRangeAxis);
										xamlMember.SetIsReadOnly();
									}
								}
							}
							else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.TitleStyle")
							{
								XamlUserType xamlUserType38 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
								xamlMember = new XamlMember(this, "TitleStyle", "Windows.UI.Xaml.Style");
								xamlMember.SetIsDependencyProperty();
								xamlMember.Getter = new Getter(this.get_24_Chart_TitleStyle);
								xamlMember.Setter = new Setter(this.set_24_Chart_TitleStyle);
							}
						}
						else if (num != 2426412568U)
						{
							if (num == 2439665275U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.FormattedDependentValue")
								{
									XamlUserType xamlUserType39 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
									xamlMember = new XamlMember(this, "FormattedDependentValue", "String");
									xamlMember.SetIsDependencyProperty();
									xamlMember.Getter = new Getter(this.get_51_DataPoint_FormattedDependentValue);
									xamlMember.SetIsReadOnly();
								}
							}
						}
						else if (longMemberName == "MobileBandSync.SleepPage.CanvasSize")
						{
							XamlUserType xamlUserType40 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SleepPage");
							xamlMember = new XamlMember(this, "CanvasSize", "Windows.Foundation.Size");
							xamlMember.Getter = new Getter(this.get_71_SleepPage_CanvasSize);
							xamlMember.SetIsReadOnly();
						}
					}
					else if (num <= 2455304982U)
					{
						if (num != 2443995256U)
						{
							if (num == 2455304982U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Palette")
								{
									XamlUserType xamlUserType41 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
									xamlMember = new XamlMember(this, "Palette", "System.Collections.ObjectModel.Collection`1<Windows.UI.Xaml.ResourceDictionary>");
									xamlMember.SetIsDependencyProperty();
									xamlMember.Getter = new Getter(this.get_22_Chart_Palette);
									xamlMember.Setter = new Setter(this.set_22_Chart_Palette);
								}
							}
						}
						else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>.DependentRangeAxis")
						{
							XamlUserType xamlUserType42 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.LineAreaBaseSeries`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.LineDataPoint>");
							xamlMember = new XamlMember(this, "DependentRangeAxis", "WinRTXamlToolkit.Controls.DataVisualization.Charting.IRangeAxis");
							xamlMember.SetIsDependencyProperty();
							xamlMember.Getter = new Getter(this.get_32_LineAreaBaseSeries_DependentRangeAxis);
							xamlMember.Setter = new Setter(this.set_32_LineAreaBaseSeries_DependentRangeAxis);
						}
					}
					else if (num != 2480883846U)
					{
						if (num != 2673165169U)
						{
							if (num == 2725052100U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.ActualIndependentValue")
								{
									XamlUserType xamlUserType43 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
									xamlMember = new XamlMember(this, "ActualIndependentValue", "Object");
									xamlMember.SetIsDependencyProperty();
									xamlMember.Getter = new Getter(this.get_55_DataPoint_ActualIndependentValue);
									xamlMember.Setter = new Setter(this.set_55_DataPoint_ActualIndependentValue);
								}
							}
						}
						else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DependentValuePath")
						{
							XamlUserType xamlUserType44 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
							xamlMember = new XamlMember(this, "DependentValuePath", "String");
							xamlMember.Getter = new Getter(this.get_37_DataPointSeries_DependentValuePath);
							xamlMember.Setter = new Setter(this.set_37_DataPointSeries_DependentValuePath);
						}
					}
					else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IndependentValuePath")
					{
						XamlUserType xamlUserType45 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
						xamlMember = new XamlMember(this, "IndependentValuePath", "String");
						xamlMember.Getter = new Getter(this.get_38_DataPointSeries_IndependentValuePath);
						xamlMember.Setter = new Setter(this.set_38_DataPointSeries_IndependentValuePath);
					}
				}
				else if (num <= 2921783420U)
				{
					if (num <= 2737927134U)
					{
						if (num != 2726864442U)
						{
							if (num == 2737927134U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.Axes")
								{
									XamlUserType xamlUserType46 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
									xamlMember = new XamlMember(this, "Axes", "System.Collections.ObjectModel.Collection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
									xamlMember.Getter = new Getter(this.get_12_Chart_Axes);
									xamlMember.Setter = new Setter(this.set_12_Chart_Axes);
								}
							}
						}
						else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.PlotAreaStyle")
						{
							XamlUserType xamlUserType47 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
							xamlMember = new XamlMember(this, "PlotAreaStyle", "Windows.UI.Xaml.Style");
							xamlMember.SetIsDependencyProperty();
							xamlMember.Getter = new Getter(this.get_21_Chart_PlotAreaStyle);
							xamlMember.Setter = new Setter(this.set_21_Chart_PlotAreaStyle);
						}
					}
					else if (num != 2770642653U)
					{
						if (num == 2921783420U)
						{
							if (longMemberName == "MobileBandSync.SleepPage.currentWorkoutId")
							{
								XamlUserType xamlUserType48 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SleepPage");
								xamlMember = new XamlMember(this, "currentWorkoutId", "Int32");
								xamlMember.Getter = new Getter(this.get_68_SleepPage_currentWorkoutId);
								xamlMember.SetIsReadOnly();
							}
						}
					}
					else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IsSelectionEnabled")
					{
						XamlUserType xamlUserType49 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
						xamlMember = new XamlMember(this, "IsSelectionEnabled", "Boolean");
						xamlMember.SetIsDependencyProperty();
						xamlMember.Getter = new Getter(this.get_28_DataPointSeries_IsSelectionEnabled);
						xamlMember.Setter = new Setter(this.set_28_DataPointSeries_IsSelectionEnabled);
					}
				}
				else if (num <= 3050974545U)
				{
					if (num != 2987709385U)
					{
						if (num == 3050974545U)
						{
							if (longMemberName == "MobileBandSync.SectionPage.CurrentWorkout")
							{
								XamlUserType xamlUserType50 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
								xamlMember = new XamlMember(this, "CurrentWorkout", "MobileBandSync.Data.WorkoutItem");
								xamlMember.Getter = new Getter(this.get_62_SectionPage_CurrentWorkout);
								xamlMember.SetIsReadOnly();
							}
						}
					}
					else if (longMemberName == "MobileBandSync.SectionPage.MapInitialized")
					{
						XamlUserType xamlUserType51 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
						xamlMember = new XamlMember(this, "MapInitialized", "Boolean");
						xamlMember.Getter = new Getter(this.get_60_SectionPage_MapInitialized);
						xamlMember.SetIsReadOnly();
					}
				}
				else if (num != 3122573721U)
				{
					if (num != 3131955187U)
					{
						if (num == 3139154834U)
						{
							if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.IndependentValueBinding")
							{
								XamlUserType xamlUserType52 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
								xamlMember = new XamlMember(this, "IndependentValueBinding", "Windows.UI.Xaml.Data.Binding");
								xamlMember.Getter = new Getter(this.get_26_DataPointSeries_IndependentValueBinding);
								xamlMember.Setter = new Setter(this.set_26_DataPointSeries_IndependentValueBinding);
							}
						}
					}
					else if (longMemberName == "MobileBandSync.HubPage.ToggleFilter")
					{
						XamlUserType xamlUserType53 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.HubPage");
						xamlMember = new XamlMember(this, "ToggleFilter", "Windows.UI.Xaml.Controls.Primitives.ToggleButton");
						xamlMember.Getter = new Getter(this.get_7_HubPage_ToggleFilter);
						xamlMember.SetIsReadOnly();
					}
				}
				else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes.GlobalSeriesIndex")
				{
					XamlUserType xamlUserType54 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSingleSeriesWithAxes");
					xamlMember = new XamlMember(this, "GlobalSeriesIndex", "System.Nullable`1<Int32>");
					xamlMember.SetIsDependencyProperty();
					xamlMember.Getter = new Getter(this.get_36_DataPointSingleSeriesWithAxes_GlobalSeriesIndex);
					xamlMember.SetIsReadOnly();
				}
			}
			else if (num <= 3603149293U)
			{
				if (num <= 3437410228U)
				{
					if (num <= 3310559340U)
					{
						if (num != 3273522981U)
						{
							if (num == 3310559340U)
							{
								if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.Title")
								{
									XamlUserType xamlUserType55 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
									xamlMember = new XamlMember(this, "Title", "Object");
									xamlMember.SetIsDependencyProperty();
									xamlMember.Getter = new Getter(this.get_25_Series_Title);
									xamlMember.Setter = new Setter(this.set_25_Series_Title);
								}
							}
						}
						else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.ChartAreaStyle")
						{
							XamlUserType xamlUserType56 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
							xamlMember = new XamlMember(this, "ChartAreaStyle", "Windows.UI.Xaml.Style");
							xamlMember.SetIsDependencyProperty();
							xamlMember.Getter = new Getter(this.get_17_Chart_ChartAreaStyle);
							xamlMember.Setter = new Setter(this.set_17_Chart_ChartAreaStyle);
						}
					}
					else if (num != 3312231924U)
					{
						if (num == 3437410228U)
						{
							if (longMemberName == "MobileBandSync.SleepPage.DefaultViewModel")
							{
								XamlUserType xamlUserType57 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SleepPage");
								xamlMember = new XamlMember(this, "DefaultViewModel", "MobileBandSync.Common.ObservableDictionary");
								xamlMember.Getter = new Getter(this.get_67_SleepPage_DefaultViewModel);
								xamlMember.SetIsReadOnly();
							}
						}
					}
					else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IndependentValueStringFormat")
					{
						XamlUserType xamlUserType58 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
						xamlMember = new XamlMember(this, "IndependentValueStringFormat", "String");
						xamlMember.SetIsDependencyProperty();
						xamlMember.Getter = new Getter(this.get_54_DataPoint_IndependentValueStringFormat);
						xamlMember.Setter = new Setter(this.set_54_DataPoint_IndependentValueStringFormat);
					}
				}
				else if (num <= 3496200431U)
				{
					if (num != 3460433233U)
					{
						if (num == 3496200431U)
						{
							if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.ActualDependentValue")
							{
								XamlUserType xamlUserType59 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
								xamlMember = new XamlMember(this, "ActualDependentValue", "Double");
								xamlMember.SetIsDependencyProperty();
								xamlMember.Getter = new Getter(this.get_48_DataPoint_ActualDependentValue);
								xamlMember.Setter = new Setter(this.set_48_DataPoint_ActualDependentValue);
							}
						}
					}
					else if (longMemberName == "MobileBandSync.ItemPage.NavigationHelper")
					{
						XamlUserType xamlUserType60 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.ItemPage");
						xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
						xamlMember.Getter = new Getter(this.get_8_ItemPage_NavigationHelper);
						xamlMember.SetIsReadOnly();
					}
				}
				else if (num != 3527786265U)
				{
					if (num != 3534857138U)
					{
						if (num == 3603149293U)
						{
							if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Series.SeriesHost")
							{
								XamlUserType xamlUserType61 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Series");
								xamlMember = new XamlMember(this, "SeriesHost", "WinRTXamlToolkit.Controls.DataVisualization.Charting.ISeriesHost");
								xamlMember.Getter = new Getter(this.get_45_Series_SeriesHost);
								xamlMember.Setter = new Setter(this.set_45_Series_SeriesHost);
							}
						}
					}
					else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.IndependentValue")
					{
						XamlUserType xamlUserType62 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
						xamlMember = new XamlMember(this, "IndependentValue", "Object");
						xamlMember.SetIsDependencyProperty();
						xamlMember.Getter = new Getter(this.get_53_DataPoint_IndependentValue);
						xamlMember.Setter = new Setter(this.set_53_DataPoint_IndependentValue);
					}
				}
				else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint.DependentValue")
				{
					XamlUserType xamlUserType63 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPoint");
					xamlMember = new XamlMember(this, "DependentValue", "Double");
					xamlMember.SetIsDependencyProperty();
					xamlMember.Getter = new Getter(this.get_49_DataPoint_DependentValue);
					xamlMember.Setter = new Setter(this.set_49_DataPoint_DependentValue);
				}
			}
			else if (num <= 3927388190U)
			{
				if (num <= 3792588793U)
				{
					if (num != 3668697055U)
					{
						if (num == 3792588793U)
						{
							if (longMemberName == "MobileBandSync.SleepPage.CurrentWorkout")
							{
								XamlUserType xamlUserType64 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SleepPage");
								xamlMember = new XamlMember(this, "CurrentWorkout", "MobileBandSync.Data.WorkoutItem");
								xamlMember.Getter = new Getter(this.get_70_SleepPage_CurrentWorkout);
								xamlMember.SetIsReadOnly();
							}
						}
					}
					else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.ItemsSource")
					{
						XamlUserType xamlUserType65 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
						xamlMember = new XamlMember(this, "ItemsSource", "System.Collections.IEnumerable");
						xamlMember.SetIsDependencyProperty();
						xamlMember.Getter = new Getter(this.get_39_DataPointSeries_ItemsSource);
						xamlMember.Setter = new Setter(this.set_39_DataPointSeries_ItemsSource);
					}
				}
				else if (num != 3822882408U)
				{
					if (num == 3927388190U)
					{
						if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis.RegisteredListeners")
						{
							XamlUserType xamlUserType66 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis");
							xamlMember = new XamlMember(this, "RegisteredListeners", "System.Collections.ObjectModel.ObservableCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxisListener>");
							xamlMember.Getter = new Getter(this.get_14_IAxis_RegisteredListeners);
							xamlMember.SetIsReadOnly();
						}
					}
				}
				else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.ActualAxes")
				{
					XamlUserType xamlUserType67 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
					xamlMember = new XamlMember(this, "ActualAxes", "System.Collections.ObjectModel.ReadOnlyCollection`1<WinRTXamlToolkit.Controls.DataVisualization.Charting.IAxis>");
					xamlMember.Getter = new Getter(this.get_16_Chart_ActualAxes);
					xamlMember.SetIsReadOnly();
				}
			}
			else if (num <= 4023991716U)
			{
				if (num != 3959485423U)
				{
					if (num == 4023991716U)
					{
						if (longMemberName == "MobileBandSync.SectionPage.currentWorkoutId")
						{
							XamlUserType xamlUserType68 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.SectionPage");
							xamlMember = new XamlMember(this, "currentWorkoutId", "Int32");
							xamlMember.Getter = new Getter(this.get_58_SectionPage_currentWorkoutId);
							xamlMember.SetIsReadOnly();
						}
					}
				}
				else if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries.DependentValueBinding")
				{
					XamlUserType xamlUserType69 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.DataPointSeries");
					xamlMember = new XamlMember(this, "DependentValueBinding", "Windows.UI.Xaml.Data.Binding");
					xamlMember.Getter = new Getter(this.get_27_DataPointSeries_DependentValueBinding);
					xamlMember.Setter = new Setter(this.set_27_DataPointSeries_DependentValueBinding);
				}
			}
			else if (num != 4124560665U)
			{
				if (num != 4208683195U)
				{
					if (num == 4261184504U)
					{
						if (longMemberName == "WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart.LegendTitle")
						{
							XamlUserType xamlUserType70 = (XamlUserType)this.GetXamlTypeByName("WinRTXamlToolkit.Controls.DataVisualization.Charting.Chart");
							xamlMember = new XamlMember(this, "LegendTitle", "Object");
							xamlMember.SetIsDependencyProperty();
							xamlMember.Getter = new Getter(this.get_20_Chart_LegendTitle);
							xamlMember.Setter = new Setter(this.set_20_Chart_LegendTitle);
						}
					}
				}
				else if (longMemberName == "MobileBandSync.HubPage.NavigationHelper")
				{
					XamlUserType xamlUserType71 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.HubPage");
					xamlMember = new XamlMember(this, "NavigationHelper", "MobileBandSync.Common.NavigationHelper");
					xamlMember.Getter = new Getter(this.get_0_HubPage_NavigationHelper);
					xamlMember.SetIsReadOnly();
				}
			}
			else if (longMemberName == "MobileBandSync.HubPage.MapServiceToken")
			{
				XamlUserType xamlUserType72 = (XamlUserType)this.GetXamlTypeByName("MobileBandSync.HubPage");
				xamlMember = new XamlMember(this, "MapServiceToken", "String");
				xamlMember.Getter = new Getter(this.get_4_HubPage_MapServiceToken);
				xamlMember.SetIsReadOnly();
			}
			return xamlMember;
		}

		// Token: 0x0400005C RID: 92
		private Dictionary<string, IXamlType> _xamlTypeCacheByName = new Dictionary<string, IXamlType>();

		// Token: 0x0400005D RID: 93
		private Dictionary<Type, IXamlType> _xamlTypeCacheByType = new Dictionary<Type, IXamlType>();

		// Token: 0x0400005E RID: 94
		private Dictionary<string, IXamlMember> _xamlMembers = new Dictionary<string, IXamlMember>();

		// Token: 0x0400005F RID: 95
		private string[] _typeNameTable;

		// Token: 0x04000060 RID: 96
		private Type[] _typeTable;

		// Token: 0x04000061 RID: 97
		private List<IXamlMetadataProvider> _otherProviders;
	}
}
