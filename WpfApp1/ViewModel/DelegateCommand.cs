using System;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }
            
        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        
        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
         
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
