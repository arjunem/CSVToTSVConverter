FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# # Creates a non-root user with an explicit UID and adds permission to access the /app folder
# # For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER root

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["CSVToTSVConverter/CSVToTSVConverter.csproj", "CSVToTSVConverter/"]
RUN dotnet restore "CSVToTSVConverter/CSVToTSVConverter.csproj"
COPY . .
WORKDIR "/src/CSVToTSVConverter"
RUN dotnet build "CSVToTSVConverter.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "CSVToTSVConverter.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSVToTSVConverter.dll"]
# CMD ["/app/data/currency.csv","/app/data/curreny.tsv"]

