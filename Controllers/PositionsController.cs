using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PositionsController : ControllerBase
{
    private IPositionsService PositionsService { get; set; }
    public PositionsController(IPositionsService positionsService)
    {
        PositionsService = positionsService;
    }

    [HttpGet]
    public List<Position> GetAll()
    {
        return PositionsService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(Position position)
    {
        return await PositionsService.Create(position);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(Position position)
    {
        return await PositionsService.Update(position);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await PositionsService.Delete(Id);
    }
}