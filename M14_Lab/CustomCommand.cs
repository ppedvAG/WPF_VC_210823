using System;
using System.Windows.Input;

namespace M14_Lab
{
    public class CustomCommand : ICommand
    {
        public Action<object> ExecuteMethod { get; set; }
        public Func<object, bool> CanExecuteMethod { get; set; }

        public CustomCommand(Action<object> execute, Func<object, bool> can = null)
        {
            ExecuteMethod = execute;

            if (can == null) CanExecuteMethod = p => true;
            else CanExecuteMethod = can;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteMethod(parameter);
        }
    }
}
