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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M04_EventRouting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Wnd_Main_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ButtonBase.Click-Wnd_Main_Click");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Stoppt Event Bubbeling
            e.Handled = true;

            MessageBox.Show("Button_Click");
        }

        private void Wnd_Main_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;
            //MessageBox.Show("TextBoxBase.TextChanged.Wnd_Main_TextChanged");
        }

        private void PreviewMouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement el = sender as FrameworkElement;
            FrameworkElement originalSource = e.OriginalSource as FrameworkElement;

            if (el?.Name == "A")
            {
                Tbl_Output.Text = $"Origin: {originalSource?.Name}\n\n";
            }

            Tbl_Output.Text = el.Name + " Tunnel/Preview\n";
        }

        private void MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            //Ausgabe des Namens des werfenden StackPanles (sender)
            Tbl_Output.Text += (sender as FrameworkElement).Name + " Bubble\n";

            //Handling des Events abschließen (= Weiterleitung wird unterbunden), wenn der Name des werfenden StackPanels "Gelb" ist
            if ((sender as FrameworkElement).Name == "Gelb")
            {
                e.Handled = true;
                Tbl_Output.Text += "Handled\n";
            }
        }
    }
}
