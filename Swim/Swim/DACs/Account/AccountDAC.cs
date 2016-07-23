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

        /// <summary>
        /// 新增帳號資料
        /// </summary>
        /// 2016/04/05 by Yohey
        /// <param name="newAccountModel"></param>
        public void CreateNewAccount(RegisterDataModel newAccountModel)
        {
            // 組合生日日期
            string birthday = newAccountModel.Birthday_Year + "/" + newAccountModel.Birthday_Month + "/" + newAccountModel.Birthday_Day;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"
                INSERT INTO AccountData
                    (Role, UserId, LoginPassword, Sex, Birthday,
                     EmailAddress, Address_County, Address_Township, Address_Detail, MobilePhone,
                     Memo, CreateDate)
                VALUES 
                    ({0}, {1}, {2}, {3}, CONVERT(DATETIME, {4}),
                     {5}, CONVERT(INT, {6}), CONVERT(INT, {7}), {8}, {9},
                     {10}, GETDATE())
            ");
            dbConn.ExecuteCommand(sql.ToString(),
                newAccountModel.Role, newAccountModel.UserId, newAccountModel.LoginPassword, newAccountModel.Sex, birthday,
                newAccountModel.EmailAddress, newAccountModel.Address_County, newAccountModel.Address_Township, newAccountModel.Address_Detail ?? "", newAccountModel.MobilePhone,
                newAccountModel.Memo ?? "");
        }

        /// <summary>
        /// 驗證是否傳入的使用者ID已經被使用過
        /// </summary>
        /// 2016/04/05 by Yohey
        /// <param name="userId"></param>
        /// <returns>true:有被使用過; false:無使用過</returns>
        public bool IsUserIdBeUsed(string userId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"
                SELECT COUNT(*)
                FROM AccountData
                WHERE UserId = {0}
            ");
            int count = dbConn.ExecuteQuery<int>(sql.ToString(), userId).SingleOrDefault();
            return count > 0 ? true : false;
        }

        /// <summary>
        /// 依照登入的ID取得該帳號的密碼(已加密)
        /// </summary>
        /// 2016/04/10 by Yohey
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetPasswordByUserId(string userId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"
                SELECT LoginPassword
                FROM AccountData
                WHERE UserId = {0}
            ");
            return dbConn.ExecuteQuery<string>(sql.ToString(), userId).SingleOrDefault();
        }

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfoModel GetUserData(string userId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"
                SELECT USR.UserId, USR.Role, USR.Sex, USR.Birthday, COUNTY.AreaName AS Address_County, TOWNSHIP.AreaName AS Address_Township, USR.Memo
                FROM AccountData AS USR
	                LEFT JOIN AreaData COUNTY
		                ON USR.Address_County = COUNTY.AreaId
	                LEFT JOIN AreaData TOWNSHIP
		                ON USR.Address_Township = TOWNSHIP.AreaId
                WHERE USR.UserId = {0}
            ");
            return dbConn.ExecuteQuery<UserInfoModel>(sql.ToString(), userId).SingleOrDefault();
        }
    }

}