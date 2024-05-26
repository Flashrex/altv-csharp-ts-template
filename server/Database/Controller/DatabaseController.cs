

using Server.Core.Services;

namespace Server.Database.Controller {
    public class DatabaseController {

        public static async Task<bool> CheckConnection() {
            using var dbContext = new DatabaseContext();
            try {
                if (await dbContext.Database.CanConnectAsync()) {
                    return true;
                }
                return false;
            } catch (Exception e) {
                LogService.LogError("Database", "Database connection failed: ");
                LogService.LogError("Database", e.Message);
                return false;
            }
        }
    }
}
