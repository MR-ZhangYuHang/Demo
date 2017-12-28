
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCDemo.DAL
{
    public class AccountInitializer : DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var sysUsers = new List<SysUser>
            {
                new SysUser{UserName="TOM",Email="123@qq.com",Password="123456"},
                new SysUser{UserName="Jerry",Email="111@qq.com",Password="123456"}

            };
            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();
            var sysRoles = new List<SysRole>
            {
                new SysRole{RoleName="学院组",RoleDesc="111"},
                new SysRole{RoleName="企业组",RoleDesc="222"}
            };
            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();
        }
    }
}