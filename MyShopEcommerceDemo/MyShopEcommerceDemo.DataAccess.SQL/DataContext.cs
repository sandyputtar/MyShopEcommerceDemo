using MyShopEcommerceDemo.core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopEcommerceDemo.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection"){
            
            }
        public DbSet<Product> product { get; set; }
        public DbSet<ProductCategory> productcategory { get; set; }
    }
}
