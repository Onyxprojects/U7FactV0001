using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class Factuur
{
    // Code Tom
    public int Id { get; set; }

    public string? FactuurNummer { get; set; } // Dit is een uniek nummer dat automatisch wordt aangemaakt

    public string? Referentie { get; set; }
    [Required]
    public FactuurType Type { get; set; } // Voorschotfactuur, Slotfactuur, LosFactuur, Creditnota
    public enum FactuurType
        {
            Voorschotfactuur, // Dit is een factuur die aan een offerte is gekoppeld
            Slotfactuur, // Dit is een factuur die aan een offerte is gekoppeld
            LosFactuur, // Dit is een factuur die niet aan een offerte is gekoppeld
            Creditnota // Dit is een factuur die een negatief bedrag heeft
        }
    [Required(ErrorMessage = "Is een verplicht veld")]
    public DateTime FactuurDatum { get; set; } // datum van aanmaak
    public DateTime? VerzendDatum { get; set; } // datum waarop het factuur verzonden is
    public int? Betalingstermijn { get; set; } // in dagen
    public string? Verzendmetode { get; set; } // bv. e-mail, post, ... (Later zou deze info uit een lijst moeten komen AlgemeneInstellingen)
    public string? InterneNotitie { get; set; }
    public string? LosseBijlage { get; set; } // Hier is het de bedoeling dat per offerte een bijlage (pdf bestand, Word bestand, ....) kan toegevoegd worden (of meerdere?)
    

    // Code Tom (navigation properties)
            
    public int? KlantId { get; set; }
    public Klant? Klant { get; set; }

    public int? OfferteId { get; set; }
    public Offerte? Offerte { get; set; }
}