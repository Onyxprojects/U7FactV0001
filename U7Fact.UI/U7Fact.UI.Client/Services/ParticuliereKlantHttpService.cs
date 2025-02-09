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
        return result ?? new List<ParticuliereKlant>(); // Zorgt voor een lege lijst als de response null is
    }

    public Task<ParticuliereKlant?> GetAsync(int id)
    {
        return _httpClient.GetFromJsonAsync<ParticuliereKlant>($"/api/ParticuliereKlanten/{id}");
    }

    // AddAsync moet een Task<ParticuliereKlant> retourneren zoals gedefinieerd in de interface
    public async Task<ParticuliereKlant> AddAsync(ParticuliereKlant particuliereKlant)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/ParticuliereKlanten", particuliereKlant);
        if (response.IsSuccessStatusCode)
        {
            // De toegevoegde klant wordt teruggegeven
            return await response.Content.ReadFromJsonAsync<ParticuliereKlant>();
        }
        else
        {
            throw new Exception("Er is een fout opgetreden bij het toevoegen van de klant.");
        }
    }

    public async Task<ParticuliereKlant> UpdateAsync(ParticuliereKlant particuliereKlant)
    {
        var response = await _httpClient.PutAsJsonAsync("/api/ParticuliereKlanten", particuliereKlant);
        if (response.IsSuccessStatusCode)
        {
            // De bijgewerkte klant wordt teruggegeven
            return await response.Content.ReadFromJsonAsync<ParticuliereKlant>();
        }
        else
        {
            throw new Exception("Er is een fout opgetreden bij het bijwerken van de klant.");
        }
    }
    // Toevoegen van delete methode
    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/api/ParticuliereKlanten/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Er is een fout opgetreden bij het verwijderen van de klant.");
        }
    }
}