using System.Windows;
using System.Windows.Controls;

namespace M11_UserControls2
{
    /// <summary>
    /// Interaction logic for LabledTextBoxUserControl.xaml
    /// </summary>
    public partial class LabledTextBoxUserControl : UserControl
    {
        public LabledTextBoxUserControl()
        {
            InitializeComponent();

            DataContext = this; // Ich bin meine eigene Standarddatenquelle für die Bindings
        }

        // Normalen .NET Property:
        //public string LabelText { get; set; } // Binding mit Kurzschreibweise
        //public string TextBoxText { get; set; }

        // Dependency Properties propdp + tab + tab
        // DP für mehr Funktionalität

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelTextProperty", typeof(string), typeof(LabledTextBoxUserControl), new PropertyMetadata(""));


        public string TextBoxText
        {
            get { return (string)GetValue(TextBoxTextProperty); }
            set { SetValue(TextBoxTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextBoxTextProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextBoxTextProperty =
            DependencyProperty.Register("TextBoxText", typeof(string), typeof(LabledTextBoxUserControl), new PropertyMetadata(""));


    }
}
