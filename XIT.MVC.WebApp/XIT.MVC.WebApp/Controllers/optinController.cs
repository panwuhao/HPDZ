using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XIT.EF.Dal.Engineer;

namespace XIT.MVC.WebApp.Controllers
{
    public class optinController : Controller
    {
        
        // GET: optin
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取省份
        /// </summary>
        //public JsonResult GetEngineerlist()
        //{
        //    EngineerModel db = new EngineerModel();
        //    db.Configuration.ProxyCreationEnabled = false;
        //    return Json(db.Engineer.ToList(), JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// 获取城市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public JsonResult GetAssessmentlist(int id)
        //{
        //    EngineerModel db = new EngineerModel();
        //    List<Assessment> list = db.Assessment.Where(c => c.AssEngID == id).ToList();
        //    List<SelectListItem> item = new List<SelectListItem>();
        //    foreach (var Asses in list)
        //    {
        //        item.Add(new SelectListItem { Text = Asses.AssName, Value = Asses.AssEngID.ToString() });
        //    }
        //    return Json(item, JsonRequestBehavior.AllowGet);
        //}
    }
}