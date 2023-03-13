using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MobileBandSync.Common;

internal sealed class SuspensionManager
{
	private static Dictionary<string, object> _sessionState = new Dictionary<string, object>();

	private static List<Type> _knownTypes = new List<Type>();

	private const string sessionStateFilename = "_sessionState.xml";

	private static DependencyProperty FrameSessionStateKeyProperty = DependencyProperty.RegisterAttached("_FrameSessionStateKey", typeof(string), typeof(SuspensionManager), (PropertyMetadata)null);

	private static DependencyProperty FrameSessionBaseKeyProperty = DependencyProperty.RegisterAttached("_FrameSessionBaseKeyParams", typeof(string), typeof(SuspensionManager), (PropertyMetadata)null);

	private static DependencyProperty FrameSessionStateProperty = DependencyProperty.RegisterAttached("_FrameSessionState", typeof(Dictionary<string, object>), typeof(SuspensionManager), (PropertyMetadata)null);

	private static List<WeakReference<Frame>> _registeredFrames = new List<WeakReference<Frame>>();

	public static Dictionary<string, object> SessionState => _sessionState;

	public static List<Type> KnownTypes => _knownTypes;

	public static async Task SaveAsync()
	{
		try
		{
			foreach (WeakReference<Frame> registeredFrame in _registeredFrames)
			{
				if (registeredFrame.TryGetTarget(out var target))
				{
					SaveFrameNavigationState(target);
				}
			}
			MemoryStream sessionData = new MemoryStream();
			new DataContractSerializer(typeof(Dictionary<string, object>), _knownTypes).WriteObject(sessionData, _sessionState);
			TaskAwaiter<StorageFile> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(ApplicationData.Current.LocalFolder.CreateFileAsync("_sessionState.xml", (CreationCollisionOption)1));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<StorageFile> taskAwaiter2 = default(TaskAwaiter<StorageFile>);
				taskAwaiter = taskAwaiter2;
			}
			using Stream fileStream = await WindowsRuntimeStorageExtensions.OpenStreamForWriteAsync((IStorageFile)(object)taskAwaiter.GetResult());
			sessionData.Seek(0L, SeekOrigin.Begin);
			await sessionData.CopyToAsync(fileStream);
		}
		catch (Exception e)
		{
			throw new SuspensionManagerException(e);
		}
	}

	public static async Task RestoreAsync(string sessionBaseKey = null)
	{
		_sessionState = new Dictionary<string, object>();
		try
		{
			TaskAwaiter<StorageFile> taskAwaiter = WindowsRuntimeSystemExtensions.GetAwaiter<StorageFile>(ApplicationData.Current.LocalFolder.GetFileAsync("_sessionState.xml"));
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<StorageFile> taskAwaiter2 = default(TaskAwaiter<StorageFile>);
				taskAwaiter = taskAwaiter2;
			}
			TaskAwaiter<IInputStream> taskAwaiter3 = WindowsRuntimeSystemExtensions.GetAwaiter<IInputStream>(taskAwaiter.GetResult().OpenSequentialReadAsync());
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter<IInputStream> taskAwaiter4 = default(TaskAwaiter<IInputStream>);
				taskAwaiter3 = taskAwaiter4;
			}
			IInputStream result = taskAwaiter3.GetResult();
			try
			{
				_sessionState = (Dictionary<string, object>)new DataContractSerializer(typeof(Dictionary<string, object>), _knownTypes).ReadObject(WindowsRuntimeStreamExtensions.AsStreamForRead(result));
			}
			finally
			{
				((IDisposable)result)?.Dispose();
			}
			foreach (WeakReference<Frame> registeredFrame in _registeredFrames)
			{
				if (registeredFrame.TryGetTarget(out var target) && (string)((DependencyObject)target).GetValue(FrameSessionBaseKeyProperty) == sessionBaseKey)
				{
					((DependencyObject)target).ClearValue(FrameSessionStateProperty);
					RestoreFrameNavigationState(target);
				}
			}
		}
		catch (Exception e)
		{
			throw new SuspensionManagerException(e);
		}
	}

	public static void RegisterFrame(Frame frame, string sessionStateKey, string sessionBaseKey = null)
	{
		if (((DependencyObject)frame).GetValue(FrameSessionStateKeyProperty) != null)
		{
			throw new InvalidOperationException("Frames can only be registered to one session state key");
		}
		if (((DependencyObject)frame).GetValue(FrameSessionStateProperty) != null)
		{
			throw new InvalidOperationException("Frames must be either be registered before accessing frame session state, or not registered at all");
		}
		if (!string.IsNullOrEmpty(sessionBaseKey))
		{
			((DependencyObject)frame).SetValue(FrameSessionBaseKeyProperty, (object)sessionBaseKey);
			sessionStateKey = sessionBaseKey + "_" + sessionStateKey;
		}
		((DependencyObject)frame).SetValue(FrameSessionStateKeyProperty, (object)sessionStateKey);
		_registeredFrames.Add(new WeakReference<Frame>(frame));
		RestoreFrameNavigationState(frame);
	}

	public static void UnregisterFrame(Frame frame)
	{
		SessionState.Remove((string)((DependencyObject)frame).GetValue(FrameSessionStateKeyProperty));
		_registeredFrames.RemoveAll((WeakReference<Frame> weakFrameReference) => !weakFrameReference.TryGetTarget(out var target) || target == frame);
	}

	public static Dictionary<string, object> SessionStateForFrame(Frame frame)
	{
		Dictionary<string, object> dictionary = (Dictionary<string, object>)((DependencyObject)frame).GetValue(FrameSessionStateProperty);
		if (dictionary == null)
		{
			string text = (string)((DependencyObject)frame).GetValue(FrameSessionStateKeyProperty);
			if (text != null)
			{
				if (!_sessionState.ContainsKey(text))
				{
					_sessionState[text] = new Dictionary<string, object>();
				}
				dictionary = (Dictionary<string, object>)_sessionState[text];
			}
			else
			{
				dictionary = new Dictionary<string, object>();
			}
			((DependencyObject)frame).SetValue(FrameSessionStateProperty, (object)dictionary);
		}
		return dictionary;
	}

	private static void RestoreFrameNavigationState(Frame frame)
	{
		Dictionary<string, object> dictionary = SessionStateForFrame(frame);
		if (dictionary.ContainsKey("Navigation"))
		{
			frame.SetNavigationState((string)dictionary["Navigation"]);
		}
	}

	private static void SaveFrameNavigationState(Frame frame)
	{
		SessionStateForFrame(frame)["Navigation"] = frame.GetNavigationState();
	}
}
