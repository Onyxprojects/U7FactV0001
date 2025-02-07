using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public abstract class Relatie
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Voornaam is een verplicht veld")]
    public required string Voornaam { get; set; }
    [Required(ErrorMessage = "Achternaam is een verplicht veld")]
    public required string Achternaam { get; set; }
    // Toegevoegd na bezoek Tom
    
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
}