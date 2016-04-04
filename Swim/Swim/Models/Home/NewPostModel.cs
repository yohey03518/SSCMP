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
        /// 使用者ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public string Sex { get; set; }

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
