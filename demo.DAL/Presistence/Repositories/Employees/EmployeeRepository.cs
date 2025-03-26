using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Entities.Departments;
using demo.DAL.Entities.Employeees;
using demo.DAL.Presistence.Data;
using demo.DAL.Presistence.Repositories._Generic;
using Microsoft.EntityFrameworkCore;

namespace demo.DAL.Presistence.Repositories.Employees
{
    public class EmployeeRepository : GenericRepositotry<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext):base(dbContext)
        {
            
        }

    }
}
