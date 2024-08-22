# Installation Guide

This guide will walk you through the process of setting up the environment and installing the necessary tools to run the Quantum Wavefunction Simulation project.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Installing gfortran](#installing-gfortran)
  - [Using MSYS2](#using-msys2)
  - [Using MinGW-w64](#using-mingw-w64)
- [Setting Up the Project](#setting-up-the-project)
- [Running the Fortran Simulation](#running-the-fortran-simulation)
- [Setting Up Unity](#setting-up-unity)
- [Troubleshooting](#troubleshooting)

## Prerequisites

Before you begin, make sure you have the following installed on your system:

- **Git**: Version control system for managing the project repository.
- **Unity**: Unity Hub and Unity Editor (version 2021.x or newer recommended).
- **Fortran Compiler**: gfortran is recommended for compiling Fortran code.

## Installing gfortran

### Using MSYS2

1. **Install MSYS2**:
   - Download and install MSYS2 from the [official website](https://www.msys2.org/).

2. **Update the Package Database**:
   - Open the MSYS2 terminal and run:
     ```bash
     pacman -Syu
     ```

3. **Install gfortran**:
   - In the MSYS2 terminal, install gfortran with:
     ```bash
     pacman -S mingw-w64-x86_64-gcc-fortran
     ```

4. **Verify Installation**:
   - Check that gfortran is installed correctly:
     ```bash
     gfortran --version
     ```

### Using MinGW-w64

1. **Download MinGW-w64**:
   - Visit [MinGW-w64 SourceForge](https://sourceforge.net/projects/mingw-w64/) and download the installer.

2. **Install MinGW-w64**:
   - Follow the installer instructions, ensuring that the Fortran component is selected.

3. **Add to PATH**:
   - Add the MinGW-w64 `bin` directory to your system’s PATH environment variable.

4. **Verify Installation**:
   - Open a new Command Prompt and verify:
     ```bash
     gfortran --version
     ```

## Setting Up the Project

1. **Clone the Repository**:
   - Open a terminal and clone the repository:
     ```bash
     git clone https://github.com/yourusername/quantum-wave-simulation.git
     cd quantum-wave-simulation
     ```

2. **Navigate to the Fortran Source Directory**:
   - Go to the source directory where the Fortran code is located:
     ```bash
     cd Fortran/src/
     ```

3. **Compile the Fortran Code**:
   - Compile the Fortran simulation code:
     ```bash
     gfortran -o ../build/simulation simulation.f90
     ```

## Running the Fortran Simulation

1. **Run the Simulation**:
   - Execute the compiled Fortran simulation:
     ```bash
     ../build/simulation
     ```

2. **Check the Output**:
   - The output data files will be generated in the `Fortran/data/` directory.

## Setting Up Unity

1. **Open Unity Hub**:
   - Use Unity Hub to open the project located in the `Unity/` directory.

2. **Load the Scene**:
   - In Unity, load the scene titled `QuantumWaveSimulation`.

3. **Run the Visualization**:
   - Play the scene in Unity to visualize the wavefunction data.

## Troubleshooting

- **gfortran Not Recognized**:
  - Ensure gfortran is correctly installed and added to your PATH.
  - Refer to the [troubleshooting guide](#) for more details.

- **MSYS2 Installation Issues**:
  - If you encounter errors during MSYS2 setup, try clearing the package cache or running MSYS2 as an administrator.

For further assistance, please contact the project maintainers.

