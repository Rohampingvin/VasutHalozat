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
        public DbSet<Cities> cities { get; set;}
        public DbSet<Railways> Railyways { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vasuthalozat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
