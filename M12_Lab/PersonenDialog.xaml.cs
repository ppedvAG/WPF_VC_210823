using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M12_Lab
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

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            Person person = DataContext as Person;

            if (MessageBox.Show("Abspeichern?", person.Vorname + person.Nachname, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                DialogResult = true;

                Close();
            }
        }

        private void Btn_Abbruch_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
