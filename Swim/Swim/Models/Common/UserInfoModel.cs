using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swim.Models
{
    /// <summary>
    /// 使用者資訊
    /// </summary>
    /// 2016/05/08Create By Yohey
    public class UserInfoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "會員ID")]
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "角色")]
        public string Role_View
        {
            get
            {
                if (this.Role == "Student")
                    return "學生";
                else if (this.Role == "Coach")
                    return "教練";
                else
                    return "";
            }
            set { }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "性別")]
        public string Sex_View 
        {
            get
            {
                if (this.Sex == "F")
                    return "女";
                else if (this.Sex == "M")
                    return "男";
                else
                    return "";
            }
            set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "生日")]
        public string Birthday_View
        {
            get
            {
                return this.Birthday.Year + "年" + this.Birthday.Month + "日";
            }
            set { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "縣市")]
        public string Address_County { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "區")]
        public string Address_Township { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address_Detail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "行動電話")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "備註")]
        public string Memo { get; set; }
    }
}
