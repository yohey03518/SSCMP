using SSCMP.Domain.DTO;
using SSCMP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Service.Interface
{
    /// <summary>
    /// Table - AreaData專用Service Interface
    /// </summary>
    /// 2016/11/22 Create by Yohey
    public interface IAreaDataService 
    {
        /// <summary>
        /// 取得地區別所有階層資料
        /// </summary>
        /// 2016/11/22 Create by Yohey
        /// <returns>地區別所有階層資料</returns>
        IList<AreaDTO> GetAllLevelAreaData();
    }
}
