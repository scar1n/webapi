using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class InstrumentsService : IInstrumentsService
    {
        private ApplicationContext Context { get; set; }

        public InstrumentsService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(Instrument instrument)
        {
            bool success = true;
            try
            {
                Context.Instruments.Add(instrument);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {instrument.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var instrument = Context.Instruments.FirstOrDefault(p => p.Id == id);
            try
            {
                if (instrument != null)
                {
                    Context.Instruments.Remove(instrument);
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

        public List<Instrument> ReadAll()
        {
            return Context.Instruments.ToList();
        }

        public async Task<string> Update(Instrument instrument)
        {
            bool success = true;
            var clnt = Context.Instruments.FirstOrDefault(m => m.Id == instrument.Id);
            try
            {
                if (clnt != null)
                {
                    Context.Instruments.Update(instrument);
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
            return success ? $"Update successful {clnt.Id}" : "Update was not successful";
        }
    }
}