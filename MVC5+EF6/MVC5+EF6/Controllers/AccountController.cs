using MVC5_EF6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_EF6.Controllers
{
    public class AccountController : Controller
    {
        private AccountContext db = new AccountContext();
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View(db.SysUsers);
        }
        
        public ActionResult Login(FormCollection fc)
        {
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];
            if (email!=null)
            {
                var user = db.SysUsers.Where(b => b.Email == email & b.Pasword == password);
                if (user.Count() > 0)
                {
                    ViewBag.LoginState = email + "登录后---";
                }
                else
                {
                    ViewBag.LoginState = email + "用户不存在---";
                }
            }
            
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            SysUser sysUser = db.SysUsers.Find(id);
            return View(sysUser);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateNew(SysUser sysUser)
        {

            db.SysUsers.Add(sysUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}