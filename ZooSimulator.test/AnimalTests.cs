using Xunit;
using ZooSimulator.Models;

namespace ZooSimulator.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void ReduceHealth_ShouldDecreaseCorrectly()
        {
            var monkey = new Monkey("Test Monkey");
            monkey.ReduceHealth(20); // Reduce 20% of current health
            Assert.True(monkey.Health < 100);
        }

        [Fact]
        public void IncreaseHealth_ShouldIncreaseCorrectly()
        {
            var giraffe = new Giraffe("Test Giraffe");
            giraffe.ReduceHealth(50); // First lower health to 50%
            giraffe.IncreaseHealth(20); // Increase 20% of current health
            Assert.True(giraffe.Health > 50 && giraffe.Health <= 100);
        }

        [Fact]
        public void Monkey_ShouldDieBelow30PercentHealth()
        {
            var monkey = new Monkey("Test Monkey");
            monkey.ReduceHealth(80); // Make health 20
            monkey.CheckIfDead();
            Assert.False(monkey.IsAlive);
        }

        [Fact]
        public void Giraffe_ShouldDieBelow50PercentHealth()
        {
            var giraffe = new Giraffe("Test Giraffe");
            giraffe.ReduceHealth(60); // Make health 40
            giraffe.CheckIfDead();
            Assert.False(giraffe.IsAlive);
        }

        [Fact]
        public void Elephant_ShouldCannotWalkAndDieProperly()
        {
            var elephant = new Elephant("Test Elephant");
            elephant.ReduceHealth(40); // Health now 60%
            elephant.CheckIfDead();

            Assert.True(elephant.CannotWalk);
            Assert.True(elephant.IsAlive);

            // Simulate next hour
            elephant.CheckIfDead(); // Check again
            Assert.False(elephant.IsAlive);
        }
    }
}
