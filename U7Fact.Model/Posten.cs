using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U7Fact.Model
{
    public class Posten
    {
        public int Id { get; set; }

        [Required]
        public string Omschrijving { get; set; } = string.Empty;  // Beschrijving van de post

        [Required]
        public decimal Prijs { get; set; }  // Totale prijs van de post (excl. BTW)

        public List<DocumentRegel> DocumentRegels { get; set; } = new();  // Koppeling met DocumentRegels
    }
}
