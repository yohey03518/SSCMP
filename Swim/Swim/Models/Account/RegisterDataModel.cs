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
        [Required]
        public string Role { get; set; }

        /// <summary>
        /// 使用者ID
        /// </summary>
        [Required]
        [Display(Name="使用者ID")]
        public string UserId { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "登入密碼")]
        public string LoginPassword { get; set; }// TO DO 再次輸入驗證

        /// <summary>
        /// 性別
        /// </summary>
        [Required]
        [Display(Name = "性別")]
        public string Sex { get; set; }

        /// <summary>
        /// 生日-年
        /// </summary>
        [Required]
        public string Birthday_Year { get; set; }

        /// <summary>
        /// 生日-月
        /// </summary>
        [Required]
        public string Birthday_Month { get; set; }

        /// <summary>
        /// 生日-日
        /// </summary>
        [Required]
        public string Birthday_Day { get; set; }

        /// <summary>
        /// Email地址
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email地址")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址 - 縣市
        /// </summary>
        [Required]
        public string Address_County { get; set; }

        /// <summary>
        /// 地址 - 區
        /// </summary>
        [Required]
        public string Address_Township { get; set; }

        /// <summary>
        /// 地址 - 其餘詳細
        /// </summary>
        public string Address_Detail { get; set; }

        /// <summary>
        /// 手機號碼
        /// </summary>
        [Required]
        [Display(Name = "手機號碼")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [Display(Name = "相關經歷/想法")]
        public string Memo { get; set; }
    }
}
