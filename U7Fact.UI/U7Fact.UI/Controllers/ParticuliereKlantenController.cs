using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticuliereKlantenController : Controller
{
    private readonly IParticuliereKlantService _particuliereKlantenService;

    // Toegevoegd voor delete methode
    private readonly DataContext _context;

    public ParticuliereKlantenController(IParticuliereKlantService particuliereKlantenService)
    {
        _particuliereKlantenService = particuliereKlantenService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_particuliereKlantenService.GetAsync());
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_particuliereKlantenService.GetAsync(id));
    }
    
    [HttpPost]
    public IActionResult Post(ParticuliereKlant klant)
    {
        return Ok(_particuliereKlantenService.AddAsync(klant));
    }
    
    [HttpPut("{id}")]
    public IActionResult Get(int id, ParticuliereKlant klant)
    {
        return Ok(_particuliereKlantenService.UpdateAsync(klant));
    }


    // Toevoegen van delete methode iov ChatGPT
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var klant = await _context.ParticuliereKlanten.FirstOrDefaultAsync(x => x.Id == id);
        if (klant == null)
        {
            return NotFound();
        }

        _context.ParticuliereKlanten.Remove(klant);
        await _context.SaveChangesAsync();
        return NoContent(); // Successfully deleted
    }

}