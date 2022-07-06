using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface ICarQueuesService
    {
        public Task<string> Create(CarQueue carQueue);
        public List<CarQueue> ReadAll();
        public Task<string> Update(CarQueue carQueue);
        public Task<string> Delete(int id);
    }
}