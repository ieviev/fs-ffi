#!/usr/bin/env bash

echo "compiling"

g++ -I. -L. ./Main.cpp -o program.exe -L./lib/ -lfsharplibrary -Wall

echo "running program.exe"

export LD_LIBRARY_PATH="./lib"
chmod +x ./program.exe
./program.exe
