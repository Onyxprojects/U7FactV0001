using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class BedrijfsKlant : Relatie
{
    [Required(ErrorMessage = "BtwNummer is een verplicht veld")]
    public required string BtwNummer { get; set; }

    public int BtwTariefId { get; set; }
    public ICollection<Offerte> Offertes { get; set; }
}