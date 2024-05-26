
using Microsoft.EntityFrameworkCore;
using Server.Core.Entities;
using Server.Database.Models;

namespace Server.Database.Controller {
    public class AccountController {

        public static async Task<uint> IsRegisteredAsync(Player player) {
            using var db = new DatabaseContext();

            var account = await db.Accounts.FirstOrDefaultAsync(x => x.Username == player.DisplayName);
            return account != null ? account.Id : 0;
        }

        public static async Task<bool> CheckPasswordAsync(Player player, string password) {
            using var db = new DatabaseContext();

            var account = await db.Accounts.FirstOrDefaultAsync(x => x.Id == player.Db_Id);
            if (account == null) return false;

            return BCrypt.Net.BCrypt.Verify(password, account.Password);
        }

        public static async Task CreateAsync(Player player, string username, string password) {
            using var db = new DatabaseContext();

            var account = db.Accounts.Add(new Account {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                LastLogin = DateTime.Now
            });

            await db.SaveChangesAsync();
            player.Db_Id = account.Entity.Id;
        }

        public static async Task LoadAsync(Player player) {
            if (!player.IsLoggedIn) return;
            using var db = new DatabaseContext();

            var account = await db.Accounts.FirstOrDefaultAsync(u => u.Id == player.Db_Id);
            if (account == null) return;

            player.DisplayName = account.Username;
            account.LastLogin = DateTime.Now;

            await db.SaveChangesAsync();
        }

        public static async Task SaveAsync(Player player) {
            if (!player.IsLoggedIn) return;
            using var db = new DatabaseContext();

            var account = await db.Accounts.FirstOrDefaultAsync(u => u.Id == player.Db_Id);
            if(account == null) return;

            account.Username = player.DisplayName;
            account.UpdatedAt = DateTime.Now;

            await db.SaveChangesAsync();
        }
    }
}
