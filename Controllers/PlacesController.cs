using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PlacesController : ControllerBase
{
    private IPlacesService PlacesService { get; set; }
    public PlacesController(IPlacesService placesService)
    {
        PlacesService = placesService;
    }

    [HttpGet]
    public List<Place> GetAll()
    {
        return PlacesService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(Place place)
    {
        return await PlacesService.Create(place);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(Place place)
    {
        return await PlacesService.Update(place);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await PlacesService.Delete(Id);
    }
}
