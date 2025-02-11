using Microsoft.EntityFrameworkCore;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.Services;

public class FactuurService: IFactuurService
{
    private readonly DataContext _context;

    public FactuurService(DataContext context)
    {
        _context = context;
    }

    public async Task<Offerte?> GetOfferteByIdAsync(int id)
    {
        return await _context.Offertes
            .FirstOrDefaultAsync(o => o.Id == id); // Haalt de offerte op aan de hand van het ID
    }

    // Alle facturen opvragen
    public Task<List<Factuur>> GetAsync()
    {
        return _context.Facturen.ToListAsync();
    }

    // Een bepaalde factuur opvragen ahv de Id
    public Task<Factuur?> GetAsync(int id)
    {
        return _context.Facturen.FirstOrDefaultAsync(x => x.Id == id);
    }

    // Factuur toevoegen
    public async Task<Factuur> AddAsync(Factuur factuur)
    {
        if (factuur.KlantId == null)
        {
            throw new ArgumentException("Een factuur moet aan een particuliere klant of een bedrijfsklant gekoppeld zijn.");
        }

        await _context.AddAsync(factuur);
        await _context.SaveChangesAsync();
        return factuur; // ✅ Moet factuur retourneren
    }

    // Factuur updaten
    public async Task<Factuur> UpdateAsync(Factuur factuur)
    {
        var dbFactuur = await _context.Facturen.FirstOrDefaultAsync(x => x.Id == factuur.Id);

        if (dbFactuur == null)
            throw new KeyNotFoundException($"Factuur met ID {factuur.Id} niet gevonden.");

        _context.Entry(dbFactuur).CurrentValues.SetValues(factuur);
        await _context.SaveChangesAsync();

        return dbFactuur;  // ✅ Moet een factuur retourneren
    }

    // Toevoegen van delete methode voor offertes
    public async Task DeleteAsync(int id)
    {
        var factuur = await _context.Facturen.FirstOrDefaultAsync(x => x.Id == id);
        if (factuur != null)
        {
            _context.Facturen.Remove(factuur);
            await _context.SaveChangesAsync();
        }
    }
}