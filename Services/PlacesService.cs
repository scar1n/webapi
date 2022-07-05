using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class PlacesService : IPlacesService
    {
        private ApplicationContext Context { get; set; }

        public PlacesService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(Place place)
        {
            bool success = true;
            try
            {
                Context.Places.Add(place);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {place.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var place = Context.Places.FirstOrDefault(p => p.Id == id);
            try
            {
                if (place != null)
                {
                    Context.Places.Remove(place);
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

        public List<Place> ReadAll()
        {
            return Context.Places.ToList();
        }

        public async Task<string> Update(Place place)
        {
            bool success = true;
            var plac = Context.Places.FirstOrDefault(m => m.Id == place.Id);
            try
            {
                if (plac != null)
                {
                    Context.Places.Update(place);
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
            return success ? $"Update successful {plac.Id}" : "Update was not successful";
        }
    }
}