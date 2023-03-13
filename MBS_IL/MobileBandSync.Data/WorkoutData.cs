using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileBandSync.Data;

public class WorkoutData
{
	private IEnumerable<WorkoutItem> _workouts;

	private string _workoutTitle;

	public string WorkoutTitle
	{
		get
		{
			return _workoutTitle;
		}
		set
		{
			_workoutTitle = value;
			OnPropertyChanged("WorkoutTitle");
		}
	}

	public IEnumerable<WorkoutItem> Workouts
	{
		get
		{
			return _workouts;
		}
		set
		{
			_workouts = value;
			OnPropertyChanged("Workouts");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	private void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
