using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model
{
    public class DocumentRegel
    {
        public int Id { get; set; }

        [Required]
        public int OfferteId { get; set; }  // Verwijzing naar de bijbehorende offerte
        public Offerte? Offerte { get; set; } // Navigatie naar de offerte

        [Required]
        public int FactuurId { get; set; }  // Verwijzing naar de bijbehorende factuur
        public Factuur? Factuur { get; set; } // Navigatie naar de factuur

        [Required]
        public int Aantal { get; set; }  // Aantal artikelen/materieel/werkuren/posten

        [Required]
        public decimal PrijsPerEenheidExclBTW { get; set; } // Prijs per eenheid zonder BTW

        public decimal TotaalExclBTW => Aantal * PrijsPerEenheidExclBTW;  // Totale prijs excl. BTW

        public decimal TotaalInclBTW => TotaalExclBTW * (1 + (BTWPercentage / 100));  // Totale prijs incl. BTW

        [Required]
        public decimal BTWPercentage { get; set; } // Het BTW-percentage voor de regel

        [Required]
        public string Omschrijving { get; set; } = string.Empty;  // Korte omschrijving van het item

        // Verwijzing naar de verschillende types van items
        public int? ArtikelId { get; set; }  // Verwijzing naar een artikel
        public Artikel? Artikel { get; set; } // Navigatie naar het artikel

        public int? MaterieelId { get; set; }  // Verwijzing naar materieel
        public Materieel? Materieel { get; set; } // Navigatie naar het materieel

        public int? WerkurenId { get; set; }  // Verwijzing naar werkuren
        public Werkuren? Werkuur { get; set; } // Navigatie naar werkuren

        public int? PostenId { get; set; }  // Verwijzing naar posten
        public Posten? Posten { get; set; } // Navigatie naar posten

        // Extra velden voor eventuele andere specificaties zoals een foto, eenheid, etc.
        public string? Foto { get; set; } // Foto van het product/item (optioneel)

        public string? Eenheid { get; set; }  // Eenheid van het product (bijv. stuk, meter, liter, etc.)

        [Required]
        public DocumentRegelType RegelType { get; set; }  // Het type regel (Artikel, Materieel, Werkuren, Posten)

        public enum DocumentRegelType
        {
            Artikel,
            Materieel,
            Werkuren,
            Posten
        }
    }
}
