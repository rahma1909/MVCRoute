using demo.BLL.DTOs.Department;
using demo.BLL.DTOs.Employee;
using demo.BLL.Services.Departments;
using demo.BLL.Services.Employees;

using demo.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;
namespace demo.PL.Controllers

{
    public class EmployeeController:Controller
    {
        #region Services
        private readonly IEmployeeService _employeeService;
        //private readonly IEmployeeService employeeService;
        private readonly ILogger<DepartmentController> _logger;

        private readonly IWebHostEnvironment _enviroment;

        //[FromServices]
        //public IEmployeeServiceDepartmentService { get; } = null!;

        //========
        public EmployeeController(IEmployeeService employeeService, ILogger<DepartmentController> logger, IWebHostEnvironment enviroment)
        {
           
            _employeeService = employeeService;
            _logger = logger;
            _enviroment = enviroment;
        }
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View("Index", employees);
        }
        #endregion

        #region Create
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedEmployeeDto employeedto)
        {
            var message = string.Empty;
            if (!ModelState.IsValid)
                return View(employeedto);

            try
            {
                var result = _employeeService.CreateEmployee(employeedto);

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "employee is not created");
                return View(employeedto);
            }
            catch (Exception ex)
            {

                //1.log for exception
                _logger.LogError(ex, ex.Message);
                //2.set massege
                if (_enviroment.IsDevelopment())
                {

                    message = ex.Message;
                    return View(employeedto);
                }
                else
                {

                    message = "employee is not created";
                    return View("Error", message);
                }
            }
        }

        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)

                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee is null)
                return NotFound();
            return View(employee);
        }


        #endregion

        #region Edit
        [HttpGet] //Get: /DEP/EDIT/ID
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            var employeeDto = new UpdatedEmployeeDto
            {
                Name = employee.Name,
                Email = employee.Email,
                Address = employee.Address,
                Salary = employee.Salary,
                Phone = employee.Phone,
                EmployeeType = employee.EmployeeType,
                Gendar = employee.Gendar,
                HiringDate = employee.HiringDate,
                IsActive = employee.IsActive
            };

            return View(employeeDto);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, UpdatedEmployeeDto updatedEmployeeDto)
        {
            if (!ModelState.IsValid)
                return View(updatedEmployeeDto);

            var massege = string.Empty;

            try
            {
               

                var result = _employeeService.UpdatedEmployee(updatedEmployeeDto) > 0;


                if (result)
                    return RedirectToAction(nameof(Index));

                massege = "an error has happend while updateing the employee";
            }
            catch (Exception ex)
            {
                //1.log for exception
                _logger.LogError(ex, ex.Message);
                //2.set massege


                massege = _enviroment.IsDevelopment() ? ex.Message : "an error has happend while updateing the employee";


            }
            ModelState.AddModelError(string.Empty, massege);
            return View(updatedEmployeeDto);
        }
        #endregion


        #region Delete
        [HttpGet]

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee is null)
                return NotFound();
            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var massege = string.Empty;

            try
            {
                var deleted = _employeeService.DeleteEmployee(id);

                if (deleted)
                    return RedirectToAction(nameof(Index));

                massege = "an error happened during deleting";
            }
            catch (Exception ex)
            {

                //1.log for exception
                _logger.LogError(ex, ex.Message);
                //2.set massege

                massege = _enviroment.IsDevelopment() ? ex.Message : "an error has happend while updateing the employee :(";


            }
            //ModelState.AddModelError(string.Empty, massege);
            return RedirectToAction(nameof(Index)); //will implement toaster 

        }
        #endregion

    }
}
