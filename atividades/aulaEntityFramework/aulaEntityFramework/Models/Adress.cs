using System.ComponentModel.DataAnnotations.Schema;

namespace aulaEntityFramework.Models
{
    public enum UF
    {
        AC, AL, AM, AP, BA, CE, DF, ES, GO, MA, MG, 
        MS, MT, PA, PB, PE, PI, PR, RJ, RN, RO, RR, 
        RS, SC, SE, SP, TO
    }
    public class Adress
    {
        public long Id { get; set; } 
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public UF UF { get; set; }
        public string Country { get; set; } = "Brasil";
        public string? CEP { get; set; }
        public long PersonID { get; set; }
        [ForeignKey("PersonID")]
        public Person? Person{ get; set; }
    }
}
