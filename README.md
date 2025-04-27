**🦁 Zoo Simulator — Quick Summary**
**📄 Overview**
The Zoo Simulator is a C# Console Application that simulates a zoo containing Monkeys, Giraffes, and Elephants.
Animals lose health over time and must be fed to stay alive.
Specific death rules apply based on animal type.

**🚀 How to Run**
- Open the solution in Visual Studio.

- Run the project (ZooSimulator).

- Every 20 seconds, 1 zoo hour passes.

**Controls:**
- Press F → Feed animals.

- Press Q → Quit simulation.


**🏗 Project Structure**
- Models/Animal.cs — Abstract base class for animals.

- Models/Monkey.cs — Monkey-specific death logic.

- Models/Giraffe.cs — Giraffe-specific death logic.

- Models/Elephant.cs — Elephant-specific death logic (cannot walk below 70% health).

- Zoo.cs — Manages animals, time simulation, and feeding.

- Program.cs — Main simulation loop and user input handling.

- ZooSimulator.Tests/AnimalTests.cs — xUnit unit tests.


**🧪 Unit Testing**
- Framework: xUnit

Basic Tests:
- Health reduction and increase validation.

- Death rules for Monkey, Giraffe, and Elephant.

- Run tests using Test Explorer → Run All.


**📋 Key Features**
- Random health loss per hour (0–20%).

- Random health gain per feeding (10–25%).

- Clean, readable console output with color coding.

- Health capped at 100%.

- Fully documented code with XML comments.


**📜 Assumptions**
- No warning for overfeeding becuase health is capped at 100%.

- Elephants die only after staying weak for 2 hours.

- Health calculations are always based on current health, not maximum.
