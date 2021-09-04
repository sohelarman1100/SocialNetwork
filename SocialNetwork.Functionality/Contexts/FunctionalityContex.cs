using Microsoft.EntityFrameworkCore;
using SocialNetwork.Functionality.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.Contexts
{
    public class FunctionalityContext : DbContext, IFunctionalityContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public FunctionalityContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
