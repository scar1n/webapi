using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CarQueuesController : ControllerBase
{
    private ICarQueuesService CarQueuesService { get; set; }
    public CarQueuesController(ICarQueuesService carQueuesService)
    {
        CarQueuesService = carQueuesService;
    }

    [HttpGet]
    public List<CarQueue> GetAll()
    {
        return CarQueuesService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(CarQueue carQueue)
    {
        return await CarQueuesService.Create(carQueue);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(CarQueue carQueue)
    {
        return await CarQueuesService.Update(carQueue);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await CarQueuesService.Delete(Id);
    }
}