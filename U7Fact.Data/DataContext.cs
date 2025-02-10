using Microsoft.EntityFrameworkCore;
using U7Fact.Data.ModelBuilders;
using U7Fact.Model;

namespace U7Fact.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Klant> Klanten { get; set; }
    public DbSet<ParticuliereKlant> ParticuliereKlanten { get; set; }
    public DbSet<BedrijfsKlant> BedrijfsKlanten { get; set; }
    public DbSet<Offerte> Offertes { get; set; }
    public DbSet<Factuur> Facturen { get; set; } //Jeroen

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        OfferteModelConfiguration.AddModelConfigToBuilder(modelBuilder);
        FactuurModelConfiguration.AddModelConfigToBuilder(modelBuilder); //Jeroen
        KlantModelConfiguration.AddModelConfigToBuilder(modelBuilder);
        ParticuliereKlantModelConfiguration.AddModelConfigToBuilder(modelBuilder);
        BedrijfsKlantModelConfiguration.AddModelConfigToBuilder(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
}