FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy
WORKDIR /usr/local/src/TextLinesCompareTool

COPY TextLinesComparing.Library/ TextLinesComparing.Library/
COPY TextLinesComparing.Testing/ TextLinesComparing.Testing/
COPY TextLinesComparing.App.CLI/ TextLinesComparing.App.CLI/
COPY TextLinesComparing.App.Web/ TextLinesComparing.App.Web/

RUN dotnet publish TextLinesComparing.App.CLI/TextLinesComparing.App.CLI.csproj --output "/usr/local/bin/TextLinesCompareTool/CLI/" --configuration "Release" --use-current-runtime --no-self-contained
RUN dotnet publish TextLinesComparing.App.Web/TextLinesComparing.App.Web.csproj --output "/usr/local/bin/TextLinesCompareTool/Web/" --configuration "Release" --use-current-runtime --no-self-contained

ENV ASPNETCORE_ENVIRONMENT=Production \
    ASPNETCORE_URLS="https://+;http://+" \
    ASPNETCORE_HTTPS_PORT=5002 \
    ASPNETCORE_Kestrel__Certificates__Default__Path=/https/TextLinesComparing.pfx \
    ASPNETCORE_Kestrel__Certificates__Default__Password="Text_Lines_Comparing_2023!"

WORKDIR /usr/local/bin/TextLinesCompareTool
COPY Examples/ Examples/
COPY Scripts/ .
