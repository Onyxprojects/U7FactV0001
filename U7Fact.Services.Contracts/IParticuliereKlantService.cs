using U7Fact.Model;

namespace U7Fact.Services.Contracts;

public interface IParticuliereKlantService
{
    Task<List<ParticuliereKlant>> GetAsync();
    Task<ParticuliereKlant?> GetAsync(int id);
    Task<ParticuliereKlant> AddAsync(ParticuliereKlant particuliereKlant); // ✅ Moet klant retourneren
    Task<ParticuliereKlant> UpdateAsync(ParticuliereKlant particuliereKlant); // Retourneert de klant
    Task DeleteAsync(int id);
}