using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swim.Models
{
    /// <summary>
    /// 刊登教游泳View Model
    /// </summary>
    /// 2016/05/08 Create By Yohey
    public class NewPostToTeachModel
    {

        /// <summary>
        /// 
        /// </summary>
        [Display(Name="希望上課地點")]
        public string HopeArea { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name="希望學生性別")]
        public string HopeStudentSex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name="可以教學")]
        public string ToTeachType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "備註")]
        public string Memo { get; set; }


    }
}
