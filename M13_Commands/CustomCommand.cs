using System;
using System.Windows.Input;

namespace M13_Commands
{
    //Allgemeine generische Commandklasse, welche individuell befüllt werden kann.
    //ICommand ermöglicht dieser Klasse, als Command verwendet zu werden
    public class CustomCommand : ICommand
    {
        // Delegates zum Speichern der Logik
        public Action<object> ExecuteMethod { get; set; }
        public Func<object, bool> CanExecuteMethod { get; set; }

        // Konstruktor
        public CustomCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod = null)
        {
            ExecuteMethod = executeMethod;

            CanExecuteMethod = (canExecuteMethod == null) ? (p => true) : canExecuteMethod;
        }

        //Anmeldung des Commands im CommandManager
        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Bedingung für die Ausführung
        public bool CanExecute(object parameter)
        {
            return CanExecuteMethod(parameter);
        }

        //Aktion bei Ausführung
        public void Execute(object parameter)
        {
            ExecuteMethod(parameter);
        }
    }
}
