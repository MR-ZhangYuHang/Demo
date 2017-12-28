using MVCDemo.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Repositories;
using PagedList;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class AccountController : Controller
    {
        IsysUserRepository ur = new SysUserRepository();
        private AccountContext db = new AccountContext();
        AccountInitializer ai = new AccountInitializer();
        //
        // GET: /Account/
        public ActionResult Index(string sortOrder,string searchString,string currentFilter,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString!=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var users = from u in db.SysUsers
                        select u;
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.UserName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case"name_desc":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                default:
                    users = users.OrderBy(u => u.UserName);
                    break;
            }
            int pageSize = 3;
            int PageNumber = (page ?? 1);
            return View(users.ToPagedList(PageNumber,pageSize));
        }
        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前。。。";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail3"];
            string passworld = fc["inputPassword3"];
            var user = db.SysUsers.Single(b => b.Email == email & b.Password == passworld);
            var users=from b in db.SysUsers where b.Email==email &&b.Password==passworld select b;
            int i= users.Count();
            if (user!=null)
            {
                ViewBag.LoginState = user.UserName + "登录后";
            }
            else
            {
                ViewBag.LoginState = "用户不存在";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            SysUser sysUser = db.SysUsers.Find(id);
            return View(sysUser);
        }
        //新建用户

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]

        public ActionResult Create(SysUser sysUser)
        {
            ur.Add(sysUser);

            //db.SysUsers.Add(sysUser);

            //db.SaveChanges();

            return RedirectToAction("Index");

        }
        //修改用户

        public ActionResult Edit(int id)
        {

            SysUser sysUser = db.SysUsers.Find(id);

            return View(sysUser);

        }

        [HttpPost]

        public ActionResult Edit(SysUser sysUser)
        {

            db.Entry(sysUser).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");

        }
        //删除用户

        public ActionResult Delete(int id)
        {

            SysUser sysUser = db.SysUsers.Find(id);

            return View(sysUser);

        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            ur.Delete(id);

            //SysUser sysUser = db.SysUsers.Find(id);

            //db.SysUsers.Remove(sysUser);

            //db.SaveChanges();

            return RedirectToAction("Index");

        } 
    }
}