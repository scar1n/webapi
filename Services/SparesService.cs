using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class SparesService : ISparesService
    {
        private ApplicationContext Context { get; set; }

        public SparesService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(Spare spare)
        {
            bool success = true;
            try
            {
                Context.Spares.Add(spare);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {spare.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var spare = Context.Spares.FirstOrDefault(p => p.Id == id);
            try
            {
                if (spare != null)
                {
                    Context.Spares.Remove(spare);
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

        public List<Spare> ReadAll()
        {
            return Context.Spares.ToList();
        }

        public async Task<string> Update(Spare spare)
        {
            bool success = true;
            var spar = Context.Spares.FirstOrDefault(m => m.Id == spare.Id);
            try
            {
                if (spar != null)
                {
                    Context.Spares.Update(spare);
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
            return success ? $"Update successful {spar.Id}" : "Update was not successful";
        }
    }
}