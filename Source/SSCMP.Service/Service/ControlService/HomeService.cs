using SSCMP.Domain.DTO;
using SSCMP.Domain.Entity;
using SSCMP.Repository;
using SSCMP.Service;
using SSCMP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Service
{
    /// <summary>
    /// HomeController專用Service Interface
    /// </summary>
    /// 2016/11/22 Create by Yohey
    public class HomeService : IHomeService
    {
        #region Service Declare

        public IAreaDataService AreaDataService { get; set; }

        #endregion

        #region IHomeService Members

        /// <summary>
        /// 取得地區樹Data
        /// </summary>
        /// 2016/11/22 by Yohey
        /// <returns></returns>
        public IList<AreaDTO> GetAreaTreeData()
        {
            return AreaDataService.GetAllLevelAreaData();
        }

        #endregion

        #region Private Function

        #endregion
    }
}
