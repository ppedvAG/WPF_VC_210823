using System.Windows;
using System.Windows.Controls;

namespace M07_Lab
{
    /// <summary>
    /// Interaction logic for PersonenDialog.xaml
    /// </summary>
    public partial class PersonenDialog : Window
    {
        public PersonenDialog()
        {
            InitializeComponent();

            //DataContext = new Person();
        }

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            Person person = DataContext as Person;

            var comboBoxItem = Cbb_Lieblingsfarbe.SelectedItem as ComboBoxItem;

            string lieblingsFarbe = "No color";

            if (comboBoxItem != null)
            {
                lieblingsFarbe = comboBoxItem.Content.ToString();
            }

            string ausgabe = $"{person.Vorname} {person.Nachname} ({person.Geschlecht}) {person.Geburtsdatum.ToShortDateString()} {lieblingsFarbe}";

            MessageBox.Show(ausgabe);
        }

        private void Btn_Abbruch_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
