#!/bin/bash

src_1="Examples/my-tests/test_1.txt"
src_2="Examples/my-tests/test_2.txt"
src_3="Examples/my-tests/test_3.txt"
src_4="Examples/my-tests/test_4.txt"

./CLI/TextLinesComparing.App.CLI $src_1 $src_2 $src_3 $src_4

$SHELL