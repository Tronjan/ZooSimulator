using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator.Models
{
    /// <summary>
    /// Represents a Monkey in the Zoo.
    /// </summary>
    public class Monkey : Animal
    {
        public Monkey(string name) : base(name)
        {
        }

        /// <summary>
        /// Checks if the Monkey should be considered dead based on its health.
        /// If health falls below 30%, the monkey dies immediately.
        /// </summary>
        public override void CheckIfDead()
        {
            if (IsAlive && Health < 30)
            {
                IsAlive = false;
                Console.WriteLine($"🐒 {Name} the Monkey has died.");
            }
        }
    }
}
