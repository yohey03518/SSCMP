using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swim.Models
{
    /// <summary>
    /// 登入Model
    /// </summary>
    /// 2016/04/08 Create By Yohey
    public class LoginInfoModel
    {
        /// <summary>
        /// 使用者ID
        /// </summary>]
        [Display(Name = "ID")]
        [StringLength(20, ErrorMessage = "ID長度為20字內")]
        [MinLength(2, ErrorMessage = "ID長度為2個字元以上")]
        [Required(ErrorMessage = "請輸入{0}")]
        [RegularExpression(@"^\w+$", ErrorMessage = "ID格式不正確")]
        public string UserId { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Display(Name = "密碼")]
        [Required(ErrorMessage = "請輸入{0}")]
        [StringLength(20, ErrorMessage = "密碼超過最大長度")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}
