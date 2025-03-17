using demo.BLL.DTOs.Department;
using demo.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;

namespace demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;

        private readonly IWebHostEnvironment _enviroment;

        //[FromServices]
        //public IDepartmentService DepartmentService { get; } = null!;

        //========
        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger,IWebHostEnvironment enviroment)
        {
            _departmentService = departmentService;
            _logger = logger;
            _enviroment = enviroment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View("Index",departments);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(CreatedDepartmentToRetrunDto departmentDto)
        {
            var message = string.Empty;
            if (!ModelState.IsValid)
                return View(departmentDto);

            try
            {
                var result = _departmentService.CreateDepartment(departmentDto);

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Department is not created");
                return View(departmentDto);
            }
            catch (Exception ex)
            {

                //1.log for exception
                _logger.LogError(ex, ex.Message);
                //2.set massege
                if (_enviroment.IsDevelopment())
                {
                    
                    message = ex.Message;
                    return View(departmentDto);
                }
                else
                {

                    message = "department is not created";
                    return View("Error", message);
                }
            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            
                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();
            return View(department);
        }
    }
}
