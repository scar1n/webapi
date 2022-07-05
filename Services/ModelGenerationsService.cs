using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class ModelGenerationsService : IModelGenerationsService
    {
        private ApplicationContext Context { get; set; }

        public ModelGenerationsService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(ModelGeneration modelGeneration)
        {
            bool success = true;
            try
            {
                Context.ModelGenerations.Add(modelGeneration);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {modelGeneration.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var modelGeneration = Context.ModelGenerations.FirstOrDefault(p => p.Id == id);
            try
            {
                if (modelGeneration != null)
                {
                    Context.ModelGenerations.Remove(modelGeneration);
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

        public List<ModelGeneration> ReadAll()
        {
            return Context.ModelGenerations.ToList();
        }

        public async Task<string> Update(ModelGeneration modelGeneration)
        {
            bool success = true;
            var comService = Context.ModelGenerations.FirstOrDefault(m => m.Id == modelGeneration.Id);
            try
            {
                if (comService != null)
                {
                    Context.ModelGenerations.Update(modelGeneration);
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