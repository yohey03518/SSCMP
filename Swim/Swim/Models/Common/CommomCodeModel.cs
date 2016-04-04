using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swim.Models
{
    /// <summary>
    /// 共用代碼+代碼名稱Model
    /// </summary>
    /// 2016/04/01 Create By Yohey
    public class CommonCodeModel
    {
        /// <summary>
        /// 代碼ID
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 代碼名稱
        /// </summary>
        public string CodeName { get; set; }

    }
}
