namespace MobileBandSync.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class SaveStateEventArgs : EventArgs
    {
        public SaveStateEventArgs(Dictionary<string, object> pageState);

        public Dictionary<string, object> PageState { get; private set; }
    }
}

