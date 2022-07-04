using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CarModelsController : ControllerBase
{
    private ApplicationContext db = new ApplicationContext();

    [HttpGet]
    public JsonResult Get()
    {
        return new JsonResult(db.CarModels.ToList());
    }

    [HttpPost]
    public JsonResult Post()
    {
        return new JsonResult("Work was successfully done");
    }

    [HttpPut]
    public JsonResult Put(CarModel temp)
    {
        bool success = true;
        var carModel = db.CarModels.FirstOrDefault(m => m.Id == temp.Id);
        try
        {
            if (carModel != null)
            {
                db.CarModels.Update(carModel);
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
        return success ? new JsonResult($"Update successful {carModel.Id}") : new JsonResult("Update was not successful");
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        bool success = true;
        var temp = db.CarModels.FirstOrDefault(p => p.Id == id);

        try
        {
            if (temp != null)
            {
                db.CarModels.Remove(temp);
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