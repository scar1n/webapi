using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


[ApiController]
[Route("[controller]")]
public class PositionsController : ControllerBase
{
    private ApplicationContext db = new ApplicationContext();

    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(db.Positions.ToList());
    }

    [HttpPost]
    public JsonResult Post()
    {
        return new JsonResult("Work was successfully done");
    }

    [HttpPut]
    public JsonResult Put(CompletedService temp)
    {
        bool success = true;
        var pos = db.Positions.FirstOrDefault(m => m.Id == temp.Id);
        try
        {
            if (pos != null)
            {
                db.Positions.Update(pos);
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
        return success ? new JsonResult($"Update successful {pos.Id}") : new JsonResult("Update was not successful");
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool success = true;
        var temp = db.Positions.FirstOrDefault(p => p.Id == id);

        try
        {
            if (temp != null)
            {
                db.Positions.Remove(temp);
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