using Newtonsoft.Json;
using Owl.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Owl.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
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
            Users login = OwlDal.Login(Name);
            //实例化json
            JsonResult jsonResult = new JsonResult();
            if (login != null)
            {
                if (login.UserPassword == Pwd)
                {
                    string json = JsonConvert.SerializeObject(login);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, "loginUser", DateTime.Now, DateTime.Now.AddDays(1), false, json);
                    //加密
                    var ticketEncrypt = FormsAuthentication.Encrypt(ticket);
                    //添加到cookie
                    HttpCookie cokie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketEncrypt);
                    //过期时间
                    cokie.Expires = DateTime.Now.Add(FormsAuthentication.Timeout);
                    //域
                    cokie.Domain = FormsAuthentication.CookieDomain;
                    //Http协议
                    cokie.HttpOnly = true;
                    //ssl 安全套接字
                    cokie.Secure = FormsAuthentication.RequireSSL;
                    //cookie 浏览器的存储路径
                    cokie.Path = FormsAuthentication.FormsCookiePath;
                    //先删除
                    Response.Cookies.Remove(FormsAuthentication.FormsCookieName); 
                    Response.Cookies.Add(cokie);
                    jsonResult.Data = new { data = login, state = "007" };
                    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    return jsonResult;
                }
                else
                {
                    jsonResult.Data = new { data = "未找到用户！", state = "009" };
                    return jsonResult;
                }
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
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}