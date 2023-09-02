Write-Host "`nStep 1: Creating a New Solution`n"

dotnet new sln
dotnet new gitignore


Write-Host "`nStep 2: Creating Projects from Templates`n"

dotnet new classlib --name "TextLinesComparing.Library" --framework "net6.0"
dotnet new nunit --name "TextLinesComparing.Testing" --framework "net6.0"
dotnet new console --name "TextLinesComparing.App.CLI" --framework "net6.0"
dotnet new web --name "TextLinesComparing.App.Web" --framework "net6.0"


Write-Host "`nStep 3: Adding References to Projects`n"

dotnet add "TextLinesComparing.Testing" reference "TextLinesComparing.Library"
dotnet add "TextLinesComparing.App.CLI" reference "TextLinesComparing.Library"
dotnet add "TextLinesComparing.App.Web" reference "TextLinesComparing.Library"


Write-Host "`nStep 4: Adding Projects to the Solution`n"

dotnet sln add "TextLinesComparing.Library"
dotnet sln add "TextLinesComparing.Testing"
dotnet sln add "TextLinesComparing.App.CLI"
dotnet sln add "TextLinesComparing.App.Web"


Write-Host "`nStep 5: Displaying Projects from the Solution`n"

dotnet sln list
