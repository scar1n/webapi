using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class ClientsService : IClientsService
    {
        private ApplicationContext Context { get; set; }

        public ClientsService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(Client client)
        {
            bool success = true;
            try
            {
                Context.Clients.Add(client);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {client.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var client = Context.Clients.FirstOrDefault(p => p.Id == id);
            try
            {
                if (client != null)
                {
                    Context.Clients.Remove(client);
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

        public List<Client> ReadAll()
        {
            return Context.Clients.ToList();
        }

        public async Task<string> Update(Client client)
        {
            bool success = true;
            var clnt = Context.Clients.FirstOrDefault(m => m.Id == client.Id);
            try
            {
                if (clnt != null)
                {
                    Context.Clients.Update(client);
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