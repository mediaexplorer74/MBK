namespace MobileBandSync.Common
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute);
        public RelayCommand(Action execute, Func<bool> canExecute);
        public bool CanExecute(object parameter);
        public void Execute(object parameter);
        public void RaiseCanExecuteChanged();
    }
}

