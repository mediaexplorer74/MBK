using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MobileBandSync.Common;

[WebHostHidden]
public class NavigationHelper : DependencyObject
{
	private RelayCommand _goBackCommand;

	private RelayCommand _goForwardCommand;

	private string _pageKey;

	private Page Page { get; set; }

	private Frame Frame => Page.Frame;

	public RelayCommand GoBackCommand
	{
		get
		{
			if (_goBackCommand == null)
			{
				_goBackCommand = new RelayCommand(delegate
				{
					GoBack();
				}, () => CanGoBack());
			}
			return _goBackCommand;
		}
		set
		{
			_goBackCommand = value;
		}
	}

	public RelayCommand GoForwardCommand
	{
		get
		{
			if (_goForwardCommand == null)
			{
				_goForwardCommand = new RelayCommand(delegate
				{
					GoForward();
				}, () => CanGoForward());
			}
			return _goForwardCommand;
		}
	}

	public event LoadStateEventHandler LoadState;

	public event SaveStateEventHandler SaveState;

	public unsafe NavigationHelper(Page page)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		Page = page;
		Page page2 = Page;
		WindowsRuntimeMarshal.AddEventHandler((Func<RoutedEventHandler, EventRegistrationToken>)((FrameworkElement)page2).add_Loaded, (Action<EventRegistrationToken>)((FrameworkElement)page2).remove_Loaded, (RoutedEventHandler)delegate
		{
			WindowsRuntimeMarshal.AddEventHandler(new Func<EventHandler<BackPressedEventArgs>, EventRegistrationToken>(null, (nint)(delegate*<EventHandler<BackPressedEventArgs>, EventRegistrationToken>)(&HardwareButtons.add_BackPressed)), new Action<EventRegistrationToken>(null, (nint)(delegate*<EventRegistrationToken, void>)(&HardwareButtons.remove_BackPressed)), HardwareButtons_BackPressed);
		});
		page2 = Page;
		WindowsRuntimeMarshal.AddEventHandler((Func<RoutedEventHandler, EventRegistrationToken>)((FrameworkElement)page2).add_Unloaded, (Action<EventRegistrationToken>)((FrameworkElement)page2).remove_Unloaded, (RoutedEventHandler)delegate
		{
			WindowsRuntimeMarshal.RemoveEventHandler<EventHandler<BackPressedEventArgs>>(new Action<EventRegistrationToken>(null, (nint)(delegate*<EventRegistrationToken, void>)(&HardwareButtons.remove_BackPressed)), HardwareButtons_BackPressed);
		});
	}

	public virtual bool CanGoBack()
	{
		if (Frame != null)
		{
			return Frame.CanGoBack;
		}
		return false;
	}

	public virtual bool CanGoForward()
	{
		if (Frame != null)
		{
			return Frame.CanGoForward;
		}
		return false;
	}

	public virtual void GoBack()
	{
		if (Frame != null && Frame.CanGoBack)
		{
			Frame.GoBack();
		}
	}

	public virtual void GoForward()
	{
		if (Frame != null && Frame.CanGoForward)
		{
			Frame.GoForward();
		}
	}

	private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
	{
		if (GoBackCommand.CanExecute(null))
		{
			e.put_Handled(true);
			GoBackCommand.Execute(null);
		}
	}

	public void OnNavigatedTo(NavigationEventArgs e)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, object> dictionary = SuspensionManager.SessionStateForFrame(Frame);
		_pageKey = "Page-" + Frame.BackStackDepth;
		if ((int)e.NavigationMode == 0)
		{
			string key = _pageKey;
			int num = Frame.BackStackDepth;
			while (dictionary.Remove(key))
			{
				num++;
				key = "Page-" + num;
			}
			if (this.LoadState != null)
			{
				this.LoadState(this, new LoadStateEventArgs(e.Parameter, null));
			}
		}
		else if (this.LoadState != null)
		{
			this.LoadState(this, new LoadStateEventArgs(e.Parameter, (Dictionary<string, object>)dictionary[_pageKey]));
		}
	}

	public void OnNavigatedFrom(NavigationEventArgs e)
	{
		Dictionary<string, object> dictionary = SuspensionManager.SessionStateForFrame(Frame);
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		if (this.SaveState != null)
		{
			this.SaveState(this, new SaveStateEventArgs(dictionary2));
		}
		dictionary[_pageKey] = dictionary2;
	}
}
