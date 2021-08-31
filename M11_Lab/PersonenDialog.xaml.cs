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

namespace M11_Lab
{
    /// <summary>
    /// Interaction logic for PersonenDialog.xaml
    /// </summary>
    public partial class PersonenDialog : Window
    {
        public PersonenDialog()
        {
            InitializeComponent();

            DataContext = new Person();
        }

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            Person person = DataContext as Person;

            var lieblingsFarbe = ((ComboBoxItem)Cbb_Lieblingsfarbe.SelectedItem).Content;

            string ausgabe = $"{person.Vorname} {person.Nachname} ({person.Geschlecht}) {person.Geburtsdatum.ToShortDateString()} {lieblingsFarbe}";

            MessageBox.Show(ausgabe);
        }

        private void Btn_Abbruch_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
