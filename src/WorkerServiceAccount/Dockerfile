FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/WorkerServiceAccount/WorkerServiceAccount.csproj", "src/WorkerServiceAccount/"]
RUN dotnet restore "src/WorkerServiceAccount/WorkerServiceAccount.csproj"
COPY . .
WORKDIR "/src/src/WorkerServiceAccount"
RUN dotnet build "WorkerServiceAccount.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkerServiceAccount.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerServiceAccount.dll"]
