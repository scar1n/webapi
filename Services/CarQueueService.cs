using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class CarQueueService : ICarQueueService
    {
        private ApplicationContext Context { get; set; }

        public CarQueueService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(CarQueue carQueue)
        {
            bool success = true;
            try
            {
                Context.CarQueues.Add(carQueue);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {carQueue.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var carQueue = Context.CarQueues.FirstOrDefault(p => p.Id == id);
            try
            {
                if (carQueue != null)
                {
                    Context.CarQueues.Remove(carQueue);
                    await Context.SaveChangesAsync();
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
            return success ? "Delete successful" : "Delete was not successful";
        }

        public List<CarQueue> ReadAll()
        {
            return Context.CarQueues.ToList();
        }

        public async Task<string> Update(CarQueue carQueue)
        {
            bool success = true;
            var queue = Context.CarQueues.FirstOrDefault(m => m.Id == carQueue.Id);
            try
            {
                if (queue != null)
                {
                    Context.CarQueues.Update(carQueue);
                    await Context.SaveChangesAsync();
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
            return success ? $"Update successful {queue.Id}" : "Update was not successful";
        }
    }
}