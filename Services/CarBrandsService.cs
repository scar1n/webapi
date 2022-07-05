using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class CarBrandsService : ICarBrandsService
    {
        private ApplicationContext Context { get; set; }

        public CarBrandsService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(CarBrand carBrand)
        {
            bool success = true;
            try
            {
                Context.CarBrands.Add(carBrand);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {carBrand.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var carBrand = Context.CarBrands.FirstOrDefault(p => p.Id == id);
            try
            {
                if (carBrand != null)
                {
                    Context.CarBrands.Remove(carBrand);
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

        public List<CarBrand> ReadAll()
        {
            return Context.CarBrands.ToList();
        }

        public async Task<string> Update(CarBrand carBrand)
        {
            bool success = true;
            var brand = Context.CarBrands.FirstOrDefault(m => m.Id == carBrand.Id);
            try
            {
                if (brand != null)
                {
                    Context.CarBrands.Update(carBrand);
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
            return success ? $"Update successful {brand.Id}" : "Update was not successful";
        }
    }
}