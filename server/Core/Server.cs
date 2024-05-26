using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.Configuration;
using Server.Core.Factories;
using Server.Core.Services;
using Server.Database.Controller;
using System.Diagnostics;

namespace Server.Core
{
    public class Server : AsyncResource {

        public Server() : base(true) { }

        private static IConfigurationRoot? Configuration = null;

        public async override void OnStart() {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            LogService.Log("Server", "Starting Resource...");

            LogService.Log("Server", "Loading Settings...");
            if (!InitializeConfiguration()) {
                LogService.LogError("Server", "Failed to load appsettings.json.");
                LogService.LogError("Server", "Stopping Ressource...");

                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            LogService.Log("Server", "Loaded Settings successfully");

            LogService.Log("Server", "Checking Database Connection...");
            if (!await DatabaseController.CheckConnection()) {
                LogService.LogError("Server", "Failed to connect to database.");
                LogService.LogError("Server", "Stopping Ressource...");

                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            LogService.Log("Server", "Database Connection established");

            stopwatch.Stop();
            LogService.Log("Server", $"Resource started in {stopwatch.ElapsedMilliseconds}ms.");
        }

        public async override void OnStop() {
            throw new NotImplementedException();
        }

        public override IEntityFactory<IPlayer> GetPlayerFactory() {
            return new PlayerFactory();
        }

        public override IEntityFactory<IVehicle> GetVehicleFactory() {
            return new VehicleFactory();
        }

        private static bool InitializeConfiguration() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Alt.Core.Resource.Path)
                .AddJsonFile("server/appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            return Configuration != null;
        }

        public static IConfigurationRoot? GetConfiguration() {
            return Configuration;
        }
    }
}
