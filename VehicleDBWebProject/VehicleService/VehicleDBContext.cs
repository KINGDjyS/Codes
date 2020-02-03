using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleService
{
    public class VehicleDBContext : DbContext
    {
        public VehicleDBContext()
        {
        }
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options) : base(options)
        {
        } 
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localDB)\\mssqllocaldb;Database=VehicleDBContext;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleMake>().ToTable("VehicleMakers");
            modelBuilder.Entity<VehicleModel>().ToTable("VehicleModels");
        }

        /*private static DbContextOptions GetOptions(string connectionString)
        {
            var modelBuilder = new DbContextOptionsBuilder();
            return modelBuilder.UseSqlServer(connectionString).Options;
        }*/
    }
}
