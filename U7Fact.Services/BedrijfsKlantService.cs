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

    public Task<List<BedrijfsKlant>> GetAsync()
    {
        return _context.BedrijfsKlanten.ToListAsync();
    }

    // Oude methode voor het ophalen van een klant
    //public Task<ParticuliereKlant?> GetAsync(int id)
    //{
    //    return _context.ParticuliereKlanten.FirstOrDefaultAsync(x => x.Id == id);
    //}

    // Nieuwe methode voor het ophalen van een klant met inladen van offertes
    public Task<BedrijfsKlant?> GetAsync(int id)
    {
        // Offertes worden hier mee ingeladen (IS DIT EEN GOED IDEE OF MOET HIER EEN ANDERE SERVICE VOOR WORDEN GEBRUIKT?)
        return _context.BedrijfsKlanten
            .Include(x => x.Offertes)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(BedrijfsKlant bedrijfsKlant)
    {
        await _context.AddAsync(bedrijfsKlant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BedrijfsKlant bedrijfsKlant)
    {
        var dbKlant = await _context.BedrijfsKlanten.FirstAsync(x => x.Id == bedrijfsKlant.Id);
        _context.Entry(dbKlant).CurrentValues.SetValues(bedrijfsKlant);
        await _context.SaveChangesAsync();
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