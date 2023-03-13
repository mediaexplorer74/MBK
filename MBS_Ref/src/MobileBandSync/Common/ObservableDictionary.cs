namespace MobileBandSync.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation.Collections;

    public class ObservableDictionary : IObservableMap<string, object>, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
    {
        private Dictionary<string, object> _dictionary;
        [CompilerGenerated]
        private EventRegistrationTokenTable<MapChangedEventHandler<string, object>> MapChanged;

        public event MapChangedEventHandler<string, object> MapChanged;

        public ObservableDictionary();
        public void Add(KeyValuePair<string, object> item);
        public void Add(string key, object value);
        public void Clear();
        public bool Contains(KeyValuePair<string, object> item);
        public bool ContainsKey(string key);
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex);
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator();
        private void InvokeMapChanged(CollectionChange change, string key);
        public bool Remove(KeyValuePair<string, object> item);
        public bool Remove(string key);
        IEnumerator IEnumerable.GetEnumerator();
        public bool TryGetValue(string key, out object value);

        public object this[string key] { get; set; }

        public ICollection<string> Keys { get; }

        public ICollection<object> Values { get; }

        public int Count { get; }

        public bool IsReadOnly { get; }

        private class ObservableDictionaryChangedEventArgs : IMapChangedEventArgs<string>
        {
            public ObservableDictionaryChangedEventArgs(Windows.Foundation.Collections.CollectionChange change, string key);

            public Windows.Foundation.Collections.CollectionChange CollectionChange { get; private set; }

            public string Key { get; private set; }
        }
    }
}

