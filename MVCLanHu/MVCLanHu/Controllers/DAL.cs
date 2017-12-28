using MVCLanHu.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCLanHu.Controllers
{
    public class DAL
    {
        public class EFDbContext : DbContext
        {
            public DbSet<Product> Products { get; set; }
        }
    }
}