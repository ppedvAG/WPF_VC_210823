using AutoFixture;
using System.Collections.Generic;
using System.Linq;

namespace M14_Model
{

    // PersonenService
    public class PersonenService : IPersonenService
    {
        public IList<Person> GetAllPeople()
        {
            // Todo: Daten aus einer DB laden - oder REST Service etc.
            return new List<Person>
            {
                new Person{ Vorname="Mary", Nachname="Christmas", Alter=24, Kontostand=100},
                new Person{ Vorname="Malte", Nachname="Heinz", Alter=35, Kontostand=200},
                new Person{ Vorname="Max", Nachname="Mustermann", Alter=0, Kontostand=300},
            };
        }

        public IEnumerable<Person> CreatePeople(int amount)
        {
            Fixture fix = new Fixture();
            List<Person> personen = fix.CreateMany<Person>(amount).ToList();

            return personen;
        }
    }
}