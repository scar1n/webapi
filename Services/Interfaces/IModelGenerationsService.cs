using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface IModelGenerationsService
    {
        public Task<string> Create(ModelGeneration modelGeneration);
        public List<ModelGeneration> ReadAll();
        public Task<string> Update(ModelGeneration modelGeneration);
        public Task<string> Delete(int id);
    }
}