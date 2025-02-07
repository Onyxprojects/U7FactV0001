using Microsoft.EntityFrameworkCore;
using U7Fact.Data.ModelBuilders;
using U7Fact.Model;

namespace U7Fact.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<ParticuliereKlant> ParticuliereKlanten { get; set; }
    public DbSet<BedrijfsKlant> BedrijfsKlanten { get; set; }
    public DbSet<Offerte> Offertes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        RelatieModelConfiguration.AddModelConfigToBuilder(modelBuilder);
        BedrijfsKlantModelConfiguration.AddModelConfigToBuilder(modelBuilder);
        ParticuliereKlantModelConfiguration.AddModelConfigToBuilder(modelBuilder);
        OfferteModelConfiguration.AddModelConfigToBuilder(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }
}