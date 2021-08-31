using System;
using System.Windows.Markup;

namespace M15_Localisation
{
    public partial class MainWindow
    {
        //Spezielles Markup-Extension-Objekt
        public sealed class EnumerateExtension : MarkupExtension
        {
            //Type = Enum-Typ
            public Type Type { get; set; }
            //Der Übergabe-Parameter wird in XAML direkt hinter den Aufruf der Markupextension gesetzt (vgl. XAML)
            public EnumerateExtension(Type type)
            {
                this.Type = type;
            }

            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                //Umwandlung der Enums in lokalisierte Strings und Rückgabe dieser an den Aufrufer (hier wird eine ItemsSource-Property erwartet)
                string[] names = Enum.GetNames(Type);
                string[] values = new string[names.Length];

                for (int i = 0; i < names.Length; i++)
                    values[i] = Loc.Strings.ResourceManager.GetString(names[i]);

                return values;
            }
        }
    }
}
