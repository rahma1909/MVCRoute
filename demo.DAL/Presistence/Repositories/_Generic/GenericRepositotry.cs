using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Entities;
using demo.DAL.Entities.Departments;
using demo.DAL.Presistence.Data;
using Microsoft.EntityFrameworkCore;

namespace demo.DAL.Presistence.Repositories._Generic
{
    public class GenericRepositotry<T> where T:ModelBase
    {

        private readonly AppDbContext _dbContext;

        public GenericRepositotry(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public T? Get(int Id)
        {
            //var department = _dbContext.Departments.Local.FirstOrDefault((d) => d.Id == Id);
            //if(department == null)
            //{
            //    department = _dbContext.Departments.FirstOrDefault((d) => d.Id == Id);
            //}
            //return department;


            return _dbContext.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
            {
                return _dbContext.Set<T>().AsNoTracking().ToList();
            }
            return _dbContext.Set<T>().ToList();
        }

        public IQueryable<T> GetAllQuerable()
        {
            return _dbContext.Set<T>();
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
}
