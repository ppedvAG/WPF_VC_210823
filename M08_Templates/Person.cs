namespace M08_Templates
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }

        public override string ToString()
        {
            return $"Person: {Nachname}";
        }
    }
}
