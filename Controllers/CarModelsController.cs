using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CarModelsController : ControllerBase
{
    private ICarModelsService CarModelsService { get; set; }
    public CarModelsController(ICarModelsService carModelsService)
    {
        CarModelsService = carModelsService;
    }

    [HttpGet]
    public List<CarModel> GetAll()
    {
        return CarModelsService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(CarModel carModel)
    {
        return await CarModelsService.Create(carModel);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(CarModel carModel)
    {
        return await CarModelsService.Update(carModel);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await CarModelsService.Delete(Id);
    }
}