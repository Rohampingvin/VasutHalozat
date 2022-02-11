using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vasuthalozat.models;
using Microsoft.EntityFrameworkCore;

namespace Vasuthalozat.Repository
{
    class VasutDbContext : DbContext
    {
        private static VasutDbContext context = null;
        public static VasutDbContext Instance
        {
            get
            {
                if (context == null)
                {
                    context = new VasutDbContext();
                }
                return context;
            }
        }

        private VasutDbContext()
        {

            Database.EnsureCreated();

        }
        public DbSet<Cities> cities { get; set;}
        public DbSet<Railways> Railyways { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vasuthalozat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
