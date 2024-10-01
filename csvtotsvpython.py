import subprocess

# # Define the shell script path and arguments
# # bash_path =r"C:\Program Files\Git\bin\bash.exe"
script_path = r"/home/amukundan/Documents/CSVToTSVConverter/csvtotsvshell.sh"
inputPath = r'/home/amukundan/Documents/Deployed/Input/currency.csv'
outputPath =  r'/home/amukundan/Documents/Deployed/Output/currency.tsv'
direction = 'x'
noOfLines = '15'
args = [inputPath,outputPath,direction,noOfLines]

# Run the shell script using Git Bash
process = subprocess.Popen(["bash", script_path] + args, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)

# Capture output and errors
stdout, stderr = process.communicate()

# Print output
print("stdout:", stdout)
print("stderr:", stderr)
