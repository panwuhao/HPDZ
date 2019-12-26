using Owl.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApI.Controllers
{
    public class IndexController : ApiController
    {
        public object  GetList()
        {

            var json=new {Data= OwlDal.FlightDel() };
            return json;
        }

    }
}
