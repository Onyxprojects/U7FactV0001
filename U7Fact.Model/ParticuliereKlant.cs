using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class ParticuliereKlant: Relatie
{
    [Required(ErrorMessage = "Aanspreking is een verplicht veld")]
    public required string Aanspreking { get; set; }
    public ICollection<Offerte> Offertes { get; set; }
}