using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CarBrandsController : ControllerBase
{
    private ICarBrandsService CarBrandsService { get; set; }
    public CarBrandsController(ICarBrandsService carBrandsService)
    {
        CarBrandsService = carBrandsService;
    }

    [HttpGet]
    public List<CarBrand> GetAll()
    {
        return CarBrandsService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(CarBrand carBrand)
    {
        return await CarBrandsService.Create(carBrand);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(CarBrand carBrand)
    {
        return await CarBrandsService.Update(carBrand);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await CarBrandsService.Delete(Id);
    }
}