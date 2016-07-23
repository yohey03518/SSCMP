using System;
using System.Linq;
using Swim.Models;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Swim.DAC
{
    /// <summary>
    /// 刊登相關使用的DAC
    /// </summary>
    /// 2016/04/21 by Yohey
    public class PostDAC : _DAC
    {
        /// <summary>
        /// 取得學習種類的List
        /// </summary>
        /// 2016/04/21 by Yohey 
        /// <returns></returns>
        public IList<LearnTypeModel> GetLearnTypeList()
        {
            StringBuilder sql = new StringBuilder();
            // 先取得所有母類型
            sql.AppendLine(@"
                SELECT TypeId AS Code, TypeName AS CodeName
                FROM LearnTypeData
                WHERE TreeLevel = {0}
            ");
            IList<LearnTypeModel> parentTypeList = dbConn.ExecuteQuery<LearnTypeModel>(sql.ToString(), 1).ToList();

            // 取得三層類型
            sql.AppendLine(@"AND TypeParentId = {1}");
            foreach (LearnTypeModel parent in parentTypeList)
            {
                parent.ChildList = dbConn.ExecuteQuery<LearnTypeModel>(sql.ToString(), 2, parent.Code).ToList();
                foreach (LearnTypeModel child1 in parent.ChildList)
                {
                    child1.ChildList = dbConn.ExecuteQuery<LearnTypeModel>(sql.ToString(), 3, child1.Code).ToList();
                }
            }
            return parentTypeList;
        }

        /// <summary>
        /// 新刊登存檔 - 學生刊登
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        public void SaveNewPost(NewPostToLearnModel model, string userId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                StringBuilder sql = new StringBuilder();

                // 1.新增學生刊登主檔並取得新增的ID
                sql.AppendLine(@"
                    INSERT INTO StudentPost(StudentId, IsOpen, HopeCoachSex, Memo, CreateDate)
                    OUTPUT INSERTED.PostId
                    VALUES({0}, 'Y', {1}, {2}, GETDATE())
                ");
                int postId = dbConn.ExecuteQuery<int>(sql.ToString(), userId, model.HopeCoachSex, model.Memo ?? "").SingleOrDefault();

                // 2.加入地區關聯檔
                sql.Clear();
                sql.AppendLine(@"
                    INSERT INTO PostHopeArea(PostCharacter, PostId, AreaId)
                    SELECT 'Student' AS PostCharacter, {0} AS PostId, COD AS AreaId
                    FROM dbo.fn_SPLIT({1}, ',')
                ");
                dbConn.ExecuteCommand(sql.ToString(), postId, model.HopeArea);

                // 3.加入學習類型關聯檔
                sql.Clear();
                sql.AppendLine(@"
                    INSERT INTO PostLearnType(PostCharacter, PostId, TypeId)
                    SELECT 'Student' AS PostCharacter, {0} AS PostId, COD AS TypeId
                    FROM dbo.fn_SPLIT({1}, ',')
                ");
                dbConn.ExecuteCommand(sql.ToString(), postId, model.ToLearnType);

                scope.Complete();
            }
        }

        /// <summary>
        /// 新刊登存檔 - 教練刊登
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        public void SaveNewPost(NewPostToTeachModel model, string userId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                StringBuilder sql = new StringBuilder();

                // 1.新增教練刊登主檔並取得新增的ID
                sql.AppendLine(@"
                    INSERT INTO CoachPost(CoachId, IsOpen, HopeStudentSex, Memo, CreateDate)
                    OUTPUT INSERTED.PostId
                    VALUES({0}, 'Y', {1}, {2}, GETDATE())
                ");
                int postId = dbConn.ExecuteQuery<int>(sql.ToString(), userId, model.HopeStudentSex, model.Memo ?? "").SingleOrDefault();

                // 2.加入地區關聯檔
                sql.Clear();
                sql.AppendLine(@"
                    INSERT INTO PostHopeArea(PostCharacter, PostId, AreaId)
                    SELECT 'Coach' AS PostCharacter, {0} AS PostId, COD AS AreaId
                    FROM dbo.fn_SPLIT({1}, ',')
                ");
                dbConn.ExecuteCommand(sql.ToString(), postId, model.HopeArea);

                // 3.加入學習類型關聯檔
                sql.Clear();
                sql.AppendLine(@"
                    INSERT INTO PostLearnType(PostCharacter, PostId, TypeId)
                    SELECT 'Coach' AS PostCharacter, {0} AS PostId, COD AS TypeId
                    FROM dbo.fn_SPLIT({1}, ',')
                ");
                dbConn.ExecuteCommand(sql.ToString(), postId, model.ToTeachType);

                scope.Complete();
            }
        }

        /// <summary>
        /// 取得學生刊登前五新
        /// </summary>
        /// <returns></returns>
        public IList<NewPostModel> GetTop5NewStudentPost()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(@"
                SELECT TOP 5 PostId, account.UserId, account.Sex, dbo.GetAreaNames('S', PostId, 2) AS Area, post.Memo
                FROM StudentPost post
	                LEFT JOIN AccountData account
		                ON post.StudentId = account.UserId
                ORDER BY post.CreateDate DESC
            ");
            return dbConn.ExecuteQuery<NewPostModel>(sql.ToString()).ToList();
        }
    }

}