using demo.BLL.Services.Departments;
using demo.DAL.Presistence.Data;
using demo.DAL.Presistence.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(
                contextLifetime:ServiceLifetime.Scoped,
                optionsLifetime:ServiceLifetime.Scoped,
                optionsAction: (optionsBuilder) =>
                {
                    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                }
                );


            //builder.Services.AddScoped<AppDbContext>();
            //builder.Services.AddScoped<DbContextOptions<AppDbContext>>((ServiceProvider) =>
            //{
            //    var optionbuilder = new DbContextOptionsBuilder<AppDbContext>();
            //    optionbuilder.UseSqlServer("");
            //    var options = optionbuilder.Options;
            //    return options;

            //});
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>(); //allow dependancy injection for deprepo
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
