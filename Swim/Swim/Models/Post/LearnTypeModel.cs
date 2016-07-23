using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swim.Models
{
    /// <summary>
    /// 學習種類Model
    /// </summary>
    /// 2016/04/01 Create By Yohey
    public class LearnTypeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CodeName { get; set; }

        /// <summary>
        /// 用來裝子選單的list
        /// </summary>
        public IList<LearnTypeModel> ChildList { get; set; }
    }
}
