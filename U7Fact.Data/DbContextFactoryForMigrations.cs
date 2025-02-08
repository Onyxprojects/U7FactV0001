using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace U7Fact.Data;

public class DbContextFactoryForMigrations: IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=U7Fact;Trusted_Connection=True;Encrypt=False");

        return new DataContext(optionsBuilder.Options);
    }
}