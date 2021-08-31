using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Text;
using System;

namespace M04_Lab
{
    /// <summary>
    /// Interaction logic for PersonenDialog.xaml
    /// </summary>
    public partial class PersonenDialog : Window
    {
        public PersonenDialog()
        {
            InitializeComponent();
        }

        public StringBuilder Log { get; set; } = new StringBuilder("WindowLog:\n\n");

        #region Original EventHandler

        //private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{

        //}

        //private void Window_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        //private void Window_Click(object sender, RoutedEventArgs e)
        //{

        //}

        #endregion

        // Logging einer Aktion
        private void LogAction(object sender, RoutedEventArgs e)
        {
            // Speichern des Namens des Quellelements
            string originalSource = e.OriginalSource is TextBox ? (e.OriginalSource as TextBox).Name : e.OriginalSource.ToString();

            // Testen auf Art des Events anhand der EventArgs und Eintrag ins Log
            if (e.GetType() == typeof(MouseButtonEventArgs))
            {
                Log.Append($"{originalSource}: MouseButtonPressed: {(e as MouseButtonEventArgs).ChangedButton}");
            }
            else if(e.GetType() == typeof(KeyEventArgs))
            {
                Log.Append($"{originalSource}: KeyPressed: {(e as KeyEventArgs).Key}");
            }
            else if(e.GetType() == typeof(TextChangedEventArgs))
            {
                Log.Append($"{originalSource}: TextChanged: {(e.OriginalSource as TextBox).Text}");
            }
            else
            {
                Log.Append($"{originalSource}: Unknown Event");
            }

            Log.Append(Environment.NewLine);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Test, ob "F1" gedrückt wurde
            if (e.Key == Key.F1)
            {
                // Log Anzeige
                MessageBox.Show(Log.ToString(), "Log", MessageBoxButton.OK);
            }
            else
            {
                // Ansonsten Eintrag ins Log
                LogAction(sender, e);
            }
        }
    }
}
