using System.Collections.Generic;

namespace M14_Model
{
    // Interface für PersonenService => Kapselt Funktionalität
    public interface IPersonenService
    {
        public IList<Person> GetAllPeople();
        public IEnumerable<Person> CreatePeople(int amount);
    }
}