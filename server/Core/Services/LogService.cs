using AltV.Net;

namespace Server.Core.Services {
    public class LogService {

        public static void Log(string sender, string message) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"[{DateTime.Now.ToLongTimeString()}] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{sender}] {message}\n");
        }

        public static void LogError(string sender, string message) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[{DateTime.Now.ToLongTimeString()}] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{sender}] {message}\n");
        }

        public static void LogWarning(string sender, string message) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"[{DateTime.Now.ToLongTimeString()}] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{sender}] {message}\n");
        }

        /// <summary>
        /// Schreibt den gegebenen Text in den gegebenen Dateipfad.
        /// <para>Erstellt automatisch einen Ordner + Datei falls nicht vorhanden.</para>
        /// </summary>
        /// <param name="path">Name des Pfads</param>
        /// <param name="filename">Name der Datei</param>
        /// <param name="input">Text zum speichern</param>
        public static async Task<bool> WriteInLogFileAsync(string path, string filename, string text) {
            var serverName = Server.GetConfiguration()?["ServerName"];

            if (serverName == null) {
                LogError("Logging", "Error reading Configuration File.");
                return false;
            }

            if (!Directory.Exists(Alt.Core.Resource.Path + $"/{serverName}/" + path)) {
                Directory.CreateDirectory(Alt.Core.Resource.Path + $"/{serverName}/" + path);
            }

            string line = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] {text}";

            using StreamWriter file =
            new StreamWriter(@$"{Alt.Core.Resource.Path}\{serverName}\" + path + "\\" + filename + ".txt", true);
            await file.WriteLineAsync(line);
            return true;
        }
    }
}
