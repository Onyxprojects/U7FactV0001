using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using U7Fact.Model;

namespace U7Fact.Data.ModelBuilders;

public static class KlantModelConfiguration
{
    public static void AddModelConfigToBuilder(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<Klant>();

        entity.Property(x => x.Voornaam).IsRequired();
        entity.Property(x => x.Achternaam).IsRequired();
        entity.Property(x => x.Klantnummer).IsRequired();
        entity.Property(x => x.KlantType)
            .HasConversion<string>() // Enum opslaan als string
            .IsRequired();

        // ✅ Klantnummer uniek maken
        entity.HasIndex(x => x.Klantnummer)
            .IsUnique();

    }
}