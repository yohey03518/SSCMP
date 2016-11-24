using System.Collections.Generic;

namespace SSCMP.Domain.DTO
{
    /// <summary>
    /// 地區選單Model
    /// </summary>
    /// 2016/04/01 Create By Yohey
    public class AreaDTO
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
        /// 用來裝區的list
        /// </summary>
        public IList<CommonCodeDTO> TownshipList { get; set; }
    }
}
