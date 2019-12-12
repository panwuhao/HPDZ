using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XIT.EF.Dal;

namespace XIT.MVC.Web.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
      
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public JsonResult LoginReault(string Name, string Pwd)
        {
            LoginInfo login = UserDal.Login(Name);
            //实例化json
            JsonResult jsonResult = new JsonResult();
            if (login.LogPwd == Pwd)
            {
                string json = JsonConvert.SerializeObject(login);
                HttpCookie cookie = new HttpCookie("Login", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json)));
                Response.Cookies.Add(cookie);
                jsonResult.Data = new { data = json, state = "007" };
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return jsonResult;
            }
            else
            {
                jsonResult.Data = new { data = "未找到用户！", state = "009" };
                return jsonResult;
            }
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            Request.Cookies.Clear();
            Response.Cookies.Clear();
            return View("Login");
        }
    }
}