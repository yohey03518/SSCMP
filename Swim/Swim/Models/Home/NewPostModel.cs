using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swim.Models
{
    /// <summary>
    /// 最新刊登Grid Model
    /// </summary>
    /// 2016/03/24 Create By Yohey
    public class NewPostModel
    {
        /// <summary>
        /// 刊登ID
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// 使用者ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public string Sex { get; set; }
        public string Sex_Text
        {
            get
            {
                if (this.Sex == "M")
                    return "女";
                else if (this.Sex == "F")
                    return "男";
                else
                    return "";                
            }
            set
            {

            }
        }

        /// <summary>
        /// 地區
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { get; set; }
    }
}
