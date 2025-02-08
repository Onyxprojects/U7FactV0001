using Microsoft.EntityFrameworkCore;
using U7Fact.Model;

namespace U7Fact.Data.ModelBuilders;

public static class OfferteModelConfiguration
{
    public static void AddModelConfigToBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Offerte>()
            .HasOne(x => x.ParticuliereKlant)
            .WithMany(x => x.Offertes)
            .HasForeignKey(x => x.ParticuliereKlantId)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<Offerte>()
            .HasOne(x => x.BedrijfsKlant)
            .WithMany(x => x.Offertes)
            .HasForeignKey(x => x.BedrijfsKlantId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}