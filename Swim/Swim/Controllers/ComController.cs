using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swim.DAC;
using Swim.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Swim.Controllers
{
    /// <summary>
    ///  共用相關控制器
    /// </summary>
    /// 2016/05/03 by Yarin
    public class ComController : Controller
    {
        /// <summary>
        /// 地區樹
        /// </summary>
        /// 2016/03/27 Create By Yohey
        /// <param name="id">欲設定的樹ID</param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult AreaTree(string id)
        {
            ViewBag.treeId = id;
            return PartialView();
        }

        /// <summary>
        /// 取得地區搜尋樹的區域資料
        /// </summary>
        /// 2016/03/28 Create By Yohey
        /// <returns>縣市+區json</returns>
        [HttpPost]
        public JsonResult GetAreaTreeData()
        {
            IList<AreaModel> countyList = new List<AreaModel>();
            // 進資料庫取得所有縣市及其區
            using (HomeDAC dac = new HomeDAC())
            {
                countyList = dac.GetAreaList();
            }

            //取出的資料組合json字串並回傳
            var jsonString = from county in countyList
                             select new
                             {
                                 id = county.Code,
                                 text = county.CodeName,
                                 children = from area in county.TownshipList
                                            select new
                                            {
                                                id = area.Code,
                                                text = area.CodeName
                                            }
                             };
            return Json(jsonString);
        }

        /// <summary>
        /// 學習類別樹
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult LearnTypeTree(string id)
        {
            ViewBag.treeId = id;
            return PartialView();
        }

        /// <summary>
        /// 取得學習種類的樹
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetLearnTypeData()
        {
            IList<LearnTypeModel> learnList = new List<LearnTypeModel>();
            using (PostDAC dac = new PostDAC())
            {
                learnList = dac.GetLearnTypeList();
            }

            var list = from parent in learnList
                       select new
                       {
                           id = parent.Code,
                           text = parent.CodeName,
                           children = from child1 in parent.ChildList
                                      select new
                                      {
                                          id = child1.Code,
                                          text = child1.CodeName,
                                          children = from child2 in child1.ChildList
                                                     select new
                                                     {
                                                         id = child2.Code,
                                                         text = child2.CodeName
                                                     }
                                      }
                       };
            return Json(list);

        }
    }
}