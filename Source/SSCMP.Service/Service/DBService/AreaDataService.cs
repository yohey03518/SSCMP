using SSCMP.Domain.DTO;
using SSCMP.Domain.Entity;
using SSCMP.Repository.Interface;
using SSCMP.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Service
{
    /// <summary>
    /// Table - AreaData專用Service
    /// </summary>
    /// 2016/11/22 Create by Yohey
    public class AreaDataService : IAreaDataService
    {
        #region Service Declare

        public AbstractAreaDataRepository AreaDataRepo { get; set; }

        #endregion

        #region IAreaDataService Members

        /// <summary>
        /// 取得地區別所有階層資料
        /// </summary>
        /// 2016/11/22 Create by Yohey
        /// <returns>地區別所有階層資料</returns>
        public IList<AreaDTO> GetAllLevelAreaData()
        {
            // 取得地區別代碼檔所有資料
            IList<AreaData> datas = AreaDataRepo.ReadAll();

            // 先取出縣市(Level為1)
            IList<AreaData> countys = datas.Where(m => m.TreeLevel == 1).ToList();

            IList<AreaDTO> result = new List<AreaDTO>();
            
            // 針對縣市的ID去爬出子階層之資料(鄉鎮區)後塞回各縣市DTO內的List
            foreach (AreaData county in countys)
            {
                int id = county.AreaId;
                IList<AreaData> townships = datas.Where(m => m.AreaParentId == id).ToList();
                AreaDTO oneCounty = new AreaDTO
                {
                    Code = county.AreaId,
                    CodeName = county.AreaName,
                    TownshipList = (from township in townships
                                    select new CommonCodeDTO { Code = township.AreaId, CodeName = township.AreaName }).ToList()
                };
                result.Add(oneCounty);
            }

            return result;
        }

        #endregion

        #region Private Function

        #endregion
    }
}
