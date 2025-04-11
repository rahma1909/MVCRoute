using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Presistence.Repositories.Departments;
using demo.DAL.Presistence.Repositories.Employees;

namespace demo.DAL.Presistence.UnitOfWork
{
    public interface IUnitOfWork
    {

        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get;  }
        int Complete();
        void Dispose();

        
    }
}
