using CarServiceApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceApi.Services
{
    public class CompaniesService : ICompaniesService
    {
        private ApplicationContext Context { get; set; }

        public CompaniesService(ApplicationContext db)
        {
            Context = db;
        }

        public async Task<string> Create(Company company)
        {
            bool success = true;
            try
            {
                Context.Companies.Add(company);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                success = false;
                throw new Exception("NotFoundException");
            }
            return success ? $"Create successful {company.Id}" : "Create was not successful";
        }

        public async Task<string> Delete(int id)
        {
            bool success = true;
            var company = Context.Companies.FirstOrDefault(p => p.Id == id);
            try
            {
                if (company != null)
                {
                    Context.Companies.Remove(company);
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

        public List<Company> ReadAll()
        {
            return Context.Companies.ToList();
        }

        public async Task<string> Update(Company company)
        {
            bool success = true;
            var compan = Context.Companies.FirstOrDefault(m => m.Id == company.Id);
            try
            {
                if (compan != null)
                {
                    Context.Companies.Update(company);
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
            return success ? $"Update successful {compan.Id}" : "Update was not successful";
        }
    }
}