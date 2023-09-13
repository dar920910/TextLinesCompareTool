FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/TextLinesCompareTool

COPY TextLinesComparing.Library/ TextLinesComparing.Library/
COPY TextLinesComparing.App.CLI/ TextLinesComparing.App.CLI/

RUN dotnet publish TextLinesComparing.App.CLI/TextLinesComparing.App.CLI.csproj --output "/usr/local/bin/TextLinesCompareTool/CLI/" --configuration "Release" --use-current-runtime --no-self-contained

WORKDIR /usr/local/bin/TextLinesCompareTool
COPY Examples/ Examples/
COPY Scripts/ .
