using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U7Fact.Model
{
    public class Werkuren
    {
        public int Id { get; set; }

        [Required]
        public string Omschrijving { get; set; } = string.Empty;  // Beschrijving van het type werkuren

        [Required]
        public decimal UurTarief { get; set; }  // Tarief per uur (excl. BTW)

        [Required]
        public string Eenheid { get; set; } = string.Empty;  // Eenheid van de werkuren (bijv. per uur, per dag)

        public List<DocumentRegel> DocumentRegels { get; set; } = new();  // Koppeling met DocumentRegels
    }
}
