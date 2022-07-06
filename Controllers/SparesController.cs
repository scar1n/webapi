using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class SparesController : ControllerBase
{
    private ISparesService SparesService { get; set; }
    public SparesController(ISparesService sparesService)
    {
        SparesService = sparesService;
    }

    [HttpGet]
    public List<Spare> GetAll()
    {
        return SparesService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(Spare spare)
    {
        return await SparesService.Create(spare);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(Spare spare)
    {
        return await SparesService.Update(spare);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await SparesService.Delete(Id);
    }
}
