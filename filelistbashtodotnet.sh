#!/bin/bash

# Define the target directory
# directory="/home/amukundan/Documents/Doc/Input"
directory="/home/amukundan/Documents/Doc/Input"
outdirectory="/home/amukundan/Documents/Doc/Output"

cd /home/amukundan/Documents/Deployed

#It is a function
executedotnetcall() {
  echo $1
  dotnet CSVToTSVConverter.dll  $1 $2 $3 $4
}

# Check if the target is not a directory
if [ ! -d "$directory" ]; then
  exit 1
fi

# Loop through files in the target directory
for file in "$directory"/*; do
  if [ -f "$file" ]; then
    filename=${file##*/}
    outfile="${outdirectory}/${filename}"
    echo "$file"
    echo "$outfile"
    executedotnetcall "$file" "$outfile" "x" "12"
  fi
done

cd -