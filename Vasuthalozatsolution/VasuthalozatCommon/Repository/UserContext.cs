using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VasuthalozatCommon.Model.UserHandling;

namespace VasuthalozatCommon.Repository
{
    public class UserContext : DbContext
    {
        private static UserContext? userContext;

        public static UserContext Instance
        {
            get
            {
                if (userContext == null)
                {
                    userContext = new UserContext();
                }
                return userContext;
            }
        }

        public DbSet<User> Users { get; set; }

        private UserContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VasuthalozatUser; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
