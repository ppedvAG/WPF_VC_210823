using System;
using System.Windows.Input;

namespace M14_ViewModel
{
    public class CustomCommand : ICommand
    {
        private Action executeHandler;

        public CustomCommand(Action executeHandler)
        {
            this.executeHandler = executeHandler;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; // Command darf IMMER ausgeführt werden
        }

        public void Execute(object parameter)
        {
            executeHandler();
        }
    }
}
