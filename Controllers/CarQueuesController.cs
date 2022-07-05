//using CarServiceApi.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Linq;

//[ApiController]
//[Route("[controller]")]
//public class CarQueueController : ControllerBase
//{
//    private IClientCarsService ClientCarActions { get; set; }

//    public CarQueueController(IClientCarsService clientCarService)
//    {
//        ClientCarActions = clientCarService;
//    }

//    [HttpGet]
//    public JsonResult Get()
//    {
//        return new JsonResult(db.CarQueues.ToList());
//    }

//    [HttpPost]
//    public JsonResult Post()
//    {
//        return new JsonResult("Work was successfully done");
//    }

//    [HttpPut]
//    public JsonResult Put(CarQueue cq)
//    {
//        bool success = true;
//        var carQueue = db.CarQueues.FirstOrDefault(m => m.Id == cq.Id);
//        try
//        {
//            if (carQueue != null)
//            {
//                db.CarQueues.Update(carQueue);
//            }
//            else
//            {
//                success = false;
//            }
//        }
//        catch (Exception)
//        {
//            success = false;
//        }
//        db.SaveChanges();
//        return success ? new JsonResult($"Update successful {carQueue.Id}") : new JsonResult("Update was not successful");
//    }

//    [HttpDelete]
//    public JsonResult Delete(int id)
//    {
//        bool success = true;
//        var car = db.CarQueues.FirstOrDefault(p => p.Id == id);

//        try
//        {
//            if (car != null)
//            {
//                db.CarQueues.Remove(car);
//            }
//            else
//            {
//                success = false;
//            }
//        }
//        catch (Exception)
//        {
//            success = false;
//        }

//        return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
//    }
//}