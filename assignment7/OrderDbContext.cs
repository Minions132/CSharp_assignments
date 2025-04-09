using Microsoft.EntityFrameworkCore;

namespace OrderManagement_Win{
    public class OrderDbContext : DbContext{
        public DbSet<Order> Orders {get; set;}
        public OrderDbContext() {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string connectionString = "Server=localhost;Database=OrderManagement;User=root;Password=wyo269kxnsn@";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Order>().ToTable("Orders");
        }
    }
}