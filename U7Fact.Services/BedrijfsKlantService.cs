using Microsoft.EntityFrameworkCore;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.Services;

public class BedrijfsKlantService: IBedrijfsKlantService
{
    private readonly DataContext _context;

    public BedrijfsKlantService(DataContext context)
    {
        _context = context;
    }

    // Alle klantgegevens opvragen
    public Task<List<BedrijfsKlant>> GetAsync()
    {
        return _context.BedrijfsKlanten.ToListAsync();
    }

    // Alle klantgegevens opvragen ahv de Id
    public Task<BedrijfsKlant?> GetAsync(int id)
    {
        return _context.BedrijfsKlanten.FirstOrDefaultAsync(x => x.Id == id);
    }

    // Offertes opvragen die aan een bepaalde klant vasthangen
    public Task<List<Offerte>> GetOffertesVoorBedrijfsKlantAsync(int klantId)
    {
        return _context.Offertes
            .Where(o => o.BedrijfsKlantId == klantId)
            .ToListAsync();
    }

    // Klant toevoegen
    public async Task<BedrijfsKlant> AddAsync(BedrijfsKlant bedrijfsKlant)
    {
        await _context.AddAsync(bedrijfsKlant);
        await _context.SaveChangesAsync();
        return bedrijfsKlant; // ✅ Moet klant retourneren
    }

    // Klant updaten
    public async Task<BedrijfsKlant> UpdateAsync(BedrijfsKlant bedrijfsKlant)
    {
        var dbBedrijfsKlant = await _context.BedrijfsKlanten.FirstOrDefaultAsync(x => x.Id == bedrijfsKlant.Id);

        if (dbBedrijfsKlant == null)
            throw new KeyNotFoundException($"Klant met ID {bedrijfsKlant.Id} niet gevonden.");

        _context.Entry(dbBedrijfsKlant).CurrentValues.SetValues(bedrijfsKlant);
        await _context.SaveChangesAsync();

        return dbBedrijfsKlant;  // ✅ Moet een klant retourneren
    }

    // Toevoegen van delete methode
    public async Task DeleteAsync(int id)
    {
        var klant = await _context.BedrijfsKlanten.FirstOrDefaultAsync(x => x.Id == id);
        if (klant != null)
        {
            _context.BedrijfsKlanten.Remove(klant);
            await _context.SaveChangesAsync();
        }
    }
}