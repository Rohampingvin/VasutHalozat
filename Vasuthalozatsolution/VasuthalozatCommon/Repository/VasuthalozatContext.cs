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

        public DbSet<Cities> Cities { get; set; }
        public DbSet<Railway> Railways { get; set; }

        private VasuthalozatContext()
        {
           
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Vasuthalozat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public void CreateCity(Cities city)
        {
            Instance.Cities.Add(city);
            Instance.SaveChanges();
        }

        public void UpdateCity(Cities city)
        {
            var s = Instance.Cities.FirstOrDefault(r => r.Id == city.Id);
            s.Name = city.Name;
            Instance.SaveChanges();
        }

        public void DeleteCity(Cities city)
        {
            Instance.Cities.Remove(city);
            Instance.SaveChanges();
        }

        public Cities GetCity(Cities city)
        {
            return city;
        }

        public void CreateRailway(Railway railway)
        {
            Instance.Railways.Add(railway);
            Instance.SaveChanges();
        }

        public void UpdateRailways(Railway railway)
        {
            var s = Instance.Railways.FirstOrDefault(r => r.Id == railway.Id);
            s = railway;
            Instance.SaveChanges();
        }

        public void DeleteRailways(Railway railway)
        {
            Instance.Remove(railway);
            Instance.SaveChanges();
        }

        public Railway GetRailways(Railway railway)
        {
            return railway;
        }

        public List<Cities> GetCities()
        {
            var list = Instance.Cities.ToList();
            return list;
        }
        public List<Railway> GetRailways()
        {
            var list = Instance.Railways.ToList();
            return list;
        }
    }
}
