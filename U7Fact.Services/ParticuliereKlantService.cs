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

    public Task<List<ParticuliereKlant>> GetAsync()
    {
        return _context.ParticuliereKlanten.ToListAsync();
    }

    // Oude methode voor het ophalen van een klant
    public Task<ParticuliereKlant?> GetAsync(int id)
    {
        return _context.ParticuliereKlanten.FirstOrDefaultAsync(x => x.Id == id);
    }

    // Nieuwe methode voor het ophalen van een klant met inladen van offertes
    //public Task<ParticuliereKlant?> GetAsync(int id)
    //{
    //    // Offertes worden hier mee ingeladen (IS DIT EEN GOED IDEE OF MOET HIER EEN ANDERE SERVICE VOOR WORDEN GEBRUIKT?)
    //    return _context.ParticuliereKlanten
    //        .Include(x => x.Offertes)
    //        .FirstOrDefaultAsync(x => x.Id == id);
    //}

    public async Task<ParticuliereKlant> AddAsync(ParticuliereKlant particuliereKlant)
    {
        await _context.AddAsync(particuliereKlant);
        await _context.SaveChangesAsync();
        return particuliereKlant; // ✅ Moet klant retourneren
    }

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