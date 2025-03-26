using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Common.Enums;
using demo.DAL.Entities.Employeees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.DAL.Presistence.Data.configrations.Employees
{
    internal class EmployeeConfigrations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Address).HasColumnType("varchar(100)");
            builder.Property(e => e.Salary).HasColumnType("decimal(8,2)");

            builder.Property(e => e.Gendar).HasConversion(

                (gender) => gender.ToString(),
                (gender)=>(Gendar)Enum.Parse(typeof(Gendar),gender)
                );

            builder.Property(e => e.EmployeeType).HasConversion(

               (EmployeeType) => EmployeeType.ToString(),
               (EmployeeType) => (EmpType) Enum.Parse(typeof(EmpType), EmployeeType)
               );
            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETDATE()");
        }
    }
}
