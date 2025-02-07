using U7Fact.Model;

namespace U7Fact.Services.Contracts;

public interface IBedrijfsKlantService
{
    Task<List<BedrijfsKlant>> GetAsync();
    Task<BedrijfsKlant?> GetAsync(int id);
    Task AddAsync(BedrijfsKlant bedrijfsKlant);
}