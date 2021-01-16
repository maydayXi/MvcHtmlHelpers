using System.ComponentModel.DataAnnotations;

namespace MvcHtmlHelpers.Models
{
    /// <summary>
    /// Employee Data Model
    /// </summary>
    public class Employee
    {
        [Display(Name = "員工編號")]
        public int Id { get; set; }
        
        [Display(Name = "員工姓名")]
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "少需要三個字元！")]
        public string Name { get; set; }
        
        [Display(Name = "員工手機")]
        [Required]
        [RegularExpression(@"^\d{4}-\d{3}-\d{3}$", ErrorMessage = "格式為 09XX-XXX-XXX")]
        public string Mobile { get; set; }
        
        [Display(Name = "電子郵件")]
        [Required(ErrorMessage = "請輸入 Email！")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display(Name = "部門")]
        [Required(ErrorMessage = "請輸入 Department！")]
        public string Department { get; set; }

        [Display(Name = "職稱")]
        [Required(ErrorMessage = "請輸入職稱！")]
        public string Title { get; set; }
    }
}