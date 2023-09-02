
Write-Host "`nStep # 0. Check project's build directory:`n`n"
$BUILD_DIRECTORY = "build"
if (-not (Test-Path $BUILD_DIRECTORY)) { New-Item -ItemType "Directory" -Name $BUILD_DIRECTORY -Path ".\" }
Write-Host "`n"

Write-Host "`nStep # 1. Generate CMake build's files:`n`n"
cmake -S ./ -B $BUILD_DIRECTORY -G "MinGW Makefiles"
Write-Host "`n"

Write-Host "`nStep # 2. Produce binaries from build's configuration:`n`n"
cmake --build $BUILD_DIRECTORY
Write-Host "`n"

Write-Host "`nStep # 3. Run unit tests via GoogleTest:`n`n"
ctest --test-dir $BUILD_DIRECTORY
Write-Host "`n"