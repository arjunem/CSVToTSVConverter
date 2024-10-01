import subprocess

# # Define the shell script path and arguments
bash_path =r"C:\Program Files\Git\bin\bash.exe"
script_path = r"D:\Learn\DotNetDocker\csvtotsvshell.sh"
inputPath = r'D:\Learn\DotNetDocker\Input\currency.csv'
outputPath = r'D:\Learn\DotNetDocker\Output\currency.tsv'
direction = 'x'
noOfLines = '15'
args = [inputPath,outputPath,direction,noOfLines]

# Run the shell script using Git Bash
process = subprocess.Popen([bash_path, script_path] + args, stdout=subprocess.PIPE, stderr=subprocess.PIPE, text=True)

# Capture output and errors
stdout, stderr = process.communicate()

# Print output
print("stdout:", stdout)
print("stderr:", stderr)