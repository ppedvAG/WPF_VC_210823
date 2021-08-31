using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace M11_Lib
{
    /// <summary>
    /// Interaction logic for IntegerUpDown.xaml
    /// </summary>
    public partial class IntegerUpDown : UserControl
    {
        public IntegerUpDown()
        {
            InitializeComponent();
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(IntegerUpDown), new PropertyMetadata(default(int)));


        private void Btn_Up_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void Btn_Down_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void Uc_IntegerUpDown_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    Btn_Up_Click(sender, e);
                    break;
                case Key.Down:
                    Btn_Down_Click(sender, e);
                    break;
            }
        }
    }
}