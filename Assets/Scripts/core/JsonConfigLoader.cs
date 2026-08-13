using System.IO;
using UnityEngine;
using ColonySim.Core;

namespace ColonySim.Unity
{
    public static class JsonConfigLoader
    {
        public static PopulationConfig LoadPopulationConfig(string fileName = "population.json")
        {
            return LoadConfig<PopulationConfig>(fileName);
        }

        public static ConsumptionConfig LoadConsumptionConfig(string fileName = "consumption.json")
        {
            return LoadConfig<ConsumptionConfig>(fileName);
        }

        private static T LoadConfig<T>(string fileName)
        {
            string path = Path.Combine(Application.streamingAssetsPath, fileName);

            if (!File.Exists(path))
                throw new FileNotFoundException($"Config file not found: {path}");

            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }
    }
}