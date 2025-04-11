using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Presistence.Data;
using demo.DAL.Presistence.Repositories.Departments;
using demo.DAL.Presistence.Repositories.Employees;
using Microsoft.EntityFrameworkCore;

namespace demo.DAL.Presistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly AppDbContext _dbContext;

        public IEmployeeRepository EmployeeRepository {
            get { return new EmployeeRepository(_dbContext); }
        }
        public IDepartmentRepository DepartmentRepository {
            get { return new DepartmentRepository(_dbContext); } }

        public int Complete()
        {
           return _dbContext.SaveChanges();
        }

        public void Dispose()
        {

             _dbContext.Dispose();
        }

        public UnitOfWork(AppDbContext dbContext)
        {
           
            _dbContext = dbContext;
        }
    }
}
