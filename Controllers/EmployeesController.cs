using CarServiceApi.Services;
using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private IEmployeesService EmployeesService { get; set; }
    public EmployeesController(IEmployeesService employeeService)
    {
        EmployeesService = employeeService;
    }

    [HttpGet]
    public List<Employee> GetAll()
    {
        return EmployeesService.ReadAll();
    }

    [HttpPost]
    public async Task<ActionResult<string>> Create(Employee employee)
    {
        return await EmployeesService.Create(employee);
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(Employee employee)
    {
        return await EmployeesService.Update(employee);
    }

    [HttpDelete("Delete/{Id}")]
    public async Task<ActionResult<string>> Delete(int Id)
    {
        return await EmployeesService.Delete(Id);
    }
}