using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wachowski.ProjectsManager.Models;

namespace Wachowski.ProjectsManager.Data
{
    public class WachowskiProjectsManagerContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public WachowskiProjectsManagerContext (DbContextOptions<WachowskiProjectsManagerContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("WachowskiProjectsManagerContext"));
        }

        public DbSet<Wachowski.ProjectsManager.Models.Project> Projects { get; set; }

        public DbSet<Wachowski.ProjectsManager.Models.Person> Members { get; set; }
    }
}
