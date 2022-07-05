using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarServiceApi.Services.Interfaces
{
    public interface IEmployeesService
    {
        public Task<string> Create(Employee employee);
        public List<Employee> ReadAll();
        public Task<string> Update(Employee employee);
        public Task<string> Delete(int id);
    }
}