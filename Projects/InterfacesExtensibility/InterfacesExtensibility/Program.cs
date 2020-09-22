using System;
using System.Runtime.InteropServices;

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

        void ILogger.LogUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }
    public interface ILogger
    {
        void LogError(string message);  // method
        void LogInfo(string message);  // method
        void LogUser(string message);  // My added method
    }
    public class DbMigrator
    {
        private readonly ILogger _logger;
        public DbMigrator(ILogger logger)
        {
            _logger = logger;
        }
        public void Migrate(string userMessage)
        {
            _logger.LogInfo($"Migrating started at {DateTime.Now}");
            _logger.LogInfo($"Migrating ended at {DateTime.Now}");
            _logger.LogUser(userMessage);
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
        public void LogUser(string message)
        {
            Log(message, "USER");
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
            Console.WriteLine("Please enter a comment for the file...");
            string myText = Console.ReadLine();

            var dbMigrator = new DbMigrator(new ConsoleLogger());
            dbMigrator.Migrate(myText);

            var dbMigrator2 = new DbMigrator(new FileLogger("log.txt"));
            dbMigrator2.Migrate(myText);

            Console.WriteLine("\npress any key to exit...");
            Console.ReadKey();
        }
    }
}