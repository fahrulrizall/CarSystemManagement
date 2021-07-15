using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        //public DbSet<CarDetails> CarDetails { get; set; } 
        public DbSet<CarOwner> CarOwner { get; set; }
        public DbSet<CarServices> CarServices { get; set; }
        public DbSet<Mechanics> Mechanics { get; set; }
    }
}
