using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class Offerte
{
    public int Id { get; set; }

    [Required]
    public string OfferteNummer { get; set; } = string.Empty;

    [Required] 
    public int KlantId { get; set; }

    [Required]
    public DateTime OfferteDatum { get; set; } = DateTime.Now; // datum van aanmaak

    [Required]
    public int? Geldigheidsduur { get; set; } // in dagen

    [Required]
    public OfferteStatus Status { get; set; } = OfferteStatus.Concept;

    public DateTime? VerzendDatum { get; set; } // datum waarop de offerte verzonden is
                      
    
    // EXTRA VELDEN: Verzendmethode zou afkomstig moeten zijn van AlgemeneInstellingen
    public string? Verzendmethode { get; set; } // bv. e-mail, post, ... (Later zou deze info uit een lijst moeten komen AlgemeneInstellingen)
    public string? InterneNotitie { get; set; }
    //public string? LosseBijlage { get; set; } // Hier is het de bedoeling dat per offerte een bijlage (pdf bestand, Word bestand, ....) kan toegevoegd worden (of meerdere?)
    public List<string>? LosseBijlagen { get; set; }  // Lijst van bijlagen


    // Navigatie
    public List<DocumentRegel> DocumentRegels { get; set; } = new();

    public Klant? Klant { get; set; }

    public enum OfferteStatus
    {
        Concept,
        Verstuurd,
        Goedgekeurd,
        InUitvoering,
        Afgewerkt
    }

}