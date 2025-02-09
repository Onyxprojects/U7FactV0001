using System.ComponentModel.DataAnnotations;


namespace U7Fact.Model
{
    public class Leverancier
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string? BTWNummer { get; set; }
        public string? Straatnaam { get; set; }
        public string? Postcode { get; set; }
        public string? Gemeente { get; set; }
        public string? Land { get; set; }

        //// Relatie naar artikelen of inkomende facturen
        //public ICollection<Artikel> Artikelen { get; set; } // Voor leveranciers kan je producten/artikelen toevoegen
        //public ICollection<InkomendeFactuur> InkomendeFacturen { get; set; }
    }
}