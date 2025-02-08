using Microsoft.EntityFrameworkCore;
using U7Fact.Model;

namespace U7Fact.Data.ModelBuilders;

public static class ParticuliereKlantModelConfiguration
{
    public static void AddModelConfigToBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParticuliereKlant>()
            .Property(x => x.Aanspreking).IsRequired();
    }
}