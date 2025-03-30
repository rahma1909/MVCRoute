using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Entities;
using demo.DAL.Entities.Employeees;

namespace demo.DAL.Presistence.Repositories._Generic
{
    public interface IGenericRepository<T> where T:ModelBase
    {
        T? Get(int Id);
        IEnumerable<T> GetAll(bool withAsNoTracking = true);
        IQueryable<T> GetAllQuerable();
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
