using Microsoft.AspNetCore.Mvc;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfferteController : Controller
{
    private readonly IOfferteService _offertesService;

    public OfferteController(IOfferteService offerteService)
    {
        _offertesService = offerteService;
    }

    // GET api/Offertes
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var offertes = await _offertesService.GetAsync();
        return Ok(offertes);
    }

    // GET api/Offertes/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var offerte = await _offertesService.GetAsync(id);
        if (offerte == null)
            return NotFound($"Offerte met ID {id} niet gevonden.");

        return Ok(offerte);
    }
    
    // POST api/Offertes
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Offerte offerte)
    {
        if (offerte == null)
            return BadRequest("Offertegegevens zijn verplicht.");

        var nieuweOfferte = await _offertesService.AddAsync(offerte);
        return CreatedAtAction(nameof(Get), new { id = nieuweOfferte.Id }, nieuweOfferte);
    }

    // PUT api/Offertes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Offerte offerte)
    {
        if (offerte == null)
            return BadRequest("Offertegegevens zijn verplicht.");

        if (id != offerte.Id)
            return BadRequest("Id in URL en offerte-id komen niet overeen.");

        var updatedOfferte = await _offertesService.UpdateAsync(offerte);
        return Ok(updatedOfferte);
    }

    // DELETE api/Offertes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var bestaandeOfferte = await _offertesService.GetAsync(id);
        if (bestaandeOfferte == null)
            return NotFound($"Offerte met ID {id} niet gevonden.");

        await _offertesService.DeleteAsync(id);
        return NoContent();
    }        
}