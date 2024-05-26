using Microsoft.EntityFrameworkCore;
using Server.Database.Models;

namespace Server.Database {
    public class DatabaseContext : DbContext {

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            var conString = Core.Server.GetConfiguration()?["ConnectionString"];
            optionsBuilder.UseMySql(conString, ServerVersion.AutoDetect(conString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Account>(u => {
                u.HasKey(u => u.Id);
                u.Property(u => u.Username).IsRequired();
                u.Property(u => u.Password).IsRequired();
            });
        }
    }
}
