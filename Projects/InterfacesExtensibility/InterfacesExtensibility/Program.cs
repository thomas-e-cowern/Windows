using System;
namespace InterfacesExtensibility
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }
    }
    public interface ILogger
    {
        void LogError(string message);  // method
        void LogInfo(string message);  // method
    }
    public class DbMigrator
    {
        private readonly ILogger _logger;
        public DbMigrator(ILogger logger)
        {
            _logger = logger;
        }
        public void Migrate()
        {
            _logger.LogInfo($"Migrating started at {DateTime.Now}");
            _logger.LogInfo($"Migrating ended at {DateTime.Now}");
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _path;
        public FileLogger(string path)
        {
            _path = path;
        }
        public void LogError(string message)
        {
            Log(message, "ERROR");
        }
        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }
        private void Log(string message, string messageType)
        {
            using (var streamWriter = new System.IO.StreamWriter(_path, true))
            {
                streamWriter.WriteLine(messageType + ": " + message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dbMigrator = new DbMigrator(new ConsoleLogger());
            dbMigrator.Migrate();

            var dbMigrator2 = new DbMigrator(new FileLogger("log.txt"));
            dbMigrator2.Migrate();

            Console.WriteLine("\npress any key to exit...");
            Console.ReadKey();
        }
    }
}