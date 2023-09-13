$BUILD_DIRECTORY = "TextLinesComparing.App.CLI\bin\Debug\net6.0"
$EXECUTABLE = "TextLinesComparing.App.CLI.exe"

$src_1 = "Examples\my-tests\test_1.txt"
$src_2 = "Examples\my-tests\test_2.txt"
$src_3 = "Examples\my-tests\test_3.txt"
$src_4 = "Examples\my-tests\test_4.txt"

Write-Host "`n -> Executing the Program via LinesStorageMap:`n"
& ".\$BUILD_DIRECTORY\$EXECUTABLE" $src_1 $src_2 $src_3 $src_4
Write-Host "`n"

Write-Host "`n -> Executing the Program via LinesStorageSet:`n"
& ".\$BUILD_DIRECTORY\$EXECUTABLE" $src_1 $src_2
Write-Host "`n"
