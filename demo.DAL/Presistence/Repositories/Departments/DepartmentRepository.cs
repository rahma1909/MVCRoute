using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Entities.Departments;
using demo.DAL.Presistence.Data;
using Microsoft.EntityFrameworkCore;

namespace demo.DAL.Presistence.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();        }

        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public Department? Get(int Id)
        {
            //var department = _dbContext.Departments.Local.FirstOrDefault((d) => d.Id == Id);
            //if(department == null)
            //{
            //    department = _dbContext.Departments.FirstOrDefault((d) => d.Id == Id);
            //}
            //return department;


            return _dbContext.Departments.Find(Id);
        }

        public IEnumerable<Department> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }
           return _dbContext.Departments.ToList();
        }

        public IQueryable<Department> GetAllQuerable()
        {
            return _dbContext.Departments; 
        }

        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
