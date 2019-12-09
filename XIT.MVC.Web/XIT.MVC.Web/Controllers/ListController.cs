using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XIT.EF.Dal;

namespace XIT.MVC.Web.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            UserDal dal = new UserDal();
            List<StuInfo> user = dal.GetUserList();
            return View(user);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            UserDal dal = new UserDal();
            ViewData["ClaName"] = dal.GetClaName().Select(ClassInfo => new SelectListItem()
            { Text = ClassInfo.ClaName, Value = ClassInfo.ClaID.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateModel(StuInfo stu)
        {
            UserDal dal = new UserDal();
            if (dal.AddUser(stu) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public JsonResult GetJsonStu()
        {
            XITDataModel1 Det = new XITDataModel1(); 
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = Det.Finance.ToList();
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            XITDataModel1 Det = new XITDataModel1();
            //通过id查询数据
            var user = Det.StuInfo.Where(x => x.StuID == id);
            //删除表中遍历出来的数据
            Det.StuInfo.Remove(user.ToList()[0]);
            //提交到数据库
            Det.SaveChanges();
            //返回重新加载页面
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public ActionResult Edit(int id=0)
        //{
        //    XITDataModel1 xm = new XITDataModel1();
        //    StuInfo stu = xm.StuInfo.Find(id);
        //    if (stu == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(stu);



        //}

        //[HttpPost]
        //public ActionResult Edit(StuInfo stu)
        //{
        //    XITDataModel1 xm = new XITDataModel1();
        //    if (ModelState.IsValid)
        //    {
        //        xm.Entry(stu).State = EntityState.Modified;
        //        xm.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(stu);
        //}

        public ActionResult Edit(int id = 0)
        {
            UserDal dal = new UserDal();
            StuInfo stu = dal.GetUserByID(id);
            ViewData["ClaName"] = dal.GetClaName().Select(ClassInfo => new SelectListItem()
            { Text = ClassInfo.ClaName, Value = ClassInfo.ClaID.ToString() }).ToList();
            return View(stu);
        }
        public ActionResult EditStu(StuInfo stu)
        {
            UserDal dal = new UserDal();
            if (dal.UpdateUser(stu) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
    }
}