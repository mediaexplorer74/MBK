namespace MobileBandSync.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class LoadStateEventArgs : EventArgs
    {
        public LoadStateEventArgs(object navigationParameter, Dictionary<string, object> pageState);

        public object NavigationParameter { get; private set; }

        public Dictionary<string, object> PageState { get; private set; }
    }
}

