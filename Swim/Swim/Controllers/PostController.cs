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
    /// 刊登資訊相關
    /// </summary>
    /// 2016/04/19 by Yohey
    public class PostController : _Controller
    {
        /// <summary>
        /// 刊登學游泳畫面
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult NewPostToLearn()
        {
            return View();
        }

        /// <summary>
        /// 刊登教游泳畫面
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult NewPostToTeach()
        {
            return View();
        }

        /// <summary>
        /// 學生刊登存檔
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public JsonResult ToLearnPostSave(NewPostToLearnModel model)
        {
            using(PostDAC dac = new PostDAC())
            {
                try
                {
                    dac.SaveNewPost(model, userId);
                    return Json("SUCCESS");
                }
                catch
                {
                    return Json("存檔失敗");
                }
            }
        }

        /// <summary>
        /// 教練刊登存檔
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public JsonResult ToTeachPostSave(NewPostToTeachModel model)
        {
            using (PostDAC dac = new PostDAC())
            {
                try
                {
                    dac.SaveNewPost(model, userId);
                    return Json("SUCCESS");
                }
                catch
                {
                    return Json("存檔失敗");
                }
            }
        }
    }
}