using U7Fact.Model;

namespace U7Fact.Services.Contracts;

public interface IBedrijfsKlantService
{
    Task<List<BedrijfsKlant>> GetAsync();
    Task<BedrijfsKlant?> GetAsync(int id);
    Task<BedrijfsKlant> AddAsync(BedrijfsKlant bedrijfsKlant); // ✅ Moet klant retourneren
    Task<BedrijfsKlant> UpdateAsync(BedrijfsKlant bedrijfsKlant); // Retourneert de klant
    Task DeleteAsync(int id);
}