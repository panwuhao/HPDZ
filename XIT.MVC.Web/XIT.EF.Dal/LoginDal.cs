using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIT.EF.Dal
{
   public class LoginDal
    {
        public static LoginDal Instance = new LoginDal();
        public LoginInfo LoginMember(string username, string password)
        {
            //string sql = @"select * from(select m. RealName, m. Mobile, m. Email,r.Category, r . FullName,r . Description,r .0rganizeId
            //            ,o.FullName as oFullName , o. Address ,.Manager ,o.Mobile as oMobile , ma. Password
            //            from Member m
            //            left join RoleInfo r on m.RoleId = r.Id
            //            left join Organize on m.OrganizeId = o.Id
            //            left join MemberAccount ma on ma.Id = m.MemberAccountId) t where t. username = @username and t.password = @password";
            //            LoginInfo stu = new LoginInfo();
            //stu.LogNum = username;
            //stu.LogPwd = Md5Encrypt.Md5(password);
            //XITDataModel1.Default.WriteInfo(stu.LogNum + "--- " + stu.LogPwd);
            //List<LoginInfo> result = DapperDBHelper.Instance.ExcuteQuery<LoginInfo>(sql, stu).ToList();
            XITDataModel1 model = new XITDataModel1();
            List<LoginInfo> list = model.LoginInfo.ToList();
            return list.FirstOrDefault(p => p.LogNum == username && p.LogPwd == password);
        }
    }
}
