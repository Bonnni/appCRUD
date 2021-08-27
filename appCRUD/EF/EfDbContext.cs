using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appCRUD.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace appCRUD.EF
{
    class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = "Server = DESKTOP - QNIVVVU\\SQLEXPRESS; Database = User; Trusted_Connection = True";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(path);
            }
        }
    }
}
