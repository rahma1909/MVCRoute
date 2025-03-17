﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAL.Entities.Departments
{    //dep is a modelbase
    public class Department : ModelBase
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; } 
        public DateOnly CreationDate { get; set; } 
    }
}
