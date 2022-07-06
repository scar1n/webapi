using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CompletedServicesController : ControllerBase
{
    private ICompletedServicesService CompletedServicesService { get; set; }
    public CompletedServicesController(ICompletedServicesService completedServicesService)
    {
        CompletedServicesService = completedServicesService;
    }

    [HttpGet]
    public List<CompletedService> GetAll()
    {
        return CompletedServicesService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(CompletedService completedService)
    {
        return await CompletedServicesService.Create(completedService);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(CompletedService completedService)
    {
        return await CompletedServicesService.Update(completedService);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await CompletedServicesService.Delete(Id);
    }
}
