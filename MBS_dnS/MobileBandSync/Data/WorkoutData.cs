using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileBandSync.Data
{
	// Token: 0x0200007F RID: 127
	public class WorkoutData
	{
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x0000DAA7 File Offset: 0x0000BCA7
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x0000DAAF File Offset: 0x0000BCAF
		public string WorkoutTitle
		{
			get
			{
				return this._workoutTitle;
			}
			set
			{
				this._workoutTitle = value;
				this.OnPropertyChanged("WorkoutTitle");
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x0000DAC3 File Offset: 0x0000BCC3
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x0000DACB File Offset: 0x0000BCCB
		public IEnumerable<WorkoutItem> Workouts
		{
			get
			{
				return this._workouts;
			}
			set
			{
				this._workouts = value;
				this.OnPropertyChanged("Workouts");
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060004CE RID: 1230 RVA: 0x0000DAE0 File Offset: 0x0000BCE0
		// (remove) Token: 0x060004CF RID: 1231 RVA: 0x0000DB18 File Offset: 0x0000BD18
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x060004D0 RID: 1232 RVA: 0x0000DB4D File Offset: 0x0000BD4D
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			propertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		// Token: 0x04000338 RID: 824
		private IEnumerable<WorkoutItem> _workouts;

		// Token: 0x04000339 RID: 825
		private string _workoutTitle;
	}
}
