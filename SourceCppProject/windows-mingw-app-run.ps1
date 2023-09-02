$BUILD_DIRECTORY = "build"
$EXECUTABLE = "lines_explorer.exe"

$src_1 = "$BUILD_DIRECTORY\examples\my-tests\test_1.txt"
$src_2 = "$BUILD_DIRECTORY\examples\my-tests\test_2.txt"
$src_3 = "$BUILD_DIRECTORY\examples\my-tests\test_3.txt"
$src_4 = "$BUILD_DIRECTORY\examples\my-tests\test_4.txt"

Write-Host "`n -> Executing the Program via LinesStorageMap:`n"
& ".\$BUILD_DIRECTORY\$EXECUTABLE" $src_1 $src_2 $src_3 $src_4
Write-Host "`n"

Write-Host "`n -> Executing the Program via LinesStorageSet:`n"
& ".\$BUILD_DIRECTORY\$EXECUTABLE" $src_1 $src_2
Write-Host "`n"