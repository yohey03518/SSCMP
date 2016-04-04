using System;
using System.Linq;
using Swim.Models;
using System.Collections.Generic;
using System.Text;

namespace Swim.DAC
{
    /// <summary>
    /// 帳號相關DAC
    /// </summary>
    /// 2016/04/04 by Yohey
    public class AccountDAC : _DAC
    {
        /// <summary>
        /// 取得縣市List
        /// </summary>
        /// 2016/04/04 by Yohey 
        /// <returns>所有縣市的LIST</returns>
        public IList<AreaModel> GetAreaList()
        {
            StringBuilder sql = new StringBuilder();
            // 先取得所有縣市
            sql.AppendLine(@"
                SELECT AreaId AS Code, AreaName AS CodeName
                FROM AreaData
                WHERE TreeLevel = 1
            ");
            return dbConn.ExecuteQuery<AreaModel>(sql.ToString()).ToList();
        }

        /// <summary>
        /// 取得縣市List
        /// </summary>
        /// 2016/04/04 by Yohey 
        /// <param name="countyId">縣市代碼</param>
        /// <returns>該縣市所有區的LIST</returns>
        public IList<CommonCodeModel> GetTownshipList(int countyId)
        {
            StringBuilder sql = new StringBuilder();
            // 先取得所有縣市
            sql.AppendLine(@"
                SELECT AreaId AS Code, AreaName AS CodeName
                FROM AreaData
                WHERE TreeLevel = 2
                    AND AreaParentId = {0}
            ");
            return dbConn.ExecuteQuery<CommonCodeModel>(sql.ToString(), countyId).ToList();
        }


    }

}