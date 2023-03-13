using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MobileBandSync.Common
{
	// Token: 0x020000A1 RID: 161
	internal sealed class SuspensionManager
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x0000FB9E File Offset: 0x0000DD9E
		public static Dictionary<string, object> SessionState
		{
			get
			{
				return SuspensionManager._sessionState;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000610 RID: 1552 RVA: 0x0000FBA5 File Offset: 0x0000DDA5
		public static List<Type> KnownTypes
		{
			get
			{
				return SuspensionManager._knownTypes;
			}
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0000FBAC File Offset: 0x0000DDAC
		public static async Task SaveAsync()
		{
			try
			{
				using (List<WeakReference<Frame>>.Enumerator enumerator = SuspensionManager._registeredFrames.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Frame frame;
						if (enumerator.Current.TryGetTarget(out frame))
						{
							SuspensionManager.SaveFrameNavigationState(frame);
						}
					}
				}
				MemoryStream sessionData = new MemoryStream();
				new DataContractSerializer(typeof(Dictionary<string, object>), SuspensionManager._knownTypes).WriteObject(sessionData, SuspensionManager._sessionState);
				using (Stream fileStream = await(await ApplicationData.Current.LocalFolder.CreateFileAsync("_sessionState.xml", 1)).OpenStreamForWriteAsync())
				{
					sessionData.Seek(0L, SeekOrigin.Begin);
					await sessionData.CopyToAsync(fileStream);
				}
				Stream fileStream = null;
				sessionData = null;
			}
			catch (Exception e)
			{
				throw new SuspensionManagerException(e);
			}
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0000FBEC File Offset: 0x0000DDEC
		public static async Task RestoreAsync(string sessionBaseKey = null)
		{
			SuspensionManager._sessionState = new Dictionary<string, object>();
			try
			{
				using (IInputStream inputStream = await(await ApplicationData.Current.LocalFolder.GetFileAsync("_sessionState.xml")).OpenSequentialReadAsync())
				{
					SuspensionManager._sessionState = (Dictionary<string, object>)new DataContractSerializer(typeof(Dictionary<string, object>), SuspensionManager._knownTypes).ReadObject(inputStream.AsStreamForRead());
				}
				using (List<WeakReference<Frame>>.Enumerator enumerator = SuspensionManager._registeredFrames.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Frame frame;
						if (enumerator.Current.TryGetTarget(out frame) && (string)frame.GetValue(SuspensionManager.FrameSessionBaseKeyProperty) == sessionBaseKey)
						{
							frame.ClearValue(SuspensionManager.FrameSessionStateProperty);
							SuspensionManager.RestoreFrameNavigationState(frame);
						}
					}
				}
			}
			catch (Exception e)
			{
				throw new SuspensionManagerException(e);
			}
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0000FC34 File Offset: 0x0000DE34
		public static void RegisterFrame(Frame frame, string sessionStateKey, string sessionBaseKey = null)
		{
			if (frame.GetValue(SuspensionManager.FrameSessionStateKeyProperty) != null)
			{
				throw new InvalidOperationException("Frames can only be registered to one session state key");
			}
			if (frame.GetValue(SuspensionManager.FrameSessionStateProperty) != null)
			{
				throw new InvalidOperationException("Frames must be either be registered before accessing frame session state, or not registered at all");
			}
			if (!string.IsNullOrEmpty(sessionBaseKey))
			{
				frame.SetValue(SuspensionManager.FrameSessionBaseKeyProperty, sessionBaseKey);
				sessionStateKey = sessionBaseKey + "_" + sessionStateKey;
			}
			frame.SetValue(SuspensionManager.FrameSessionStateKeyProperty, sessionStateKey);
			SuspensionManager._registeredFrames.Add(new WeakReference<Frame>(frame));
			SuspensionManager.RestoreFrameNavigationState(frame);
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0000FCB8 File Offset: 0x0000DEB8
		public static void UnregisterFrame(Frame frame)
		{
			SuspensionManager.SessionState.Remove((string)frame.GetValue(SuspensionManager.FrameSessionStateKeyProperty));
			SuspensionManager._registeredFrames.RemoveAll(delegate(WeakReference<Frame> weakFrameReference)
			{
				Frame frame2;
				return !weakFrameReference.TryGetTarget(out frame2) || frame2 == frame;
			});
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0000FD0C File Offset: 0x0000DF0C
		public static Dictionary<string, object> SessionStateForFrame(Frame frame)
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)frame.GetValue(SuspensionManager.FrameSessionStateProperty);
			if (dictionary == null)
			{
				string text = (string)frame.GetValue(SuspensionManager.FrameSessionStateKeyProperty);
				if (text != null)
				{
					if (!SuspensionManager._sessionState.ContainsKey(text))
					{
						SuspensionManager._sessionState[text] = new Dictionary<string, object>();
					}
					dictionary = (Dictionary<string, object>)SuspensionManager._sessionState[text];
				}
				else
				{
					dictionary = new Dictionary<string, object>();
				}
				frame.SetValue(SuspensionManager.FrameSessionStateProperty, dictionary);
			}
			return dictionary;
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0000FD84 File Offset: 0x0000DF84
		private static void RestoreFrameNavigationState(Frame frame)
		{
			Dictionary<string, object> dictionary = SuspensionManager.SessionStateForFrame(frame);
			if (dictionary.ContainsKey("Navigation"))
			{
				frame.SetNavigationState((string)dictionary["Navigation"]);
			}
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0000FDBB File Offset: 0x0000DFBB
		private static void SaveFrameNavigationState(Frame frame)
		{
			SuspensionManager.SessionStateForFrame(frame)["Navigation"] = frame.GetNavigationState();
		}

		// Token: 0x040003FE RID: 1022
		private static Dictionary<string, object> _sessionState = new Dictionary<string, object>();

		// Token: 0x040003FF RID: 1023
		private static List<Type> _knownTypes = new List<Type>();

		// Token: 0x04000400 RID: 1024
		private const string sessionStateFilename = "_sessionState.xml";

		// Token: 0x04000401 RID: 1025
		private static DependencyProperty FrameSessionStateKeyProperty = DependencyProperty.RegisterAttached("_FrameSessionStateKey", typeof(string), typeof(SuspensionManager), null);

		// Token: 0x04000402 RID: 1026
		private static DependencyProperty FrameSessionBaseKeyProperty = DependencyProperty.RegisterAttached("_FrameSessionBaseKeyParams", typeof(string), typeof(SuspensionManager), null);

		// Token: 0x04000403 RID: 1027
		private static DependencyProperty FrameSessionStateProperty = DependencyProperty.RegisterAttached("_FrameSessionState", typeof(Dictionary<string, object>), typeof(SuspensionManager), null);

		// Token: 0x04000404 RID: 1028
		private static List<WeakReference<Frame>> _registeredFrames = new List<WeakReference<Frame>>();
	}
}
