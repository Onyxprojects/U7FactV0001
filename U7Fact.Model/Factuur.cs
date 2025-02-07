using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class Factuur

    // Aangemaakt door Jeroen
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Beschrijving is een verplicht veld")]
    public required string Beschrijving { get; set; }
    public int? BedrijfsKlantId { get; set; }
    public BedrijfsKlant? BedrijfsKlant { get; set; }
    public int? ParticuliereKlantId { get; set; }
    public ParticuliereKlant? ParticuliereKlant { get; set; }
}