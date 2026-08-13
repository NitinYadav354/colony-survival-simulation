using System;

namespace ColonySim.Core
{

    public class ColonySimulation
    {
        private readonly int villagerCount;
        private readonly float foodPerVillagerPerDay;
        private readonly float waterPerVillagerPerDay;

        public float FoodStored { get; private set; }
        public float WaterStored { get; private set; }
        public int CurrentDay { get; private set; }

        public float DailyFoodConsumption => villagerCount * foodPerVillagerPerDay;
        public float DailyWaterConsumption => villagerCount * waterPerVillagerPerDay;

        public float FoodDaysRemaining => DailyFoodConsumption > 0f
            ? FoodStored / DailyFoodConsumption
            : float.PositiveInfinity;

        public float WaterDaysRemaining => DailyWaterConsumption > 0f
            ? WaterStored / DailyWaterConsumption
            : float.PositiveInfinity;

        public bool IsFoodStarving => FoodStored <= 0f;
        public bool IsWaterStarving => WaterStored <= 0f;
        public bool IsStarving => IsFoodStarving || IsWaterStarving;

        public ColonySimulation(
            int villagerCount,
            float startingFood,
            float startingWater,
            float foodPerVillagerPerDay,
            float waterPerVillagerPerDay)
        {
            if (villagerCount < 0)
                throw new ArgumentException("villagerCount cannot be negative.", nameof(villagerCount));
            if (startingFood < 0f)
                throw new ArgumentException("startingFood cannot be negative.", nameof(startingFood));
            if (startingWater < 0f)
                throw new ArgumentException("startingWater cannot be negative.", nameof(startingWater));
            if (foodPerVillagerPerDay < 0f)
                throw new ArgumentException("foodPerVillagerPerDay cannot be negative.", nameof(foodPerVillagerPerDay));
            if (waterPerVillagerPerDay < 0f)
                throw new ArgumentException("waterPerVillagerPerDay cannot be negative.", nameof(waterPerVillagerPerDay));

            this.villagerCount = villagerCount;
            this.foodPerVillagerPerDay = foodPerVillagerPerDay;
            this.waterPerVillagerPerDay = waterPerVillagerPerDay;

            FoodStored = startingFood;
            WaterStored = startingWater;
            CurrentDay = 0;
        }

        public static ColonySimulation FromConfigs(PopulationConfig population, ConsumptionConfig consumption)
        {
            if (population == null) throw new ArgumentNullException(nameof(population));
            if (consumption == null) throw new ArgumentNullException(nameof(consumption));

            return new ColonySimulation(
                population.villagerCount,
                population.startingFood,
                population.startingWater,
                consumption.foodPerVillagerPerDay,
                consumption.waterPerVillagerPerDay);
        }

        public void AdvanceDay()
        {
            FoodStored = Math.Max(0f, FoodStored - DailyFoodConsumption);
            WaterStored = Math.Max(0f, WaterStored - DailyWaterConsumption);
            CurrentDay++;
        }
    }
}