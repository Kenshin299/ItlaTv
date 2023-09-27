using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ItlaTVDbContext : DbContext
    {
        public ItlaTVDbContext(DbContextOptions<ItlaTVDbContext> options) : base(options)
        {
        }

        public DbSet<Series> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}