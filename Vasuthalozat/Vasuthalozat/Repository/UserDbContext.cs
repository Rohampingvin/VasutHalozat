using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vasuthalozat.models;
using Vasuthalozat.models.Userauth;

namespace Vasuthalozat.Repository
{
    class UserDbContext : DbContext
    {
        private static UserDbContext? userDbContext;

        public static UserDbContext Instance
        {
            get
            {
                if (userDbContext == null)
                {
                    userDbContext = new UserDbContext();
                }
                return userDbContext;
            }
        }

        public DbSet<Users> Users { get; set; }

        private UserDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Vasuthalozat; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

