# import required module
from pathlib import Path
import subprocess
import sys

# assign directory
directory = "/home/amukundan/Documents/Doc/Input"
outDirectory = "/home/amukundan/Documents/Doc/Output/"


def execute_dotnet_app(inputPath,outputPath,direction,noOfLines):
    # for single and multiple substitutions()
    # mandatory
    print("Conversion starts for file % s ! with direction % s and no of line %s." % (inputPath, direction,noOfLines))
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


# iterate over files in
# that directory
files = Path(directory).glob('*')
for file in files:
    execute_dotnet_app(file, outDirectory+file.name, 'x', "15" )