using System;
using System.ComponentModel.DataAnnotations;

namespace MvcHtmlHelpers.Models
{
    /// <summary>
    /// 註冊登入的資料模型
    /// </summary>
    public class RegisterDataAnnotations
    {
        [Display(Name = "編號")]
        public int Id { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名不得空白")]
        public string Name { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼不得空白")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "電子郵件")]
        [Required(ErrorMessage = "電子郵件不得空白")]
        public string Email { get; set; }

        [Display(Name = "部落格")]
        [DataType(DataType.Url)]
        public string Blog { get; set; }

        [Display(Name = "性別")]
        public Gender? Gender { get; set; }

        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "生日")]
        [DataType(DataType.DateTime)]
        public DateTime Birthday2 { get; set; }

        [Display(Name = "收入")]
        [DataType(DataType.Currency)]
        public decimal Income { get; set; }

        [Display(Name = "城市")]
        [Required(ErrorMessage = "不得為空白")]
        [Range(1, 10)]
        public int City { get; set; }

        [Display(Name = "意見")]
        [DataType(DataType.MultilineText)]
        [StringLength(255)]
        public string Comment { get; set; }

        [Display(Name = "條款")]
        public bool Terms { get; set; }
    }
}

/// <summary>
/// 性別列舉
/// </summary>
public enum Gender
{
    Female  = 0,
    Male    = 1,
    Other   = 2
}