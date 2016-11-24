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
    /// HomeController專用Service Interface
    /// </summary>
    /// 2016/11/22 Create by Yohey
    public interface IHomeService 
    {
        /// <summary>
        /// 取得地區樹Data
        /// </summary>
        /// 2016/11/22 Create by Yohey
        /// <returns></returns>
        IList<AreaDTO> GetAreaTreeData();
    }
}
