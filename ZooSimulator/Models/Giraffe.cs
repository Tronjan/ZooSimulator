using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator.Models
{
    /// <summary>
    /// </summary>
    public class Giraffe : Animal
    {
        public Giraffe(string name) : base(name)
        {
        }

        /// <summary>
        /// Checks if the Giraffe should be considered dead based on its health.
        /// If health falls below 50%, the giraffe dies immediately.
        /// </summary>
        public override void CheckIfDead()
        {
            if (IsAlive && Health < 50)
            {
                IsAlive = false;
                Console.WriteLine($"🦒 {Name} the Giraffe has died.");
            }
        }
    }
}
