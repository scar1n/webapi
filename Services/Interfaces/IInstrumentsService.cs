using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface IInstrumentsService
    {
        public Task<string> Create(Instrument instrument);
        public List<Instrument> ReadAll();
        public Task<string> Update(Instrument instrument);
        public Task<string> Delete(int id);
    }
}