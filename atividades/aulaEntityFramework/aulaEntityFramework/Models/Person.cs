namespace aulaEntityFramework.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Adress>? Adresses { get; set; }
    }
}
