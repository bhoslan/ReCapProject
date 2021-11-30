using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class CarContext : DbContext //Db tabloları ile classlarını bağladık. Amacımız veri tabanında işler yapmak.
    {//
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB ; Database=CarDB ;Trusted_Connection=true ");
        }
        public DbSet<Car> Cars { get; set; } //Veri tabanındaki Cars ile car sınıfını eşleştirdik. 
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }

    }
}
 