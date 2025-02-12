using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U7Fact.Model
{
    public class Materieel
    {
        public int Id { get; set; }

        [Required]
        public string Omschrijving { get; set; } = string.Empty;  // Beschrijving van het materieel

        public string? UitgebreideOmschrijving { get; set; }

        [Required]
        public decimal PrijsPerDag { get; set; }  // Prijs per dag of andere tijdseenheid

        [Required]
        public string Eenheid { get; set; } = string.Empty;  // Eenheid van het materieel (bijv. per dag, per uur)

        public string? Categorie { get; set; }  // Optioneel: Categorie van het materieel

        public List<DocumentRegel> DocumentRegels { get; set; } = new();  // Koppeling met DocumentRegels
    }
}
