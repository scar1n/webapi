using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface IClientsService
    {
        public Task<string> Create(Client client);
        public List<Client> ReadAll();
        public Task<string> Update(Client client);
        public Task<string> Delete(int id);
    }
}