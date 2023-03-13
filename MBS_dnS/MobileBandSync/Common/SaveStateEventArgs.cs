using System;
using System.Collections.Generic;

namespace MobileBandSync.Common
{
	// Token: 0x02000084 RID: 132
	public class SaveStateEventArgs : EventArgs
	{
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x0000DF96 File Offset: 0x0000C196
		// (set) Token: 0x060004F8 RID: 1272 RVA: 0x0000DF9E File Offset: 0x0000C19E
		public Dictionary<string, object> PageState { get; private set; }

		// Token: 0x060004F9 RID: 1273 RVA: 0x0000DFA7 File Offset: 0x0000C1A7
		public SaveStateEventArgs(Dictionary<string, object> pageState)
		{
			this.PageState = pageState;
		}
	}
}
