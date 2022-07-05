using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface IServicesService
    {
        public Task<string> Create(Service service);
        public List<Service> ReadAll();
        public Task<string> Update(Service service);
        public Task<string> Delete(int id);
    }
}