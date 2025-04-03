using demo.BLL.DTOs.Department;
using demo.BLL.Services.Departments;
using demo.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;

namespace demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        #region Services
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;

        private readonly IWebHostEnvironment _enviroment;

        //[FromServices]
        //public IDepartmentService DepartmentService { get; } = null!;

        //========
        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment enviroment)
        {
            _departmentService = departmentService;
            _logger = logger;
            _enviroment = enviroment;
        }
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View("Index", departments);
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
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            var message = string.Empty;
            if (!ModelState.IsValid)
                return View(departmentVM);

            try
            {

                var createdDepartment = new CreatedDepartmentToRetrunDto()
                {
                   
                    Code = departmentVM.Code,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate,
                    Name = departmentVM.Name,
                };

                var result = _departmentService.CreateDepartment(createdDepartment);

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Department is not created");
                return View(departmentVM);
            }
            catch (Exception ex)
            {

                //1.log for exception
                _logger.LogError(ex, ex.Message);
                //2.set massege
                if (_enviroment.IsDevelopment())
                {

                    message = ex.Message;
                    return View(departmentVM);
                }
                else
                {

                    message = "department is not created";
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

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();
            return View(department);
        }


        #endregion

        #region Edit
        [HttpGet] //Get: /DEP/EDIT/ID
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();//400
            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();//404
            return View(new DepartmentViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreationDate = department.CreationDate,
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid)
                return View(departmentViewModel);

            var massege = string.Empty;

            try
            {
                var departmentToUpdate = new UpdatedDepartmentDto()
                {
                    Id = id,
                    Code = departmentViewModel.Code,
                    Description = departmentViewModel.Description,
                    CreationDate = departmentViewModel.CreationDate,
                    Name = departmentViewModel.Name,
                };


                var result = _departmentService.UpdatedDepatment(departmentToUpdate) > 0;


                if (result)
                    return RedirectToAction(nameof(Index));

                massege = "an error has happend while updateing the department :(";
            }
            catch (Exception ex)
            {
                //1.log for exception
                _logger.LogError(ex, ex.Message);
                //2.set massege


                massege = _enviroment.IsDevelopment() ? ex.Message : "an error has happend while updateing the department :(";


            }
            ModelState.AddModelError(string.Empty, massege);
            return View(departmentViewModel);
        }
        #endregion


        #region Delete
        [HttpGet]

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
                return NotFound();
            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var massege = string.Empty;

            try
            {
                var deleted = _departmentService.DeleteDepartment(id);

                if (deleted)
                    return RedirectToAction(nameof(Index));

                massege = "an error happened during deleting";
            }
            catch (Exception ex)
            {

                //1.log for exception
                _logger.LogError(ex, ex.Message);
                //2.set massege


                massege = _enviroment.IsDevelopment() ? ex.Message : "an error has happend while updateing the department :(";


            }
            //ModelState.AddModelError(string.Empty, massege);
            return RedirectToAction(nameof(Index)); //will implement toaster 

        } 
        #endregion

    }
}
