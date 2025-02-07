using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class BedrijfsKlant : Relatie
{
    // Bestaand veld na bezoek Tom
    [Required(ErrorMessage = "BtwNummer is een verplicht veld")]
    public required string BtwNummer { get; set; }
    // Vanaf hier bijgevoegd
    [Required(ErrorMessage = "Bedrijfsnaam is een verplicht veld")]
    public required string Bedrijfsnaam { get; set; }
    [Required(ErrorMessage = "AansprekingContactpersoon is een verplicht veld")]
    public required string AansprekingContactpersoon { get; set; }

    public string? KboNummer { get; set; }
    public string? Achtervoegsel { get; set; } // bv. BV, NV, VOF, ...




    // Bestaand veld na bezoek Tom
    public int BtwTariefId { get; set; }
    public ICollection<Offerte> Offertes { get; set; }
}