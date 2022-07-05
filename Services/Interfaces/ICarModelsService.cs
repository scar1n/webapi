using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface ICarModelsService
    {
        public Task<string> Create(CarModel carModel);
        public List<CarModel> ReadAll();
        public Task<string> Update(CarModel carModel);
        public Task<string> Delete(int id);
    }
}