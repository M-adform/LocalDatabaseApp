using LocalDatabaseApp.Interfaces;
using LocalDatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class PersonController : ControllerBase
{
    private readonly IDarbuotojasService _darbuotojasService;

    public PersonController(IDarbuotojasService darbuotojasService)
    {
        _darbuotojasService = darbuotojasService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertDarbuotojas([FromBody] Darbuotojas darbuotojas)
    {
        return Ok(_darbuotojasService.InsertDarbuotojas(darbuotojas.Vardas, darbuotojas.Pavarde, darbuotojas.AsmensKodas));
    }

    [HttpPut]
    public async Task<IActionResult> ModifyDarbuotojas([FromForm] Darbuotojas darbuotojas)
    {
        return Ok(_darbuotojasService.ModifyDarbuotojas(darbuotojas.Vardas, darbuotojas.Pavarde, darbuotojas.AsmensKodas));
    }
}