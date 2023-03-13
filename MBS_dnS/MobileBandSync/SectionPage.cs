using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using MobileBandSync.Common;
using MobileBandSync.Data;
using Windows.ApplicationModel.Resources;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace MobileBandSync
{
	// Token: 0x02000005 RID: 5
	public sealed class SectionPage : Page, IComponentConnector
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00002A74 File Offset: 0x00000C74
		public SectionPage()
		{
			this.InitializeComponent();
			this.navigationHelper = new NavigationHelper(this);
			this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
			this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
			MapControl workoutMap = this.WorkoutMap;
			WindowsRuntimeMarshal.AddEventHandler<TypedEventHandler<MapControl, object>>(new Func<TypedEventHandler<MapControl, object>, EventRegistrationToken>(workoutMap.add_LoadingStatusChanged), new Action<EventRegistrationToken>(workoutMap.remove_LoadingStatusChanged), new TypedEventHandler<MapControl, object>(this.Map_LoadingStatusChanged));
			this.CancelTokenSource = new CancellationTokenSource();
			this.Viewport = null;
			this.ViewInitialized = false;
			this.WorkoutMap.put_MapServiceToken(WorkoutDataSource.GetMapServiceToken());
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002B2D File Offset: 0x00000D2D
		public NavigationHelper NavigationHelper
		{
			get
			{
				return this.navigationHelper;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002B35 File Offset: 0x00000D35
		public ObservableDictionary DefaultViewModel
		{
			get
			{
				return this.defaultViewModel;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002B3D File Offset: 0x00000D3D
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002B45 File Offset: 0x00000D45
		public int currentWorkoutId { get; private set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002B4E File Offset: 0x00000D4E
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002B56 File Offset: 0x00000D56
		public GeoboundingBox Viewport { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002B5F File Offset: 0x00000D5F
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002B67 File Offset: 0x00000D67
		public bool MapInitialized { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002B70 File Offset: 0x00000D70
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002B78 File Offset: 0x00000D78
		public CancellationTokenSource CancelTokenSource { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002B81 File Offset: 0x00000D81
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002B89 File Offset: 0x00000D89
		public WorkoutItem CurrentWorkout { get; private set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002B92 File Offset: 0x00000D92
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002B9A File Offset: 0x00000D9A
		public bool ViewInitialized { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002BA3 File Offset: 0x00000DA3
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002BAB File Offset: 0x00000DAB
		public Line chartLine { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002BB4 File Offset: 0x00000DB4
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002BBC File Offset: 0x00000DBC
		public MapIcon PosNeedleIcon { get; private set; }

		// Token: 0x06000046 RID: 70 RVA: 0x00002BC8 File Offset: 0x00000DC8
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
			await this.ShowWorkout(workoutItem);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002C0C File Offset: 0x00000E0C
		private async Task ShowWorkout(WorkoutItem workout)
		{
			if (workout != null)
			{
				try
				{
					this.MapInitialized = false;
					this.ViewInitialized = false;
					this.StatusText.put_Text("");
					this.StatusGrid.put_Visibility(1);
					this.CurrentWorkout = workout;
					this.DefaultViewModel["Workout"] = workout;
					BasicGeoposition basicGeoposition = default(BasicGeoposition);
					basicGeoposition.Latitude = (double)(workout.LatitudeStart + (long)workout.LatDeltaRectNE) / 10000000.0;
					basicGeoposition.Longitude = (double)(workout.LongitudeStart + (long)workout.LongDeltaRectSW) / 10000000.0;
					BasicGeoposition basicGeoposition2 = basicGeoposition;
					basicGeoposition = default(BasicGeoposition);
					basicGeoposition.Latitude = (double)(workout.LatitudeStart + (long)workout.LatDeltaRectSW) / 10000000.0;
					basicGeoposition.Longitude = (double)(workout.LongitudeStart + (long)workout.LongDeltaRectNE) / 10000000.0;
					BasicGeoposition basicGeoposition3 = basicGeoposition;
					this.Viewport = new GeoboundingBox(basicGeoposition2, basicGeoposition3, 1);
					if (this.CurrentWorkout != null)
					{
						this.CancelTokenSource.Dispose();
						this.CancelTokenSource = new CancellationTokenSource();
						if (this.CurrentWorkout.Items == null || this.CurrentWorkout.Items.Count == 0)
						{
							this.CurrentWorkout.TracksLoaded += this.WorkoutTracks_Loaded;
							this.PosNeedleIcon = null;
							this.WorkoutMap.MapElements.Clear();
							this.CurrentWorkout.ReadTrackData(this.CancelTokenSource.Token);
						}
						else
						{
							this.LoadChartContents(this.CurrentWorkout);
							await this.AddTracks(this.CurrentWorkout);
						}
					}
				}
				catch (Exception)
				{
					this.PosNeedleIcon = null;
					this.WorkoutMap.MapElements.Clear();
				}
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002C5C File Offset: 0x00000E5C
		private async void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
		{
			this.CleanupChart();
			if (this.CurrentWorkout != null && this.CurrentWorkout.Items != null && this.CurrentWorkout.Items.Count > 0)
			{
				this.CurrentWorkout.Items.Clear();
				this.CurrentWorkout.ElevationChart.Clear();
				this.CurrentWorkout.HeartRateChart.Clear();
				this.CurrentWorkout.CadenceNormChart.Clear();
				this.CurrentWorkout.SpeedChart.Clear();
			}
			if (this.CurrentWorkout.Modified)
			{
				await WorkoutDataSource.UpdateWorkoutAsync(this.CurrentWorkout.WorkoutId, this.CurrentWorkout.Title, this.CurrentWorkout.Notes);
				await this.CurrentWorkout.UpdateWorkout();
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002C98 File Offset: 0x00000E98
		public async void CreateDistancePoint(WorkoutItem item, TrackItem trackpoint, int iDistance)
		{
			if (item != null)
			{
				try
				{
					DisplayInformation displayInformation = DisplayInformation.GetForCurrentView();
					float num = (float)(DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel * 2.0 / 6.0);
					int num2 = (int)((float)((iDistance > 0) ? 50 : 30) * num);
					string text = iDistance.ToString();
					CanvasDevice sharedDevice = CanvasDevice.GetSharedDevice();
					CanvasRenderTarget distanceMarker = new CanvasRenderTarget(sharedDevice, (float)num2, (float)num2, 96f);
					using (CanvasDrawingSession canvasDrawingSession = distanceMarker.CreateDrawingSession())
					{
						canvasDrawingSession.FillRectangle(0f, 0f, (float)num2, (float)num2, (iDistance > 0) ? Colors.DarkRed : Colors.Green);
						canvasDrawingSession.DrawRectangle(2f * num, 2f * num, (float)num2 - 3f * num, (float)num2 - 3f * num, Colors.White, 5f * num);
						if (iDistance > 0)
						{
							CanvasDrawingSession canvasDrawingSession2 = canvasDrawingSession;
							string text2 = text;
							float num3 = (float)((text.Length > 1) ? 6 : 15) * num;
							float num4 = 1f * num;
							Color white = Colors.White;
							CanvasTextFormat canvasTextFormat = new CanvasTextFormat();
							canvasTextFormat.put_FontSize((float)((int)((double)num2 / 1.5)));
							canvasTextFormat.put_FontWeight(FontWeights.Bold);
							canvasDrawingSession2.DrawText(text2, num3, num4, white, canvasTextFormat);
						}
					}
					MapIcon mapIcon = new MapIcon();
					using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
					{
						object obj = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
						obj.SetPixelData(87, 2, (uint)distanceMarker.Size.Width, (uint)distanceMarker.Size.Height, (double)displayInformation.LogicalDpi, (double)displayInformation.LogicalDpi, distanceMarker.GetPixelBytes());
						await obj.FlushAsync();
						mapIcon.put_Image(RandomAccessStreamReference.CreateFromStream(stream));
						mapIcon.put_ZIndex(iDistance + 2);
						mapIcon.put_Title("");
						mapIcon.put_Visible(true);
						mapIcon.put_NormalizedAnchorPoint(new Point(0.5, 0.5));
						MapIcon mapIcon2 = mapIcon;
						BasicGeoposition basicGeoposition = default(BasicGeoposition);
						basicGeoposition.Latitude = (double)(item.LatitudeStart + (long)((trackpoint == null) ? 0 : trackpoint.LatDelta)) / 10000000.0;
						basicGeoposition.Longitude = (double)(item.LongitudeStart + (long)((trackpoint == null) ? 0 : trackpoint.LongDelta)) / 10000000.0;
						basicGeoposition.Altitude = 0.0;
						mapIcon2.put_Location(new Geopoint(basicGeoposition));
						this.WorkoutMap.MapElements.Add(mapIcon);
						SectionPage.DistanceMarkers.Add(mapIcon);
					}
					InMemoryRandomAccessStream stream = null;
					displayInformation = null;
					distanceMarker = null;
					mapIcon = null;
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002CEC File Offset: 0x00000EEC
		private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
		{
			string uniqueId = ((TrackItem)e.ClickedItem).UniqueId;
			if (!base.Frame.Navigate(typeof(ItemPage), uniqueId))
			{
				throw new Exception(ResourceLoader.GetForCurrentView("Resources").GetString("NavigationFailedExceptionMessage"));
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002D3C File Offset: 0x00000F3C
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			this.navigationHelper.OnNavigatedTo(e);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002D4A File Offset: 0x00000F4A
		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			this.navigationHelper.OnNavigatedFrom(e);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002D58 File Offset: 0x00000F58
		private async void Left_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (this.CurrentWorkout != null)
			{
				if (this.CurrentWorkout.Modified)
				{
					await WorkoutDataSource.UpdateWorkoutAsync(this.CurrentWorkout.WorkoutId, this.CurrentWorkout.Title, this.CurrentWorkout.Notes);
					await this.CurrentWorkout.UpdateWorkout();
					this.CurrentWorkout.Modified = false;
				}
				if (this.CurrentWorkout.Items != null && this.CurrentWorkout.Items.Count > 0)
				{
					this.PosNeedleIcon = null;
					this.WorkoutMap.MapElements.Clear();
					this.CurrentWorkout.Items.Clear();
					this.CurrentWorkout.ElevationChart.Clear();
					this.CurrentWorkout.HeartRateChart.Clear();
					this.CurrentWorkout.CadenceNormChart.Clear();
					this.CurrentWorkout.SpeedChart.Clear();
				}
				if (this.chartLine != null)
				{
					this.DiagramGrid.Children.Remove(this.chartLine);
				}
				this.CleanupChart();
				WorkoutItem prevSibling = this.CurrentWorkout.GetPrevSibling();
				if (prevSibling != null)
				{
					this.CurrentWorkout = prevSibling;
					this.CancelTokenSource.Cancel();
					this.ShowWorkout(prevSibling);
				}
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002D94 File Offset: 0x00000F94
		private async void Right_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (this.CurrentWorkout != null)
			{
				if (this.CurrentWorkout.Modified)
				{
					await WorkoutDataSource.UpdateWorkoutAsync(this.CurrentWorkout.WorkoutId, this.CurrentWorkout.Title, this.CurrentWorkout.Notes);
					await this.CurrentWorkout.UpdateWorkout();
					this.CurrentWorkout.Modified = false;
				}
				if (this.CurrentWorkout.Items != null && this.CurrentWorkout.Items.Count > 0)
				{
					this.PosNeedleIcon = null;
					this.WorkoutMap.MapElements.Clear();
					this.CurrentWorkout.Items.Clear();
					this.CurrentWorkout.ElevationChart.Clear();
					this.CurrentWorkout.HeartRateChart.Clear();
					this.CurrentWorkout.CadenceNormChart.Clear();
					this.CurrentWorkout.SpeedChart.Clear();
				}
				if (this.chartLine != null)
				{
					this.DiagramGrid.Children.Remove(this.chartLine);
				}
				this.CleanupChart();
				WorkoutItem nextSibling = this.CurrentWorkout.GetNextSibling();
				if (nextSibling != null)
				{
					this.CurrentWorkout = nextSibling;
					this.CancelTokenSource.Cancel();
					this.ShowWorkout(this.CurrentWorkout);
				}
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002DD0 File Offset: 0x00000FD0
		private async void Share_Tapped(object sender, TappedRoutedEventArgs e)
		{
			if (this.CurrentWorkout != null)
			{
				FileSavePicker fileSavePicker = new FileSavePicker();
				bool bResult = false;
				fileSavePicker.put_SuggestedStartLocation(0);
				fileSavePicker.FileTypeChoices.Add("Garmin Training Center Database", new List<string>
				{
					".tcx"
				});
				fileSavePicker.put_SuggestedFileName(this.CurrentWorkout.FilenameTCX);
				StorageFile storageFile = await fileSavePicker.PickSaveFileAsync();
				if (storageFile != null)
				{
					bResult = await this.CurrentWorkout.ExportWorkout(storageFile);
				}
				if (bResult)
				{
					this.ViewInitialized = true;
					this.MapInitialized = true;
				}
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002E0C File Offset: 0x0000100C
		private async void Map_LoadingStatusChanged(MapControl sender, object args)
		{
			if (sender.LoadingStatus == 1)
			{
				try
				{
					if (!this.MapInitialized && this.Viewport != null)
					{
						this.MapInitialized = true;
						this.WorkoutMap.put_DesiredPitch(0.0);
						int iRetry = 0;
						Thickness margin = new Thickness(70.0, 70.0, 70.0, 70.0);
						bool flag;
						do
						{
							flag = await this.WorkoutMap.TrySetViewBoundsAsync(this.Viewport, new Thickness?(margin), 1);
							if (!flag)
							{
								this.CancelTokenSource.Token.ThrowIfCancellationRequested();
							}
						}
						while (!flag && iRetry++ < 10);
						this.Viewport = null;
						if (NetworkInterface.GetIsNetworkAvailable())
						{
							this.WorkoutMap.put_Style(3);
						}
						margin = default(Thickness);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002E50 File Offset: 0x00001050
		private async Task AddTracks(WorkoutItem workout)
		{
			await this.Dispatcher.RunAsync(1, delegate()
			{
				if (workout != null && workout.Items.Count > 0 && this.WorkoutMap.MapElements.Count <= 10)
				{
					try
					{
						List<BasicGeoposition> list = new List<BasicGeoposition>();
						int num = -1;
						TrackItem trackItem = workout.Items[workout.Items.Count - 1];
						foreach (TrackItem trackItem2 in workout.Items)
						{
							if (num < 0 || trackItem2 == trackItem || trackItem2.SecFromStart - num >= 6)
							{
								num = trackItem2.SecFromStart;
								List<BasicGeoposition> list2 = list;
								BasicGeoposition item = default(BasicGeoposition);
								item.Latitude = (double)(workout.LatitudeStart + (long)trackItem2.LatDelta) / 10000000.0;
								item.Longitude = (double)(workout.LongitudeStart + (long)trackItem2.LongDelta) / 10000000.0;
								list2.Add(item);
							}
							this.CancelTokenSource.Token.ThrowIfCancellationRequested();
						}
						Geopath geopath = new Geopath(list);
						MapPolyline mapPolyline = new MapPolyline();
						mapPolyline.put_Path(geopath);
						mapPolyline.put_ZIndex(1);
						mapPolyline.put_StrokeColor(Colors.Red);
						mapPolyline.put_StrokeThickness(4.0);
						mapPolyline.put_StrokeDashed(false);
						mapPolyline.put_Visible(true);
						MapPolyline item2 = mapPolyline;
						this.WorkoutMap.MapElements.Add(item2);
					}
					catch (Exception)
					{
						this.PosNeedleIcon = null;
						this.WorkoutMap.MapElements.Clear();
					}
				}
			});
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002EA0 File Offset: 0x000010A0
		private async void WorkoutTracks_Loaded(object sender, TracksLoadedEventArgs e)
		{
			if (e.Workout == this.CurrentWorkout)
			{
				this.CurrentWorkout.TracksLoaded -= this.WorkoutTracks_Loaded;
				try
				{
					SectionPage.DistanceMarkers.Clear();
					this.LoadChartContents(this.CurrentWorkout);
					await this.Dispatcher.RunAsync(1, delegate()
					{
						if (this.CurrentWorkout.Items.Count > 0)
						{
							int num = 0;
							this.CreateDistancePoint(this.CurrentWorkout, this.CurrentWorkout.Items[0], num);
							foreach (TrackItem trackItem in this.CurrentWorkout.Items)
							{
								if (trackItem.TotalMeters / 1000.0 >= (double)(num + 1))
								{
									num++;
									this.CancelTokenSource.Token.ThrowIfCancellationRequested();
									this.CreateDistancePoint(this.CurrentWorkout, trackItem, num);
								}
							}
						}
					});
					this.AddTracks(this.CurrentWorkout);
				}
				catch (Exception)
				{
					this.PosNeedleIcon = null;
					this.WorkoutMap.MapElements.Clear();
				}
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002EE1 File Offset: 0x000010E1
		private void RunIfSelected(UIElement element, Action action)
		{
			action();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002EEC File Offset: 0x000010EC
		private async Task LoadChartContents(WorkoutItem workout)
		{
			Action <>9__1;
			await this.Dispatcher.RunAsync(1, delegate()
			{
				SectionPage <>4__this = this;
				UIElement element = this.lineChart;
				Action action;
				if ((action = <>9__1) == null)
				{
					action = (<>9__1 = delegate()
					{
						LineSeries lineSeries = this.lineChart.Series[3] as LineSeries;
						if (lineSeries != null)
						{
							lineSeries.ItemsSource = workout.HeartRateChart;
						}
						LineSeries lineSeries2 = this.lineChart.Series[2] as LineSeries;
						if (lineSeries2 != null)
						{
							lineSeries2.ItemsSource = workout.SpeedChart;
						}
						LineSeries lineSeries3 = this.lineChart.Series[1] as LineSeries;
						if (lineSeries3 != null)
						{
							lineSeries3.ItemsSource = workout.ElevationChart;
						}
						LineSeries lineSeries4 = this.lineChart.Series[0] as LineSeries;
						if (lineSeries4 != null)
						{
							lineSeries4.ItemsSource = workout.CadenceNormChart;
						}
					});
				}
				<>4__this.RunIfSelected(element, action);
			});
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002F3C File Offset: 0x0000113C
		private async void CleanupChart()
		{
			await this.Dispatcher.RunAsync(1, delegate()
			{
				if (this.lineChart != null && this.lineChart.Series != null && this.lineChart.Series.Count > 0)
				{
					for (int i = 0; i <= 3; i++)
					{
						LineSeries lineSeries = this.lineChart.Series[i] as LineSeries;
						if (lineSeries != null)
						{
							if (lineSeries.Triggers != null)
							{
								lineSeries.Triggers.Clear();
							}
							if (lineSeries.Points != null)
							{
								lineSeries.Points.Clear();
							}
							if (lineSeries.Resources != null)
							{
								lineSeries.Resources.Clear();
							}
							lineSeries.ItemsSource = null;
						}
					}
					if (this.lineChart.Transitions != null)
					{
						this.lineChart.Transitions.Clear();
					}
					if (this.lineChart.Triggers != null)
					{
						this.lineChart.Triggers.Clear();
					}
				}
			});
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002F78 File Offset: 0x00001178
		private async void WorkoutMap_LayoutUpdated(object sender, object e)
		{
			try
			{
				if (!this.ViewInitialized && this.CurrentWorkout != null && this.Viewport != null)
				{
					this.ViewInitialized = true;
					int iRetry = 0;
					Thickness margin = new Thickness(70.0, 70.0, 70.0, 70.0);
					bool flag;
					do
					{
						flag = await this.WorkoutMap.TrySetViewBoundsAsync(this.Viewport, new Thickness?(margin), 1);
						if (!flag)
						{
							this.CancelTokenSource.Token.ThrowIfCancellationRequested();
						}
					}
					while (!flag && iRetry++ < 10);
					margin = default(Thickness);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002FB4 File Offset: 0x000011B4
		private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
		{
			Grid grid = sender as Grid;
			if (grid != null)
			{
				Point position = e.GetPosition(grid);
				bool flag = false;
				if (this.chartLine != null)
				{
					grid.Children.Remove(this.chartLine);
				}
				if (this.PosNeedleIcon != null)
				{
					this.WorkoutMap.MapElements.Remove(this.PosNeedleIcon);
				}
				LineSeries lineSeries = grid.FindName("heartLine") as LineSeries;
				if (lineSeries != null)
				{
					WorkoutItem workoutItem = lineSeries.DataContext as WorkoutItem;
					ObservableCollection<DiagramData> observableCollection = lineSeries.ItemsSource as ObservableCollection<DiagramData>;
					if (workoutItem != null && observableCollection != null)
					{
						GeneralTransform generalTransform = lineSeries.TransformToVisual(grid);
						Point point = generalTransform.TransformPoint(new Point(lineSeries.ActualWidth, 0.0));
						Point point2 = generalTransform.TransformPoint(new Point(0.0, 0.0));
						if (position.X >= point2.X && position.X <= point.X)
						{
							double num = lineSeries.ActualWidth / (double)observableCollection.Count;
							int index = (int)((position.X - point2.X) / num);
							int index2 = observableCollection[index].Index;
							TrackItem trackItem = (index2 < workoutItem.Items.Count) ? workoutItem.Items[index2] : null;
							if (trackItem != null)
							{
								this.chartLine = new Line();
								this.chartLine.put_Stroke(new SolidColorBrush(Colors.White));
								Line chartLine = this.chartLine;
								double x;
								this.chartLine.put_X2(x = position.X);
								chartLine.put_X1(x);
								this.chartLine.put_Y1(0.0);
								this.chartLine.put_Y2(grid.ActualHeight);
								grid.Children.Add(this.chartLine);
								double num2 = 1.0 / trackItem.SpeedMeterPerSecond / 60.0 * 1000.0;
								double num3 = num2 % 1.0;
								double num4 = num2 - num3;
								double num5 = Math.Round(num3 * 60.0);
								double num6 = trackItem.SpeedMeterPerSecond * 3.6;
								if (trackItem.SpeedMeterPerSecond <= 0.0)
								{
									num5 = (num4 = 0.0);
								}
								double num7 = trackItem.TotalMeters / 1000.0;
								this.StatusText.put_Text(string.Concat(new string[]
								{
									num7.ToString("0.000"),
									" km, ",
									trackItem.Elevation.ToString(),
									" m, ",
									num4.ToString(),
									":",
									num5.ToString("00"),
									"/km, ",
									num6.ToString("0.00"),
									" km/h, HR: ",
									trackItem.Heartrate.ToString(),
									", GSR: ",
									trackItem.GSR.ToString(),
									", Temp: ",
									trackItem.SkinTemp.ToString()
								}));
								this.StatusGrid.put_Visibility(0);
								BasicGeoposition basicGeoposition = default(BasicGeoposition);
								basicGeoposition.Latitude = (double)(workoutItem.LatitudeStart + (long)trackItem.LatDelta) / 10000000.0;
								basicGeoposition.Longitude = (double)(workoutItem.LongitudeStart + (long)trackItem.LongDelta) / 10000000.0;
								basicGeoposition.Altitude = 0.0;
								Geopoint geopoint = new Geopoint(basicGeoposition);
								MapIcon mapIcon = new MapIcon();
								mapIcon.put_Location(geopoint);
								mapIcon.put_NormalizedAnchorPoint(new Point(0.5, 1.0));
								mapIcon.put_ZIndex(80);
								mapIcon.put_Image(RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/DetailPos.png")));
								mapIcon.put_Title("");
								mapIcon.put_Visible(true);
								this.PosNeedleIcon = mapIcon;
								this.WorkoutMap.MapElements.Add(this.PosNeedleIcon);
								GeoboundingBox bounds = this.GetBounds(this.WorkoutMap);
								if (!this.IsGeopointInGeoboundingBox(bounds, geopoint))
								{
									this.WorkoutMap.put_Center(geopoint);
								}
								flag = true;
							}
						}
						if (!flag)
						{
							this.StatusText.put_Text("");
							this.StatusGrid.put_Visibility(1);
							int iRetry = 0;
							Thickness margin = new Thickness(70.0, 70.0, 70.0, 70.0);
							BasicGeoposition basicGeoposition = default(BasicGeoposition);
							basicGeoposition.Latitude = (double)(workoutItem.LatitudeStart + (long)workoutItem.LatDeltaRectNE) / 10000000.0;
							basicGeoposition.Longitude = (double)(workoutItem.LongitudeStart + (long)workoutItem.LongDeltaRectSW) / 10000000.0;
							BasicGeoposition basicGeoposition2 = basicGeoposition;
							basicGeoposition = default(BasicGeoposition);
							basicGeoposition.Latitude = (double)(workoutItem.LatitudeStart + (long)workoutItem.LatDeltaRectSW) / 10000000.0;
							basicGeoposition.Longitude = (double)(workoutItem.LongitudeStart + (long)workoutItem.LongDeltaRectNE) / 10000000.0;
							BasicGeoposition basicGeoposition3 = basicGeoposition;
							GeoboundingBox viewport = new GeoboundingBox(basicGeoposition2, basicGeoposition3, 1);
							int num8;
							do
							{
								bool flag2 = await this.WorkoutMap.TrySetViewBoundsAsync(viewport, new Thickness?(margin), 1);
								if (!flag2)
								{
									this.CancelTokenSource.Token.ThrowIfCancellationRequested();
								}
								if (flag2)
								{
									break;
								}
								num8 = iRetry;
								iRetry = num8 + 1;
							}
							while (num8 < 10);
							margin = default(Thickness);
							viewport = null;
						}
					}
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003000 File Offset: 0x00001200
		public GeoboundingBox GetBounds(MapControl map)
		{
			if (map.Center.Position.Latitude == 0.0)
			{
				return null;
			}
			double num = 156543.04 * Math.Cos(map.Center.Position.Latitude * 3.141592653589793 / 180.0) / (111325.0 * Math.Pow(2.0, map.ZoomLevel));
			double num2 = map.ActualWidth * num / 0.9;
			double num3 = map.ActualHeight * num / 1.7;
			double latitude = map.Center.Position.Latitude + num3;
			double longitude = map.Center.Position.Longitude - num2;
			double latitude2 = map.Center.Position.Latitude - num3;
			double longitude2 = map.Center.Position.Longitude + num2;
			BasicGeoposition basicGeoposition = default(BasicGeoposition);
			basicGeoposition.Latitude = latitude;
			basicGeoposition.Longitude = longitude;
			BasicGeoposition basicGeoposition2 = basicGeoposition;
			basicGeoposition = default(BasicGeoposition);
			basicGeoposition.Latitude = latitude2;
			basicGeoposition.Longitude = longitude2;
			return new GeoboundingBox(basicGeoposition2, basicGeoposition);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003130 File Offset: 0x00001330
		public bool IsGeopointInGeoboundingBox(GeoboundingBox bounds, Geopoint point)
		{
			return point.Position.Latitude < bounds.NorthwestCorner.Latitude && point.Position.Longitude > bounds.NorthwestCorner.Longitude && point.Position.Latitude > bounds.SoutheastCorner.Latitude && point.Position.Longitude < bounds.SoutheastCorner.Longitude;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000031A0 File Offset: 0x000013A0
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

		// Token: 0x0600005B RID: 91 RVA: 0x000031D0 File Offset: 0x000013D0
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Application.LoadComponent(this, new Uri("ms-appx:///SectionPage.xaml"), 0);
			this.pageRoot = (Page)base.FindName("pageRoot");
			this.DiagramGrid = (Grid)base.FindName("DiagramGrid");
			this.StatusGrid = (Grid)base.FindName("StatusGrid");
			this.StatusText = (TextBlock)base.FindName("StatusText");
			this.lineChart = (Chart)base.FindName("lineChart");
			this.heartLine = (LineSeries)base.FindName("heartLine");
			this.WorkoutMap = (MapControl)base.FindName("WorkoutMap");
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003298 File Offset: 0x00001498
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
				UIElement @object = (UIElement)target;
				WindowsRuntimeMarshal.AddEventHandler<TappedEventHandler>(new Func<TappedEventHandler, EventRegistrationToken>(@object.add_Tapped), new Action<EventRegistrationToken>(@object.remove_Tapped), new TappedEventHandler(this.Share_Tapped));
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
			case 5:
			{
				FrameworkElement object2 = (FrameworkElement)target;
				WindowsRuntimeMarshal.AddEventHandler<EventHandler<object>>(new Func<EventHandler<object>, EventRegistrationToken>(object2.add_LayoutUpdated), new Action<EventRegistrationToken>(object2.remove_LayoutUpdated), new EventHandler<object>(this.WorkoutMap_LayoutUpdated));
				break;
			}
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400001F RID: 31
		private readonly NavigationHelper navigationHelper;

		// Token: 0x04000020 RID: 32
		private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

		// Token: 0x04000029 RID: 41
		public static List<MapIcon> DistanceMarkers = new List<MapIcon>();

		// Token: 0x0400002A RID: 42
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Page pageRoot;

		// Token: 0x0400002B RID: 43
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid DiagramGrid;

		// Token: 0x0400002C RID: 44
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Grid StatusGrid;

		// Token: 0x0400002D RID: 45
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private TextBlock StatusText;

		// Token: 0x0400002E RID: 46
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private Chart lineChart;

		// Token: 0x0400002F RID: 47
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private LineSeries heartLine;

		// Token: 0x04000030 RID: 48
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private MapControl WorkoutMap;

		// Token: 0x04000031 RID: 49
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		private bool _contentLoaded;
	}
}
