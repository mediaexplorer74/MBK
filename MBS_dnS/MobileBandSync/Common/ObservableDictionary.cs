using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation.Collections;

namespace MobileBandSync.Common
{
	// Token: 0x02000085 RID: 133
	public class ObservableDictionary : IObservableMap<string, object>, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060004FA RID: 1274 RVA: 0x0000DFB6 File Offset: 0x0000C1B6
		// (remove) Token: 0x060004FB RID: 1275 RVA: 0x0000DFC9 File Offset: 0x0000C1C9
		public event MapChangedEventHandler<string, object> MapChanged
		{
			[CompilerGenerated]
			add
			{
				return EventRegistrationTokenTable<MapChangedEventHandler<string, object>>.GetOrCreateEventRegistrationTokenTable(ref this.MapChanged).AddEventHandler(value);
			}
			[CompilerGenerated]
			remove
			{
				EventRegistrationTokenTable<MapChangedEventHandler<string, object>>.GetOrCreateEventRegistrationTokenTable(ref this.MapChanged).RemoveEventHandler(value);
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0000DFDC File Offset: 0x0000C1DC
		private void InvokeMapChanged(CollectionChange change, string key)
		{
			MapChangedEventHandler<string, object> invocationList = EventRegistrationTokenTable<MapChangedEventHandler<string, object>>.GetOrCreateEventRegistrationTokenTable(ref this.MapChanged).InvocationList;
			if (invocationList != null)
			{
				invocationList.Invoke(this, new ObservableDictionary.ObservableDictionaryChangedEventArgs(change, key));
			}
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0000E00B File Offset: 0x0000C20B
		public void Add(string key, object value)
		{
			this._dictionary.Add(key, value);
			this.InvokeMapChanged(1, key);
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x0000E022 File Offset: 0x0000C222
		public void Add(KeyValuePair<string, object> item)
		{
			this.Add(item.Key, item.Value);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0000E038 File Offset: 0x0000C238
		public bool Remove(string key)
		{
			if (this._dictionary.Remove(key))
			{
				this.InvokeMapChanged(2, key);
				return true;
			}
			return false;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0000E054 File Offset: 0x0000C254
		public bool Remove(KeyValuePair<string, object> item)
		{
			object objB;
			if (this._dictionary.TryGetValue(item.Key, out objB) && object.Equals(item.Value, objB) && this._dictionary.Remove(item.Key))
			{
				this.InvokeMapChanged(2, item.Key);
				return true;
			}
			return false;
		}

		// Token: 0x17000171 RID: 369
		public object this[string key]
		{
			get
			{
				return this._dictionary[key];
			}
			set
			{
				this._dictionary[key] = value;
				this.InvokeMapChanged(3, key);
			}
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0000E0D0 File Offset: 0x0000C2D0
		public void Clear()
		{
			string[] array = this._dictionary.Keys.ToArray<string>();
			this._dictionary.Clear();
			foreach (string key in array)
			{
				this.InvokeMapChanged(2, key);
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x0000E113 File Offset: 0x0000C313
		public ICollection<string> Keys
		{
			get
			{
				return this._dictionary.Keys;
			}
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0000E120 File Offset: 0x0000C320
		public bool ContainsKey(string key)
		{
			return this._dictionary.ContainsKey(key);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0000E12E File Offset: 0x0000C32E
		public bool TryGetValue(string key, out object value)
		{
			return this._dictionary.TryGetValue(key, out value);
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x0000E13D File Offset: 0x0000C33D
		public ICollection<object> Values
		{
			get
			{
				return this._dictionary.Values;
			}
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0000E14A File Offset: 0x0000C34A
		public bool Contains(KeyValuePair<string, object> item)
		{
			return this._dictionary.Contains(item);
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0000E158 File Offset: 0x0000C358
		public int Count
		{
			get
			{
				return this._dictionary.Count;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x0000E165 File Offset: 0x0000C365
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0000E168 File Offset: 0x0000C368
		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return this._dictionary.GetEnumerator();
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0000E168 File Offset: 0x0000C368
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._dictionary.GetEnumerator();
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000E17C File Offset: 0x0000C37C
		public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			int num = array.Length;
			foreach (KeyValuePair<string, object> keyValuePair in this._dictionary)
			{
				if (arrayIndex >= num)
				{
					break;
				}
				array[arrayIndex++] = keyValuePair;
			}
		}

		// Token: 0x04000344 RID: 836
		private Dictionary<string, object> _dictionary = new Dictionary<string, object>();

		// Token: 0x02000121 RID: 289
		private class ObservableDictionaryChangedEventArgs : IMapChangedEventArgs<string>
		{
			// Token: 0x06000752 RID: 1874 RVA: 0x0001EA72 File Offset: 0x0001CC72
			public ObservableDictionaryChangedEventArgs(CollectionChange change, string key)
			{
				this.CollectionChange = change;
				this.Key = key;
			}

			// Token: 0x17000205 RID: 517
			// (get) Token: 0x06000753 RID: 1875 RVA: 0x0001EA88 File Offset: 0x0001CC88
			// (set) Token: 0x06000754 RID: 1876 RVA: 0x0001EA90 File Offset: 0x0001CC90
			public CollectionChange CollectionChange { get; private set; }

			// Token: 0x17000206 RID: 518
			// (get) Token: 0x06000755 RID: 1877 RVA: 0x0001EA99 File Offset: 0x0001CC99
			// (set) Token: 0x06000756 RID: 1878 RVA: 0x0001EAA1 File Offset: 0x0001CCA1
			public string Key { get; private set; }
		}
	}
}
