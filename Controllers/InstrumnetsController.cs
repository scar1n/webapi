using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class InstrumentsController : ControllerBase
{
    private IInstrumentsService InstrumentsService { get; set; }
    public InstrumentsController(IInstrumentsService instrumentsService)
    {
        InstrumentsService = instrumentsService;
    }

    [HttpGet]
    public List<Instrument> GetAll()
    {
        return InstrumentsService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(Instrument instrument)
    {
        return await InstrumentsService.Create(instrument);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(Instrument instrument)
    {
        return await InstrumentsService.Update(instrument);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await InstrumentsService.Delete(Id);
    }
}
