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
   public class UserDbContext : DbContext
    {
        private static UserDbContext? userContext;

        public static UserDbContext Instance
        {
            get
            {
                if (userContext == null)
                {
                    userContext = new UserDbContext();
                }
                return userContext;
            }
        }

        public DbSet<User> Users { get; set; }

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

