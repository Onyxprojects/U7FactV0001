using Microsoft.AspNetCore.Mvc;
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
}