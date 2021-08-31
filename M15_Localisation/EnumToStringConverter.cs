using System;
using System.Globalization;
using System.Windows.Data;

namespace M15_Localisation
{
    public sealed class EnumToStringConverter : IValueConverter
    {
        //Enum -> lokalisierter ComboBoxEintrag
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            //Zugriff auf ResX
            return Loc.Strings.ResourceManager.GetString(value.ToString());
        }

        //lokalisierter ComboBoxEintrag -> Enum
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = (string)value;

            foreach (object enumValue in Enum.GetValues(targetType))
            {
                if (str == Loc.Strings.ResourceManager.GetString(enumValue.ToString()))
                    return enumValue;
            }

            throw new ArgumentException(null, "value");
        }
    }
}
