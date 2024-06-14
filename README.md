# 6letterword
This repository contains a solution for the [Peripass developer test case](https://github.com/Peripass/6letterwordexercise).

Technologies used:
* .NET
* C#

The solution is a .NET Console application that takes following input parameters to run:
* -i or --inputFile: the path to the .txt input file. An example file is included in the codebase
* -c or --characterCount: the amount of characters to create words from with the input file. The included input file should be used with character count 6

# How to run
* Open cmd
* cd change directory to the location of 6letterword\SDEV.Peripass\SDEV.Peripass.WordExcercise
* run command: dotnet run -- -i ".\Input\input.txt" -c 6