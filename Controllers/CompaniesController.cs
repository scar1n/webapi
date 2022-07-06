using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CompaniesController : ControllerBase
{
    private ICompaniesService CompaniesService { get; set; }
    public CompaniesController(ICompaniesService companyService)
    {
        CompaniesService = companyService;
    }

    [HttpGet]
    public List<Company> GetAll()
    {
        return CompaniesService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(Company company)
    {
        return await CompaniesService.Create(company);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(Company company)
    {
        return await CompaniesService.Update(company);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await CompaniesService.Delete(Id);
    }
}