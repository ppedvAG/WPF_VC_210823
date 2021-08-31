using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace M09_Validation
{
    public class Person : IDataErrorInfo
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                //Bei ValidatesOnException wird im Fehlerfall eine Exception geworfen, welche von der GUI aufgefangen
                //wird und als Validierungsfehler interpretiert wird. Die Exception-Message ist der
                //ErrorContent
                if (value.All(x => Char.IsLetter(x)))
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Bitte gib nur einen Buchstaben ein.");
                }
            }
        }

        public int Alter { get; set; }

        // Error wird von WPF nicht benutzt
        public string Error => null;

        //Diese Property wird von der GUI als Validierung verwendet. Wenn ein nicht-leerer String zurückgegeben wird, 
        //dann wird dies als Fehler interpretiert und dieser String als Fehlermeldung
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case (nameof(Alter)):
                        if (Alter < 0 || Alter > 150) return "Bitte gib ein richtiges Alter an.";
                        break;
                    default:
                        break;
                }

                return null;
            }
        }
    }
}
