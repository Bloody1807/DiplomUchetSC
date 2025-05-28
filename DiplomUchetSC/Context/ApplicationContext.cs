using DiplomUchetSC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomUchetSC.Context
{
    public class ApplicationContext: DbContext
    {
        public static ApplicationContext Instance { get; } = new();

        public DbSet<User> Users { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-JHDTFKK\\SQLEXPRESS;Database=ServiceCenter_db;Trusted_Connection=true;Encrypt=false");
        }
    }
}
