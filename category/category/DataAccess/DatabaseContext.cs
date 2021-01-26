using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using category.Model;
using category;
using Microsoft.EntityFrameworkCore;
using Product = category.Model.Product;
using ProductModel = category.ProductModel;

namespace category.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
