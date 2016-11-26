using SSCMP.Domain.Entity;
using SSCMP.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Test.Service.FakeClass
{
    /// <summary>
    /// AreaData Repository
    /// </summary>
    public class AreaDataRepositoryFake : AbstractAreaDataRepository
    {
        #region AbstractAreaDataRepository Members

        /// <summary>
        /// 取得所有地區代碼資料
        /// </summary>
        /// 2016/11/24 by Yohey
        /// <returns></returns>
        public override IList<AreaData> ReadAll()
        {
                return new List<AreaData>
                {
                    new AreaData
                    {
                        AreaId = 1,
                        AreaName = "臺北市",
                        TreeLevel = 1,
                        OrderNumber = 1,
                        AreaParentId = 0
                    },
                    new AreaData
                    {
                        AreaId = 6,
                        AreaName = "高雄市",
                        TreeLevel = 1,
                        OrderNumber = 6,
                        AreaParentId = 0
                    },
                    new AreaData
                    {
                        AreaId = 23,
                        AreaName = "中正區",
                        TreeLevel = 2,
                        OrderNumber = 1,
                        AreaParentId = 1
                    },
                    new AreaData
                    {
                        AreaId = 24,
                        AreaName = "大同區",
                        TreeLevel = 2,
                        OrderNumber = 2,
                        AreaParentId = 1
                    },
                    new AreaData
                    {
                        AreaId = 143,
                        AreaName = "楠梓區",
                        TreeLevel = 2,
                        OrderNumber = 1,
                        AreaParentId = 6
                    },
                    new AreaData
                    {
                        AreaId = 146,
                        AreaName = "三民區",
                        TreeLevel = 2,
                        OrderNumber = 4,
                        AreaParentId = 6
                    }
                }
                ;
        }

        #endregion

        #region Private Function

        #endregion
    }
}
