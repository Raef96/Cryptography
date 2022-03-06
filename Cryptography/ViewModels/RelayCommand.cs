using System;
using System.Windows.Input;

namespace Cryptography.App.ViewModels
{
    internal class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null) return false;
            return _canExecute();
        }

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
