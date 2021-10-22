﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class CarContext : DbContext //Db tabloları ile classlarını bağladık.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB ; Database=CarDB ;Trusted_Connection=true ");
        }
        public DbSet<Car> Cars { get; set; }

    }
}
 