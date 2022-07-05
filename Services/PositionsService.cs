using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class PositionsService : IPositionsService
    {
        private ApplicationContext Context { get; set; }

        public PositionsService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(Position position)
        {
            bool success = true;
            try
            {
                Context.Positions.Add(position);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {position.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var position = Context.Positions.FirstOrDefault(p => p.Id == id);
            try
            {
                if (position != null)
                {
                    Context.Positions.Remove(position);
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

        public List<Position> ReadAll()
        {
            return Context.Positions.ToList();
        }

        public async Task<string> Update(Position position)
        {
            bool success = true;
            var plac = Context.Positions.FirstOrDefault(m => m.Id == position.Id);
            try
            {
                if (plac != null)
                {
                    Context.Positions.Update(position);
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