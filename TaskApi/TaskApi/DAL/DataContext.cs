using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Task>().HasIndex(t => t.Title).IsUnique(); 
        }
        #region DbSets
  
        public DbSet<Task> Tasks { get; set; }
  
        #endregion
    }
}
