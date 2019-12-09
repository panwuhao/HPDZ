using HPIT.Data.Core;
using HPIT.Survey.Portal.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XIT.EF.Dal;

namespace XIT.MVC.Web.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }
        public DeluxeJsonResult QueryPageData(SearchModel<XIT.EF.Dal.StuInfo> search)
        {
            int total = 0;
            var result = Dictionory.insentes.GetPageData(search, out total);
            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : total / search.PageSize + 1;
            return new DeluxeJsonResult(new
            {
                Data = result,
                Total = total,
                TotalPages = totalPages
            }, "yyyy-MM- dd HH: mm");
    }

    }
}