using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M08_Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> PersonenListe { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            PersonenListe = new ObservableCollection<Person>
            {
                new Person{ Vorname="Mary", Nachname="Christmas", Alter=20 },
                new Person{ Vorname="Albert", Nachname="Einstein", Alter=33 },
                new Person{ Vorname="Max", Nachname="Musterfrau", Alter=45 }
            };

            DataContext = this;
        }

        private void Btn_ControlTemplate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button funktioniert");
        }

        private void Btn_Loeschen_02_Click(object sender, RoutedEventArgs e)
        {
            //Löschen der Person, welche in dem Button-Tag liegt
            if ((sender as Button).Tag is Person)
            {
                PersonenListe.Remove((sender as Button).Tag as Person);
            }
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            // Hinzufügen einer neuen Person
            PersonenListe.Add(new Person { Vorname = "Bill", Nachname = "G.", Alter = 149 });
        }

        private void Btn_Loeschen_01_Click(object sender, RoutedEventArgs e)
        {
            if (Lbx_Personen.SelectedItem is Person)
            {
                PersonenListe.Remove(Lbx_Personen.SelectedItem as Person);
            }
        }
    }
}
