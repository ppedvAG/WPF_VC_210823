using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace M11_UserControls
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        // Custom Event
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent("Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ColorPicker));

        // Handleranmeldung
        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }

        // Methode zum Feuern des Eventhandlers
        void RaiseTapEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ColorPicker.TapEvent);
            RaiseEvent(newEventArgs);
        }

        public ColorPicker()
        {
            InitializeComponent();

            // EventRaising
            Tbl_Output.PreviewMouseDown += (s, e) => RaiseTapEvent();

            //Erstellen einer neuen Bindung (Fill-Eigenschaft des Rechtecks an PickedColor-Eigenschaft)
            //Initialisierung mit Übergabe der zu Bindenden Quell-Eigenschaft
            Binding binding = new Binding("Fill");

            //Setzen des Quell-Objekts
            binding.Source = Rct_Output;

            //Setzen des Bindings-Modes
            binding.Mode = BindingMode.OneWay;

            //Setzen des UpdateSourceTriggers
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //Erstellen der Bindung mit Übergabe des Ziel-Objekts, der Ziel-Eigenschaft und des Bindungs-Elements
            BindingOperations.SetBinding(this, PickedColorProperty, binding);
        }

        //Damit der Control eine Ausgabe hat, an welche die User andere Properties binden können muss für jede dieser Ausgaben eine DependencyProperty
        //erstellt werden, welche im Konstruktor des UserControlls manuell an die entsprechnende Property eines Teilelements gebunden wird.
        //DependencyProperties sind spezielle WPF-Element-Properties, welche nicht in den Objekten selbst gespeichert werden. Stattdessen werden diese
        //in einer eigenen Liste abgelegt. Durch diese Mechanik werden Bindungen und Co in WPF erst möglich.

        // propdp + Tab => Dependency Property erstellen
        // Getter/Setter der DependencyProperty
        public SolidColorBrush PickedColor
        {
            get { return (SolidColorBrush)GetValue(PickedColorProperty); }
            set { SetValue(PickedColorProperty, value); }
        }

        // Registrierung für neue Bindung an der DependencyProperty
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PickedColorProperty =
            DependencyProperty.Register("PickedColor", typeof(SolidColorBrush), typeof(ColorPicker), new PropertyMetadata(default(SolidColorBrush)));

        // propa + Tab => Attached Property erstellen
        // AttachedProperty
         public static int GetCount(DependencyObject obj)
        {
            return (int)obj.GetValue(CountProperty);
        }

        public static void SetCount(DependencyObject obj, int value)
        {
            obj.SetValue(CountProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.RegisterAttached("Count", typeof(int), typeof(ColorPicker), new PropertyMetadata(0));


    }
}
