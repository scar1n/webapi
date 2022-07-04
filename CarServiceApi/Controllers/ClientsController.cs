using CarServiceApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    private IClientCarService ClientCarActions { get; set; }
    private ApplicationContext db = new ApplicationContext();
    public ClientsController(IClientCarService clientCarService)
    {
        ClientCarActions = clientCarService;
    }

    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(db.Clients.ToList());
    }

    [HttpPost]
    public JsonResult Post()
    {
        ClientCarActions.Add();
        return new JsonResult("Work was successfully done");
    }

    [HttpPut]
    public JsonResult Put(ClientCar cc)
    {
        bool success = true;
        var client = db.Clients.FirstOrDefault(m => m.Id == cc.Id);
        try
        {
            if (client != null)
            {
                db.Clients.Update(client);
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
        return success ? new JsonResult($"Update successful {client.Id}") : new JsonResult("Update was not successful");
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool success = true;
        var client = db.Clients.FirstOrDefault(p => p.Id == id);

        try
        {
            if (client != null)
            {
                db.Clients.Remove(client);
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