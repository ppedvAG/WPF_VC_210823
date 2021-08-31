using System.Collections.ObjectModel;
using System.Windows;

namespace M06_DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Properties vom Typ ObservableCollection informieren die GUI automatisch über Veränderungen (z.B. neuer Listeneintrag). Sie eignen sich besonders gut
        //für eine Bindung an ein ItemControl (z.B. ComboBox, ListBox, DataGrid, ...)
        public ObservableCollection<Person> PersonenListe { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //Erstellen von Bsp-Daten
            PersonenListe = new ObservableCollection<Person>
            {
                new Person{Vorname = "Max", Nachname="Mustermann", Alter=40},
                new Person{Vorname = "Anna", Nachname="Meier", Alter=50},
            };

            //Setzen des DataContext des Fensters auf sich selbst (Einfache Bindungen zu Properties in diesem Objekt möglich)
            DataContext = this;
        }

        private void Btn_Show_Click(object sender, RoutedEventArgs e)
        {
            // Ausgabe der Vorname-Property
            MessageBox.Show((Spl_DataContextBsp.DataContext as Person).Vorname);
        }

        private void Btn_Altern_Click(object sender, RoutedEventArgs e)
        {
            // Erhöhung des Alters der Person im DataContext des StackPanels
            (Spl_DataContextBsp.DataContext as Person).Alter++;
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            // Hinzufügen einer neuen Person
            var person = new Person
            {
                Vorname = (Spl_DataContextBsp.DataContext as Person).Vorname,
                Nachname = "Christmas",
                Alter = 24
            };

            PersonenListe.Add(person);
        }

        private void Btn_Löschen_Click(object sender, RoutedEventArgs e)
        {
            // Löschen der ausgewählten Person in der ListView
            if (Lbl_Personen.SelectedItem is Person)
            {
                PersonenListe.Remove(Lbl_Personen.SelectedItem as Person);
            }
        }
    }
}
