using System;
using System.Windows.Input;

namespace MobileBandSync.Common
{
	// Token: 0x02000086 RID: 134
	public class RelayCommand : ICommand
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600050F RID: 1295 RVA: 0x0000E1F4 File Offset: 0x0000C3F4
		// (remove) Token: 0x06000510 RID: 1296 RVA: 0x0000E22C File Offset: 0x0000C42C
		public event EventHandler CanExecuteChanged;

		// Token: 0x06000511 RID: 1297 RVA: 0x0000E261 File Offset: 0x0000C461
		public RelayCommand(Action execute) : this(execute, null)
		{
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0000E26B File Offset: 0x0000C46B
		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			this._execute = execute;
			this._canExecute = canExecute;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0000E28F File Offset: 0x0000C48F
		public bool CanExecute(object parameter)
		{
			return this._canExecute == null || this._canExecute();
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0000E2A6 File Offset: 0x0000C4A6
		public void Execute(object parameter)
		{
			this._execute();
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0000E2B4 File Offset: 0x0000C4B4
		public void RaiseCanExecuteChanged()
		{
			EventHandler canExecuteChanged = this.CanExecuteChanged;
			if (canExecuteChanged != null)
			{
				canExecuteChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x04000346 RID: 838
		private readonly Action _execute;

		// Token: 0x04000347 RID: 839
		private readonly Func<bool> _canExecute;
	}
}
