using Microsoft.EntityFrameworkCore;
using U7Fact.Model;

namespace U7Fact.Data.ModelBuilders;

public static class FactuurModelConfiguration
{
    public static void AddModelConfigToBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Factuur>()
            .HasOne(x => x.ParticuliereKlant)
            .WithMany(x => x.Facturen)
            .HasForeignKey(x => x.ParticuliereKlantId)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<Factuur>()
            .HasOne(x => x.BedrijfsKlant)
            .WithMany(x => x.Facturen)
            .HasForeignKey(x => x.BedrijfsKlantId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}