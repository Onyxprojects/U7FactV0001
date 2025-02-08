using Microsoft.EntityFrameworkCore;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.Services;

public class OfferteService: IOfferteService
{
    private readonly DataContext _context;

    public OfferteService(DataContext context)
    {
        _context = context;
    }
    // Alle offertes opvragen
    public Task<List<Offerte>> GetAsync()
    {
        return _context.Offertes.ToListAsync();
    }

    // Een bepaalde offerte opvragen ahv de Id
    public Task<Offerte?> GetAsync(int id)
    {
        return _context.Offertes.FirstOrDefaultAsync(x => x.Id == id);
    }

    // Offerte toevoegen
    public async Task<Offerte> AddAsync(Offerte offerte)
    {
        await _context.AddAsync(offerte);
        await _context.SaveChangesAsync();
        return offerte; // ✅ Moet offerte retourneren
    }

    // Offerte updaten
    public async Task<Offerte> UpdateAsync(Offerte offerte)
    {
        var dbOfferte = await _context.Offertes.FirstOrDefaultAsync(x => x.Id == offerte.Id);

        if (dbOfferte == null)
            throw new KeyNotFoundException($"Offerte met ID {offerte.Id} niet gevonden.");

        _context.Entry(dbOfferte).CurrentValues.SetValues(offerte);
        await _context.SaveChangesAsync();

        return dbOfferte;  // ✅ Moet een offerte retourneren
    }

    // Toevoegen van delete methode voor offertes
    public async Task DeleteAsync(int id)
    {
        var offerte = await _context.Offertes.FirstOrDefaultAsync(x => x.Id == id);
        if (offerte != null)
        {
            _context.Offertes.Remove(offerte);
            await _context.SaveChangesAsync();
        }
    }
}