using System.Net.Http.Json;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.UI.Client.Services;

public class ParticuliereKlantHttpService: IParticuliereKlantService
{
    private readonly HttpClient _httpClient;

    public ParticuliereKlantHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ParticuliereKlant>> GetAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<ParticuliereKlant>>("/api/ParticuliereKlanten");
        return result ?? [];
    }

    public Task<ParticuliereKlant?> GetAsync(int id)
    {
        return _httpClient.GetFromJsonAsync<ParticuliereKlant>($"/api/ParticuliereKlanten/{id}");
    }

    public Task AddAsync(ParticuliereKlant particuliereKlant)
    {
        return _httpClient.PostAsJsonAsync("/api/ParticuliereKlanten", particuliereKlant);
    }

    public Task UpdateAsync(ParticuliereKlant particuliereKlant)
    {
        return _httpClient.PutAsJsonAsync("/api/ParticuliereKlanten", particuliereKlant);
    }
    // Toevoegen van delete methode
    public Task DeleteAsync(int id)
    {
        return _httpClient.DeleteAsync($"/api/ParticuliereKlanten/{id}");
    }
}