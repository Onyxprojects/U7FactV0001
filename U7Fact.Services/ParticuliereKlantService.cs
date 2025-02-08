using Microsoft.EntityFrameworkCore;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.Services;

public class ParticuliereKlantService: IParticuliereKlantService
{
    private readonly DataContext _context;

    public ParticuliereKlantService(DataContext context)
    {
        _context = context;
    }
    // Alle klantgegevens opvragen
    public Task<List<ParticuliereKlant>> GetAsync()
    {
        return _context.ParticuliereKlanten.ToListAsync();
    }

    // Alle klantgegevens opvragen ahv de Id
    public Task<ParticuliereKlant?> GetAsync(int id)
    {
        return _context.ParticuliereKlanten.FirstOrDefaultAsync(x => x.Id == id);
    }

    // Offertes opvragen die aan een bepaalde klant vasthangen
    public Task<List<Offerte>> GetOffertesVoorKlantAsync(int klantId)
    {
        return _context.Offertes
            .Where(o => o.ParticuliereKlantId == klantId)
            .ToListAsync();
    }

    // Klant toevoegen
    public async Task<ParticuliereKlant> AddAsync(ParticuliereKlant particuliereKlant)
    {
        await _context.AddAsync(particuliereKlant);
        await _context.SaveChangesAsync();
        return particuliereKlant; // ✅ Moet klant retourneren
    }

    // Klant updaten
    public async Task<ParticuliereKlant> UpdateAsync(ParticuliereKlant particuliereKlant)
    {
        var dbKlant = await _context.ParticuliereKlanten.FirstOrDefaultAsync(x => x.Id == particuliereKlant.Id);

        if (dbKlant == null)
            throw new KeyNotFoundException($"Klant met ID {particuliereKlant.Id} niet gevonden.");

        _context.Entry(dbKlant).CurrentValues.SetValues(particuliereKlant);
        await _context.SaveChangesAsync();

        return dbKlant;  // ✅ Moet een klant retourneren
    }

    // Toevoegen van delete methode
    public async Task DeleteAsync(int id)
    {
        var klant = await _context.ParticuliereKlanten.FirstOrDefaultAsync(x => x.Id == id);
        if (klant != null)
        {
            _context.ParticuliereKlanten.Remove(klant);
            await _context.SaveChangesAsync();
        }
    }
}