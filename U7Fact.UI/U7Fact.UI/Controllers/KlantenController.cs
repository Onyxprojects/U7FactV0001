using Microsoft.AspNetCore.Mvc;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services;
using U7Fact.Services.Contracts;

namespace U7Fact.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KlantenController : Controller
{
    
    private readonly IKlantService _klantenService;

    public KlantenController(IKlantService klantenService)
    {
        _klantenService = klantenService;
    }

    // GET api/Klanten
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var klanten = await _klantenService.GetAsync();
        return Ok(klanten);
    }

    // GET api/Klanten/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var klant = await _klantenService.GetAsync(id);
        if (klant == null)
            return NotFound($"Klant met ID {id} niet gevonden.");

        return Ok(klant);
    }
    
    // POST api/Klanten
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Klant klant)
    {
        if (klant == null)
            return BadRequest("Klantgegevens zijn verplicht.");

        var nieuweKlant = await _klantenService.AddAsync(klant);
        return CreatedAtAction(nameof(Get), new { id = nieuweKlant.Id }, nieuweKlant);
    }

    // PUT api/Klanten/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Klant klant)
    {
        if (klant == null)
            return BadRequest("Klantgegevens zijn verplicht.");

        if (id != klant.Id)
            return BadRequest("Id in URL en klant-id komen niet overeen.");

        var updatedKlant = await _klantenService.UpdateAsync(klant);
        return Ok(updatedKlant);
    }

    // DELETE api/Klanten/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var bestaandeKlant = await _klantenService.GetAsync(id);
        if (bestaandeKlant == null)
            return NotFound($"Klant met ID {id} niet gevonden.");

        await _klantenService.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("laatste-klantnummer")]
    public async Task<ActionResult<int>> GetLaatsteKlantnummer()
    {
        var laatsteNummer = await _klantenService.GetLaatsteKlantnummer();
        return Ok(laatsteNummer);
    }
}