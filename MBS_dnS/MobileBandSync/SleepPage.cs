using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using MobileBandSync.Common;
using MobileBandSync.Data;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace MobileBandSync
{
	// Token: 0x02000006 RID: 6
	public sealed class SleepPage : Page, IComponentConnector
	{
		// Token: 0x06000060 RID: 96 RVA: 0x00003580 File Offset: 0x00001780
		public SleepPage()
		{
			this.InitializeComponent();
			this.navigationHelper = new NavigationHelper(this);
			this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
			this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
			this.CancelTokenSource = new CancellationTokenSource();
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00003954 File Offset: 0x00001B54
		public NavigationHelper NavigationHelper
		{
			get
			{
				return this.navigationHelper;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000395C File Offset: 0x00001B5C
		public ObservableDictionary DefaultViewModel
		{
			get
			{
				return this.defaultViewModel;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00003964 File Offset: 0x00001B64
		// (set) Token: 0x06000064 RID: 100 RVA: 0x0000396C File Offset: 0x00001B6C
		public int currentWorkoutId { get; private set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00003975 File Offset: 0x00001B75
		// (set) Token: 0x06000066 RID: 102 RVA: 0x0000397D File Offset: 0x00001B7D
		public CancellationTokenSource CancelTokenSource { get; private set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00003986 File Offset: 0x00001B86
		// (set) Token: 0x06000068 RID: 104 RVA: 0x0000398E File Offset: 0x00001B8E
		public WorkoutItem CurrentWorkout { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003997 File Offset: 0x00001B97
		// (set) Token: 0x0600006A RID: 106 RVA: 0x0000399F File Offset: 0x00001B9F
		public Size CanvasSize { get; private set; }

		// Token: 0x0600006B RID: 107 RVA: 0x000039A8 File Offset: 0x00001BA8
		private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
		{
			this.currentWorkoutId = (int)e.NavigationParameter;
			WorkoutItem workoutItem = await WorkoutDataSource.GetWorkoutAsync(this.currentWorkoutId);
			if (workoutItem.Items.Count == 0)
			{
				this.CancelTokenSource.Dispose();
				this.CancelTokenSource = new CancellationTokenSource();
			}
			workoutItem.Modified = false;
			this.ShowWorkout(workoutItem);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000039EC File Offset: 0x00001BEC
		private async void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
		{
			if (this.CurrentWorkout != null && this.CurrentWorkout.Items != null && this.CurrentWorkout.Items.Count > 0)
			{
				this.CurrentWorkout.Items.Clear();
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003A28 File Offset: 0x00001C28
		private async Task ShowWorkout(WorkoutItem workout)
		{
			if (workout != null)
			{
				try
				{
					this.CurrentWorkout = workout;
					this.DefaultViewModel["Workout"] = workout;
					if (this.CurrentWorkout != null)
					{
						this.CancelTokenSource.Dispose();
						this.CancelTokenSource = new CancellationTokenSource();
						if (this.CurrentWorkout.Items == null || this.CurrentWorkout.Items.Count == 0)
						{
							this.CurrentWorkout.TracksLoaded += this.WorkoutTracks_Loaded;
							await this.CurrentWorkout.ReadSleepData(this.CancelTokenSource.Token);
							await this.ShowChart(this.CanvasSize.Width, this.CanvasSize.Height, this.CurrentWorkout);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003A75 File Offset: 0x00001C75
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			this.navigationHelper.OnNavigatedTo(e);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003A83 File Offset: 0x00001C83
		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			this.navigationHelper.OnNavigatedFrom(e);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003A94 File Offset: 0x00001C94
		private async void Left_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (this.CurrentWorkout != null)
			{
				if (this.CurrentWorkout.Items != null && this.CurrentWorkout.Items.Count > 0)
				{
					this.CurrentWorkout.Items.Clear();
				}
				WorkoutItem prevSibling = this.CurrentWorkout.GetPrevSibling();
				if (prevSibling != null)
				{
					this.CurrentWorkout = prevSibling;
					this.CancelTokenSource.Cancel();
					this.ShowWorkout(prevSibling);
				}
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003AD0 File Offset: 0x00001CD0
		private async void Right_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (this.CurrentWorkout != null)
			{
				if (this.CurrentWorkout.Items != null && this.CurrentWorkout.Items.Count > 0)
				{
					this.CurrentWorkout.Items.Clear();
				}
				WorkoutItem nextSibling = this.CurrentWorkout.GetNextSibling();
				if (nextSibling != null)
				{
					this.CurrentWorkout = nextSibling;
					this.CancelTokenSource.Cancel();
					this.ShowWorkout(this.CurrentWorkout);
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003B0C File Offset: 0x00001D0C
		private async void Share_Tapped(object sender, TappedRoutedEventArgs e)
		{
			WorkoutItem currentWorkout = this.CurrentWorkout;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003B48 File Offset: 0x00001D48
		private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Grid grid = sender as Grid;
			if (grid != null)
			{
				e.GetPosition(grid);
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003B8C File Offset: 0x00001D8C
		private bool TryGoBack()
		{
			Frame frame = Window.Current.Content as Frame;
			if (frame.CanGoBack)
			{
				frame.GoBack();
				return true;
			}
			return false;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003BBC File Offset: 0x00001DBC
		private bool DrawSleepDiagram()
		{
			this.BarPanel.Children.Clear();
			this.BarPanel.ColumnDefinitions.Clear();
			if (this.CurrentWorkout != null && this.CurrentWorkout.Items.Count > 0)
			{
				uint sleepType = (uint)this.CurrentWorkout.Items[0].SleepType;
				uint segmentType = (uint)this.CurrentWorkout.Items[0].SegmentType;
				DateTime start = this.CurrentWorkout.Start;
				DateTime start2 = this.CurrentWorkout.Start;
				this.AddXAxis(this.CurrentWorkout.Start, this.CurrentWorkout.End);
				this.Hours.put_Text(this.CurrentWorkout.SleepDuration.Hours.ToString());
				this.Minutes.put_Text(this.CurrentWorkout.SleepDuration.Minutes.ToString("00"));
				this.RestfulHours.put_Text(this.CurrentWorkout.TotalRestfulSleepDuration.Hours.ToString());
				this.RestfulMinutes.put_Text(this.CurrentWorkout.TotalRestfulSleepDuration.Minutes.ToString("00"));
				this.LightHours.put_Text(this.CurrentWorkout.TotalRestlessSleepDuration.Hours.ToString());
				this.LightMinutes.put_Text(this.CurrentWorkout.TotalRestlessSleepDuration.Minutes.ToString("00"));
				foreach (TrackItem trackItem in this.CurrentWorkout.Items)
				{
					this.CurrentWorkout.Start + new TimeSpan(0, 0, trackItem.SecFromStart);
					this.AddSleepItem(trackItem, ref sleepType, ref segmentType, ref start);
				}
				this.AddSleepItem(null, ref sleepType, ref segmentType, ref start);
			}
			return true;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003DE8 File Offset: 0x00001FE8
		private void AddSleepItem(TrackItem item, ref uint lastSleepType, ref uint lastSegmentType, ref DateTime lastSegmentDate)
		{
			if (item != null)
			{
				DateTime dateTime = this.CurrentWorkout.Start + new TimeSpan(0, 0, item.SecFromStart);
				if ((uint)item.SleepType != lastSleepType || (uint)item.SegmentType != lastSegmentType || item == this.CurrentWorkout.Items[this.CurrentWorkout.Items.Count - 1])
				{
					TimeSpan timeSpan = new TimeSpan(0, (int)(dateTime - lastSegmentDate).TotalMinutes, 0);
					string item2 = Convert.ToString((long)((ulong)item.Cadence), 2).PadLeft(32, '0');
					this.slCadence.Add(item2);
					if (lastSleepType == 0U && lastSegmentType == 0U)
					{
						this.AddAwakeBar(timeSpan);
						this.awakeTimeSpan += timeSpan;
					}
					else
					{
						if (lastSleepType >= 20000U)
						{
							this.AddRestfulBar(timeSpan);
						}
						else
						{
							this.AddLightBar(timeSpan);
						}
						this.sleepTimeSpan += timeSpan;
					}
					lastSleepType = (uint)item.SleepType;
					lastSegmentType = (uint)item.SegmentType;
					lastSegmentDate = dateTime;
					return;
				}
			}
			else if (lastSegmentDate < this.CurrentWorkout.End)
			{
				TimeSpan timeSpan2 = new TimeSpan(0, (int)(this.CurrentWorkout.End - lastSegmentDate).TotalMinutes, 0);
				this.AddAwakeBar(timeSpan2);
				this.awakeTimeSpan += timeSpan2;
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003F60 File Offset: 0x00002160
		private bool AddXAxis(DateTime dtStart, DateTime dtEnd)
		{
			bool result = true;
			int num = 60 - dtStart.Minute;
			int minute = dtEnd.Minute;
			DateTime t = dtStart.AddMinutes((double)num);
			this.Date.put_Text(string.Concat(new string[]
			{
				dtStart.ToLocalTime().ToString("ddd M/d", this.sleepPageCultureInfo),
				"   Avg HR: ",
				this.CurrentWorkout.AvgHR.ToString(),
				"   Max HR: ",
				this.CurrentWorkout.MaxHR.ToString(),
				"   Cal: ",
				this.CurrentWorkout.Calories.ToString()
			}));
			string text = dtStart.ToLocalTime().ToString("h:mmtt", this.sleepPageCultureInfo).ToLower();
			text = text.Substring(0, text.Length - 1);
			this.AsleepTime.put_Text("Asleep " + text);
			text = dtEnd.ToLocalTime().ToString("h:mmtt", this.sleepPageCultureInfo).ToLower();
			text = text.Substring(0, text.Length - 1);
			this.AwakeTime.put_Text("Woke up " + text);
			this.HourText.Children.Clear();
			this.LineHour.ColumnDefinitions.Clear();
			this.HourText.ColumnDefinitions.Clear();
			if (num > 0)
			{
				ICollection<ColumnDefinition> columnDefinitions = this.LineHour.ColumnDefinitions;
				ColumnDefinition columnDefinition = new ColumnDefinition();
				columnDefinition.put_Width(new GridLength((double)num, GridUnitType.Star));
				columnDefinitions.Add(columnDefinition);
				ICollection<ColumnDefinition> columnDefinitions2 = this.HourText.ColumnDefinitions;
				ColumnDefinition columnDefinition2 = new ColumnDefinition();
				columnDefinition2.put_Width(new GridLength((double)num, GridUnitType.Star));
				columnDefinitions2.Add(columnDefinition2);
				if (num > 15)
				{
					string text2;
					if (dtStart.ToLocalTime().Hour == 23 || dtStart.ToLocalTime().Hour == 0)
					{
						text2 = dtStart.ToLocalTime().ToString("htt", this.sleepPageCultureInfo).ToLower();
						text2 = text2.Substring(0, text2.Length - 1);
					}
					else
					{
						text2 = dtStart.ToLocalTime().ToString("hh", this.sleepPageCultureInfo).TrimStart(new char[]
						{
							'0'
						});
					}
					TextBlock textBlock = new TextBlock();
					textBlock.put_Text(text2);
					textBlock.put_VerticalAlignment(2);
					textBlock.put_HorizontalAlignment(2);
					textBlock.put_FontSize(16.0);
					textBlock.put_FontWeight(FontWeights.Normal);
					textBlock.put_Foreground(new SolidColorBrush(new Color
					{
						A = byte.MaxValue,
						R = 145,
						G = 145,
						B = 145
					}));
					textBlock.put_Margin(new Thickness(0.0, 0.0, -4.0, 0.0));
					TextBlock textBlock2 = textBlock;
					Grid.SetColumn(textBlock2, 0);
					this.HourText.Children.Add(textBlock2);
				}
				Border border = new Border();
				border.put_BorderThickness(new Thickness(0.0, 0.0, 1.0, 0.0));
				border.put_BorderBrush(new SolidColorBrush(new Color
				{
					A = byte.MaxValue,
					R = 237,
					G = 236,
					B = 234
				}));
				border.put_HorizontalAlignment(3);
				border.put_VerticalAlignment(3);
				border.put_Margin(new Thickness(0.0, 0.0, 0.0, 23.0));
				Grid.SetColumn(border, this.LineHour.ColumnDefinitions.Count - 1);
				Grid.SetRow(border, 0);
				this.LineHour.Children.Add(border);
			}
			do
			{
				ICollection<ColumnDefinition> columnDefinitions3 = this.LineHour.ColumnDefinitions;
				ColumnDefinition columnDefinition3 = new ColumnDefinition();
				columnDefinition3.put_Width(new GridLength(60.0, GridUnitType.Star));
				columnDefinitions3.Add(columnDefinition3);
				ICollection<ColumnDefinition> columnDefinitions4 = this.HourText.ColumnDefinitions;
				ColumnDefinition columnDefinition4 = new ColumnDefinition();
				columnDefinition4.put_Width(new GridLength(60.0, GridUnitType.Star));
				columnDefinitions4.Add(columnDefinition4);
				string text3;
				if (t.ToLocalTime().Hour == 23 || t.ToLocalTime().Hour == 0)
				{
					text3 = t.ToLocalTime().ToString("htt", this.sleepPageCultureInfo).ToLower();
					text3 = text3.Substring(0, text3.Length - 1);
				}
				else
				{
					text3 = t.ToLocalTime().ToString("hh", this.sleepPageCultureInfo).TrimStart(new char[]
					{
						'0'
					});
				}
				TextBlock textBlock3 = new TextBlock();
				textBlock3.put_Text(text3);
				textBlock3.put_VerticalAlignment(2);
				textBlock3.put_HorizontalAlignment(2);
				textBlock3.put_FontSize(16.0);
				textBlock3.put_FontWeight(FontWeights.Normal);
				textBlock3.put_Foreground(new SolidColorBrush(new Color
				{
					A = byte.MaxValue,
					R = 145,
					G = 145,
					B = 145
				}));
				textBlock3.put_Margin(new Thickness(0.0, 0.0, -4.0, 0.0));
				TextBlock textBlock4 = textBlock3;
				Grid.SetColumn(textBlock4, this.HourText.ColumnDefinitions.Count - 1);
				this.HourText.Children.Add(textBlock4);
				Border border2 = new Border();
				border2.put_BorderThickness(new Thickness(0.0, 0.0, 1.0, 0.0));
				border2.put_BorderBrush(new SolidColorBrush(new Color
				{
					A = byte.MaxValue,
					R = 237,
					G = 236,
					B = 234
				}));
				border2.put_HorizontalAlignment(3);
				border2.put_VerticalAlignment(3);
				border2.put_Margin(new Thickness(0.0, 0.0, 0.0, 23.0));
				Grid.SetColumn(border2, this.LineHour.ColumnDefinitions.Count - 1);
				Grid.SetRow(border2, 0);
				this.LineHour.Children.Add(border2);
				t = t.AddHours(1.0);
			}
			while (t <= dtEnd);
			if (minute > 0)
			{
				ICollection<ColumnDefinition> columnDefinitions5 = this.LineHour.ColumnDefinitions;
				ColumnDefinition columnDefinition5 = new ColumnDefinition();
				columnDefinition5.put_Width(new GridLength((double)minute, GridUnitType.Star));
				columnDefinitions5.Add(columnDefinition5);
				ICollection<ColumnDefinition> columnDefinitions6 = this.HourText.ColumnDefinitions;
				ColumnDefinition columnDefinition6 = new ColumnDefinition();
				columnDefinition6.put_Width(new GridLength((double)minute, GridUnitType.Star));
				columnDefinitions6.Add(columnDefinition6);
			}
			return result;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00004688 File Offset: 0x00002888
		private bool AddBar(SleepPage.SleepType sleepType, TimeSpan tsLength)
		{
			bool result = true;
			Rectangle rectangle = new Rectangle();
			rectangle.put_Margin(new Thickness(0.0, 0.0, 0.0, 0.0));
			rectangle.put_VerticalAlignment(3);
			rectangle.put_HorizontalAlignment(3);
			switch (sleepType)
			{
			case SleepPage.SleepType.Awake:
				rectangle.put_Fill(new SolidColorBrush(this.colAwakeBar));
				rectangle.put_Stroke(new SolidColorBrush(this.colAwakeBar));
				Grid.SetRow(rectangle, 0);
				break;
			case SleepPage.SleepType.LightSleep:
				rectangle.put_Fill(new SolidColorBrush(this.colLightBar));
				rectangle.put_Stroke(new SolidColorBrush(this.colLightBar));
				Grid.SetRow(rectangle, 1);
				break;
			case SleepPage.SleepType.RestfulSleep:
				rectangle.put_Fill(new SolidColorBrush(this.colRestfulBar));
				rectangle.put_Stroke(new SolidColorBrush(this.colRestfulBar));
				Grid.SetRow(rectangle, 1);
				Grid.SetRowSpan(rectangle, 2);
				break;
			}
			ICollection<ColumnDefinition> columnDefinitions = this.BarPanel.ColumnDefinitions;
			ColumnDefinition columnDefinition = new ColumnDefinition();
			columnDefinition.put_Width(new GridLength(tsLength.TotalMinutes, GridUnitType.Star));
			columnDefinitions.Add(columnDefinition);
			Grid.SetColumn(rectangle, this.BarPanel.ColumnDefinitions.Count - 1);
			this.BarPanel.Children.Add(rectangle);
			return result;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000047CB File Offset: 0x000029CB
		private bool AddAwakeBar(TimeSpan dtLength)
		{
			return this.AddBar(SleepPage.SleepType.Awake, dtLength);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000047D5 File Offset: 0x000029D5
		private bool AddLightBar(TimeSpan dtLength)
		{
			return this.AddBar(SleepPage.SleepType.LightSleep, dtLength);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000047DF File Offset: 0x000029DF
		private bool AddRestfulBar(TimeSpan dtLength)
		{
			return this.AddBar(SleepPage.SleepType.RestfulSleep, dtLength);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000047EC File Offset: 0x000029EC
		private async void WorkoutTracks_Loaded(object sender, TracksLoadedEventArgs e)
		{
			e.Workout.TracksLoaded -= this.WorkoutTracks_Loaded;
			if (e.Workout == this.CurrentWorkout)
			{
				try
				{
					await this.Dispatcher.RunAsync(1, delegate()
					{
						if (this.CurrentWorkout.Items.Count > 0)
						{
							this.DrawSleepDiagram();
						}
					});
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002EE1 File Offset: 0x000010E1
		private void RunIfSelected(UIElement element, Action action)
		{
			action();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00004830 File Offset: 0x00002A30
		public async Task ShowChart(double width, double height, WorkoutItem workout)
		{
			await this.Dispatcher.RunAsync(0, delegate()
			{
				double num = height / 70.0;
				double num2 = height / 10.0;
				double num3 = width / (double)workout.Items.Count;
				double num4 = 0.0;
				this.SleepDiagrams.Children.Clear();
				PointCollection pointCollection = new PointCollection();
				PointCollection pointCollection2 = new PointCollection();
				foreach (TrackItem trackItem in workout.Items)
				{
					pointCollection.Add(new Point(num4, height - (double)trackItem.Heartrate * num + 40.0));
					pointCollection2.Add(new Point(num4, height - (double)trackItem.Heartrate * num + 40.0));
					num4 += num3;
				}
				pointCollection.Add(new Point(num4 - num3, height));
				pointCollection.Add(new Point(0.0, height));
				Polyline polyline = new Polyline();
				polyline.put_Points(pointCollection);
				polyline.put_Stroke(new SolidColorBrush(Colors.Transparent));
				polyline.put_Fill(new SolidColorBrush(new Color
				{
					A = 51,
					R = byte.MaxValue,
					B = 0,
					G = 0
				}));
				polyline.put_StrokeThickness(1.0);
				Polyline polyline2 = new Polyline();
				polyline2.put_Points(pointCollection2);
				polyline2.put_Stroke(new SolidColorBrush(new Color
				{
					A = byte.MaxValue,
					R = byte.MaxValue,
					B = 0,
					G = 0
				}));
				polyline2.put_StrokeThickness(1.0);
				this.SleepDiagrams.Children.Add(polyline);
				this.SleepDiagrams.Children.Add(polyline2);
			});
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00004890 File Offset: 0x00002A90
		private async void SleepDiagrams_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (e != null)
			{
				this.CanvasSize = e.NewSize;
				if (e.PreviousSize != e.NewSize)
				{
					Canvas canvas = sender as Canvas;
					WorkoutItem workoutItem = (canvas != null) ? (canvas.DataContext as WorkoutItem) : null;
					if (workoutItem != null)
					{
						await this.ShowChart(e.NewSize.Width, e.NewSize.Height, workoutItem);
					}
				}
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000048DC File Offset: 0x00002ADC
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Application.LoadComponent(this, new Uri("ms-appx:///SleepPage.xaml"), 0);
			this.pageRoot = (Page)base.FindName("pageRoot");
			this.DiagramGrid = (Grid)base.FindName("DiagramGrid");
			this.Summary = (TextBlock)base.FindName("Summary");
			this.Date = (TextBlock)base.FindName("Date");
			this.LightHours = (TextBlock)base.FindName("LightHours");
			this.LightMinutes = (TextBlock)base.FindName("LightMinutes");
			this.RestfulHours = (TextBlock)base.FindName("RestfulHours");
			this.RestfulMinutes = (TextBlock)base.FindName("RestfulMinutes");
			this.Hours = (TextBlock)base.FindName("Hours");
			this.Minutes = (TextBlock)base.FindName("Minutes");
			this.AsleepTime = (TextBlock)base.FindName("AsleepTime");
			this.AwakeTime = (TextBlock)base.FindName("AwakeTime");
			this.XAxis = (Grid)base.FindName("XAxis");
			this.BarPanel = (Grid)base.FindName("BarPanel");
			this.SleepDiagrams = (Canvas)base.FindName("SleepDiagrams");
			this.LineHour = (Grid)base.FindName("LineHour");
			this.HourText = (Grid)base.FindName("HourText");
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00004A80 File Offset: 0x00002C80
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
			{
				UIElement @object = (UIElement)target;
				WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(@object.add_Tapped), new Action<EventRegistrationToken>(@object.remove_Tapped), new TappedEventHandler(this.Grid_Tapped));
				break;
			}
			case 2:
			{
				FrameworkElement object2 = (FrameworkElement)target;
				WindowsRuntimeMarshal.AddEventHandler<SizeChangedEventHandler>(new Func<SizeChangedEventHandler, EventRegistrationToken>(object2.add_SizeChanged), new Action<EventRegistrationToken>(object2.remove_SizeChanged), new SizeChangedEventHandler(this.SleepDiagrams_SizeChanged));
				break;
			}
			case 3:
			{
				UIElement @object = (UIElement)target;
				WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(@object.add_Tapped), new Action<EventRegistrationToken>(@object.remove_Tapped), new TappedEventHandler(this.Left_Tapped));
				break;
			}
			case 4:
			{
				UIElement @object = (UIElement)target;
				WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(@object.add_Tapped), new Action<EventRegistrationToken>(@object.remove_Tapped), new TappedEventHandler(this.Right_Tapped));
				break;
			}
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000032 RID: 50
		private readonly NavigationHelper navigationHelper;

		// Token: 0x04000033 RID: 51
		private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

		// Token: 0x04000034 RID: 52
		private TimeSpan awakeTimeSpan;

		// Token: 0x04000035 RID: 53
		private TimeSpan sleepTimeSpan;

		// Token: 0x04000036 RID: 54
		private Color colAwakeBar = new Color
		{
			A = byte.MaxValue,
			R = byte.MaxValue,
			G = 139,
			B = 2
		};

		// Token: 0x04000037 RID: 55
		private Color colLightBar = new Color
		{
			A = byte.MaxValue,
			R = 0,
			G = 121,
			B = 214
		};

		// Token: 0x04000038 RID: 56
		private Color colRestfulBar = new Color
		{
			A = byte.MaxValue,
			R = 0,
			G = 61,
			B = 110
		};

		// Token: 0x04000039 RID: 57
		private Color colHeaderBackground = new Color
		{
			A = byte.MaxValue,
			R = 0,
			G = 90,
			B = 161
		};

		// Token: 0x0400003A RID: 58
		private Color colHeaderSummaryDate = new Color
		{
			A = byte.MaxValue,
			R = 144,
			G = 206,
			B = byte.MaxValue
		};

		// Token: 0x0400003B RID: 59
		private Color colHeaderSummaryTime = new Color
		{
			A = byte.MaxValue,
			R = 242,
			G = byte.MaxValue,
			B = byte.MaxValue
		};

		// Token: 0x0400003C RID: 60
		private Color colHeaderSummaryText = new Color
		{
			A = byte.MaxValue,
			R = 242,
			G = byte.MaxValue,
			B = byte.MaxValue
		};

		// Token: 0x0400003D RID: 61
		private Color colDiagramHeader = new Color
		{
			A = byte.MaxValue,
			R = 213,
			G = 213,
			B = 213
		};

		// Token: 0x0400003E RID: 62
		private Color colDiagramXAxisText = new Color
		{
			A = byte.MaxValue,
			R = 213,
			G = 213,
			B = 213
		};

		// Token: 0x0400003F RID: 63
		private Color colDiagramYAxisText = new Color
		{
			A = byte.MaxValue,
			R = 213,
			G = 213,
			B = 213
		};

		// Token: 0x04000040 RID: 64
		private Color colDiagramFooterTitle = new Color
		{
			A = byte.MaxValue,
			R = 235,
			G = 235,
			B = 235
		};

		// Token: 0x04000041 RID: 65
		private Color colDiagramFooterSubtitle = new Color
		{
			A = byte.MaxValue,
			R = 145,
			G = 145,
			B = 145
		};

		// Token: 0x04000042 RID: 66
		private Color colDiagramFooterDuration = new Color
		{
			A = byte.MaxValue,
			R = 35,
			G = 104,
			B = 169
		};

		// Token: 0x04000043 RID: 67
		private Color colDiagramGrid = new Color
		{
			A = byte.MaxValue,
			R = 239,
			G = 238,
			B = 236
		};

		// Token: 0x04000044 RID: 68
		private List<string> slCadence = new List<string>();

		// Token: 0x04000045 RID: 69
		private CultureInfo sleepPageCultureInfo = new CultureInfo("en-US");

		// Token: 0x0400004A RID: 74
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Page pageRoot;

		// Token: 0x0400004B RID: 75
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid DiagramGrid;

		// Token: 0x0400004C RID: 76
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock Summary;

		// Token: 0x0400004D RID: 77
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock Date;

		// Token: 0x0400004E RID: 78
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock LightHours;

		// Token: 0x0400004F RID: 79
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock LightMinutes;

		// Token: 0x04000050 RID: 80
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock RestfulHours;

		// Token: 0x04000051 RID: 81
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock RestfulMinutes;

		// Token: 0x04000052 RID: 82
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock Hours;

		// Token: 0x04000053 RID: 83
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock Minutes;

		// Token: 0x04000054 RID: 84
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock AsleepTime;

		// Token: 0x04000055 RID: 85
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock AwakeTime;

		// Token: 0x04000056 RID: 86
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid XAxis;

		// Token: 0x04000057 RID: 87
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid BarPanel;

		// Token: 0x04000058 RID: 88
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Canvas SleepDiagrams;

		// Token: 0x04000059 RID: 89
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid LineHour;

		// Token: 0x0400005A RID: 90
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid HourText;

		// Token: 0x0400005B RID: 91
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private bool _contentLoaded;

		// Token: 0x020000C3 RID: 195
		public enum SleepType
		{
			// Token: 0x040004C0 RID: 1216
			Unknown,
			// Token: 0x040004C1 RID: 1217
			Awake,
			// Token: 0x040004C2 RID: 1218
			LightSleep,
			// Token: 0x040004C3 RID: 1219
			RestfulSleep
		}
	}
}
