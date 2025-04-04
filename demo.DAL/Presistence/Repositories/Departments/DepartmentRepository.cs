﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Entities.Departments;
using demo.DAL.Presistence.Data;
using demo.DAL.Presistence.Repositories._Generic;
using Microsoft.EntityFrameworkCore;

namespace demo.DAL.Presistence.Repositories.Departments
{
    public class DepartmentRepository : GenericRepositotry<Department>,IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbcontext):base(dbcontext)
        {
            
        }
    }
}
