using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface ICompaniesService
    {
        public Task<string> Create(Company company);
        public List<Company> ReadAll();
        public Task<string> Update(Company company);
        public Task<string> Delete(int id);
    }
}