using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.DAL;
using MVCDemo.Models;
using System.Transactions;

namespace MVCDemo.Repositories
{
    public class SysUserRepository:IsysUserRepository
    {
        protected AccountContext db = new AccountContext();
        //查询所有用户
        public IQueryable<SysUser> SelectAll()
        {
            return db.SysUsers;
        }
        //通过用户名查询用户
        public SysUser SelectByName(string userName)
        {
            return db.SysUsers.FirstOrDefault(u => u.UserName == userName);
        }
        //添加用户，事务TransactionScope
        public void Add(SysUser sysUser)
        {
            using (var tran = new TransactionScope())
            {
                db.SysUsers.Add(sysUser);
                db.SaveChanges();
                tran.Complete();
            }
        }
        //删除用户,事务BeginTransaction()
        public bool Delete(int id)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
 var delSysUser = db.SysUsers.FirstOrDefault(u => u.ID == id);
            if (delSysUser!=null)
            {
                db.SysUsers.Remove(delSysUser);
                db.SaveChanges();
                tran.Commit();
                return true;
            }
            else
                return false;
            }
            catch (Exception ex)
            {

                tran.Rollback();
                return false;
            }
            //使用SqlParameter传值可以避免SQL注入,ef使用sql语句
           // var p_name = new SqlParameter("@name", "萝莉");
           // var p_age = new SqlParameter("@age", 13);
            //更改学生年龄
           // result = db.Database.ExecuteSqlCommand(@"UPDATE `test`.`student`
            //                               SET `age` = @age
            //                               WHERE `name` = @name;", p_age, p_name);


            //查询叫萝莉的学生信息，并指定返回值类型为student
            //DbRawSqlQuery<student> result1 = db.Database.SqlQuery<student>("SELECT  * FROM test.student WHERE name = '萝莉'");
            //也可以这样指定返回值类型
            //DbRawSqlQuery result1 = db.Database.SqlQuery(typeof(student), "SELECT  * FROM test.student WHERE name = '萝莉'");
            //Console.WriteLine(result1.FirstOrDefault().name); //打印姓名

            //using (var db = new DBModel())  //创建数据库上下文
            //{
            //    查询叫萝莉的学生信息，并修改她的年龄
            //    student result1 = db.students.SqlQuery("SELECT  * FROM test.student WHERE name = '萝莉'").FirstOrDefault();
            //    result1.age = 13;   //通过实体集合下.SqlQuery查询到的数据，修改之后是可以保存到数据库的
            //    student result2 = db.Database.SqlQuery<student>("SELECT  * FROM test.student WHERE name = '旺财'").FirstOrDefault();
            //    result2.age = 21;   //因为使用的是.Database.SqlQuery查询到的，所以这里的修改不会保存到数据库
            //    .Database.SqlQuery下查出的数据在修改后也能保存到数据库
            //    student result3 = db.Database.SqlQuery<student>("SELECT  * FROM test.student WHERE name = '小明'").FirstOrDefault();
            //    result3.age = 36;
            //    db.Entry<student>(result3).State = System.Data.Entity.EntityState.Modified; //通知数据上下文，这条记录也被修改了
            //    db.SaveChanges();
            //}
        }
    }
}