using System.Net.Http.Json;
using U7Fact.Model;
using U7Fact.Services.Contracts;
using static System.Net.WebRequestMethods;

namespace U7Fact.UI.Client.Services;

public class KlantHttpService: IKlantService
{
    private readonly HttpClient _httpClient;

    public KlantHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Klant>> GetAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Klant>>("/api/Klanten");
        return result ?? new List<Klant>(); // Zorgt voor een lege lijst als de response null is
    }

    public Task<Klant?> GetAsync(int id)
    {
        return _httpClient.GetFromJsonAsync<Klant>($"/api/Klanten/{id}");
    }

    // AddAsync moet een Task<Klant> retourneren zoals gedefinieerd in de interface
    public async Task<Klant> AddAsync(Klant klant)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/Klanten", klant);
        if (response.IsSuccessStatusCode)
        {
            // De toegevoegde klant wordt teruggegeven
            return await response.Content.ReadFromJsonAsync<Klant>();
        }
        else
        {
            throw new Exception("Er is een fout opgetreden bij het toevoegen van de klant.");
        }
    }

    public async Task<Klant> UpdateAsync(Klant klant)
    {
        var response = await _httpClient.PutAsJsonAsync("/api/Klanten", klant);
        if (response.IsSuccessStatusCode)
        {
            // De bijgewerkte klant wordt teruggegeven
            return await response.Content.ReadFromJsonAsync<Klant>();
        }
        else
        {
            throw new Exception("Er is een fout opgetreden bij het bijwerken van de klant.");
        }
    }
    // Toevoegen van delete methode
    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/api/Klanten/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Er is een fout opgetreden bij het verwijderen van de klant.");
        }
    }

    // 
    public async Task<int> GetLaatsteKlantnummer()
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<int>("api/klanten/laatste-klantnummer");
            return result;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error fetching last klantnummer: {ex.Message}");
            return 10000; // Default if there is an error
        }
    }
}