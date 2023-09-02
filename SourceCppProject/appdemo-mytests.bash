#!/bin/bash

src_1="build/examples/my-tests/test_1.txt"
src_2="build/examples/my-tests/test_2.txt"
src_3="build/examples/my-tests/test_3.txt"
src_4="build/examples/my-tests/test_4.txt"

build/lines_explorer $src_1 $src_2 $src_3 $src_4

$SHELL