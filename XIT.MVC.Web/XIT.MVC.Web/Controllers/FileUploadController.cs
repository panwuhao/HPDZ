using HPIT.Data.Core;
using HPIT.Survey.Portal.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XIT.MVC.Web.Models;

namespace XIT.MVC.Web.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        //[HttpPost]
        public ActionResult ProcessFileLoad(IEnumerable<HttpPostedFileBase> filenames)
        {
            foreach (var file in filenames)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Upload"), filename);
                file.SaveAs(path);
            }
            return RedirectToAction("FileListIndex");
        }
        [AllowAnonymous]
        public FileResult download(string filename)

        {
            string filePath = Server.MapPath("~/Upload/" + filename);
            return File(filePath, "text/plain", filename);
        }
        [AllowAnonymous]
        public JsonResult GetFilelist(SearchModel<FileModel> search)
        {
            int total = 0;
            string filePath = Server.MapPath("~/Upload/");//路径
            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
            //获取文件夹下的所有文件
            FileInfo[] allfiles = directoryInfo.GetFiles();
            //生成新的文件类型的数据集合
            var data = from file in allfiles
                       select new
                       {
                           filename = file.Name,
                           path = file.DirectoryName,
                           time = file.LastWriteTime,
                           fullname = file.FullName
                       };
            //
            total = allfiles.Length;
            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : (total / search.PageSize) + 1;
            JsonResult result = new JsonResult();
            //原生分页代码skip take
            var pagedata = data.Skip((search.PageIndex - 1) * search.PageSize).Take(search.PageSize);
            //组织新的数据Data，Total, TotalPages
            //result.Data = new
            //{
            //    Data = pagedata,
            //    Total = total,
            //    TotalPages = totalPages
            //};
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //return result;
            return new DeluxeJsonResult(new
            {
                Data = pagedata,
                Total = total,
                TotalPages = totalPages
            }, "yyyy-MM- dd HH: mm");
        }
        [AllowAnonymous]
        public ActionResult FileListIndex()
        {
            return View();
        }
    }
}