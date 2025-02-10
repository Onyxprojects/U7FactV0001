using Microsoft.EntityFrameworkCore;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.Services;

public class KlantService: IKlantService
{
    private readonly DataContext _context;

    public KlantService(DataContext context)
    {
        _context = context;
    }
    // Alle klantgegevens opvragen
    public Task<List<Klant>> GetAsync()
    {
        return _context.Klanten.ToListAsync();
    }

    // Alle klantgegevens opvragen ahv de Id
    public Task<Klant?> GetAsync(int id)
    {
        return _context.Klanten
            .Include(k => k.Offertes)
            .Include(k => k.Facturen)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    // Offertes opvragen die aan een bepaalde klant vastvrangen
    public Task<List<Offerte>> GetOffertesVoorKlantAsync(int klantId)
    {
        return _context.Offertes
            .Where(o => o.ParticuliereKlantId == klantId)
            .ToListAsync();
    }

    // Klant toevoegen
    public async Task<Klant> AddAsync(Klant klant)
    {
        // Bepaal het volgende klantnummer
        int laatsteNummer = await _context.Klanten
            .OrderByDescending(k => k.Id)
            .Select(k => (int?)int.Parse(k.Klantnummer!.Substring(2))) // Verwijdert "K-" en zet om naar int
            .FirstOrDefaultAsync() ?? 10000; // Start vanaf 10000 als er geen klanten zijn

        klant.Klantnummer = $"K-{laatsteNummer + 1}"; // Nieuwe klant krijgt +1
        await _context.AddAsync(klant);
        await _context.SaveChangesAsync();
        return klant; // ✅ Moet klant retourneren
    }

    // Klant updaten
    public async Task<Klant> UpdateAsync(Klant klant)
    {
        var dbklant = await _context.Klanten.FirstOrDefaultAsync(x => x.Id == klant.Id);

        if (dbklant == null)
            throw new KeyNotFoundException($"Klant met ID {klant.Id} niet gevonden.");

        _context.Entry(dbklant).CurrentValues.SetValues(klant);
        await _context.SaveChangesAsync();

        return dbklant;  // ✅ Moet een klant retourneren
    }

    // Toevoegen van delete methode
    public async Task DeleteAsync(int id)
    {
        var klant = await _context.Klanten.FirstOrDefaultAsync(x => x.Id == id);
        if (klant != null)
        {
            _context.Klanten.Remove(klant);
            await _context.SaveChangesAsync();
        }
    }

    // Klantnummer genereren
    public async Task<int> GetLaatsteKlantnummer()
    {
        var laatsteKlant = await _context.Klanten
            .OrderByDescending(k => k.Id)
            .Select(k => k.Klantnummer)
            .FirstOrDefaultAsync();

        if (string.IsNullOrEmpty(laatsteKlant))
        {
            return 10000; // Start bij 10000 als er nog geen klanten zijn
        }

        // Haal het numerieke deel op door "K-" te verwijderen
        if (int.TryParse(laatsteKlant.Substring(2), out int laatsteNummer))
        {
            return laatsteNummer;
        }

        throw new InvalidOperationException("Ongeldig klantnummer formaat in de database.");
    }

}