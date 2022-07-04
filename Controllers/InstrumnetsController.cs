using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


[ApiController]
[Route("[controller]")]
public class InstrumentsController : ControllerBase
{
    private ApplicationContext db = new ApplicationContext();

    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(db.Instruments.ToList());
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
        var instrument = db.Instruments.FirstOrDefault(m => m.Id == temp.Id);
        try
        {
            if (instrument != null)
            {
                db.Instruments.Update(instrument);
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
        return success ? new JsonResult($"Update successful {instrument.Id}") : new JsonResult("Update was not successful");
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool success = true;
        var instrument = db.Instruments.FirstOrDefault(p => p.Id == id);

        try
        {
            if (instrument != null)
            {
                db.Instruments.Remove(instrument);
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
