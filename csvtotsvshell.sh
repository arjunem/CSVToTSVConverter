#!/bin/bash
cd CSVToTSVConverter

Input_Path=$1
Output_Path=$2
Direction=$3
NoOfLines=$4

echo The input path given is $Input_Path
echo The output path given is $Output_Path

dotnet run $Input_Path $Output_Path $Direction $NoOfLines

cd ..

