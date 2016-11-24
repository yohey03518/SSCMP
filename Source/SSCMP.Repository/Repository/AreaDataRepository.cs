using SSCMP.Domain.Entity;
using SSCMP.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCMP.Repository
{
    /// <summary>
    /// AreaData Repository
    /// </summary>
    public class AreaDataRepository : AbstractAreaDataRepository
    {
        #region AbstractAreaDataRepository Members

        /// <summary>
        /// 取得所有地區代碼資料
        /// </summary>
        /// 2016/11/24 by Yohey
        /// <returns></returns>
        public override IList<AreaData> ReadAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IList<AreaData> allData = session.CreateCriteria<AreaData>().List<AreaData>();
                return allData;
            }
        }

        #endregion

        #region Private Function

        #endregion
    }
}
