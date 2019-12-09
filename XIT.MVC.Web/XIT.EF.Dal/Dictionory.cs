using HPIT.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIT.EF.Dal
{
    public class Dictionory
    {
        public static Dictionory insentes = new Dictionory();

        public StuInfo context { get; set; }

        public Dictionory()
        {
            this.context = new StuInfo();
        }

        public object GetPageData(SearchModel<StuInfo> search, out int count)
        {
            GetPageListParameter<StuInfo, int> parameter = new GetPageListParameter<StuInfo, int>();
            parameter.isAsc = true;
            parameter.orderByLambda = t => t.StuID;
            parameter.pageIndex = search.PageIndex;
            parameter.pageSize = search.PageSize;
            parameter.whereLambda = t => t.StuID != 0;
            XITDataModel1 indsentes = new XITDataModel1();
            DBBaseService baseService = new DBBaseService(indsentes);
            List<StuInfo> list = baseService.GetSimplePagedData<StuInfo, int>(parameter, out count);
            return list;
        }
    }
}
