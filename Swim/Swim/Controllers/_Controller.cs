using Swim.DAC;
using Swim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Swim.Controllers
{
    public class _Controller : Controller
    {
        /// <summary>
        /// 使用此model取得登入資訊
        /// </summary>
        protected UserInfoModel userModel;

        /// <summary>
        /// 登入者ID
        /// </summary>
        protected string userId;

        /// <summary>
        /// 字串加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.MD5.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }

        /// <summary>
        /// 設定Session (定義在_Controller才可供所有控制器取得)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void SetSession(string name, string value)
        {
            //Session[name] = Server.UrlEncode(value);
            Session[name] = value;
        }


        /// <summary>
        /// 取得Session
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected string GetSession(string name)
        {
            var ee = Session[name];
            return Session[name] == null ? "" : Server.UrlDecode(Session[name].ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            Session["KeepSession"] = DateTime.Now.Ticks;

            userId = User.Identity.Name ?? "";            
        }
    }
}