using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swim.Models
{
    /// <summary>
    /// 刊登學游泳View Model
    /// </summary>
    /// 2016/04/01 Create By Yohey
    public class NewPostToLearnModel
    {

        /// <summary>
        /// 
        /// </summary>
        [Display(Name="希望上課地點")]
        public string HopeArea { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name="希望教練性別")]
        public string HopeCoachSex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name="想學習")]
        public string ToLearnType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "備註")]
        public string Memo { get; set; }


    }
}
