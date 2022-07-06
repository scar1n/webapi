using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ServicesController : ControllerBase
{
    private IServicesService ServicesService { get; set; }
    public ServicesController(IServicesService positionsService)
    {
        ServicesService = positionsService;
    }

    [HttpGet]
    public List<Service> GetAll()
    {
        return ServicesService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(Service position)
    {
        return await ServicesService.Create(position);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(Service position)
    {
        return await ServicesService.Update(position);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await ServicesService.Delete(Id);
    }
}
