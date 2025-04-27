using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator.Models
{
    /// <summary>
    /// Represents an Elephant in the Zoo.
    /// </summary>
    public class Elephant : Animal
    {
        public bool CannotWalk { get; private set; }

        public int HoursBelowThreshold { get; private set; }

        public Elephant(string name) : base(name)
        {
            CannotWalk = false;
            HoursBelowThreshold = 0;
        }

        /// <summary>
        /// Checks the health of the Elephant to determine if it can walk or should die.
        /// Cannot walk if health < 70%. If still below after 1 hour, the elephant dies.
        /// </summary>
        public override void CheckIfDead()
        {
            if (!IsAlive) return;

            if (Health < 70)
            {
                if (!CannotWalk)
                {
                    // First time health dropped below threshold
                    CannotWalk = true;
                    HoursBelowThreshold = 1;
                    Console.WriteLine($"🐘 {Name} the Elephant cannot walk due to low health.");
                }
                else
                {
                    HoursBelowThreshold++;
                    if (HoursBelowThreshold > 1)
                    {
                        IsAlive = false;
                        Console.WriteLine($"🐘 {Name} the Elephant has died after remaining weak for too long.");
                    }
                }
            }
            else
            {
                // Regained health
                CannotWalk = false;
                HoursBelowThreshold = 0;
            }
        }
    }
}
