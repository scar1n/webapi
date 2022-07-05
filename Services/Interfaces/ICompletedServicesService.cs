using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface ICompletedServicesService
    {
        public Task<string> Create(CompletedService completedService);
        public List<CompletedService> ReadAll();
        public Task<string> Update(CompletedService completedService);
        public Task<string> Delete(int id);
    }
}