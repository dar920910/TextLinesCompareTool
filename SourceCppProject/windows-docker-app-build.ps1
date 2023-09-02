Write-Host "`n-> Building Docker image for the project ...`n"
docker build --pull --rm -f "Dockerfile" -t centos:latest "."