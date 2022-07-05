using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface ICarBrandsService
    {
        public Task<string> Create(CarBrand carBrand);
        public List<CarBrand> ReadAll();
        public Task<string> Update(CarBrand carBrand);
        public Task<string> Delete(int id);
    }
}