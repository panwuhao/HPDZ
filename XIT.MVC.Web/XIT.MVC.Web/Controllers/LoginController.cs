using HPIT.Data.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using XIT.EF.Dal;
using static log4net.Appender.RollingFileAppender;

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
        [AllowAnonymous]
        [HttpPost]
        public JsonResult LoginIn(string username, string passward)
        {
            LoginInfo users = LoginDal.Instance.LoginMember(username, passward);
            JsonResult jsonResult = new JsonResult();
            
            //如果找到的话，就添加到缓存当中，并且跳转到主页面
            if (users != null)
            {
                string json = JsonConvert.SerializeObject(users);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,"loginUser",DateTime.Now, DateTime.Now.AddDays(1),false,json);
                //加密
                var ticketEncrypt = FormsAuthentication.Encrypt(ticket);
                //添加到cookie
                HttpCookie cokie = new HttpCookie(FormsAuthentication.FormsCookieName,ticketEncrypt);
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
                //添加
                Response.Cookies.Add(cokie);
                jsonResult.Data = new { data = json, state = "200" };
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                LogHelper.Default.WriteInfo(users.LogNum + "登录");
                return jsonResult;
                //return Json(true);
            }
            else
            {
                jsonResult.Data = new { data ="未找到用户!",state = "403" };
            }
            return jsonResult;
        }

        public ActionResult LoginOff()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}