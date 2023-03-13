using System;
using System.Collections.Generic;

namespace MobileBandSync.Common
{
	// Token: 0x02000083 RID: 131
	public class LoadStateEventArgs : EventArgs
	{
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x0000DF5E File Offset: 0x0000C15E
		// (set) Token: 0x060004F3 RID: 1267 RVA: 0x0000DF66 File Offset: 0x0000C166
		public object NavigationParameter { get; private set; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x0000DF6F File Offset: 0x0000C16F
		// (set) Token: 0x060004F5 RID: 1269 RVA: 0x0000DF77 File Offset: 0x0000C177
		public Dictionary<string, object> PageState { get; private set; }

		// Token: 0x060004F6 RID: 1270 RVA: 0x0000DF80 File Offset: 0x0000C180
		public LoadStateEventArgs(object navigationParameter, Dictionary<string, object> pageState)
		{
			this.NavigationParameter = navigationParameter;
			this.PageState = pageState;
		}
	}
}
