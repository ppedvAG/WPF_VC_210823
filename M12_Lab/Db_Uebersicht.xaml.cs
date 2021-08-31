using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace M12_Lab
{
    /// <summary>
    /// Interaction logic for Db_Uebersicht.xaml
    /// </summary>
    public partial class Db_Uebersicht : Window
    {
        public ObservableCollection<Person> PersonenListe { get; set; } = new ObservableCollection<Person>
        {
            new Person{Vorname="Mary", Nachname="Chrsitmans", Geburtsdatum=new DateTime(1970,1,1), Verheiratet=true, Lieblingsfarbe= Colors.Green.ToString(), Geschlecht=Gender.Weiblich, Kinder=1},
            new Person{Vorname="Rainer", Nachname="Zufall", Geburtsdatum=new DateTime(1980,2,3), Verheiratet=true, Lieblingsfarbe=Colors.Blue.ToString(), Geschlecht=Gender.Männlich, Kinder=2},
            new Person{Vorname="Malte", Nachname="Heinz", Geburtsdatum=new DateTime(1990,5,4), Verheiratet=true, Lieblingsfarbe=Colors.Red.ToString(), Geschlecht=Gender.Divers, Kinder=3}
        };

        public Db_Uebersicht()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void Mei_Beenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            PersonenDialog dialog = new PersonenDialog();

            if (dialog.ShowDialog() == true)
            {
                PersonenListe.Add(dialog.DataContext as Person);
            }
        }

        private void Btn_Aendern_Click(object sender, RoutedEventArgs e)
        {
            PersonenDialog dialog = new PersonenDialog();

            dialog.DataContext = new Person(Dgd_Personen.SelectedItem as Person);

            dialog.Title = (dialog.DataContext as Person).Vorname + " " + (dialog.DataContext as Person).Nachname;

            if (dialog.ShowDialog() == true)
            {
                var person = (dialog.DataContext as Person);

                PersonenListe[Dgd_Personen.SelectedIndex] = person;
            }
        }

        private void Btn_Löschen_Click(object sender, RoutedEventArgs e)
        {
            Person person = Dgd_Personen.SelectedItem as Person;

            if (MessageBox.Show($"Soll {person.Vorname} {person.Nachname} wirklich gelöscht werden?", $"{person.Vorname} {person.Nachname} löschen?",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                PersonenListe.Remove(person);
            }
        }
    }
}
