$BUILD_DIRECTORY = "TextLinesComparing.App.CLI\bin\Debug\net6.0"
$EXECUTABLE = "TextLinesComparing.App.CLI.exe"

$src_1="Examples/lorem-ipsum/demo_1.txt"
$src_2="Examples/lorem-ipsum/demo_2.txt"
$src_3="Examples/lorem-ipsum/demo_3.txt"
$src_4="Examples/lorem-ipsum/demo_4.txt"
$src_5="Examples/lorem-ipsum/demo_5.txt"
$src_6="Examples/lorem-ipsum/demo_6.txt"
$src_7="Examples/lorem-ipsum/demo_7.txt"

Write-Host "`n -> Executing the Program:`n"
& ".\$BUILD_DIRECTORY\$EXECUTABLE" $src_1 $src_2 $src_3 $src_4 $src_5 $src_6 $src_7
Write-Host "`n"
