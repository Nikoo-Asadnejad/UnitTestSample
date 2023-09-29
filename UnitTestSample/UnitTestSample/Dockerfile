FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UnitTestSample/UnitTestSample.csproj", "UnitTestSample/"]
RUN dotnet restore "UnitTestSample/UnitTestSample.csproj"
COPY . .
WORKDIR "/src/UnitTestSample"
RUN dotnet build "UnitTestSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTestSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitTestSample.dll"]
