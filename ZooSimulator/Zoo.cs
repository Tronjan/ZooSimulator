using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooSimulator.Models;

namespace ZooSimulator
{
    /// <summary>
    /// Represents the Zoo which contains and manages all animals.
    /// Handles time progression, feeding, and health updates.
    /// </summary>
    public class Zoo
    {
        public int CurrentHour { get; private set; }

        public List<Animal> Animals { get; private set; }

        private readonly Random random;

        public Zoo()
        {
            CurrentHour = 0;
            Animals = new List<Animal>();
            random = new Random();
            InitializeAnimals();
        }


        private void InitializeAnimals()
        {
            for (int i = 1; i <= 5; i++)
            {
                Animals.Add(new Monkey($"Monkey {i}"));
                Animals.Add(new Giraffe($"Giraffe {i}"));
                Animals.Add(new Elephant($"Elephant {i}"));
            }
        }

        /// <summary>
        /// Advances the zoo's time by 1 hour.
        /// Each animal loses a random percentage (0–20%) of its current health.
        /// After health reduction, each animal is checked for death conditions.
        /// </summary>
        public void AdvanceTime()
        {
            CurrentHour++;
            Console.WriteLine($"\n Hour {CurrentHour} - Update");

            foreach (var animal in Animals)
            {
                if (!animal.IsAlive) continue;

                double percentLoss = random.Next(0, 21); // 0 to 20
                animal.ReduceHealth(percentLoss);
                animal.CheckIfDead();
            }

            DisplayAnimalStatus();
        }

        /// <summary>
        /// Feeds all animals in the zoo.
        /// Each animal type receives a random health gain between 10–25%.
        /// </summary>
        public void FeedAnimals()
        {
            Console.WriteLine("\n Time to Feed!");

            double monkeyGain = random.Next(10, 26);
            double giraffeGain = random.Next(10, 26);
            double elephantGain = random.Next(10, 26);

            foreach (var animal in Animals)
            {
                if (!animal.IsAlive) continue;

                if (animal is Monkey)
                    animal.IncreaseHealth(monkeyGain);
                else if (animal is Giraffe)
                    animal.IncreaseHealth(giraffeGain);
                else if (animal is Elephant)
                    animal.IncreaseHealth(elephantGain);
            }

            Console.WriteLine($"Health status increased after feeding: Monkeys +{monkeyGain}%, Giraffes +{giraffeGain}%, Elephants +{elephantGain}%");
            DisplayAnimalStatus();
        }

       
        public void DisplayAnimalStatus()
        {
            Console.WriteLine($"\n{"~".PadLeft(60, '~')}");
            Console.WriteLine($"Zoo Hour: {CurrentHour}".PadRight(30) + "|       Zoo Status Report");
            Console.WriteLine("~".PadLeft(60, '~'));

            DisplayGroup("[Monkey] Monkeys", typeof(Monkey));
            DisplayGroup("[Giraffe] Giraffes", typeof(Giraffe));
            DisplayGroup("[Elephant] Elephants", typeof(Elephant));

            Console.WriteLine("~".PadLeft(60, '~'));
            Console.WriteLine("Press [F] to feed animals | Press [Q] to quit");
            Console.WriteLine("~".PadLeft(60, '~'));
        }

        private void DisplayGroup(string header, Type animalType)
        {
            Console.WriteLine($"\n{header}:");

            foreach (var animal in Animals)
            {
                if (animal.GetType() == animalType)
                {
                    if (!animal.IsAlive)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"  - {animal.Name}: Dead");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (animal is Elephant elephant && elephant.CannotWalk)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"  - {animal.Name}: Cannot Walk - {animal.Health:F2}% health");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"  - {animal.Name}: Alive - {animal.Health:F2}% health");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }
    }
}
