FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CsrfExample.MvcCore/CsrfExample.MvcCore.csproj CsrfExample.MvcCore/
RUN dotnet restore CsrfExample.MvcCore/CsrfExample.MvcCore.csproj
COPY . .
WORKDIR /src/CsrfExample.MvcCore
RUN dotnet build CsrfExample.MvcCore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CsrfExample.MvcCore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CsrfExample.MvcCore.dll"]
