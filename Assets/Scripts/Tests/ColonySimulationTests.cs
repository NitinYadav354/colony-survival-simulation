using NUnit.Framework;
using ColonySim.Core;

namespace ColonySim.Tests
{
    public class ColonySimulationTests
    {
        [Test]
        public void AdvanceDay_ThreeTimes_ReducesFoodToSeventy()
        {
            int villagers = 10;
            float startingFood = 100f;
            float startingWater = 100f; 
            float foodPerDay = 1f;
            float waterPerDay = 1f; 

            var sim = new ColonySimulation(villagers, startingFood, startingWater, foodPerDay, waterPerDay);

            sim.AdvanceDay();
            sim.AdvanceDay();
            sim.AdvanceDay();

            Assert.AreEqual(70f, sim.FoodStored);
        }

        [Test]
        public void AdvanceDay_FoodReachesZero_IsStarvingFlipsTrue()
        {
            int villagers = 10;
            float startingFood = 10f; 
            float startingWater = 100f;
            float foodPerDay = 1f;
            float waterPerDay = 1f;

            var sim = new ColonySimulation(villagers, startingFood, startingWater, foodPerDay, waterPerDay);

            Assert.IsFalse(sim.IsStarving);

            sim.AdvanceDay();

            Assert.AreEqual(0f, sim.FoodStored);
            Assert.IsTrue(sim.IsStarving);
        }
    }
}