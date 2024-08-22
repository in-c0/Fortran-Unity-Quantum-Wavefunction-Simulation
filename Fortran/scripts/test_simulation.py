# File: test_simulation.py
import os

# Compile the Fortran code
os.system("gfortran -o ../build/simulation simulation.f90")

# Run the simulation
os.system("../build/simulation")

# Check if output files exist
output_file = "../data/wavefunction_0001.dat"

if os.path.exists(output_file):
    print("Test passed: Output file generated.")
else:
    print("Test failed: Output file not found.")
