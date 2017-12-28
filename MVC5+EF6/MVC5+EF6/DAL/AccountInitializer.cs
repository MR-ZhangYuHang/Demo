using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5_EF6.ViewModels
{
    public class AccountInitializer:DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var sysUsers = new List<SysUser>
            {
                new SysUser{UserName="jon",Email="123@qq.com",Pasword="1"},
                new SysUser{UserName="jerry",Email="456@qq.com",Pasword="2"}
            };
            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();
            var sysRoles=new List<SysRole>
            {
                new SysRole{RoleName="123",RoleDesc="111"},
                new SysRole{RoleName="456",RoleDesc="222"}
            };
            sysUsers.ForEach(s=>context.SysUsers.Add(s));
            context.SaveChanges();
        }
    }
}