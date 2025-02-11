using Microsoft.EntityFrameworkCore;
using U7Fact.Model;

namespace U7Fact.Data.ModelBuilders;

public static class FactuurModelConfiguration
{
    public static void AddModelConfigToBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Factuur>()
            .HasOne(x => x.Klant)
            .WithMany(x => x.Facturen)
            .HasForeignKey(x => x.KlantId)
            .OnDelete(DeleteBehavior.SetNull);
        
    }
}