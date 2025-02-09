using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public abstract class Klant
{
    public int Id { get; set; }// Dit is de primary key van de klant

    // Algemeen voor zowel bedrijven als particulieren
    [Required(ErrorMessage = "Voornaam is een verplicht veld")]
    public required string Voornaam { get; set; }
    [Required(ErrorMessage = "Achternaam is een verplicht veld")]
    public required string Achternaam { get; set; }
    
    
    public string? Klantnummer { get; set; }
    public string? Email { get; set; }
    public string? Telefoonnummer { get; set; }
    public string? Gsmnummer { get; set; }
    public string? Straatnaam { get; set; }
    public string? Huisnummer { get; set; }
    public string? Bus { get; set; }
    public string? Postcode { get; set; }
    public string? Gemeente { get; set; }
    public string? Land { get; set; }
    public string? InterneNotitie { get; set; }

    // KlantType bepaalt of het een particulier of een bedrijf is
    [Required(ErrorMessage = "KlantType is een verplicht veld")]
    public required string KlantType { get; set; } // "Particulier" of "Bedrijf"

    // Velden voor Particuliere klanten
    public string? Aanspreking { get; set; }
    public string? ExtraAanspreking { get; set; }
    public string? ExtraVoornaam { get; set; }
    public string? ExtraAchternaam { get; set; }
    public string? ExtraEmail { get; set; }
    public string? ExtraTelefoonnummer { get; set; }
    public string? ExtraGsmnummer { get; set; }

    // Velden voor Bedrijfsklanten
    public string? Bedrijfsnaam { get; set; }
    public string? BtwNummer { get; set; }
    public string? AansprekingContactpersoon { get; set; }
    public string? KboNummer { get; set; }
    public string? Achtervoegsel { get; set; } // bv. BV, NV, VOF, ...

    // Navigation properties
    // Relaties voor Offertes en Facturen
    public ICollection<Offerte> Offertes { get; set; }
    public ICollection<Factuur> Facturen { get; set; }
}