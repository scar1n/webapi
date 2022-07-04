using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


[ApiController]
[Route("[controller]")]
public class SparesController : ControllerBase
{
    private ApplicationContext db = new ApplicationContext();

    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(db.Spares.ToList());
    }

    [HttpPost]
    public JsonResult Post()
    {
        return new JsonResult("Work was successfully done");
    }

    [HttpPut]
    public JsonResult Put(Instrument temp)
    {
        bool success = true;
        var service = db.Spares.FirstOrDefault(m => m.Id == temp.Id);
        try
        {
            if (service != null)
            {
                db.Spares.Update(service);
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
        return success ? new JsonResult($"Update successful {service.Id}") : new JsonResult("Update was not successful");
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool success = true;
        var temp = db.Services.FirstOrDefault(p => p.Id == id);

        try
        {
            if (temp != null)
            {
                db.Services.Remove(temp);
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
