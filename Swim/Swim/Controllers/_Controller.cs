using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Swim.Controllers
{
    public class _Controller : Controller
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.MD5.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}