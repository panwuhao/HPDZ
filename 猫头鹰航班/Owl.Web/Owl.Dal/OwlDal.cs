using HPIT.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Dal
{
  public  class OwlDal
    {
        public static Users Login(string Name)
        {
            DalModel1 model = new DalModel1();
            Users user = model.Users.FirstOrDefault(p => p.UserName== Name);
            return user;
        }
        public static List<EchartModel> EcSellAnalyze()
        {
            DalModel1 db = new DalModel1();
            string sql = @"	SELECT   CabinType as Name ,COUNT(CabinType) as Value FROM  dbo.FlightInfo group by CabinType";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }
        //Echart图表
        public static List<EchartModel> EcSellAnalyze1()
        {
            DalModel1 db = new DalModel1();
            string sql = @"	SELECT   FlightLoad as Name ,COUNT(FlightLoad) as Value FROM  dbo.FlightInfo group by FlightLoad";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }
        //Echart图表
        public static List<EchartModel> EcSellAnalyze2()
        {
            DalModel1 db = new DalModel1();
            string sql = @"	SELECT   FlightLoad as Name ,COUNT(FlightLoad) as Value FROM  dbo.FlightInfo group by FlightLoad";
            List<EchartModel> list = db.Database.SqlQuery<EchartModel>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 查询航班延误信息
        /// </summary>
        /// <returns></returns>
        public static List<FlightInfo> FlightDel()
        {
            DalModel1 db = new DalModel1();
            string sql = @"select * from FlightInfo where DelayCause is not null";
            List<FlightInfo> list = db.Database.SqlQuery<FlightInfo>(sql).ToList();
            return list;
        }
        /// <summary>
        /// 分页查询航班信息List
        /// </summary>
        /// <returns></returns>

        public static OwlDal Instance = new OwlDal();

        public FlightInfo Context { get; set; }

        public OwlDal()
        {
            this.Context = new FlightInfo();
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object GetPageData(SearchModel<FlightInfo> search, out int count)
        {
            GetPageListParameter<FlightInfo, int> parameter = new GetPageListParameter<FlightInfo, int>();
            parameter.isAsc = true;
            parameter.orderByLambda = t => t.FlightID;
            parameter.pageIndex = search.PageIndex;
            parameter.pageSize = search.PageSize;
            parameter.whereLambda = t => t.FlightID != 0;
            DalModel1 Instance = new DalModel1();
            DBBaseService baseService = new DBBaseService(Instance);
            List<FlightInfo> list = baseService.GetSimplePagedData<FlightInfo, int>(parameter, out count);
            return list;
        }
        
        /// <summary>
        ///添加
        /// </summary>
        /// <returns></returns>
        public static int Create(FlightInfo flightInfo)
        {
            DalModel1 dalModel = new DalModel1();
            dalModel.FlightInfo.Add(flightInfo);
            return dalModel.SaveChanges();
        }
        /// <summary>
        ///修改传递ID，返回对象类型
        /// </summary>
        /// <returns></returns>
        public static FlightInfo Update(int SID)
        {
            DalModel1 dalModel = new DalModel1();
            //从Index视图页获取到ID
            return dalModel.FlightInfo.FirstOrDefault(p => p.FlightID == SID);
        }
        public static int UpdateModel(FlightInfo info)
        {
            DalModel1 dalModel = new DalModel1();
            //设置实体状态为修改状态
            dalModel.Entry(info).State = System.Data.Entity.EntityState.Modified;
            return dalModel.SaveChanges();
        }
        //删除
        public static int Delete(int id)
        {
            DalModel1 dalModel = new DalModel1();
            //获取到ID
            var num = dalModel.FlightInfo.Where(x => x.FlightID == id);
            //调用删除方法
            dalModel.FlightInfo.Remove(num.ToList()[0]);
            return dalModel.SaveChanges();
        }
    }
}
