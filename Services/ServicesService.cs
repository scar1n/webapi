using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class ServicesService : IServicesService
    {
        private ApplicationContext Context { get; set; }

        public ServicesService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(Service service)
        {
            bool success = true;
            try
            {
                Context.Services.Add(service);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {service.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var service = Context.Services.FirstOrDefault(p => p.Id == id);
            try
            {
                if (service != null)
                {
                    Context.Services.Remove(service);
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

        public List<Service> ReadAll()
        {
            return Context.Services.ToList();
        }

        public async Task<string> Update(Service service)
        {
            bool success = true;
            var servic = Context.Services.FirstOrDefault(m => m.Id == service.Id);
            try
            {
                if (servic != null)
                {
                    Context.Services.Update(service);
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
            return success ? $"Update successful {servic.Id}" : "Update was not successful";
        }
    }
}