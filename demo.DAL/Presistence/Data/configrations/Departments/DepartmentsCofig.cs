using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Entities.Departments;
using demo.DAL.Entities.Employeees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.DAL.Presistence.Data.configrations.Departments

{
    internal class DepartmentsCofig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(d => d.Code).HasColumnType("varchar(50)").IsRequired();
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");

            builder.HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
