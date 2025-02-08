using Microsoft.AspNetCore.Mvc;
using U7Fact.Data;
using U7Fact.Model;
using U7Fact.Services.Contracts;

namespace U7Fact.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticuliereKlantenController : Controller
{
    private readonly IParticuliereKlantService _particuliereKlantenService;

    public ParticuliereKlantenController(IParticuliereKlantService particuliereKlantenService)
    {
        _particuliereKlantenService = particuliereKlantenService;
    }



    //OUDE VERSIE
    //[HttpGet]
    //public IActionResult GetAll()
    //{
    //    return Ok(_particuliereKlantenService.GetAsync());
    //}

    // GET api/ParticuliereKlanten
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var klanten = await _particuliereKlantenService.GetAsync();
        return Ok(klanten);
    }

    // GET api/ParticuliereKlanten/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var klant = await _particuliereKlantenService.GetAsync(id);
        if (klant == null)
            return NotFound($"Klant met ID {id} niet gevonden.");

        return Ok(klant);
    }
    //OUDE VERSIE
    //[HttpGet("{id}")]
    //public IActionResult Get(int id)
    //{
    //    return Ok(_particuliereKlantenService.GetAsync(id));
    //}

    // POST api/ParticuliereKlanten
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ParticuliereKlant klant)
    {
        if (klant == null)
            return BadRequest("Klantgegevens zijn verplicht.");

        var nieuweKlant = await _particuliereKlantenService.AddAsync(klant);
        return CreatedAtAction(nameof(Get), new { id = nieuweKlant.Id }, nieuweKlant);
    }

    //OUDE VERSIE
    //[HttpPost]
    //public IActionResult Post(ParticuliereKlant klant)
    //{
    //    return Ok(_particuliereKlantenService.AddAsync(klant));
    //}

    // PUT api/ParticuliereKlanten/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ParticuliereKlant klant)
    {
        if (klant == null)
            return BadRequest("Klantgegevens zijn verplicht.");

        if (id != klant.Id)
            return BadRequest("Id in URL en klant-id komen niet overeen.");

        var updatedKlant = await _particuliereKlantenService.UpdateAsync(klant);
        return Ok(updatedKlant);
    }

    //OUDE VERSIE
    //[HttpPut("{id}")]// Hier stond Get ipv Put
    //public IActionResult Put(int id, ParticuliereKlant klant)
    //{
    //    return Ok(_particuliereKlantenService.UpdateAsync(klant));
    //}

    // DELETE api/ParticuliereKlanten/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var bestaandeKlant = await _particuliereKlantenService.GetAsync(id);
        if (bestaandeKlant == null)
            return NotFound($"Klant met ID {id} niet gevonden.");

        await _particuliereKlantenService.DeleteAsync(id);
        return NoContent();
    }

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    await _particuliereKlantenService.DeleteAsync(id);
    //    return NoContent();
        
    //}

}