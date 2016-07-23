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
    public class HomeController : _Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        ///  最新刊登小區塊View
        /// </summary>
        /// 2016/03/24 Create By Yohey
        /// <returns></returns>
        public ActionResult NewPost()
        {
            return PartialView();
        }

        /// <summary>
        /// 取得最新刊登資訊
        /// </summary>
        /// 2016/03/24 Create By Yohey
        /// <returns>最新刊登資訊</returns>
        [HttpPost]
        public JsonResult QueryNewPost(string test)
        {
            using (PostDAC dac = new PostDAC())
            {
                IList<NewPostModel> list = dac.GetTop5NewStudentPost();

                int total = 2;
                int page = 1;
                int records = 2;
                var gridData = new
                {
                    total,
                    page,
                    records,
                    rows = (from obj in list
                            select new
                            {
                                cell = new
                                {
                                    UserId = obj.UserId,
                                    Sex = obj.Sex_Text,
                                    Area = obj.Area
                                }

                            })
                };
                return Json(gridData);
            }
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
    }
}