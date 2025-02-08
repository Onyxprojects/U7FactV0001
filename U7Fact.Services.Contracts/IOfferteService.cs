using U7Fact.Model;

namespace U7Fact.Services.Contracts;

public interface IOfferteService
{
    Task<List<Offerte>> GetAsync();
    Task<Offerte?> GetAsync(int id);
    Task<Offerte> AddAsync(Offerte offerte); // ✅ Moet offerte retourneren
    Task<Offerte> UpdateAsync(Offerte offerte); // Retourneert de offerte
    Task DeleteAsync(int id);
}