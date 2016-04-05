using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swim.Models
{
    /// <summary>
    /// 加入會員所填寫資料Model
    /// </summary>
    /// 2016/04/03 Create By Yohey
    public class RegisterDataModel
    {
        /// <summary>
        /// 要當教練/學生
        /// </summary>
        [Required(ErrorMessage = "請選擇您的角色")]
        public string Role { get; set; }

        /// <summary>
        /// 使用者ID
        /// </summary>]
        [Key]
        [Display(Name = "使用者ID")]
        [StringLength(20, ErrorMessage = "長度限制為20字內")]
        [MinLength(2, ErrorMessage = "請至少設定2個字元以上")]
        [Required(ErrorMessage = "請輸入欲設定的{0}")]
        [RegularExpression(@"^\w+$", ErrorMessage = "請輸入正確的{0} (可為英文、數字、底線之組合)")]
        [System.Web.Mvc.Remote("IsUserIdBeUsed", "Account")]
        public string UserId { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Display(Name = "登入密碼")]
        [Required(ErrorMessage = "請輸入欲設定的{0}")]
        [StringLength(20, ErrorMessage = "長度限制為20字內")]
        [MinLength(6, ErrorMessage = "請至少設定6個字元以上")]
        [RegularExpression(@"^\w+$", ErrorMessage = "請輸入正確的{0} (可為英文、數字、底線之組合)")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }

        /// <summary>
        /// 再次輸入密碼
        /// </summary>
        [Display(Name = "再次輸入密碼")]
        [Compare("LoginPassword", ErrorMessage="兩次輸入密碼不相符")]
        [DataType(DataType.Password)]
        public string LoginPasswordConfirmation { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        [Display(Name = "性別")]
        [Required(ErrorMessage = "請選擇您的{0}")]
        public string Sex { get; set; }

        /// <summary>
        /// 生日-年
        /// </summary>
        [Required(ErrorMessage = "請選擇生日西元年")]
        public string Birthday_Year { get; set; }

        /// <summary>
        /// 生日-月
        /// </summary>
        [Required(ErrorMessage = "請選擇生日月份")]
        public string Birthday_Month { get; set; }

        /// <summary>
        /// 生日-日
        /// </summary>
        [Required(ErrorMessage = "請選擇生日日期")]
        public string Birthday_Day { get; set; }

        /// <summary>
        /// Email地址
        /// </summary>
        [Display(Name = "Email地址")]
        [Required(ErrorMessage = "請輸入{0}")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage= "請輸入正確的Email地址")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址 - 縣市
        /// </summary>
        [Required(ErrorMessage = "請選擇縣市")]
        public string Address_County { get; set; }

        /// <summary>
        /// 地址 - 區
        /// </summary>
        [Required(ErrorMessage = "請選擇區")]
        public string Address_Township { get; set; }

        /// <summary>
        /// 地址 - 其餘詳細
        /// </summary>
        [StringLength(100, ErrorMessage="長度限制為100字內")]
        public string Address_Detail { get; set; }

        /// <summary>
        /// 手機號碼
        /// </summary>
        [Display(Name = "手機號碼")]
        [Required(ErrorMessage = "請輸入{0}")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{10}$", ErrorMessage="請輸入正確的{0}")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Display(Name = "相關經歷/想法")]
        [StringLength(500, ErrorMessage = "長度限制為500字內")]
        public string Memo { get; set; }
    }
}
