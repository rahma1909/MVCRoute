using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Entities.Departments;

namespace demo.DAL.Presistence.Repositories.Departments
{
    public interface IDepartmentRepository
    {
       Department? Get(int Id);
      IEnumerable<Department>  GetAll(bool withAsNoTracking = true);
      IQueryable<Department>  GetAllQuerable();
     int   Add(Department entity);
     int   Update(Department entity);
     int   Delete(Department entity);

    }
}
