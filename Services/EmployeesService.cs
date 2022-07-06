using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class EmployeesService : IEmployeesService
    {
        private ApplicationContext Context { get; set; }

        public EmployeesService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(Employee employee)
        {
            bool success = true;
            try
            {
                Context.Employees.Add(employee);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? $"Create successful {employee.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var employee = Context.Employees.FirstOrDefault(p => p.Id == id);
            try
            {
                if (employee != null)
                {
                    Context.Employees.Remove(employee);
                    await Context.SaveChangesAsync();
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
                throw new Exception("NotFoundException");
            }
            return success ? "Delete successful" : "Delete was not successful";
        }

        public List<Employee> ReadAll()
        {
            return Context.Employees.ToList();
        }

        public async Task<string> Update(Employee employee)
        {
            bool success = true;
            var empl = Context.Employees.FirstOrDefault(m => m.Id == employee.Id);
            try
            {
                if (empl != null)
                {
                    Context.Employees.Update(employee);
                    await Context.SaveChangesAsync();
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
                throw new Exception("NotFoundException");
            }
            return success ? $"Update successful {empl.Id}" : "Update was not successful";
        }
    }
}