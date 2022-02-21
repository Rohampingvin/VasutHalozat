using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VasuthalozatCommon.Model;

namespace VasuthalozatCommon.Repository
{
    public class VasuthalozatContext : DbContext
    {
        private static VasuthalozatContext context = null;
        public static VasuthalozatContext Instance {
            get
            {
                if (context == null)
                {
                    context = new VasuthalozatContext();
                }
                return context;
            }
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Railway> Railways { get; set; }

        private VasuthalozatContext()
        {
           
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vasuthalozat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
