
using Game.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Game.Domain.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDevice>().HasKey(p => new { p.DeviceId, p.GameId });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2848GVF;Database=GameApp;Trusted_Connection=True;Integrated Security=true;Encrypt=False;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<GameEntity> Games { get; set; }  
        public DbSet<GameDevice> GameDevices { get; set; }
    }
}
