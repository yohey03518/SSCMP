using System;
//using System.Globalization;
using System.Linq;
/*using System.Security.Claims;
using System.Threading.Tasks;*/
using System.Web;
using System.Web.Mvc;
/*using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;*/
using Swim.Models;
using System.Collections;
using System.Collections.Generic;
using Swim.DAC;
using System.Configuration;
using System.Text;
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;

namespace Swim.Controllers
{
    /// <summary>
    /// 帳號處理相關
    /// </summary>
    /// 2016/04/04 by Yohey
    public class AccountController : _Controller
    {

        /// <summary>
        /// 加入會員畫面
        /// </summary>
        /// 2016/04/04 by Yohey
        /// <returns></returns>
        //[Authorize]
        public ActionResult Register()
        {
            // 西元年下拉選單 - 設為今年往前推算一百年
            IList<CommonCodeModel> yearListData = new List<CommonCodeModel>();
            int nowYear = DateTime.Now.Year;
            for (int year = nowYear - 100; year <= nowYear; year++)
            {
                CommonCodeModel model = new CommonCodeModel()
                {
                    Code = year,
                    CodeName = year.ToString()
                };
                yearListData.Add(model);
            }
            SelectList yearList = new SelectList(yearListData, "Code", "CodeName");
            ViewBag.yearList = yearList;

            // 月份下拉選單
            IList<CommonCodeModel> monthListData = new List<CommonCodeModel>();
            for (int month = 1; month <= 12; month++)
            {
                CommonCodeModel model = new CommonCodeModel()
                {
                    Code = month,
                    CodeName = month.ToString()
                };
                monthListData.Add(model);
            }
            SelectList monthList = new SelectList(monthListData, "Code", "CodeName");
            ViewBag.monthList = monthList;

            // 日下拉選單(預設空)
            IList<string> dayListData = new List<string>();
            ViewBag.dayList = new SelectList(dayListData);

            // 縣市下拉選單(進資料庫取得)
            using (AccountDAC dac = new AccountDAC())
            {
                ViewBag.countyList = new SelectList(dac.GetAreaList(), "Code", "CodeName");
            }

            // 區下拉選單(預設空)
            IList<string> townshipData = new List<string>();
            ViewBag.townshipList = new SelectList(townshipData);

            return View();
        }

        /// <summary>
        /// 依照選取的年份及月分計算當月最大天數
        /// </summary>
        /// 2016/04/03 by Yohey
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetMaxDayByYearAndMonth(string year, string month)
        {
            // 先依照傳回的年及月組成datetime(該月1號)
            DateTime thisMonthFirstDay = new DateTime(int.Parse(year), int.Parse(month), 1);
            // //將組好的datetime月份+1，日期-1並取出日期即可得該月最大天數
            int maxDay = thisMonthFirstDay.AddMonths(1).AddDays(-1).Day;

            return Json(maxDay);
        }

        /// <summary>
        /// 依據縣市代碼取得區的list
        /// </summary>
        /// 2016/04/04 by Yohey
        /// <param name="countyId">縣市代碼</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetTownshipList(string countyId)
        {
            using (AccountDAC dac = new AccountDAC())
            {
                return Json(dac.GetTownshipList(int.Parse(countyId)));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="newAccountModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Register(RegisterDataModel newAccountModel)
        {
            if (ModelState.IsValid)
            {
                // 密碼加密
                newAccountModel.LoginPassword = Hash(newAccountModel.LoginPassword);

                // 避免角色被亂改
                if (newAccountModel.Role != "Coach" && newAccountModel.Role != "Student")
                    return Json("Wrong Role");

                try
                {
                    using (AccountDAC dac = new AccountDAC())
                    {
                        dac.CreateNewAccount(newAccountModel);
                    }
                    return Json("SUCCESS");
                }
                catch
                {
                    return Json("帳號建立失敗！請重試");
                }
            }
            else
                return Json("失敗！請重試");
        }

        /// <summary>
        /// 確認User ID是否已經被使用
        /// </summary>
        /// 2016/04/05 by Yohey
        /// <param name="UserId"></param>
        /// <returns></returns>
        public JsonResult IsUserIdBeUsed(string UserId)
        {
            using (AccountDAC dac = new AccountDAC())
            {
                bool isUsed = dac.IsUserIdBeUsed(UserId);
                // true: 有被使用,故回傳錯誤訊息 ; false:無被使用, 回傳true(通過)
                if (isUsed)
                    return Json("此ID已被使用", JsonRequestBehavior.AllowGet);
                else
                    return Json(true, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 登入頁面
        /// </summary>
        /// 2016/04/10 by Yohey
        /// <returns></returns>
        public ActionResult Login()
        {
            // 加上這行才不會一到登入畫面就驗證欄位
            ModelState.Clear();
            return View();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginInfoModel model, string returnUrl)
        {
            //Session.Clear();
            //Session.Abandon();
            if (ModelState.IsValid)
            {
                // 將輸入的密碼加密
                string inputPassword = Hash(model.LoginPassword);
                string hashedPasswordInDB;
                // 進資料庫針對該帳號取出密碼(已加密)
                using (AccountDAC dac = new AccountDAC())
                {
                    hashedPasswordInDB = dac.GetPasswordByUserId(model.UserId);
                }

                // 密碼不為空代表有此帳號,進行比對密碼
                if (!string.IsNullOrWhiteSpace(hashedPasswordInDB))
                {
                    // 密碼正確
                    if (inputPassword == hashedPasswordInDB)
                    {
                        //Session.RemoveAll();
                        // 將登入資訊寫入cookies
                        bool isPersistent = false;
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            1,
                            model.UserId,
                            DateTime.Now,
                            DateTime.Now.AddMinutes(30),
                            isPersistent,
                            "SSCMP",
                            FormsAuthentication.FormsCookiePath);

                        string encTicket = FormsAuthentication.Encrypt(ticket);
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                        // FormsAuthentication.SetAuthCookie(model.UserId, false);
                        //ControllerContext ct = new ControllerContext();
                        //ct.RequestContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;

                        //FormsAuthentication.RedirectFromLoginPage(model.UserId, false);
                        //var l = System.Web.HttpContext.Current.User;
                        //var kk = User.Identity;
                        // TO DO 登入紀錄 IP 時間
                        //SetSession("UserId", model.UserId);
                        //Session["UserId"] = "ttt";
                        return RedirectToAction("Index", "Home");
                    }
                    // 密碼錯誤
                    else
                    {
                        ModelState.AddModelError(string.Empty, "帳號或密碼錯誤登入失敗");

                        return View(model);
                    }
                }
                // 密碼為空代表無此帳號
                else
                {
                    ModelState.AddModelError(string.Empty, "帳號或密碼錯誤登入失敗");
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 查看指定的USER個人資料
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult UserView(string userId)
        {
            using (AccountDAC dac = new AccountDAC())
            {                
                return View(dac.GetUserData(userId));
            }
        }
    }
}