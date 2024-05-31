using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Database.Models;

namespace Server.Database {
    public class DatabaseContext : DbContext {

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            var config = Core.Server.GetConfiguration();

            if (config == null) {
                var basePath = Directory.GetCurrentDirectory();

                var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(basePath + "/appsettings.json", optional: false, reloadOnChange: true);

                config = builder.Build();
            }

            var conString = config["ConnectionString"];
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
