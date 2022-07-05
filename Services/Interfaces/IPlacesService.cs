using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface IPlacesService
    {
        public Task<string> Create(Place place);
        public List<Place> ReadAll();
        public Task<string> Update(Place place);
        public Task<string> Delete(int id);
    }
}