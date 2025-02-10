using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;


public enum KlantType
{
    Particulier,
    Bedrijf
}

public class Klant

{

    public int Id { get; set; }// Dit is de primary key van de klant

    // Algemeen voor zowel bedrijven als particulieren
    [Required(ErrorMessage = "Voornaam is een verplicht veld")]
    public required string Voornaam { get; set; }
    [Required(ErrorMessage = "Achternaam is een verplicht veld")]
    public required string Achternaam { get; set; }
    public string? Aanspreking { get; set; }
    [Required]
    public string? Klantnummer { get; set; }
    [EmailAddress(ErrorMessage = "Voer een geldig e-mailadres in.")]
    public string? Email { get; set; }
    [RegularExpression(@"^\+?\d{1,4}[-\s]?\(?\d{1,4}\)?[-\s]?\d{6,10}$", ErrorMessage = "Voer een geldig telefoonnummer in.")]
    public string? Telefoonnummer { get; set; }
    [RegularExpression(@"^04[0-9]{8}$", ErrorMessage = "Ongeldig gsm-nummer. Het nummer moet een Belgisch gsm-nummer zijn.")]
    public string? Gsmnummer { get; set; }
    public string? Straatnaam { get; set; }
    [RegularExpression(@"^\d+([a-zA-Z]|\s*\d+)?$", ErrorMessage = "Huisnummer moet een geldig nummer zijn.")]
    public string? Huisnummer { get; set; }
    public string? Bus { get; set; }
    public string? Postcode { get; set; }
    public string? Gemeente { get; set; }
    public string? Land { get; set; }
    public string? InterneNotitie { get; set; }

    // Enum in plaats van string
    [Required(ErrorMessage = "KlantType is een verplicht veld")]
    public KlantType KlantType { get; set; }

    // Velden voor Particuliere klanten
    
    public string? ExtraAanspreking { get; set; }
    public string? ExtraVoornaam { get; set; }
    public string? ExtraAchternaam { get; set; }
    [EmailAddress(ErrorMessage = "Voer een geldig e-mailadres in.")]
    public string? ExtraEmail { get; set; }
    [RegularExpression(@"^\+?\d{1,4}[-\s]?\(?\d{1,4}\)?[-\s]?\d{6,10}$", ErrorMessage = "Voer een geldig telefoonnummer in.")]
    public string? ExtraTelefoonnummer { get; set; }
    [RegularExpression(@"^04[0-9]{8}$", ErrorMessage = "Ongeldig gsm-nummer. Het nummer moet een Belgisch gsm-nummer zijn.")]
    public string? ExtraGsmnummer { get; set; }

    // Velden voor Bedrijfsklanten
    public string? Bedrijfsnaam { get; set; }
    public string? AansprekingContactpersoon { get; set; }
    [RegularExpression(@"^BE\d{10}$", ErrorMessage = "BTW-nummer moet starten met 'BE' gevolgd door 10 cijfers.")]
    public string? BtwNummer { get; set; }
    [RegularExpression(@"^\d{10}$", ErrorMessage = "KBO-nummer moet precies 10 cijfers bevatten.")]
    public string? KboNummer { get; set; }
    public string? Achtervoegsel { get; set; } // bv. BV, NV, VOF, ...

    // Navigation properties
    // Relaties voor Offertes en Facturen
    public ICollection<Offerte> Offertes { get; set; }
    public ICollection<Factuur> Facturen { get; set; }
}