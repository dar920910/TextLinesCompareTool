$BUILD_DIRECTORY = "TextLinesComparing.App.CLI\bin\Debug\net6.0"
$EXECUTABLE = "TextLinesComparing.App.CLI.exe"

$src_1="Examples/comments/file_1.txt"
$src_2="Examples/comments/file_2.txt"
$src_3="Examples/comments/file_3.txt"

Write-Host "`n -> Executing the Program:`n"
& ".\$BUILD_DIRECTORY\$EXECUTABLE" $src_1 $src_2 $src_3
Write-Host "`n"
