using Microsoft.EntityFrameworkCore;
using MyApplication.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.DataAccessLayer.DataContext
{
    public class MyApplicationDbContext : DbContext
    {
        //public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options)
        //    : base(options)
        //{

        //}
        private readonly string connectionString;

        public MyApplicationDbContext(string con)
        {
            connectionString = con;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MovieDb");
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
