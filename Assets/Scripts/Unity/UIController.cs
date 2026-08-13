using UnityEngine;
using TMPro;
using ColonySim.Core;

namespace ColonySim.Unity
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TMP_Text dayCounterText;
        [SerializeField] private TMP_Text foodStoredText;
        [SerializeField] private TMP_Text waterStoredText;
        [SerializeField] private TMP_Text foodDaysRemainingText;
        [SerializeField] private TMP_Text waterDaysRemainingText;
        [SerializeField] private GameObject starvingBanner;

        public void UpdateDisplay(ColonySimulation simulation)
        {
            dayCounterText.text = $"Day {simulation.CurrentDay}";

            foodStoredText.text = $"Food: {simulation.FoodStored:F1}";
            waterStoredText.text = $"Water: {simulation.WaterStored:F1}";

            foodDaysRemainingText.text = $"Food days remaining: {FormatDaysRemaining(simulation.FoodDaysRemaining)}";
            waterDaysRemainingText.text = $"Water days remaining: {FormatDaysRemaining(simulation.WaterDaysRemaining)}";

            starvingBanner.SetActive(simulation.IsStarving);
        }

        private static string FormatDaysRemaining(float days)
        {
            return float.IsPositiveInfinity(days) ? "\u221e" : days.ToString("F1");
        }
    }
}