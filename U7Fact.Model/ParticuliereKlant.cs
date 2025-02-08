using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class ParticuliereKlant: Relatie
{
    // De aanspreking bij particuliere klanten: Dhr., Mevr., Familie, Meester, Juffrouw, ... (Hier moet een dropdown menu van gemaakt worden
    [Required(ErrorMessage = "Aanspreking is een verplicht veld")]
    public required string Aanspreking { get; set; }


    // Indien een extra contactpersoon moet worden toegevoegd, kan dit hier
    public string? ExtraAanspreking { get; set; }
    public string? ExtraVoornaam { get; set; }
    public string? ExtraAchternaam { get; set; }
    public string? ExtraEmail { get; set; }
    public string? ExtraTelefoonnummer { get; set; }
    public string? ExtraGsmnummer { get; set; }

    // Bestond reeds na bezoek Tom
    public ICollection<Offerte> Offertes { get; set; }
    public ICollection<Factuur> Facturen { get; set; } // Hier zullen alle facturen van deze klant in komen
}