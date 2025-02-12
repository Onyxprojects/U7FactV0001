using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U7Fact.Model
{
    public class Artikel
    {
        public int Id { get; set; }

        [Required]
        public string Omschrijving { get; set; } = string.Empty;  // Beschrijving van het artikel (Hoofding)

        public string? UitgebreideOmschrijving { get; set; }

        [Required]
        public decimal PrijsPerEenheid { get; set; }  // Prijs per eenheid (excl. BTW)

        [Required]
        public string Eenheid { get; set; } = string.Empty;  // Eenheid van het artikel (bijv. stuk, liter, m², etc.)

        public string? Categorie { get; set; }  // Optioneel: Categorie van het artikel

        public List<DocumentRegel> DocumentRegels { get; set; } = new();  // Koppeling met DocumentRegels
    }
}
