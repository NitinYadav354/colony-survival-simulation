# Colony Survival Prototype

A mobile-first Unity prototype demonstrating a colony survival simulation. The project calculates the depletion of food and water reserves over time using data loaded from JSON configurations, strictly separating pure C# logic from Unity-specific rendering.

## How to open and run the project

1. Open Unity Hub and click **Add** or **Open**.
2. Select the root folder of this repository. 
3. Once the Unity Editor loads, navigate to the Project window.
4. Open the main scene located at `Assets/Scenes/SimulationScene.unity`.
5. Press the **Play** button at the top center of the Editor.
6. The simulation will begin immediately, using an accelerated clock where 1 real second equals 1 game day.

## How to run the unit test(s)

The pure C# simulation logic is covered by Edit Mode unit tests to ensure mathematical accuracy without relying on the Unity game loop.

1. In the Unity Editor, open the Test Runner by navigating to **Window > General > Test Runner**.
2. Expand the test tree to locate `ColonySimulationTests`.
3. Click **Run All** (or select the specific test and click **Run Selected**) to verify the logic.

## AI tools used

*   **Tools:** Claude and Gemini
*   **How they were used:** I used these tools as supplementary assistants to accelerate development. They acted as a sounding board for debugging Editor errors, provided quick syntax reminders throughout the project, and handled minor boilerplate generation.
*   **What I wrote:** As the primary developer, I drove the entire project. I designed the core architecture and hand-coded the pure C# simulation math (`ColonySimulation.cs`, `JsonConfigLoader.cs`), the Unity MonoBehaviours (`GameManager.cs`, `UIController.cs`), the JSON configurations, and the UI Canvas setup.
*   **What the AI generated:** The AI generated the structural skeleton for the NUnit tests based on my provided worked examples, offered step-by-step Editor troubleshooting to resolve a package registry `NullReferenceException`, and provided syntax refreshers.

## Decisions & trade-offs

*   **Architectural Separation:** The core simulation math (`ColonySimulation.cs`) and configuration classes are standard C# classes that do not reference `UnityEngine`, strictly adhering to the architectural rules. The `GameManager.cs` bridges the gap by instantiating the simulation and advancing time.
*   **Post-Starvation State:** The brief explicitly warned against adding extra features. Therefore, I chose not to implement a "Game Over" screen, a time-pausing mechanic, or villager death logic when the colony starves. The simulation clock continues to advance, and the "Colony Starving" UI banner simply remains active as requested.
*   **Minimalist UI:** To respect the time constraints and the instruction to not spend time on art, the UI relies entirely on default TextMeshPro elements and a basic colored image for the starvation banner.