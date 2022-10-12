using System.Collections.Generic;
using System.Linq;
using Dapper01.Data;
using Dapper01.Models;
using Microsoft.EntityFrameworkCore;

namespace Dapper01.Repository
{
    public interface ICompanyRepository
    {
        Company Find(int id);
        List<Company> GetAll();
        Company Add(Company company);
        Company Update(Company company);
        void Remove(int id);
    }


    internal class CompanyRepository :ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company Find(int id)
        {

            return _dbContext.Companies.Single(x => x.CompanyId == id);
        }

        public List<Company> GetAll()
        {
            return _dbContext.Companies.ToList();
        }

        public Company Add(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
            return company;
            
        }

        public Company Update(Company company)
        {
            var companys = _dbContext.Companies.Single(x => x.CompanyId == company.CompanyId);
            _dbContext.Update(company);
            _dbContext.SaveChanges();

            return companys;
        }

        public void Remove(int id)
        {
            var company =   _dbContext.Companies.Single(x => x.CompanyId == id);
            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();

        }
    }




}