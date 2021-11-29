using Microsoft.Extensions.Logging;
using System;

namespace sample_stryker
{
    class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();

            var mathOperations = new MathOperations();
            var collectionOperations = new CollectionOperations();

            logger.LogInformation("Start sum. Press any key");
            Console.ReadLine();

            var sum = mathOperations.Sum(1, 2);

            if (sum == 0)
            {
                return;
            }

            logger.LogInformation("Start division. Press any key");
            Console.ReadLine();

            var division = mathOperations.Division(1, 0);

            if (division == 0)
                return;

            logger.LogInformation("Insert a number between 0 and 6");
            var dayNumber = Console.ReadLine();

            if (dayNumber is null || dayNumber is string) return;

            Console.WriteLine(collectionOperations.GetDayOfWeek(int.Parse(dayNumber)));
        }
    }
}
