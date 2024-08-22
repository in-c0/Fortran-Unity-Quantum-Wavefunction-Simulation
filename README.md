# Quantum Wavefunction Simulation in 1D Potentials

This project simulates the behavior of quantum wavefunctions as they interact with various potential barriers and wells in one dimension. The core of the simulation is written in Fortran, solving the time-dependent Schrödinger equation. The results are visualized in a Unity application, allowing users to explore quantum phenomena such as tunneling and interference.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Running the Simulation](#running-the-simulation)
- [Using the Unity Visualization](#using-the-unity-visualization)
- [Repository Structure](#repository-structure)
- [Contributing](#contributing)
- [License](#license)

## Installation

### Prerequisites
- **Fortran Compiler**: Ensure you have a Fortran compiler installed (e.g., GNU Fortran, Intel Fortran).
- **Unity**: Unity Hub and Unity Editor (version 2021.x or newer recommended).
- **Git**: For version control and project management.

### Steps
1. **Clone the Repository**:
    ```bash
    git clone https://github.com/in-c0/quantum-wave-simulation.git
    cd quantum-wave-simulation
    ```

2. **Build the Fortran Simulation**:
    - Navigate to the `Fortran/src/` directory and compile the Fortran code:
        ```bash
        cd Fortran/src/
        gfortran -o ../build/simulation simulation.f90
        ```
    - This will generate the simulation executable in the `Fortran/build/` directory.

3. **Set Up Unity**:
    - Open the Unity project located in the `Unity/` directory using Unity Hub.
    - Unity should automatically load the project and resolve any dependencies.

## Running the Simulation

### Running the Fortran Simulation
1. Navigate to the `Fortran/build/` directory.
2. Run the simulation with the following command:
    ```bash
    ./simulation
    ```
3. The output data will be saved in the `Fortran/data/` directory.

### Using the Unity Visualization
1. After running the Fortran simulation, launch the Unity Editor.
2. In Unity, load the scene titled `QuantumWaveSimulation`.
3. Play the scene to visualize the wavefunction data.
4. Use the UI to adjust potential parameters and observe the changes in real-time.



## Repository Structure
A quick overview of the key directories in this project:

- **Fortran/**: Contains all Fortran-related code, including the solver for the Schrödinger equation.
- **Unity/**: Unity project files for visualizing the simulation results.
- **Docs/**: Documentation files, including a detailed project report and user guide.
- **AI/**: (Optional) Any machine learning scripts or models used to enhance the simulation.

For more details, refer to the individual `README.md` files in each directory.


## Contributing

Contributions are welcome! If you'd like to improve the simulation, visualization, or add new features, feel free to fork the repository and submit a pull request.

### Guidelines
- Please make sure to update tests as appropriate.
- Ensure your code follows the existing style and structure of the project.
- Document any new features in the relevant markdown files.


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

