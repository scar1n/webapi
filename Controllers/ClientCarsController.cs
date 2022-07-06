using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ClientCarsController : ControllerBase
{
    private IClientCarsService ClientCarService { get; set; }
    public ClientCarsController(IClientCarsService clientCarService)
    {
        ClientCarService = clientCarService;
    }

    [HttpGet]
    public List<ClientCar> GetAll()
    {
        return ClientCarService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(ClientCar clientCar)
    {
        return await ClientCarService.Create(clientCar);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(ClientCar clientCar)
    {
        return await ClientCarService.Update(clientCar);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await ClientCarService.Delete(Id);
    }
}