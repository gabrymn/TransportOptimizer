# Operations Research: Transport Optimizer

This C# application is designed to solve transportation problems using various methods including Vogel's Approximation Method, Russell's Approximation Method, Least Cost Method, and Northwest Corner Method.

## Features

- **Vogel's Approximation Method (VAM):** 
  - Implements Vogel's method to generate an initial feasible solution for transportation problems.
- **Russell's Approximation Method:**
  - Utilizes Russell's method to find an initial feasible solution by balancing supply and demand.
- **Least Cost Method:**
  - Implements the least cost method to allocate shipments starting from cells with the minimum cost.
- **Northwest Corner Method:**
  - Utilizes the northwest corner method to allocate shipments starting from the northwest corner of the cost matrix.

## Usage

1. **Input Data:**
   - Provide the input data including the cost matrix, supply values, and demand values.
2. **Select Method:**
   - Choose one of the available methods (Vogel, Russell, Least Cost, Northwest Corner) for solving the transportation problem.
3. **Run Solver:**
   - Execute the solver to obtain the solution.
4. **Output:**
   - View the solution including the allocation of shipments and the total transportation cost.

## Installation

- Clone the repository to your local machine.
- Open the solution file (.sln) in Visual Studio or any compatible IDE.
- Build the solution to compile the application.
- Run the application and follow the on-screen instructions to solve transportation problems.
