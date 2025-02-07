using U7Fact.Model;

namespace U7Fact.Services.Contracts;

public interface IParticuliereKlantService
{
    Task<List<ParticuliereKlant>> GetAsync();
    Task<ParticuliereKlant?> GetAsync(int id);
    Task AddAsync(ParticuliereKlant particuliereKlant);
    Task UpdateAsync(ParticuliereKlant particuliereKlant);
    Task DeleteAsync(int id); // Toevoegen van delete methode
}