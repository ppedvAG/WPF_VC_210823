﻿using System;
using System.ComponentModel;

namespace M06_Lab
{
    public enum Gender
    {
        Männlich,
        Weiblich,
        Divers
    }

    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string vorname;
        public string Vorname { 
            get => vorname;
            set
            {
                vorname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vorname)));
            }
        }

        private string nachname;
        public string Nachname
        {
            get => nachname;
            set
            {
                nachname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nachname)));
            }
        }

        private DateTime geburtsdatum;
        public DateTime Geburtsdatum
        {
            get => geburtsdatum;
            set
            {
                geburtsdatum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Geburtsdatum)));
            }
        }

        private bool verheiratet;
        public bool Verheiratet
        {
            get => verheiratet;
            set
            {
                verheiratet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Verheiratet)));
            }
        }

        private string lieblingsfarbe;
        public string Lieblingsfarbe
        {
            get => lieblingsfarbe;
            set
            {
                lieblingsfarbe = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lieblingsfarbe)));
            }
        }

        private Gender geschlecht;
        public Gender Geschlecht
        {
            get => geschlecht;
            set
            {
                geschlecht = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Geschlecht)));
            }
        }

        public Person()
        {
            Geburtsdatum = DateTime.Now;
        }
    }
}
