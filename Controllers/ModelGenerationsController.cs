using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class ModelGenerationsController : ControllerBase
{
    private IModelGenerationsService ModelGenerationsService { get; set; }
    public ModelGenerationsController(IModelGenerationsService modelGenerationsService)
    {
        ModelGenerationsService = modelGenerationsService;
    }

    [HttpGet]
    public List<ModelGeneration> GetAll()
    {
        return ModelGenerationsService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(ModelGeneration modelGeneration)
    {
        return await ModelGenerationsService.Create(modelGeneration);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(ModelGeneration modelGeneration)
    {
        return await ModelGenerationsService.Update(modelGeneration);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await ModelGenerationsService.Delete(Id);
    }
}

