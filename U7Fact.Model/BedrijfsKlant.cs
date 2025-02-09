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

    // Indien een extra contactpersoon moet worden toegevoegd, kan dit hier
    public string? ExtraAanspreking { get; set; }
    public string? ExtraVoornaam { get; set; }
    public string? ExtraAchternaam { get; set; }
    public string? ExtraEmail { get; set; }
    public string? ExtraTelefoonnummer { get; set; }
    public string? ExtraGsmnummer { get; set; }


    // Bestaand veld na bezoek Tom
    //public int BtwTariefId { get; set; }
    public ICollection<Offerte> Offertes { get; set; }
    public ICollection<Factuur> Facturen { get; set; } // Hier zullen alle facturen van deze klant in komen
}