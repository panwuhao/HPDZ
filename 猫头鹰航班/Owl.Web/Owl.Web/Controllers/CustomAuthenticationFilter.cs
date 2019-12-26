
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using Newtonsoft.Json;
using System;
using XIT.MVC.Web.Common;
using HPIT.Data.Core;
using System.Web.Security;
using Owl.Dal;

namespace MVCLearn.Filters
{
    public class CustomAuthenticationFilter : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //如果action 和 controller的添加的特性里面包含匿名的，则直接过滤掉。
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true))
            {
                return;
            }
            var Url = new UrlHelper(filterContext.RequestContext);
            var urlstr = Url.Action("Index", "Login");
            //filterContext.Result = new RedirectResult(urlstr); //指定返回重定向登录界面
            string cookieName = FormsAuthentication.FormsCookieName;
            // HttpCookie cokie = filterContext.HttpContext.Request.Cookies.Get("Login");
            HttpCookie cokie = filterContext.HttpContext.Request.Cookies[cookieName];
            if (cokie == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                       {
                                           {"controller","Login"},
                                           {"action","Index"},
                                           {"returnUrl",filterContext.HttpContext.Request.RawUrl }
                                       });
            }
            else
            {
                FormsAuthenticationTicket authTicket = null;
                try
                {
                    authTicket = FormsAuthentication.Decrypt(cokie.Value);
                }
                catch (Exception ex)
                {

                    LogHelper.Default.WriteError(ex.Message);
                }
                //var value = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(cokie.Value));
                if (authTicket!=null)
                {
                    DeluxeUser.CurrentMember = JsonConvert.DeserializeObject<Users>(authTicket.UserData);

                }

            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                       {
                                           {"controller","Login"},
                                           {"action","Index"},
                                           {"returnUrl",filterContext.HttpContext.Request.RawUrl }
                                       });
            }
        }
    }
}