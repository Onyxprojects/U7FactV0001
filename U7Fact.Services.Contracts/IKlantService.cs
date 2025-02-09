using U7Fact.Model;

namespace U7Fact.Services.Contracts;

public interface IKlantService
{
    Task<List<Klant>> GetAsync();
    Task<Klant?> GetAsync(int id);
    Task<Klant> AddAsync(Klant klant); // ✅ Moet klant retourneren
    Task<Klant> UpdateAsync(Klant klant); // Retourneert de klant
    Task DeleteAsync(int id);
}