using Microsoft.EntityFrameworkCore;
using U7Fact.Model;

namespace U7Fact.Data.ModelBuilders;

public static class OfferteModelConfiguration
{
    public static void AddModelConfigToBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Offerte>()
            .HasOne(x => x.Klant)
            .WithMany(x => x.Offertes)
            .HasForeignKey(x => x.KlantId)
            .OnDelete(DeleteBehavior.SetNull);
        
    }
}