using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class Offerte
{
    // Code Tom
    public int Id { get; set; }
    [Required(ErrorMessage = "Beschrijving is een verplicht veld")]// Van dit veld zou ik graag Omschrijving maken en het niet lager verplicht maken!!
    public required string Beschrijving { get; set; }

    // Aangemaakt door Jeroen
    [Required(ErrorMessage = "Referentie is een verplicht veld")]
    public string? Referentie { get; set; }
    public DateTime OfferteDatum { get; set; } // datum van aanmaak
    public DateTime? VerzendDatum { get; set; } // datum waarop de offerte verzonden is
    public int? Geldigheidsduur { get; set; } // in dagen
    public string? Verzendmetode { get; set; } // bv. e-mail, post, ... (Later zou deze info uit een lijst moeten komen AlgemeneInstellingen)
    public string? InterneNotitie { get; set; }
    public string? LosseBijlage { get; set; } // Hier is het de bedoeling dat per offerte een bijlage (pdf bestand, Word bestand, ....) kan toegevoegd worden (of meerdere?)

    // Code Tom (navigation properties)
    
    public int? KlantId { get; set; }
    public Klant? Klant { get; set; }
}