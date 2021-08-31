using M11_UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace M10_Triggers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //Property, auf die der DataTrigger reagiert
        private bool boolVal;
        public bool BoolVal
        {
            get { return boolVal; }
            set { 
                boolVal = value;
                //Setter mit Event-Wurf
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BoolVal)));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            BoolVal = true;

            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Btn_Ändern_Click(object sender, RoutedEventArgs e)
        {
            BoolVal = !BoolVal;
        }

        private void ColorPicker_Tap(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as ColorPicker).PickedColor.ToString());
            (sender as ColorPicker).PickedColor.ToString();
        }
    }
}
