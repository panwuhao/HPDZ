using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIT.EF.Dal
{
    public class UserDal
    {
        public List<StuInfo> GetUserList()
        {
            XITDataModel1 db = new XITDataModel1();
            List<StuInfo> result = db.StuInfo.ToList();
            return result;
        }

        public int AddUser(StuInfo stu)
        {
            XITDataModel1 db = new XITDataModel1();
            db.StuInfo.Add(stu);
            return db.SaveChanges();
        }

        public StuInfo GetUserByID(int id)
        {
            XITDataModel1 db = new XITDataModel1();
            return db.StuInfo.FirstOrDefault(p => p.StuID == id);
        }

        public int UpdateUser(StuInfo stu)
        {
            XITDataModel1 db = new XITDataModel1();
            db.Entry(stu).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }

        public List<ClassInfo> GetClaName()
        {
            XITDataModel1 db = new XITDataModel1();
            List<ClassInfo> result = db.ClassInfo.ToList();
            return result;
        }
    }
}
