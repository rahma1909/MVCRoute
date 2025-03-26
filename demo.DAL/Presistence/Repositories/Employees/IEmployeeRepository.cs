using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Entities.Departments;
using demo.DAL.Entities.Employeees;
using demo.DAL.Presistence.Repositories._Generic;

namespace demo.DAL.Presistence.Repositories.Employees
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
       
    }
}
