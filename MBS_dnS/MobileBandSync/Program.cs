using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Windows.UI.Xaml;

namespace MobileBandSync
{
	// Token: 0x02000007 RID: 7
	public static class Program
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00004B9E File Offset: 0x00002D9E
		[GeneratedCode("Microsoft.Windows.UI.Xaml.Build.Tasks", " 4.0.0.0")]
		[DebuggerNonUserCode]
		private static void Main(string[] args)
		{
			Application.Start(delegate(ApplicationInitializationCallbackParams p)
			{
				new App();
			});
		}
	}
}
