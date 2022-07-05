using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class CompletedServicesService : ICompletedServicesService
    {
        private ApplicationContext Context { get; set; }

        public CompletedServicesService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(CompletedService completedService)
        {
            bool success = true;
            try
            {
                Context.CompletedServices.Add(completedService);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {completedService.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var completedService = Context.CompletedServices.FirstOrDefault(p => p.Id == id);
            try
            {
                if (completedService != null)
                {
                    Context.CompletedServices.Remove(completedService);
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

        public List<CompletedService> ReadAll()
        {
            return Context.CompletedServices.ToList();
        }

        public async Task<string> Update(CompletedService completedService)
        {
            bool success = true;
            var comService = Context.CompletedServices.FirstOrDefault(m => m.Id == completedService.Id);
            try
            {
                if (comService != null)
                {
                    Context.CompletedServices.Update(completedService);
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
            return success ? $"Update successful {comService.Id}" : "Update was not successful";
        }
    }
}