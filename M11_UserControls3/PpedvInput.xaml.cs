using System.Windows;
using System.Windows.Controls;

namespace M11_UserControls3
{
    /// <summary>
    /// Interaction logic for PpedvInput.xaml
    /// </summary>
    public partial class PpedvInput : UserControl
    {
        public PpedvInput()
        {
            InitializeComponent();

            LayoutRoot.DataContext = this;
        }

        public string Label { get; set; }

        public string LabelText { get; set; }


        #region Dependency Property

        // Value als einfache .NET Property führt bei Binding zu Fehlern
        //public string Value { get; set; }

        // Dependency Property wird verwendet, wenn mehr Funktionalität wie z.B. Binding genutzt wird.
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string), typeof(PpedvInput), new PropertyMetadata(""));

        #endregion
    }
}
