using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSCMP.Service.Interface;
using SSCMP.Domain.DTO;

namespace SSCMP.Controllers
{
    /// <summary>
    /// 首頁相關Controller
    /// </summary>
    public class HomeController : Controller
    {
        #region Parameter Daclare

        public IHomeService HomeService { get; set; }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  地區搜尋區塊
        /// </summary>
        /// 2016/03/27 Create By Yohey
        /// <returns></returns>
        public ActionResult AreaSearch()
        {
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
            IList<AreaDTO> countyList = HomeService.GetAreaTreeData();
            return Json(countyList);
        }

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
    }
}