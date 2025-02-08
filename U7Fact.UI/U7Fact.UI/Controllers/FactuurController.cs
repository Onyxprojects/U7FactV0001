using Microsoft.AspNetCore.Mvc;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services;
using U7Fact.Services.Contracts;

namespace U7Fact.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FactuurController : Controller
{
    private readonly IFactuurService _facturenService;

    public FactuurController(IFactuurService factuurService)
    {
        _facturenService = factuurService;
    }

    // GET api/Facturen
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var facturen = await _facturenService.GetAsync();
        return Ok(facturen);
    }

    // GET api/Facturen/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var factuur = await _facturenService.GetAsync(id);
        if (factuur == null)
            return NotFound($"Factuur met ID {id} niet gevonden.");

        return Ok(factuur);
    }
    
    // POST api/Facturen
    //[HttpPost]
    //public async Task<IActionResult> Post([FromBody] Factuur factuur)
    //{
    //    if (factuur == null)
    //        return BadRequest("Factuurgegevens zijn verplicht.");

    //    var nieuweFactuur = await _facturenService.AddAsync(factuur);
    //    return CreatedAtAction(nameof(Get), new { id = nieuweFactuur.Id }, nieuweFactuur);
    //}

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Factuur factuur)
    {
        if (factuur == null)
            return BadRequest("Factuurgegevens zijn verplicht.");

        if (factuur.OfferteId != null)
        {
            var offerte = await _facturenService.GetOfferteByIdAsync(factuur.OfferteId.Value);
            if (offerte == null)
                return BadRequest("De opgegeven offerte bestaat niet.");
        }

        await _facturenService.AddAsync(factuur);
        return CreatedAtAction(nameof(Get), new { id = factuur.Id }, factuur);
    }


    // PUT api/Facturen/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Factuur factuur)
    {
        if (factuur == null)
            return BadRequest("Factuurgegevens zijn verplicht.");

        if (id != factuur.Id)
            return BadRequest("Id in URL en factuur-id komen niet overeen.");

        var updatedFactuur = await _facturenService.UpdateAsync(factuur);
        return Ok(updatedFactuur);
    }

    // DELETE api/Offertes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var bestaandeFactuur = await _facturenService.GetAsync(id);
        if (bestaandeFactuur == null)
            return NotFound($"Factuur met ID {id} niet gevonden.");

        await _facturenService.DeleteAsync(id);
        return NoContent();
    }        
}