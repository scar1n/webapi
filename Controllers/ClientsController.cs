using CarServiceApi.Services;
using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    private IClientsService ClientService { get; set; }
    public ClientsController(IClientsService clientService)
    {
        ClientService = clientService;
    }

    [HttpGet]
    public List<Client> GetAll()
    {
        return ClientService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(Client client)
    {
        return await ClientService.Create(client);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(Client client)
    {
        return await ClientService.Update(client);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await ClientService.Delete(Id);
    }
}