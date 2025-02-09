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
        return _context.Klanten.FirstOrDefaultAsync(x => x.Id == id);
    }

    // Offertes opvragen die aan een bepaalde klant vasthangen
    public Task<List<Offerte>> GetOffertesVoorKlantAsync(int klantId)
    {
        return _context.Offertes
            .Where(o => o.ParticuliereKlantId == klantId)
            .ToListAsync();
    }

    // Klant toevoegen
    public async Task<Klant> AddAsync(Klant klant)
    {
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
}