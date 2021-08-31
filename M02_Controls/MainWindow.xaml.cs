using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace M02_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetImageSource();
        }

        private void SetImageSource()
        {
            string[] resourceNames = GetType().GetTypeInfo().Assembly.GetManifestResourceNames();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "M02_Controls.Images.ppedv.bmp";

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            byte[] result = new byte[stream.Length];
            stream.Read(result, 0, result.Length);

            Img_ppedv.Source = LoadImage(result);
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                return null;
            }

            var image = new BitmapImage();
            using (var memoryStream = new MemoryStream(imageData))
            {
                memoryStream.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = memoryStream;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox-Abfrage mit Überprüfung des geklickten Buttons
            switch (MessageBox.Show("JA oder NEIN?", "Meine Frage:", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.RightAlign))
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("YES");
                    break;
                default:
                    MessageBox.Show("No");
                    break;
            }
        }

        private void Btn_KlickMich_Click2(object sender, RoutedEventArgs e)
        {
            //Neuzuweisung der Content-Eigenschaft des Labels mit dem ausgewählten Inhalt der ComboBox
            Lbl_Output.Content = (Cbb_Auswahl.SelectedItem as ComboBoxItem)?.Content;

            //Änderung der Hintergrundfarbe des Fensters
            Wnd_Main.Background = new SolidColorBrush(Colors.Blue);

            //MessageBox mit dem Inhalt der TextBox
            MessageBox.Show(Tbx_Input.Text);

            //Prüfung, ob die Checkbox abgehakt ist
            if (Cbx_Haken.IsChecked == true)
                //Anzeige einer MessageBox mit Inhalt der TextBox und Auswahl der ComboBox
                MessageBox.Show(Tbx_Input.Text + "\n" + Cbb_Auswahl.Text);
        }

        private void Beenden_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Schließen des Fensters
            Close();

            //Beenden der Applikation
            Application.Current.Shutdown();
        }

        private void Neu_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Öffen eines neuen Fensters als gleichberechtigtes Fenster
            new MainWindow() { Title = "Neues Fenster" }.Show();

            //Öffnen eines neuen Fensters als Dialogfenster mit Rückgabe des DialogResults
            bool? dialogresult = new MainWindow() { Title = "Neues Dialogfenster" }.ShowDialog();
            MessageBox.Show(dialogresult.ToString());
        }
    }
}
