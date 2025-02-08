using Microsoft.EntityFrameworkCore;
using U7Fact.Model;

namespace U7Fact.Data.ModelBuilders;

public static class BedrijfsKlantModelConfiguration
{
    public static void AddModelConfigToBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BedrijfsKlant>()
            .Property(x => x.BtwNummer).IsRequired();
    }
}