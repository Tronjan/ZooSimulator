using System;
using System.Threading.Tasks;

namespace ZooSimulator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Zoo zoo = new Zoo();
            Console.WriteLine(":) Welcome to the Zoo Simulator!");
            Console.WriteLine("Time advances by 1 hour every 20 seconds.");
            Console.WriteLine("Press [F] to feed the animals anytime.");
            Console.WriteLine("Press [Q] to quit.\n");

            zoo.DisplayAnimalStatus();

            while (true)
            {
                var startTime = DateTime.Now;

                // Run a 20 second interval
                while ((DateTime.Now - startTime).TotalSeconds < 20)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(intercept: true).Key;

                        if (key == ConsoleKey.F)
                        {
                            zoo.FeedAnimals();
                        }
                        else if (key == ConsoleKey.Q)
                        {
                            Console.WriteLine("\n :( Exiting Zoo Simulator. Goodbye!");
                            return;
                        }
                    }

                    // Add Delay
                    await Task.Delay(100);
                }

                zoo.AdvanceTime();
            }
        }
    }
}
