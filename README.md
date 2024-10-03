#CSVToTSVConverter

Add the csv path and the output path as the command line arguments.
CSVToTSVConverter.exe "D:\Learn\DotNetDocker\Input\currency.csv" "D:\Learn\DotNetDocker\Output\currency.tsv" x 14

# Result
Loading csv file D:\Learn\DotNetDocker\Input\currency.csv
Fetching First 14 records in the file!!
Writing tsv file to D:\Learn\DotNetDocker\Output\currency.tsv
Successfully Converted!

Where x here is the direction and 14 is the no of records
both these arguments are optional

This is a part of the bash-python-dotnet basic tutorial trainging:
I have added following python scripts to be kept as a reference
- **csvtotsvpython.py** - takes in the filepaths as parameters and converts it to tsv via python
- **filelistpythontodotnet.py** - loop through a list of files in a folder and convert all to tsv
- **pythontodotnet.py** - calls a dotnet application with arguments and convert the file to tsv

I have added shell scripts for sample files on conversions
- **csvtotsvshell.sh** - takes in the filepaths as parameters and converts it to tsv via shell
- **bashtopython.sh** - calls a python application with arguments and convert the file to tsv
-  **filelistbashtodotnet.sh** - loop through a list of files in a folder and convert all to tsv using shell
