docker run --interactive --tty --rm 
docker run --rm --interactive --tty --publish 5001:80 --publish 5002:443 --volume $env:USERPROFILE\.aspnet\https:/https/ text_lines_comparing /bin/bash -c "cd /usr/local/bin/TextLinesCompareTool/Web/ && dotnet TextLinesComparing.App.Web.dll"