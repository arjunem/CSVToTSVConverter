import subprocess
import sys

print ('argument list', sys.argv)
name = sys.argv[1]

# # Define the shell script path and arguments
inputPath = sys.argv[1]
outputPath = sys.argv[2]
direction = sys.argv[3]
noOfLines = sys.argv[4]

dotnet_runtime = "dotnet"

# Define the path to the .NET console app
dotnet_app_path = "/home/amukundan/Documents/Deployed/CSVToTSVConverter.dll"

# Define the arguments to pass to the .NET app
arguments = [inputPath,outputPath,direction,noOfLines]


# Build the command by combining the app path and the arguments
command = [dotnet_runtime, dotnet_app_path] + arguments

# Call the .NET app using subprocess
try:
    result = subprocess.run(command, capture_output=True, text=True)

    # Print the output and errors (if any)
    print("Output:\n", result.stdout)
    print("Errors:\n", result.stderr)

    # Check if the process was successful
    if result.returncode == 0:
        print("Execution successful!")
    else:
        print(f"Execution failed with return code: {result.returncode}")

except Exception as e:
    print(f"An error occurred: {e}")
