using System.Globalization;
using System.Threading;
using System.Windows;

namespace M13_Commands
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // UI Sprache auf Englisch stellen
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            InitializeComponent();

            // Initialisierung der Commands
            CloseCmd = new CloseCommand();
            OeffnenCmd = new CustomCommand
            ( 
                // Übergabe der Execute() Logik
                p => (new MainWindow()).Show(),

                // Übergabe der CanExecute() Logik
                p => (p as string).Length >= 1
            );

            DataContext = this;
        }

        // Command Properties
        public CloseCommand CloseCmd { get; set; }
        public CustomCommand OeffnenCmd { get; set; }
    }
}
