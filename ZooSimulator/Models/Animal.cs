using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator.Models
{
    /// <summary>
    /// Represents a generic Animal in the Zoo.
    /// </summary>
    public abstract class Animal
    {

        public string Name { get; set; }

        public double Health { get; set; }

        public bool IsAlive { get; set; }

        public Animal(string name)
        {
            Name = name;
            Health = 100.0;
            IsAlive = true;
        }

        /// <summary>
        /// Reduces the animal's health by the given percentage of its current health.
        /// </summary>
        /// <param name="healhLoss">Percentage (0-100) of the current health to reduce.</param>
        public void ReduceHealth(double healhLoss)
        {
            if (!IsAlive)
            {
                return;
            }

            double lossHealth = (Health * healhLoss) / 100;
            Health -= lossHealth;
            Health = Math.Max(0, Health); // Prevent negative health
        }

        /// <summary>
        /// Increases the animal's health by the given percentage of its current health.
        /// Health is capped at 100%.
        /// </summary>
        /// <param name="healthGain">Percentage (0-100) of the current health to increase.</param>
        public void IncreaseHealth(double healthGain)
        {
            if (!IsAlive)
            {
                return;
            }

            double gainHealth = (Health * healthGain) / 100;
            Health += gainHealth;
            Health = Math.Min(100, Health); // Cap health at 100%
        }

        /// <summary>
        /// Checks if the animal should be considered dead based on its health.
        /// This is implemented differently by each specific animal type.
        /// </summary>
        public abstract void CheckIfDead();
    }
}
