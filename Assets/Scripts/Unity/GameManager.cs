using UnityEngine;
using ColonySim.Core;

namespace ColonySim.Unity
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIController uiController;

        [Tooltip("Real seconds per game day. 1 = the trial brief's accelerated clock.")]
        [SerializeField] private float secondsPerGameDay = 1f;

        private ColonySimulation simulation;
        private float timeSinceLastDay;

        private void Start()
        {
            PopulationConfig population = JsonConfigLoader.LoadPopulationConfig();
            ConsumptionConfig consumption = JsonConfigLoader.LoadConsumptionConfig();

            simulation = ColonySimulation.FromConfigs(population, consumption);

            uiController.UpdateDisplay(simulation);
        }

        private void Update()
        {
            if (simulation == null)
                return;

            timeSinceLastDay += Time.deltaTime;

            if (timeSinceLastDay >= secondsPerGameDay)
            {
                timeSinceLastDay -= secondsPerGameDay;
                simulation.AdvanceDay();
                uiController.UpdateDisplay(simulation);
            }
        }
    }
}