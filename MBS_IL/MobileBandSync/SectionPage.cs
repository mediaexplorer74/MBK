using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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
using Windows.UI.Core;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace MobileBandSync;

public sealed class SectionPage : Page, IComponentConnector
{
	private readonly NavigationHelper navigationHelper;

	private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

	public static List<MapIcon> DistanceMarkers = new List<MapIcon>();

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Page pageRoot;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid DiagramGrid;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Grid StatusGrid;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private TextBlock StatusText;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private Chart lineChart;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private LineSeries heartLine;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private MapControl WorkoutMap;

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	private bool _contentLoaded;

	public NavigationHelper NavigationHelper => navigationHelper;

	public ObservableDictionary DefaultViewModel => defaultViewModel;

	public int currentWorkoutId { get; private set; }

	public GeoboundingBox Viewport { get; private set; }

	public bool MapInitialized { get; private set; }

	public CancellationTokenSource CancelTokenSource { get; private set; }

	public WorkoutItem CurrentWorkout { get; private set; }

	public bool ViewInitialized { get; private set; }

	public Line chartLine { get; private set; }

	public MapIcon PosNeedleIcon { get; private set; }

	public SectionPage()
	{
		InitializeComponent();
		navigationHelper = new NavigationHelper((Page)(object)this);
		navigationHelper.LoadState += NavigationHelper_LoadState;
		navigationHelper.SaveState += NavigationHelper_SaveState;
		MapControl workoutMap = WorkoutMap;
		WindowsRuntimeMarshal.AddEventHandler((Func<TypedEventHandler<MapControl, object>, EventRegistrationToken>)workoutMap.add_LoadingStatusChanged, (Action<EventRegistrationToken>)workoutMap.remove_LoadingStatusChanged, (TypedEventHandler<MapControl, object>)Map_LoadingStatusChanged);
		CancelTokenSource = new CancellationTokenSource();
		Viewport = null;
		ViewInitialized = false;
		WorkoutMap.put_MapServiceToken(WorkoutDataSource.GetMapServiceToken());
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
		await ShowWorkout(workoutItem);
	}

	private async Task ShowWorkout(WorkoutItem workout)
	{
		if (workout == null)
		{
			return;
		}
		try
		{
			MapInitialized = false;
			ViewInitialized = false;
			StatusText.put_Text("");
			((UIElement)StatusGrid).put_Visibility((Visibility)1);
			CurrentWorkout = workout;
			DefaultViewModel["Workout"] = workout;
			BasicGeoposition val = default(BasicGeoposition);
			val.Latitude = (double)(workout.LatitudeStart + workout.LatDeltaRectNE) / 10000000.0;
			val.Longitude = (double)(workout.LongitudeStart + workout.LongDeltaRectSW) / 10000000.0;
			BasicGeoposition val2 = val;
			val = default(BasicGeoposition);
			val.Latitude = (double)(workout.LatitudeStart + workout.LatDeltaRectSW) / 10000000.0;
			val.Longitude = (double)(workout.LongitudeStart + workout.LongDeltaRectNE) / 10000000.0;
			BasicGeoposition val3 = val;
			Viewport = new GeoboundingBox(val2, val3, (AltitudeReferenceSystem)1);
			if (CurrentWorkout != null)
			{
				CancelTokenSource.Dispose();
				CancelTokenSource = new CancellationTokenSource();
				if (CurrentWorkout.Items == null || CurrentWorkout.Items.Count == 0)
				{
					CurrentWorkout.TracksLoaded += WorkoutTracks_Loaded;
					PosNeedleIcon = null;
					WorkoutMap.MapElements.Clear();
					CurrentWorkout.ReadTrackData(CancelTokenSource.Token);
				}
				else
				{
					LoadChartContents(CurrentWorkout);
					await AddTracks(CurrentWorkout);
				}
			}
		}
		catch (Exception)
		{
			PosNeedleIcon = null;
			WorkoutMap.MapElements.Clear();
		}
	}

	private async void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
	{
		CleanupChart();
		if (CurrentWorkout != null && CurrentWorkout.Items != null && CurrentWorkout.Items.Count > 0)
		{
			CurrentWorkout.Items.Clear();
			CurrentWorkout.ElevationChart.Clear();
			CurrentWorkout.HeartRateChart.Clear();
			CurrentWorkout.CadenceNormChart.Clear();
			CurrentWorkout.SpeedChart.Clear();
		}
		if (CurrentWorkout.Modified)
		{
			await WorkoutDataSource.UpdateWorkoutAsync(CurrentWorkout.WorkoutId, CurrentWorkout.Title, CurrentWorkout.Notes);
			await CurrentWorkout.UpdateWorkout();
		}
	}

	public async void CreateDistancePoint(WorkoutItem item, TrackItem trackpoint, int iDistance)
	{
		if (item == null)
		{
			return;
		}
		try
		{
			DisplayInformation displayInformation = DisplayInformation.GetForCurrentView();
			float num = (float)(DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel * 2.0 / 6.0);
			int num2 = (int)((float)((iDistance > 0) ? 50 : 30) * num);
			string text = iDistance.ToString();
			CanvasDevice sharedDevice = CanvasDevice.GetSharedDevice();
			CanvasRenderTarget distanceMarker = new CanvasRenderTarget((ICanvasResourceCreator)(object)sharedDevice, (float)num2, (float)num2, 96f);
			CanvasDrawingSession val = distanceMarker.CreateDrawingSession();
			try
			{
				val.FillRectangle(0f, 0f, (float)num2, (float)num2, (iDistance > 0) ? Colors.DarkRed : Colors.Green);
				val.DrawRectangle(2f * num, 2f * num, (float)num2 - 3f * num, (float)num2 - 3f * num, Colors.White, 5f * num);
				if (iDistance > 0)
				{
					float num3 = (float)((text.Length > 1) ? 6 : 15) * num;
					float num4 = 1f * num;
					Color white = Colors.White;
					CanvasTextFormat val2 = new CanvasTextFormat();
					val2.put_FontSize((float)(int)((double)num2 / 1.5));
					val2.put_FontWeight(FontWeights.Bold);
					val.DrawText(text, num3, num4, white, val2);
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			MapIcon mapIcon = new MapIcon();
			InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
			try
			{
				TaskAwaiter<BitmapEncoder> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<BitmapEncoder>(BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, (IRandomAccessStream)(object)stream));
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<BitmapEncoder> taskAwaiter2 = default(TaskAwaiter<BitmapEncoder>);
					taskAwaiter = taskAwaiter2;
				}
				BitmapEncoder result = taskAwaiter.GetResult();
				Size size = ((CanvasBitmap)distanceMarker).Size;
				uint num5 = (uint)((Size)(ref size)).Width;
				size = ((CanvasBitmap)distanceMarker).Size;
				result.SetPixelData((BitmapPixelFormat)87, (BitmapAlphaMode)2, num5, (uint)((Size)(ref size)).Height, (double)displayInformation.LogicalDpi, (double)displayInformation.LogicalDpi, ((CanvasBitmap)distanceMarker).GetPixelBytes());
				TaskAwaiter taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter(result.FlushAsync());
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter4 = default(TaskAwaiter);
					taskAwaiter3 = taskAwaiter4;
				}
				taskAwaiter3.GetResult();
				mapIcon.put_Image((IRandomAccessStreamReference)(object)RandomAccessStreamReference.CreateFromStream((IRandomAccessStream)(object)stream));
				((MapElement)mapIcon).put_ZIndex(iDistance + 2);
				mapIcon.put_Title("");
				((MapElement)mapIcon).put_Visible(true);
				mapIcon.put_NormalizedAnchorPoint(new Point(0.5, 0.5));
				mapIcon.put_Location(new Geopoint(new BasicGeoposition
				{
					Latitude = (double)(item.LatitudeStart + (trackpoint?.LatDelta ?? 0)) / 10000000.0,
					Longitude = (double)(item.LongitudeStart + (trackpoint?.LongDelta ?? 0)) / 10000000.0,
					Altitude = 0.0
				}));
				WorkoutMap.MapElements.Add((MapElement)(object)mapIcon);
				DistanceMarkers.Add(mapIcon);
			}
			finally
			{
				((IDisposable)stream)?.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
	{
		string uniqueId = ((TrackItem)e.ClickedItem).UniqueId;
		if (!((Page)this).Frame.Navigate(typeof(ItemPage), (object)uniqueId))
		{
			throw new Exception(ResourceLoader.GetForCurrentView("Resources").GetString("NavigationFailedExceptionMessage"));
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
			if (CurrentWorkout.Modified)
			{
				await WorkoutDataSource.UpdateWorkoutAsync(CurrentWorkout.WorkoutId, CurrentWorkout.Title, CurrentWorkout.Notes);
				await CurrentWorkout.UpdateWorkout();
				CurrentWorkout.Modified = false;
			}
			if (CurrentWorkout.Items != null && CurrentWorkout.Items.Count > 0)
			{
				PosNeedleIcon = null;
				WorkoutMap.MapElements.Clear();
				CurrentWorkout.Items.Clear();
				CurrentWorkout.ElevationChart.Clear();
				CurrentWorkout.HeartRateChart.Clear();
				CurrentWorkout.CadenceNormChart.Clear();
				CurrentWorkout.SpeedChart.Clear();
			}
			if (chartLine != null)
			{
				((ICollection<UIElement>)((Panel)DiagramGrid).Children).Remove((UIElement)(object)chartLine);
			}
			CleanupChart();
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
			if (CurrentWorkout.Modified)
			{
				await WorkoutDataSource.UpdateWorkoutAsync(CurrentWorkout.WorkoutId, CurrentWorkout.Title, CurrentWorkout.Notes);
				await CurrentWorkout.UpdateWorkout();
				CurrentWorkout.Modified = false;
			}
			if (CurrentWorkout.Items != null && CurrentWorkout.Items.Count > 0)
			{
				PosNeedleIcon = null;
				WorkoutMap.MapElements.Clear();
				CurrentWorkout.Items.Clear();
				CurrentWorkout.ElevationChart.Clear();
				CurrentWorkout.HeartRateChart.Clear();
				CurrentWorkout.CadenceNormChart.Clear();
				CurrentWorkout.SpeedChart.Clear();
			}
			if (chartLine != null)
			{
				((ICollection<UIElement>)((Panel)DiagramGrid).Children).Remove((UIElement)(object)chartLine);
			}
			CleanupChart();
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
		if (CurrentWorkout != null)
		{
			FileSavePicker val = new FileSavePicker();
			bool bResult = false;
			val.put_SuggestedStartLocation((PickerLocationId)0);
			val.FileTypeChoices.Add("Garmin Training Center Database", new List<string> { ".tcx" });
			val.put_SuggestedFileName(CurrentWorkout.FilenameTCX);
			TaskAwaiter<StorageFile> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(val.PickSaveFileAsync());
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<StorageFile> taskAwaiter2 = default(TaskAwaiter<StorageFile>);
				taskAwaiter = taskAwaiter2;
			}
			StorageFile result = taskAwaiter.GetResult();
			if (result != null)
			{
				bResult = await CurrentWorkout.ExportWorkout(result);
			}
			if (bResult)
			{
				ViewInitialized = true;
				MapInitialized = true;
			}
		}
	}

	private async void Map_LoadingStatusChanged(MapControl sender, object args)
	{
		if ((int)sender.LoadingStatus != 1)
		{
			return;
		}
		try
		{
			if (MapInitialized || Viewport == null)
			{
				return;
			}
			MapInitialized = true;
			WorkoutMap.put_DesiredPitch(0.0);
			int iRetry = 0;
			Thickness margin = new Thickness(70.0, 70.0, 70.0, 70.0);
			TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
			bool result;
			do
			{
				TaskAwaiter<bool> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<bool>(WorkoutMap.TrySetViewBoundsAsync(Viewport, (Thickness?)margin, (MapAnimationKind)1));
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				result = taskAwaiter.GetResult();
				if (!result)
				{
					CancelTokenSource.Token.ThrowIfCancellationRequested();
				}
			}
			while (!result && iRetry++ < 10);
			Viewport = null;
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				WorkoutMap.put_Style((MapStyle)3);
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task AddTracks(WorkoutItem workout)
	{
		TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(((DependencyObject)this).Dispatcher.RunAsync((CoreDispatcherPriority)1, (DispatchedHandler)delegate
		{
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Expected O, but got Unknown
			if (workout != null && workout.Items.Count > 0 && WorkoutMap.MapElements.Count <= 10)
			{
				try
				{
					List<BasicGeoposition> list = new List<BasicGeoposition>();
					int num = -1;
					TrackItem trackItem = workout.Items[workout.Items.Count - 1];
					foreach (TrackItem item2 in workout.Items)
					{
						if (num < 0 || item2 == trackItem || item2.SecFromStart - num >= 6)
						{
							num = item2.SecFromStart;
							list.Add(new BasicGeoposition
							{
								Latitude = (double)(workout.LatitudeStart + item2.LatDelta) / 10000000.0,
								Longitude = (double)(workout.LongitudeStart + item2.LongDelta) / 10000000.0
							});
						}
						CancelTokenSource.Token.ThrowIfCancellationRequested();
					}
					Geopath val = new Geopath((IEnumerable<BasicGeoposition>)list);
					MapPolyline val2 = new MapPolyline();
					val2.put_Path(val);
					((MapElement)val2).put_ZIndex(1);
					val2.put_StrokeColor(Colors.Red);
					val2.put_StrokeThickness(4.0);
					val2.put_StrokeDashed(false);
					((MapElement)val2).put_Visible(true);
					MapPolyline item = val2;
					WorkoutMap.MapElements.Add((MapElement)(object)item);
				}
				catch (Exception)
				{
					PosNeedleIcon = null;
					WorkoutMap.MapElements.Clear();
				}
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

	private async void WorkoutTracks_Loaded(object sender, TracksLoadedEventArgs e)
	{
		if (e.Workout != CurrentWorkout)
		{
			return;
		}
		CurrentWorkout.TracksLoaded -= WorkoutTracks_Loaded;
		try
		{
			DistanceMarkers.Clear();
			LoadChartContents(CurrentWorkout);
			TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(((DependencyObject)this).Dispatcher.RunAsync((CoreDispatcherPriority)1, (DispatchedHandler)delegate
			{
				if (CurrentWorkout.Items.Count > 0)
				{
					int num = 0;
					CreateDistancePoint(CurrentWorkout, CurrentWorkout.Items[0], num);
					foreach (TrackItem item in CurrentWorkout.Items)
					{
						if (item.TotalMeters / 1000.0 >= (double)(num + 1))
						{
							num++;
							CancelTokenSource.Token.ThrowIfCancellationRequested();
							CreateDistancePoint(CurrentWorkout, item, num);
						}
					}
				}
			}));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
				taskAwaiter = taskAwaiter2;
			}
			taskAwaiter.GetResult();
			AddTracks(CurrentWorkout);
		}
		catch (Exception)
		{
			PosNeedleIcon = null;
			WorkoutMap.MapElements.Clear();
		}
	}

	private void RunIfSelected(UIElement element, Action action)
	{
		action();
	}

	private async Task LoadChartContents(WorkoutItem workout)
	{
		TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(((DependencyObject)this).Dispatcher.RunAsync((CoreDispatcherPriority)1, (DispatchedHandler)delegate
		{
			RunIfSelected((UIElement)(object)lineChart, delegate
			{
				if (lineChart.Series[3] is LineSeries lineSeries)
				{
					lineSeries.ItemsSource = workout.HeartRateChart;
				}
				if (lineChart.Series[2] is LineSeries lineSeries2)
				{
					lineSeries2.ItemsSource = workout.SpeedChart;
				}
				if (lineChart.Series[1] is LineSeries lineSeries3)
				{
					lineSeries3.ItemsSource = workout.ElevationChart;
				}
				if (lineChart.Series[0] is LineSeries lineSeries4)
				{
					lineSeries4.ItemsSource = workout.CadenceNormChart;
				}
			});
		}));
		if (!taskAwaiter.IsCompleted)
		{
			await taskAwaiter;
			TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
			taskAwaiter = taskAwaiter2;
		}
		taskAwaiter.GetResult();
	}

	private async void CleanupChart()
	{
		TaskAwaiter taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter(((DependencyObject)this).Dispatcher.RunAsync((CoreDispatcherPriority)1, (DispatchedHandler)delegate
		{
			if (lineChart != null && lineChart.Series != null && lineChart.Series.Count > 0)
			{
				for (int i = 0; i <= 3; i++)
				{
					if (lineChart.Series[i] is LineSeries lineSeries)
					{
						if (((FrameworkElement)lineSeries).Triggers != null)
						{
							((ICollection<TriggerBase>)((FrameworkElement)lineSeries).Triggers).Clear();
						}
						if (lineSeries.Points != null)
						{
							((ICollection<Point>)lineSeries.Points).Clear();
						}
						if (((FrameworkElement)lineSeries).Resources != null)
						{
							((ICollection<KeyValuePair<object, object>>)((FrameworkElement)lineSeries).Resources).Clear();
						}
						lineSeries.ItemsSource = null;
					}
				}
				if (((UIElement)lineChart).Transitions != null)
				{
					((ICollection<Transition>)((UIElement)lineChart).Transitions).Clear();
				}
				if (((FrameworkElement)lineChart).Triggers != null)
				{
					((ICollection<TriggerBase>)((FrameworkElement)lineChart).Triggers).Clear();
				}
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

	private async void WorkoutMap_LayoutUpdated(object sender, object e)
	{
		try
		{
			if (ViewInitialized || CurrentWorkout == null || Viewport == null)
			{
				return;
			}
			ViewInitialized = true;
			int iRetry = 0;
			Thickness margin = new Thickness(70.0, 70.0, 70.0, 70.0);
			TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
			bool result;
			do
			{
				TaskAwaiter<bool> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<bool>(WorkoutMap.TrySetViewBoundsAsync(Viewport, (Thickness?)margin, (MapAnimationKind)1));
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				result = taskAwaiter.GetResult();
				if (!result)
				{
					CancelTokenSource.Token.ThrowIfCancellationRequested();
				}
			}
			while (!result && iRetry++ < 10);
		}
		catch (Exception)
		{
		}
	}

	private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
	{
		Grid val = (Grid)((sender is Grid) ? sender : null);
		if (val == null)
		{
			return;
		}
		Point position = e.GetPosition((UIElement)(object)val);
		bool flag = false;
		if (chartLine != null)
		{
			((ICollection<UIElement>)((Panel)val).Children).Remove((UIElement)(object)chartLine);
		}
		if (PosNeedleIcon != null)
		{
			WorkoutMap.MapElements.Remove((MapElement)(object)PosNeedleIcon);
		}
		if (!(((FrameworkElement)val).FindName("heartLine") is LineSeries lineSeries))
		{
			return;
		}
		WorkoutItem workoutItem = ((FrameworkElement)lineSeries).DataContext as WorkoutItem;
		ObservableCollection<DiagramData> observableCollection = lineSeries.ItemsSource as ObservableCollection<DiagramData>;
		if (workoutItem == null || observableCollection == null)
		{
			return;
		}
		GeneralTransform obj = ((UIElement)lineSeries).TransformToVisual((UIElement)(object)val);
		Point val2 = obj.TransformPoint(new Point(((FrameworkElement)lineSeries).ActualWidth, 0.0));
		Point val3 = obj.TransformPoint(new Point(0.0, 0.0));
		BasicGeoposition val4;
		if (((Point)(ref position)).X >= ((Point)(ref val3)).X && ((Point)(ref position)).X <= ((Point)(ref val2)).X)
		{
			double num = ((FrameworkElement)lineSeries).ActualWidth / (double)observableCollection.Count;
			int index = (int)((((Point)(ref position)).X - ((Point)(ref val3)).X) / num);
			int index2 = observableCollection[index].Index;
			TrackItem trackItem = ((index2 < workoutItem.Items.Count) ? workoutItem.Items[index2] : null);
			if (trackItem != null)
			{
				chartLine = new Line();
				((Shape)chartLine).put_Stroke((Brush)new SolidColorBrush(Colors.White));
				Line obj2 = chartLine;
				double x;
				chartLine.put_X2(x = ((Point)(ref position)).X);
				obj2.put_X1(x);
				chartLine.put_Y1(0.0);
				chartLine.put_Y2(((FrameworkElement)val).ActualHeight);
				((ICollection<UIElement>)((Panel)val).Children).Add((UIElement)(object)chartLine);
				double num2 = 1.0 / trackItem.SpeedMeterPerSecond / 60.0 * 1000.0;
				double num3 = num2 % 1.0;
				double num4 = num2 - num3;
				double num5 = Math.Round(num3 * 60.0);
				double num6 = trackItem.SpeedMeterPerSecond * 3.6;
				if (trackItem.SpeedMeterPerSecond <= 0.0)
				{
					num4 = (num5 = 0.0);
				}
				double num7 = trackItem.TotalMeters / 1000.0;
				StatusText.put_Text(num7.ToString("0.000") + " km, " + trackItem.Elevation + " m, " + num4 + ":" + num5.ToString("00") + "/km, " + num6.ToString("0.00") + " km/h, HR: " + trackItem.Heartrate + ", GSR: " + trackItem.GSR + ", Temp: " + trackItem.SkinTemp);
				((UIElement)StatusGrid).put_Visibility((Visibility)0);
				val4 = default(BasicGeoposition);
				val4.Latitude = (double)(workoutItem.LatitudeStart + trackItem.LatDelta) / 10000000.0;
				val4.Longitude = (double)(workoutItem.LongitudeStart + trackItem.LongDelta) / 10000000.0;
				val4.Altitude = 0.0;
				Geopoint val5 = new Geopoint(val4);
				SectionPage sectionPage = this;
				MapIcon val6 = new MapIcon();
				val6.put_Location(val5);
				val6.put_NormalizedAnchorPoint(new Point(0.5, 1.0));
				((MapElement)val6).put_ZIndex(80);
				val6.put_Image((IRandomAccessStreamReference)(object)RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/DetailPos.png")));
				val6.put_Title("");
				((MapElement)val6).put_Visible(true);
				sectionPage.PosNeedleIcon = val6;
				WorkoutMap.MapElements.Add((MapElement)(object)PosNeedleIcon);
				GeoboundingBox bounds = GetBounds(WorkoutMap);
				if (!IsGeopointInGeoboundingBox(bounds, val5))
				{
					WorkoutMap.put_Center(val5);
				}
				flag = true;
			}
		}
		if (flag)
		{
			return;
		}
		StatusText.put_Text("");
		((UIElement)StatusGrid).put_Visibility((Visibility)1);
		int iRetry = 0;
		Thickness margin = new Thickness(70.0, 70.0, 70.0, 70.0);
		val4 = default(BasicGeoposition);
		val4.Latitude = (double)(workoutItem.LatitudeStart + workoutItem.LatDeltaRectNE) / 10000000.0;
		val4.Longitude = (double)(workoutItem.LongitudeStart + workoutItem.LongDeltaRectSW) / 10000000.0;
		BasicGeoposition val7 = val4;
		val4 = default(BasicGeoposition);
		val4.Latitude = (double)(workoutItem.LatitudeStart + workoutItem.LatDeltaRectSW) / 10000000.0;
		val4.Longitude = (double)(workoutItem.LongitudeStart + workoutItem.LongDeltaRectNE) / 10000000.0;
		BasicGeoposition val8 = val4;
		GeoboundingBox viewport = new GeoboundingBox(val7, val8, (AltitudeReferenceSystem)1);
		TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
		bool result;
		do
		{
			TaskAwaiter<bool> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<bool>(WorkoutMap.TrySetViewBoundsAsync(viewport, (Thickness?)margin, (MapAnimationKind)1));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<bool>);
			}
			result = taskAwaiter.GetResult();
			if (!result)
			{
				CancelTokenSource.Token.ThrowIfCancellationRequested();
			}
		}
		while (!result && iRetry++ < 10);
	}

	public GeoboundingBox GetBounds(MapControl map)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		if (map.Center.Position.Latitude == 0.0)
		{
			return null;
		}
		double num = 156543.04 * Math.Cos(map.Center.Position.Latitude * Math.PI / 180.0) / (111325.0 * Math.Pow(2.0, map.ZoomLevel));
		double num2 = ((FrameworkElement)map).ActualWidth * num / 0.9;
		double num3 = ((FrameworkElement)map).ActualHeight * num / 1.7;
		double latitude = map.Center.Position.Latitude + num3;
		double longitude = map.Center.Position.Longitude - num2;
		double latitude2 = map.Center.Position.Latitude - num3;
		double longitude2 = map.Center.Position.Longitude + num2;
		BasicGeoposition val = default(BasicGeoposition);
		val.Latitude = latitude;
		val.Longitude = longitude;
		return new GeoboundingBox(val, new BasicGeoposition
		{
			Latitude = latitude2,
			Longitude = longitude2
		});
	}

	public bool IsGeopointInGeoboundingBox(GeoboundingBox bounds, Geopoint point)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (point.Position.Latitude < bounds.NorthwestCorner.Latitude && point.Position.Longitude > bounds.NorthwestCorner.Longitude && point.Position.Latitude > bounds.SoutheastCorner.Latitude)
		{
			return point.Position.Longitude < bounds.SoutheastCorner.Longitude;
		}
		return false;
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
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Application.LoadComponent((object)this, new Uri("ms-appx:///SectionPage.xaml"), (ComponentResourceLocation)0);
			pageRoot = (Page)((FrameworkElement)this).FindName("pageRoot");
			DiagramGrid = (Grid)((FrameworkElement)this).FindName("DiagramGrid");
			StatusGrid = (Grid)((FrameworkElement)this).FindName("StatusGrid");
			StatusText = (TextBlock)((FrameworkElement)this).FindName("StatusText");
			lineChart = (Chart)((FrameworkElement)this).FindName("lineChart");
			heartLine = (LineSeries)((FrameworkElement)this).FindName("heartLine");
			WorkoutMap = (MapControl)((FrameworkElement)this).FindName("WorkoutMap");
		}
	}

	[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
	[DebuggerNonUserCode]
	public void Connect(int connectionId, object target)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
		{
			UIElement val2 = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val2.add_Tapped, (Action<EventRegistrationToken>)val2.remove_Tapped, new TappedEventHandler(Grid_Tapped));
			break;
		}
		case 2:
		{
			UIElement val2 = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val2.add_Tapped, (Action<EventRegistrationToken>)val2.remove_Tapped, new TappedEventHandler(Share_Tapped));
			break;
		}
		case 3:
		{
			UIElement val2 = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val2.add_Tapped, (Action<EventRegistrationToken>)val2.remove_Tapped, new TappedEventHandler(Left_Tapped));
			break;
		}
		case 4:
		{
			UIElement val2 = (UIElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<TappedEventHandler, EventRegistrationToken>)val2.add_Tapped, (Action<EventRegistrationToken>)val2.remove_Tapped, new TappedEventHandler(Right_Tapped));
			break;
		}
		case 5:
		{
			FrameworkElement val = (FrameworkElement)target;
			WindowsRuntimeMarshal.AddEventHandler((Func<EventHandler<object>, EventRegistrationToken>)val.add_LayoutUpdated, (Action<EventRegistrationToken>)val.remove_LayoutUpdated, (EventHandler<object>)WorkoutMap_LayoutUpdated);
			break;
		}
		}
		_contentLoaded = true;
	}
}
