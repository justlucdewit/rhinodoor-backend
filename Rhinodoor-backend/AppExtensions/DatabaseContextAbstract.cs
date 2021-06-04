using Microsoft.EntityFrameworkCore;
using Rhinodoor_backend.Models;

namespace Rhinodoor_backend.AppExtensions
{
    public class DatabaseContextAbstract : DbContext
    {
        public DatabaseContextAbstract(DbContextOptions<DatabaseContextAbstract> options) : base(options)
        {
        }

        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorOption> DoorOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DoorColor> DoorColors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Doors
            modelBuilder.Entity<Door>().ToTable("Doors");

            // DoorOptions
            modelBuilder.Entity<DoorOption>().ToTable("DoorOptions");
            modelBuilder.Entity<DoorOption>().HasOne(x => x.Door).WithMany(x => x.DoorOptions).HasForeignKey(x => x.DoorId);

            // Orders
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().HasOne(x => x.Door).WithMany(x => x.Orders).HasForeignKey(x => x.DoorId);
            modelBuilder.Entity<Order>().HasOne(x => x.PlacedByUser).WithOne(x => x.Order).HasForeignKey<Order>(x => x.PlacedBy);
            //modelBuilder.Entity<Order>().HasOne(x => x.DoorOption).WithMany(x => x.Orders).HasForeignKey(x => x.DoorOptionId);
            modelBuilder.Entity<Order>().HasOne(x => x.DoorColor).WithMany(x => x.Orders).HasForeignKey(x => x.DoorColorId).OnDelete(DeleteBehavior.NoAction);

            // Users
            modelBuilder.Entity<User>().ToTable("Users");
            
            // DoorColors
            modelBuilder.Entity<DoorColor>().ToTable("DoorColors");
            modelBuilder.Entity<DoorColor>().HasOne(x => x.Door).WithMany(x => x.DoorColors).HasForeignKey(x => x.DoorId);
        }
    }
}