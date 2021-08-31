using EnsureThat;
using M14_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace M14_ViewModel
{

    public class MainViewModel : INotifyPropertyChanged
    {
        private IPersonenService _personenService;

        public IList<Person> PersonenListe { get; set; }
        public ICommand GetPeopleCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel() : this(new PersonenService())
        {

        }

        public MainViewModel(IPersonenService personenService)
        {
            // Null Check für Konstruktor Parameter
            EnsureArg.IsNotNull(personenService, nameof(personenService));

            //if (personenService == null)
            //{
            //    throw new ArgumentNullException(nameof(personenService));
            //}

            _personenService = personenService;

            GetPeopleCommand = new CustomCommand(GetPeople);
        }

        private void GetPeople()
        {
            PersonenListe = _personenService.GetAllPeople();
            //PersonenListe = _personenService.CreatePeople(10).ToList();

            // Informiert UI, dass sich die PersonenListe geändert hat => Aktualisiert das Binding
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PersonenListe)));          
        }

    }
}
