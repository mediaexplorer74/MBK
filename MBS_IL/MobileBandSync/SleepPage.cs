using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using MobileBandSync.Common;
using MobileBandSync.Data;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace MobileBandSync;

public sealed class SleepPage : Page, IComponentConnector
{
	public enum SleepType
	{
		Unknown,
		Awake,
		LightSleep,
		RestfulSleep
	}

	private readonly NavigationHelper navigationHelper;

	private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

	private TimeSpan awakeTimeSpan;

	private TimeSpan sleepTimeSpan;

	private Color colAwakeBar;

	private Color colLightBar;

	private Color colRestfulBar;

	private Color colHeaderBackground;

	private Color colHeaderSummaryDate;

	private Color colHeaderSummaryTime;

	private Color colHeaderSummaryText;

	private Color colDiagramHeader;

	private Color colDiagramXAxisText;

	private Color colDiagramYAxisText;

	private Color colDiagramFooterTitle;

	private Color colDiagramFooterSubtitle;

	private Color colDiagramFooterDuration;

	private Color colDiagramGrid;

	private List<string> slCadence;

	private CultureInfo sleepPageCultureInfo;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Page pageRoot;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid DiagramGrid;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock Summary;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock Date;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock LightHours;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock LightMinutes;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock RestfulHours;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock RestfulMinutes;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock Hours;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock Minutes;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock AsleepTime;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock AwakeTime;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid XAxis;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid BarPanel;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Canvas SleepDiagrams;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid LineHour;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid HourText;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private bool _contentLoaded;

	public NavigationHelper NavigationHelper => navigationHelper;

	public ObservableDictionary DefaultViewModel => defaultViewModel;

	public int currentWorkoutId { get; private set; }

	public CancellationTokenSource CancelTokenSource { get; private set; }

	public WorkoutItem CurrentWorkout { get; private set; }

	public Size CanvasSize { get; private set; }

	public SleepPage()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		Color val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = byte.MaxValue;
		((Color)(ref val)).G = 139;
		((Color)(ref val)).B = 2;
		colAwakeBar = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 0;
		((Color)(ref val)).G = 121;
		((Color)(ref val)).B = 214;
		colLightBar = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 0;
		((Color)(ref val)).G = 61;
		((Color)(ref val)).B = 110;
		colRestfulBar = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 0;
		((Color)(ref val)).G = 90;
		((Color)(ref val)).B = 161;
		colHeaderBackground = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 144;
		((Color)(ref val)).G = 206;
		((Color)(ref val)).B = byte.MaxValue;
		colHeaderSummaryDate = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 242;
		((Color)(ref val)).G = byte.MaxValue;
		((Color)(ref val)).B = byte.MaxValue;
		colHeaderSummaryTime = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 242;
		((Color)(ref val)).G = byte.MaxValue;
		((Color)(ref val)).B = byte.MaxValue;
		colHeaderSummaryText = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 213;
		((Color)(ref val)).G = 213;
		((Color)(ref val)).B = 213;
		colDiagramHeader = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 213;
		((Color)(ref val)).G = 213;
		((Color)(ref val)).B = 213;
		colDiagramXAxisText = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 213;
		((Color)(ref val)).G = 213;
		((Color)(ref val)).B = 213;
		colDiagramYAxisText = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 235;
		((Color)(ref val)).G = 235;
		((Color)(ref val)).B = 235;
		colDiagramFooterTitle = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 145;
		((Color)(ref val)).G = 145;
		((Color)(ref val)).B = 145;
		colDiagramFooterSubtitle = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 35;
		((Color)(ref val)).G = 104;
		((Color)(ref val)).B = 169;
		colDiagramFooterDuration = val;
		val = default(Color);
		((Color)(ref val)).A = byte.MaxValue;
		((Color)(ref val)).R = 239;
		((Color)(ref val)).G = 238;
		((Color)(ref val)).B = 236;
		colDiagramGrid = val;
		slCadence = new List<string>();
		sleepPageCultureInfo = new CultureInfo("en-US");
		((Page)this)._002Ector();
		InitializeComponent();
		navigationHelper = new NavigationHelper((Page)(object)this);
		navigationHelper.LoadState += NavigationHelper_LoadState;
		navigationHelper.SaveState += NavigationHelper_SaveState;
		CancelTokenSource = new CancellationTokenSource();
	}

	private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
	{
		currentWorkoutId = (int)e.NavigationParameter;
		WorkoutItem workoutItem = await WorkoutDataSource.GetWorkoutAsync(currentWorkoutId);
		if (workoutItem.Items.Count == 0)
		{
			CancelTokenSource.Dispose();
			CancelTokenSource = new CancellationTokenSource();
		}
		workoutItem.Modified = false;
		ShowWorkout(workoutItem);
	}

	private async void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
	{
		if (CurrentWorkout != null && CurrentWorkout.Items != null && CurrentWorkout.Items.Count > 0)
		{
			CurrentWorkout.Items.Clear();
		}
	}

	private async Task ShowWorkout(WorkoutItem workout)
	{
		if (workout == null)
		{
			return;
		}
		try
		{
			CurrentWorkout = workout;
			DefaultViewModel["Workout"] = workout;
			if (CurrentWorkout != null)
			{
				CancelTokenSource.Dispose();
				CancelTokenSource = new CancellationTokenSource();
				if (CurrentWorkout.Items == null || CurrentWorkout.Items.Count == 0)
				{
					CurrentWorkout.TracksLoaded += WorkoutTracks_Loaded;
					await CurrentWorkout.ReadSleepData(CancelTokenSource.Token);
					SleepPage sleepPage = this;
					Size canvasSize = CanvasSize;
					double width = ((Size)(ref canvasSize)).Width;
					canvasSize = CanvasSize;
					await sleepPage.ShowChart(width, ((Size)(ref canvasSize)).Height, CurrentWorkout);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected override void OnNavigatedTo(NavigationEventArgs e)
	{
		navigationHelper.OnNavigatedTo(e);
	}

	protected override void OnNavigatedFrom(NavigationEventArgs e)
	{
		navigationHelper.OnNavigatedFrom(e);
	}

	private async void Left_Tapped(object sender, TappedRoutedEventArgs e)
	{
		if (CurrentWorkout != null)
		{
			if (CurrentWorkout.Items != null && CurrentWorkout.Items.Count > 0)
			{
				CurrentWorkout.Items.Clear();
			}
			WorkoutItem prevSibling = CurrentWorkout.GetPrevSibling();
			if (prevSibling != null)
			{
				CurrentWorkout = prevSibling;
				CancelTokenSource.Cancel();
				ShowWorkout(prevSibling);
			}
		}
	}

	private async void Right_Tapped(object sender, TappedRoutedEventArgs e)
	{
		if (CurrentWorkout != null)
		{
			if (CurrentWorkout.Items != null && CurrentWorkout.Items.Count > 0)
			{
				CurrentWorkout.Items.Clear();
			}
			WorkoutItem nextSibling = CurrentWorkout.GetNextSibling();
			if (nextSibling != null)
			{
				CurrentWorkout = nextSibling;
				CancelTokenSource.Cancel();
				ShowWorkout(CurrentWorkout);
			}
		}
	}

	private async void Share_Tapped(object sender, TappedRoutedEventArgs e)
	{
		_ = CurrentWorkout;
	}

	private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
	{
		Grid val = (Grid)((sender is Grid) ? sender : null);
		if (val != null)
		{
			e.GetPosition((UIElement)(object)val);
		}
	}

	private bool TryGoBack()
	{
		UIElement content = Window.Current.Content;
		Frame val = (Frame)(object)((content is Frame) ? content : null);
		if (val.CanGoBack)
		{
			val.GoBack();
			return true;
		}
		return false;
	}

	private bool DrawSleepDiagram()
	{
		((ICollection<UIElement>)((Panel)BarPanel).Children).Clear();
		((ICollection<ColumnDefinition>)BarPanel.ColumnDefinitions).Clear();
		if (CurrentWorkout != null && CurrentWorkout.Items.Count > 0)
		{
			uint lastSleepType = CurrentWorkout.Items[0].SleepType;
			uint lastSegmentType = CurrentWorkout.Items[0].SegmentType;
			DateTime lastSegmentDate = CurrentWorkout.Start;
			_ = CurrentWorkout.Start;
			AddXAxis(CurrentWorkout.Start, CurrentWorkout.End);
			Hours.put_Text(CurrentWorkout.SleepDuration.Hours.ToString());
			Minutes.put_Text(CurrentWorkout.SleepDuration.Minutes.ToString("00"));
			RestfulHours.put_Text(CurrentWorkout.TotalRestfulSleepDuration.Hours.ToString());
			RestfulMinutes.put_Text(CurrentWorkout.TotalRestfulSleepDuration.Minutes.ToString("00"));
			LightHours.put_Text(CurrentWorkout.TotalRestlessSleepDuration.Hours.ToString());
			LightMinutes.put_Text(CurrentWorkout.TotalRestlessSleepDuration.Minutes.ToString("00"));
			foreach (TrackItem item in CurrentWorkout.Items)
			{
				_ = CurrentWorkout.Start + new TimeSpan(0, 0, item.SecFromStart);
				AddSleepItem(item, ref lastSleepType, ref lastSegmentType, ref lastSegmentDate);
			}
			AddSleepItem(null, ref lastSleepType, ref lastSegmentType, ref lastSegmentDate);
		}
		return true;
	}

	private void AddSleepItem(TrackItem item, ref uint lastSleepType, ref uint lastSegmentType, ref DateTime lastSegmentDate)
	{
		if (item != null)
		{
			DateTime dateTime = CurrentWorkout.Start + new TimeSpan(0, 0, item.SecFromStart);
			if (item.SleepType == lastSleepType && item.SegmentType == lastSegmentType && item != CurrentWorkout.Items[CurrentWorkout.Items.Count - 1])
			{
				return;
			}
			TimeSpan timeSpan = new TimeSpan(0, (int)(dateTime - lastSegmentDate).TotalMinutes, 0);
			string item2 = Convert.ToString(item.Cadence, 2).PadLeft(32, '0');
			slCadence.Add(item2);
			if (lastSleepType == 0 && lastSegmentType == 0)
			{
				AddAwakeBar(timeSpan);
				awakeTimeSpan += timeSpan;
			}
			else
			{
				if (lastSleepType >= 20000)
				{
					AddRestfulBar(timeSpan);
				}
				else
				{
					AddLightBar(timeSpan);
				}
				sleepTimeSpan += timeSpan;
			}
			lastSleepType = item.SleepType;
			lastSegmentType = item.SegmentType;
			lastSegmentDate = dateTime;
		}
		else if (lastSegmentDate < CurrentWorkout.End)
		{
			TimeSpan timeSpan2 = new TimeSpan(0, (int)(CurrentWorkout.End - lastSegmentDate).TotalMinutes, 0);
			AddAwakeBar(timeSpan2);
			awakeTimeSpan += timeSpan2;
		}
	}

	private bool AddXAxis(DateTime dtStart, DateTime dtEnd)
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Expected O, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Expected O, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Expected O, but got Unknown
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		bool result = true;
		int num = 60 - dtStart.Minute;
		int minute = dtEnd.Minute;
		DateTime dateTime = dtStart.AddMinutes(num);
		Date.put_Text(dtStart.ToLocalTime().ToString("ddd M/d", sleepPageCultureInfo) + "   Avg HR: " + CurrentWorkout.AvgHR + "   Max HR: " + CurrentWorkout.MaxHR + "   Cal: " + CurrentWorkout.Calories);
		string text = dtStart.ToLocalTime().ToString("h:mmtt", sleepPageCultureInfo).ToLower();
		text = text.Substring(0, text.Length - 1);
		AsleepTime.put_Text("Asleep " + text);
		text = dtEnd.ToLocalTime().ToString("h:mmtt", sleepPageCultureInfo).ToLower();
		text = text.Substring(0, text.Length - 1);
		AwakeTime.put_Text("Woke up " + text);
		((ICollection<UIElement>)((Panel)HourText).Children).Clear();
		((ICollection<ColumnDefinition>)LineHour.ColumnDefinitions).Clear();
		((ICollection<ColumnDefinition>)HourText.ColumnDefinitions).Clear();
		Color val4;
		if (num > 0)
		{
			ColumnDefinitionCollection columnDefinitions = LineHour.ColumnDefinitions;
			ColumnDefinition val = new ColumnDefinition();
			val.put_Width(new GridLength(num, GridUnitType.Star));
			((ICollection<ColumnDefinition>)columnDefinitions).Add(val);
			ColumnDefinitionCollection columnDefinitions2 = HourText.ColumnDefinitions;
			ColumnDefinition val2 = new ColumnDefinition();
			val2.put_Width(new GridLength(num, GridUnitType.Star));
			((ICollection<ColumnDefinition>)columnDefinitions2).Add(val2);
			if (num > 15)
			{
				string text2;
				if (dtStart.ToLocalTime().Hour == 23 || dtStart.ToLocalTime().Hour == 0)
				{
					text2 = dtStart.ToLocalTime().ToString("htt", sleepPageCultureInfo).ToLower();
					text2 = text2.Substring(0, text2.Length - 1);
				}
				else
				{
					text2 = dtStart.ToLocalTime().ToString("hh", sleepPageCultureInfo).TrimStart('0');
				}
				TextBlock val3 = new TextBlock();
				val3.put_Text(text2);
				((FrameworkElement)val3).put_VerticalAlignment((VerticalAlignment)2);
				((FrameworkElement)val3).put_HorizontalAlignment((HorizontalAlignment)2);
				val3.put_FontSize(16.0);
				val3.put_FontWeight(FontWeights.Normal);
				val4 = default(Color);
				((Color)(ref val4)).A = byte.MaxValue;
				((Color)(ref val4)).R = 145;
				((Color)(ref val4)).G = 145;
				((Color)(ref val4)).B = 145;
				val3.put_Foreground((Brush)new SolidColorBrush(val4));
				((FrameworkElement)val3).put_Margin(new Thickness(0.0, 0.0, -4.0, 0.0));
				TextBlock val5 = val3;
				Grid.SetColumn((FrameworkElement)(object)val5, 0);
				((ICollection<UIElement>)((Panel)HourText).Children).Add((UIElement)(object)val5);
			}
			Border val6 = new Border();
			val6.put_BorderThickness(new Thickness(0.0, 0.0, 1.0, 0.0));
			val4 = default(Color);
			((Color)(ref val4)).A = byte.MaxValue;
			((Color)(ref val4)).R = 237;
			((Color)(ref val4)).G = 236;
			((Color)(ref val4)).B = 234;
			val6.put_BorderBrush((Brush)new SolidColorBrush(val4));
			((FrameworkElement)val6).put_HorizontalAlignment((HorizontalAlignment)3);
			((FrameworkElement)val6).put_VerticalAlignment((VerticalAlignment)3);
			((FrameworkElement)val6).put_Margin(new Thickness(0.0, 0.0, 0.0, 23.0));
			Grid.SetColumn((FrameworkElement)(object)val6, ((ICollection<ColumnDefinition>)LineHour.ColumnDefinitions).Count - 1);
			Grid.SetRow((FrameworkElement)(object)val6, 0);
			((ICollection<UIElement>)((Panel)LineHour).Children).Add((UIElement)(object)val6);
		}
		do
		{
			ColumnDefinitionCollection columnDefinitions3 = LineHour.ColumnDefinitions;
			ColumnDefinition val7 = new ColumnDefinition();
			val7.put_Width(new GridLength(60.0, GridUnitType.Star));
			((ICollection<ColumnDefinition>)columnDefinitions3).Add(val7);
			ColumnDefinitionCollection columnDefinitions4 = HourText.ColumnDefinitions;
			ColumnDefinition val8 = new ColumnDefinition();
			val8.put_Width(new GridLength(60.0, GridUnitType.Star));
			((ICollection<ColumnDefinition>)columnDefinitions4).Add(val8);
			string text3;
			if (dateTime.ToLocalTime().Hour == 23 || dateTime.ToLocalTime().Hour == 0)
			{
				text3 = dateTime.ToLocalTime().ToString("htt", sleepPageCultureInfo).ToLower();
				text3 = text3.Substring(0, text3.Length - 1);
			}
			else
			{
				text3 = dateTime.ToLocalTime().ToString("hh", sleepPageCultureInfo).TrimStart('0');
			}
			TextBlock val9 = new TextBlock();
			val9.put_Text(text3);
			((FrameworkElement)val9).put_VerticalAlignment((VerticalAlignment)2);
			((FrameworkElement)val9).put_HorizontalAlignment((HorizontalAlignment)2);
			val9.put_FontSize(16.0);
			val9.put_FontWeight(FontWeights.Normal);
			val4 = default(Color);
			((Color)(ref val4)).A = byte.MaxValue;
			((Color)(ref val4)).R = 145;
			((Color)(ref val4)).G = 145;
			((Color)(ref val4)).B = 145;
			val9.put_Foreground((Brush)new SolidColorBrush(val4));
			((FrameworkElement)val9).put_Margin(new Thickness(0.0, 0.0, -4.0, 0.0));
			TextBlock val10 = val9;
			Grid.SetColumn((FrameworkElement)(object)val10, ((ICollection<ColumnDefinition>)HourText.ColumnDefinitions).Count - 1);
			((ICollection<UIElement>)((Panel)HourText).Children).Add((UIElement)(object)val10);
			Border val11 = new Border();
			val11.put_BorderThickness(new Thickness(0.0, 0.0, 1.0, 0.0));
			val4 = default(Color);
			((Color)(ref val4)).A = byte.MaxValue;
			((Color)(ref val4)).R = 237;
			((Color)(ref val4)).G = 236;
			((Color)(ref val4)).B = 234;
			val11.put_BorderBrush((Brush)new SolidColorBrush(val4));
			((FrameworkElement)val11).put_HorizontalAlignment((HorizontalAlignment)3);
			((FrameworkElement)val11).put_VerticalAlignment((VerticalAlignment)3);
			((FrameworkElement)val11).put_Margin(new Thickness(0.0, 0.0, 0.0, 23.0));
			Grid.SetColumn((FrameworkElement)(object)val11, ((ICollection<ColumnDefinition>)LineHour.ColumnDefinitions).Count - 1);
			Grid.SetRow((FrameworkElement)(object)val11, 0);
			((ICollection<UIElement>)((Panel)LineHour).Children).Add((UIElement)(object)val11);
			dateTime = dateTime.AddHours(1.0);
		}
		while (dateTime <= dtEnd);
		if (minute > 0)
		{
			ColumnDefinitionCollection columnDefinitions5 = LineHour.ColumnDefinitions;
			ColumnDefinition val12 = new ColumnDefinition();
			val12.put_Width(new GridLength(minute, GridUnitType.Star));
			((ICollection<ColumnDefinition>)columnDefinitions5).Add(val12);
			ColumnDefinitionCollection columnDefinitions6 = HourText.ColumnDefinitions;
			ColumnDefinition val13 = new ColumnDefinition();
			val13.put_Width(new GridLength(minute, GridUnitType.Star));
			((ICollection<ColumnDefinition>)columnDefinitions6).Add(val13);
		}
		return result;
	}

	private bool AddBar(SleepType sleepType, TimeSpan tsLength)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		bool result = true;
		Rectangle val = new Rectangle();
		((FrameworkElement)val).put_Margin(new Thickness(0.0, 0.0, 0.0, 0.0));
		((FrameworkElement)val).put_VerticalAlignment((VerticalAlignment)3);
		((FrameworkElement)val).put_HorizontalAlignment((HorizontalAlignment)3);
		switch (sleepType)
		{
		case SleepType.Awake:
			((Shape)val).put_Fill((Brush)new SolidColorBrush(colAwakeBar));
			((Shape)val).put_Stroke((Brush)new SolidColorBrush(colAwakeBar));
			Grid.SetRow((FrameworkElement)(object)val, 0);
			break;
		case SleepType.LightSleep:
			((Shape)val).put_Fill((Brush)new SolidColorBrush(colLightBar));
			((Shape)val).put_Stroke((Brush)new SolidColorBrush(colLightBar));
			Grid.SetRow((FrameworkElement)(object)val, 1);
			break;
		case SleepType.RestfulSleep:
			((Shape)val).put_Fill((Brush)new SolidColorBrush(colRestfulBar));
			((Shape)val).put_Stroke((Brush)new SolidColorBrush(colRestfulBar));
			Grid.SetRow((FrameworkElement)(object)val, 1);
			Grid.SetRowSpan((FrameworkElement)(object)val, 2);
			break;
		}
		ColumnDefinitionCollection columnDefinitions = BarPanel.ColumnDefinitions;
		ColumnDefinition val2 = new ColumnDefinition();
		val2.put_Width(new GridLength(tsLength.TotalMinutes, GridUnitType.Star));
		((ICollection<ColumnDefinition>)columnDefinitions).Add(val2);
		Grid.SetColumn((FrameworkElement)(object)val, ((ICollection<ColumnDefinition>)BarPanel.ColumnDefinitions).Count - 1);
		((ICollection<UIElement>)((Panel)BarPanel).Children).Add((UIElement)(object)val);
		return result;
	}

	private bool AddAwakeBar(TimeSpan dtLength)
	{
		return AddBar(SleepType.Awake, dtLength);
	}

	private bool AddLightBar(TimeSpan dtLength)
	{
		return AddBar(SleepType.LightSleep, dtLength);
	}

	private bool AddRestfulBar(TimeSpan dtLength)
	{
		return AddBar(SleepType.RestfulSleep, dtLength);
	}

	private async void WorkoutTracks_Loaded(object sender, TracksLoadedEventArgs e)
	{
		e.Workout.TracksLoaded -= WorkoutTracks_Loaded;
		if (e.Workout != CurrentWorkout)
		{
			return;
		}
		try
		{
			TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(((DependencyObject)this).Dispatcher.RunAsync((CoreDispatcherPriority)1, (DispatchedHandler)delegate
			{
				if (CurrentWorkout.Items.Count > 0)
				{
					DrawSleepDiagram();
				}
			}));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
				taskAwaiter = taskAwaiter2;
			}
			taskAwaiter.GetResult();
		}
		catch (Exception)
		{
		}
	}

	private void RunIfSelected(UIElement element, Action action)
	{
		action();
	}

	public async Task ShowChart(double width, double height, WorkoutItem workout)
	{
		TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(((DependencyObject)this).Dispatcher.RunAsync((CoreDispatcherPriority)0, (DispatchedHandler)delegate
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Expected O, but got Unknown
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Expected O, but got Unknown
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Expected O, but got Unknown
			double num = height / 70.0;
			_ = height / 10.0;
			double num2 = width / (double)workout.Items.Count;
			double num3 = 0.0;
			((ICollection<UIElement>)((Panel)SleepDiagrams).Children).Clear();
			PointCollection val = new PointCollection();
			PointCollection val2 = new PointCollection();
			foreach (TrackItem item in workout.Items)
			{
				((ICollection<Point>)val).Add(new Point(num3, height - (double)(int)item.Heartrate * num + 40.0));
				((ICollection<Point>)val2).Add(new Point(num3, height - (double)(int)item.Heartrate * num + 40.0));
				num3 += num2;
			}
			((ICollection<Point>)val).Add(new Point(num3 - num2, height));
			((ICollection<Point>)val).Add(new Point(0.0, height));
			Polyline val3 = new Polyline();
			val3.put_Points(val);
			((Shape)val3).put_Stroke((Brush)new SolidColorBrush(Colors.Transparent));
			Color val4 = default(Color);
			((Color)(ref val4)).A = 51;
			((Color)(ref val4)).R = byte.MaxValue;
			((Color)(ref val4)).B = 0;
			((Color)(ref val4)).G = 0;
			((Shape)val3).put_Fill((Brush)new SolidColorBrush(val4));
			((Shape)val3).put_StrokeThickness(1.0);
			Polyline val5 = new Polyline();
			val5.put_Points(val2);
			val4 = default(Color);
			((Color)(ref val4)).A = byte.MaxValue;
			((Color)(ref val4)).R = byte.MaxValue;
			((Color)(ref val4)).B = 0;
			((Color)(ref val4)).G = 0;
			((Shape)val5).put_Stroke((Brush)new SolidColorBrush(val4));
			((Shape)val5).put_StrokeThickness(1.0);
			((ICollection<UIElement>)((Panel)SleepDiagrams).Children).Add((UIElement)(object)val3);
			((ICollection<UIElement>)((Panel)SleepDiagrams).Children).Add((UIElement)(object)val5);
		}));
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
			taskAwaiter = taskAwaiter2;
		}
		taskAwaiter.GetResult();
	}

	private async void SleepDiagrams_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		if (e == null)
		{
			return;
		}
		CanvasSize = e.NewSize;
		if (e.PreviousSize != e.NewSize)
		{
			Canvas val = (Canvas)((sender is Canvas) ? sender : null);
			WorkoutItem workoutItem = ((val != null) ? (((FrameworkElement)val).DataContext as WorkoutItem) : null);
			if (workoutItem != null)
			{
				SleepPage sleepPage = this;
				Size newSize = e.NewSize;
				double width = ((Size)(ref newSize)).Width;
				newSize = e.NewSize;
				await sleepPage.ShowChart(width, ((Size)(ref newSize)).Height, workoutItem);
			}
		}
	}

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Application.LoadComponent((object)this, new Uri("ms-appx:///SleepPage.xaml"), (ComponentResourceLocation)0);
			pageRoot = (Page)((FrameworkElement)this).FindName("pageRoot");
			DiagramGrid = (Grid)((FrameworkElement)this).FindName("DiagramGrid");
			Summary = (TextBlock)((FrameworkElement)this).FindName("Summary");
			Date = (TextBlock)((FrameworkElement)this).FindName("Date");
			LightHours = (TextBlock)((FrameworkElement)this).FindName("LightHours");
			LightMinutes = (TextBlock)((FrameworkElement)this).FindName("LightMinutes");
			RestfulHours = (TextBlock)((FrameworkElement)this).FindName("RestfulHours");
			RestfulMinutes = (TextBlock)((FrameworkElement)this).FindName("RestfulMinutes");
			Hours = (TextBlock)((FrameworkElement)this).FindName("Hours");
			Minutes = (TextBlock)((FrameworkElement)this).FindName("Minutes");
			AsleepTime = (TextBlock)((FrameworkElement)this).FindName("AsleepTime");
			AwakeTime = (TextBlock)((FrameworkElement)this).FindName("AwakeTime");
			XAxis = (Grid)((FrameworkElement)this).FindName("XAxis");
			BarPanel = (Grid)((FrameworkElement)this).FindName("BarPanel");
			SleepDiagrams = (Canvas)((FrameworkElement)this).FindName("SleepDiagrams");
			LineHour = (Grid)((FrameworkElement)this).FindName("LineHour");
			HourText = (Grid)((FrameworkElement)this).FindName("HourText");
		}
	}

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	[DebuggerNonUserCode]
	public void Connect(int connectionId, object target)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
		{
			UIElement val = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val.add_Tapped, (Action<EventRegistrationToken>)val.remove_Tapped, new TappedEventHandler(Grid_Tapped));
			break;
		}
		case 2:
		{
			FrameworkElement val2 = (FrameworkElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<SizeChangedEventHandler, EventRegistrationToken>)val2.add_SizeChanged, (Action<EventRegistrationToken>)val2.remove_SizeChanged, new SizeChangedEventHandler(SleepDiagrams_SizeChanged));
			break;
		}
		case 3:
		{
			UIElement val = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val.add_Tapped, (Action<EventRegistrationToken>)val.remove_Tapped, new TappedEventHandler(Left_Tapped));
			break;
		}
		case 4:
		{
			UIElement val = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val.add_Tapped, (Action<EventRegistrationToken>)val.remove_Tapped, new TappedEventHandler(Right_Tapped));
			break;
		}
		}
		_contentLoaded = true;
	}
}
