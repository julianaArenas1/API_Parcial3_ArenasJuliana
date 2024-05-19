using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using TaskApi.DAL.Entities;

namespace TaskApi.DAL
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Task1>().HasIndex(t => t.Title).IsUnique(); 
        }
        #region DbSets
  
        public DbSet<Task1> Tasks { get; set; }
  
        #endregion
    }
}
