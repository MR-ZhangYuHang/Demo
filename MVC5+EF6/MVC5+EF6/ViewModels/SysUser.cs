using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_EF6.ViewModels
{
    public class SysUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }
    }
}