using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HighWayCodeTraining.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=DBContext; Trusted_Connection = True; MultipleActiveResultSets = True; Application Name=EntityFrameworkMUE;");
            optionsBuilder.UseInternalServiceProvider(IServiceCollection services);
        } */

        protected override void OnModelCreating(ModelBuilder model)
        {
           
            model.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .IsRequired();
            model.Entity<Question>()
                .HasOne(q => q.Image)
                .WithOne(o => o.Question)
                .IsRequired();

        } 

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
