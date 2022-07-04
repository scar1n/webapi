using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


[ApiController]
[Route("[controller]")]
public class CompletedServicesController : ControllerBase
{
    private ApplicationContext db = new ApplicationContext();

    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(db.CompletedServices.ToList());
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
        var service = db.CompletedServices.FirstOrDefault(m => m.Id == temp.Id);
        try
        {
            if (service != null)
            {
                db.CompletedServices.Update(service);
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
        var temp = db.Instruments.FirstOrDefault(p => p.Id == id);

        try
        {
            if (temp != null)
            {
                db.Instruments.Remove(temp);
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
