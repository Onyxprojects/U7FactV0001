using U7Fact.Model;

namespace U7Fact.Services.Contracts;

public interface IFactuurService
{
    Task<List<Factuur>> GetAsync();
    Task<Factuur?> GetAsync(int id);
    Task<Factuur> AddAsync(Factuur factuur); // ✅ Moet factuur retourneren
    Task<Factuur> UpdateAsync(Factuur factuur); // Retourneert de factuur
    Task DeleteAsync(int id);

    Task<Offerte?> GetOfferteByIdAsync(int id);
}