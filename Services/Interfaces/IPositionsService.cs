using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface IPositionsService
    {
        public Task<string> Create(Position position);
        public List<Position> ReadAll();
        public Task<string> Update(Position position);
        public Task<string> Delete(int id);
    }
}