using CarServiceApi.Services;
using CarServiceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class ClientCarsController : ControllerBase
{
    private IClientCarsService ClientCarActions { get; set; }
    private ApplicationContext db = new ApplicationContext();
    public ClientCarsController(IClientCarsService clientCarService)
    {
        ClientCarActions = clientCarService;
    }

    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(db.ClientCars.ToList());
    }

    [HttpPost]
    public JsonResult Post()
    {
        return new JsonResult("Work was successfully done");
    }

    [HttpPut]
    public JsonResult Put(ClientCar cc)
    {
        bool success = true;
        var clientCar = db.ClientCars.FirstOrDefault(m => m.Id == cc.Id);
        try
        {
            if (clientCar != null)
            {
                 db.ClientCars.Update(clientCar);
            }
            else
            {
                success = false;
            }
        }
        catch (Exception)
        {
            success = false;
        }
        db.SaveChanges();
        return success ? new JsonResult($"Update successful {clientCar.Id}") : new JsonResult("Update was not successful");
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool success = true;
        var car = db.ClientCars.FirstOrDefault(p => p.Id == id);

        try
        {
            if (car != null)
            {
                db.ClientCars.Remove(car);
            }
            else
            {
                success = false;
            }
        }
        catch (Exception)
        {
            success = false;
        }

        return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
    }
}