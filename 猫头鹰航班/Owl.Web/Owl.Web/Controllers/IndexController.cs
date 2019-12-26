using HPIT.Data.Core;
using HPIT.Survey.Portal.Filters;
using Owl.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Owl.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexT()
        {
            return View();
        }
        //图表视图
        public ActionResult ECharts()
        {
            return View();
        }
        //[AllowAnonymous]
        public ActionResult IndexList()
        {
            return View();
        }
        //添加航班信息
        public ActionResult IndexCreate()
        {
            return View();
        }
        //延误航班信息
        public ActionResult FlightDelay()
        {
            return View();
        }
        [HttpPost]
        public JsonResult EcSellAnalyze()
        {
            List<EchartModel> list = OwlDal.EcSellAnalyze();
            return Json(list);
        }

        [HttpPost]
        public JsonResult EcSellAnalyze1()
        {
            List<EchartModel> list = OwlDal.EcSellAnalyze1();
            return Json(list);
        }
        [HttpPost]
        public JsonResult EcSellAnalyze2()
        {
            List<EchartModel> list = OwlDal.EcSellAnalyze2();
            return Json(list);
        }
        
        /// <summary>
        ///分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]

        public DeluxeJsonResult QueryPageData(SearchModel<FlightInfo> search)
        {
            int total = 0;
            var result = OwlDal.Instance.GetPageData(search, out total);
            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : total / search.PageSize + 1;
            return new DeluxeJsonResult(new
            {
                Data = result,
                Total = total,
                TotalPages = totalPages
            }, "yyyy-MM- dd HH: mm");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        /// <summary>    
        
        public ActionResult Create(FlightInfo flightInfo)
        {
            if (OwlDal.Create(flightInfo) > 0)
            {
                return Content("添加成功!");
            }
            else
            {
                return Content("添加失败!");
            }

        }
        //修改获取ID
        public ActionResult Update(int id)
        {
            //获取到ID
            FlightInfo info = OwlDal.Update(id);
            return View(info);
        }
        //修改方法
        public JsonResult UpdateModel(
            string FlightLoad, DateTime FlightDate, string FlightTime,
            string CabinType, decimal TicketPrice, int IsDelay, string DelayCause,
            int SurTicket, string PlaneType)
        {
            int num = 0;
            FlightInfo model = new FlightInfo()
            {
                FlightLoad = FlightLoad,
                FlightDate = FlightDate,
                FlightTime = FlightTime,
                CabinType = CabinType,
                TicketPrice = TicketPrice,
                IsDelay = IsDelay,
                DelayCause = DelayCause,
                SurTicket = SurTicket,
                PlaneType = PlaneType
            };
            num = OwlDal.UpdateModel(model);
            return Json(num);
        }

        //删除
        public ActionResult Delete(int id)
        {

            if (OwlDal.Delete(id) > 0)
            {
                return RedirectToAction("IndexList");
            }
            else
            {
                return RedirectToAction("Delete");
            }
        }
    }
}