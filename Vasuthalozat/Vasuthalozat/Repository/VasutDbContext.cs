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
        public DbSet<cities> cities { get; set;}
        public DbSet<Railways> Railyways { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
