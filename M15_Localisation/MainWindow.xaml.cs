using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M15_Localisation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Testen der aktuellen Sprache
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                // Ändern der Sprache
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }

            // Neu-Öffnen des aktuellen Fensters (mit neuer Sprache)
            new MainWindow().Show();

            //Schließen des alten Fensters
            this.Close();
        }

        public TestEnum SelectedEnumValue { get; set; }
    }
}
