using Microsoft.AspNetCore.Mvc;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BedrijfsKlantControler : Controller
{
    private readonly IBedrijfsKlantService _bedrijfsKlantenService;

    public BedrijfsKlantControler(IBedrijfsKlantService bedrijfsKlantenService)
    {
        _bedrijfsKlantenService = bedrijfsKlantenService;
    }

    // GET api/BedrijfsKlanten
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var klanten = await _bedrijfsKlantenService.GetAsync();
        return Ok(klanten);
    }

    // GET api/BedrijfsKlanten/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var klant = await _bedrijfsKlantenService.GetAsync(id);
        if (klant == null)
            return NotFound($"Klant met ID {id} niet gevonden.");

        return Ok(klant);
    }
    
    // POST api/BedrijfsKlanten
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BedrijfsKlant klant)
    {
        if (klant == null)
            return BadRequest("Klantgegevens zijn verplicht.");

        var nieuweKlant = await _bedrijfsKlantenService.AddAsync(klant);
        return CreatedAtAction(nameof(Get), new { id = nieuweKlant.Id }, nieuweKlant);
    }

    // PUT api/BedrijfsKlanten/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] BedrijfsKlant klant)
    {
        if (klant == null)
            return BadRequest("Klantgegevens zijn verplicht.");

        if (id != klant.Id)
            return BadRequest("Id in URL en klant-id komen niet overeen.");

        var updatedKlant = await _bedrijfsKlantenService.UpdateAsync(klant);
        return Ok(updatedKlant);
    }

    // DELETE api/BedrijfsKlanten/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var bestaandeKlant = await _bedrijfsKlantenService.GetAsync(id);
        if (bestaandeKlant == null)
            return NotFound($"Klant met ID {id} niet gevonden.");

        await _bedrijfsKlantenService.DeleteAsync(id);
        return NoContent();
    }        
}