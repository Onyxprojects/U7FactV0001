using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public abstract class Relatie
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Voornaam is een verplicht veld")]
    public required string Voornaam { get; set; }
    [Required(ErrorMessage = "Achternaam is een verplicht veld")]
    public required string Achternaam { get; set; }

}