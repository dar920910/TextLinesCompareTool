#!/bin/bash

mkdir build
BUILD_DIRECTORY=./build/

printf "\nStep # 1. Generate CMake build's files:\n\n"
cmake -S ./ -B $BUILD_DIRECTORY -G "Unix Makefiles"
printf "\n"

printf "\nStep # 2. Produce binaries from build's configuration:\n\n"
cmake --build $BUILD_DIRECTORY
printf "\n"

printf "\nStep # 3. Run unit tests via GoogleTest:\n\n"
ctest --test-dir $BUILD_DIRECTORY
printf "\n"

$SHELL