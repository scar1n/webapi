using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class CarModelsService : ICarModelsService
    {
        private ApplicationContext Context { get; set; }

        public CarModelsService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(CarModel carModel)
        {
            bool success = true;
            try
            {
                Context.CarModels.Add(carModel);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {carModel.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var carModel = Context.CarModels.FirstOrDefault(p => p.Id == id);
            try
            {
                if (carModel != null)
                {
                    Context.CarModels.Remove(carModel);
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
                throw new Exception("NotFoundException");
            }
            return success ? "Delete successful" : "Delete was not successful";
        }

        public List<CarModel> ReadAll()
        {
            return Context.CarModels.ToList();
        }

        public async Task<string> Update(CarModel carModel)
        {
            bool success = true;
            var model = Context.CarModels.FirstOrDefault(m => m.Id == carModel.Id);
            try
            {
                if (model != null)
                {
                    Context.CarModels.Update(carModel);
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
                throw new Exception("NotFoundException");
            }
            return success ? $"Update successful {model.Id}" : "Update was not successful";
        }
    }
}