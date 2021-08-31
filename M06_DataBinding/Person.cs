using System.ComponentModel;

namespace M06_DataBinding
{
    //Das Interface INotifyPropertyChanged sorgt für ein neues Event, welches bei Aktivierung die GUI über eine Veränderung in diesem Objekt informiert
    public class Person : INotifyPropertyChanged
    {
        //Eine Datenbindung kann nur an Properties durchgeführt werden (keine Felder)
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        private int alter;
        public int Alter
        {
            get { return alter; }
            set
            {
                alter = value;
                //Das PropertyChanged-Event muss zu dem Zeitpunkt geworfen werden, zu dem die GUI über eine Veränderung informiert werden soll
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        //Durch das Interface geforderte Event
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Vorname} {Nachname} ({Alter})";
        }
    }
}
