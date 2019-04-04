FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CsrfExample.EvilSiteCore/CsrfExample.EvilSiteCore.csproj CsrfExample.EvilSiteCore/
RUN dotnet restore CsrfExample.EvilSiteCore/CsrfExample.EvilSiteCore.csproj
COPY . .
WORKDIR /src/CsrfExample.EvilSiteCore
RUN dotnet build CsrfExample.EvilSiteCore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CsrfExample.EvilSiteCore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CsrfExample.EvilSiteCore.dll"]
