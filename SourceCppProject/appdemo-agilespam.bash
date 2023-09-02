#!/bin/bash

src_0="build/examples/agile-spam/AGILE-RUS.txt"
src_1="build/examples/agile-spam/AGILE-SPA.txt"
src_2="build/examples/agile-spam/AGILE-SWE.txt"
src_3="build/examples/agile-spam/AGILE-NLD.txt"
src_4="build/examples/agile-spam/AGILE-TUR.txt"
src_5="build/examples/agile-spam/AGILE-UKR.txt"
src_6="build/examples/agile-spam/AGILE-FRE.txt"
src_7="build/examples/agile-spam/AGILE-GER.txt"
src_8="build/examples/agile-spam/AGILE-HUN.txt"
src_9="build/examples/agile-spam/AGILE-ITA.txt"

build/lines_explorer $src_0 $src_1 $src_2 $src_3 $src_4 $src_5 $src_6 $src_7 $src_8 $src_9

$SHELL