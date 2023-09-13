#!/bin/bash

src_0="Examples/agile-spam/AGILE-RUS.txt"
src_1="Examples/agile-spam/AGILE-SPA.txt"
src_2="Examples/agile-spam/AGILE-SWE.txt"
src_3="Examples/agile-spam/AGILE-NLD.txt"
src_4="Examples/agile-spam/AGILE-TUR.txt"
src_5="Examples/agile-spam/AGILE-UKR.txt"
src_6="Examples/agile-spam/AGILE-FRE.txt"
src_7="Examples/agile-spam/AGILE-GER.txt"
src_8="Examples/agile-spam/AGILE-HUN.txt"
src_9="Examples/agile-spam/AGILE-ITA.txt"

./CLI/TextLinesComparing.App.CLI $src_0 $src_1 $src_2 $src_3 $src_4 $src_5 $src_6 $src_7 $src_8 $src_9

$SHELL