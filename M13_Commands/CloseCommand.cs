﻿using System;
using System.Windows.Input;

namespace M13_Commands
{
    //Auf eine Aufgabe (das Schließen eines Fensters) spezialisierte Command-Klasse (vgl. CustomCommand.cs)
    public class CloseCommand : ICommand
    {
        //Anmeldung des Events im CommandManager der Applikation
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Bedingung für Ausführung
        public bool CanExecute(object parameter)
        {
            return (parameter as MainWindow).Width < 150;
        }

        //Aktion bei Ausführung
        public void Execute(object parameter)
        {
            (parameter as MainWindow).Close();
        }
    }
}
