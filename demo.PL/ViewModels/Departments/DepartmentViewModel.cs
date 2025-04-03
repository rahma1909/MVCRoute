using System.ComponentModel.DataAnnotations;

namespace demo.PL.ViewModels.Departments
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage ="name is required !!")]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name="creation date")]
        public DateOnly CreationDate { get; set; }
    }
}
