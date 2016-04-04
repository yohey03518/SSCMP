using System;
using System.Linq;
using Swim.Models;
using System.Collections.Generic;
using System.Text;

namespace Swim.DAC
{
    /// <summary>
    /// 首頁使用的DAC
    /// </summary>
    /// 2016/04/02 by Yohey
    public class HomeDAC : _DAC
    {
        /// <summary>
        /// 取得縣市及其區別的List
        /// </summary>
        /// 2016/04/02 by Yohey 
        /// <returns>所有縣市的LIST(內含區的LIST)</returns>
        public IList<AreaModel> GetAreaList()
        {
            StringBuilder sql = new StringBuilder();
            // 先取得所有縣市
            sql.AppendLine(@"
                SELECT AreaId AS Code, AreaName AS CodeName
                FROM AreaData
                WHERE TreeLevel = {0}
            ");
            IList<AreaModel> countyList = dbConn.ExecuteQuery<AreaModel>(sql.ToString(), 1).ToList();

            //依照取出的縣市去得到對應的所有區
            sql.AppendLine(@"AND AreaParentId = {1}");
            foreach (AreaModel county in countyList)
            {
                county.TownshipList = dbConn.ExecuteQuery<CommonCodeModel>(sql.ToString(), 2, county.Code).ToList();
            }
            return countyList;
        }


    }

}