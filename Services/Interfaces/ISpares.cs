using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface ISparesService
    {
        public Task<string> Create(Spare spare);
        public List<Spare> ReadAll();
        public Task<string> Update(Spare spare);
        public Task<string> Delete(int id);
    }
}