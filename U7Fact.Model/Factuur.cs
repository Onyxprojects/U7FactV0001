using System.ComponentModel.DataAnnotations;

namespace U7Fact.Model;

public class Factuur
{
    public int Id { get; set; }

    [Required]
    public string FactuurNummer { get; set; } = string.Empty;

    [Required] 
    public int KlantId { get; set; }

    [Required]
    public DateTime FactuurDatum { get; set; } = DateTime.Now; // datum van aanmaak

    [Required]
    public int? Betalingstermijn{ get; set; } // in dagen

    [Required]
    public FactuurStatus Status { get; set; } = FactuurStatus.Concept;

    public DateTime? VerzendDatum { get; set; } // datum waarop de factuur verzonden is


    // EXTRA VELDEN: Verzendmethode zou afkomstig moeten zijn van AlgemeneInstellingen
    public string? Verzendmethode { get; set; } // bv. e-mail, post, ... (Later zou deze info uit een lijst moeten komen AlgemeneInstellingen)
    public string? InterneNotitie { get; set; }
    //public string? LosseBijlage { get; set; } // Hier is het de bedoeling dat per offerte een bijlage (pdf bestand, Word bestand, ....) kan toegevoegd worden (of meerdere?)
    public List<string>? LosseBijlagen { get; set; }  // Lijst van bijlagen



    // Navigatie
    public List<DocumentRegel> DocumentRegels { get; set; } = new();

    public Klant? Klant { get; set; }

    public enum FactuurStatus
    {
        Concept,
        Verstuurd,
        Betaald        
    }

}