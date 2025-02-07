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

    public Task<BedrijfsKlant?> GetAsync(int id)
    {
        return _context.BedrijfsKlanten.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(BedrijfsKlant bedrijfsKlant)
    {
        await _context.AddAsync(bedrijfsKlant);
        await _context.SaveChangesAsync();
    }
}