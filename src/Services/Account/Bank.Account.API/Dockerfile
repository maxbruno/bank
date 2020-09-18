FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/Account/Bank.Account.API/Bank.Account.API.csproj", "src/Services/Account/Bank.Account.API/"]
RUN dotnet restore "src/Services/Account/Bank.Account.API/Bank.Account.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Account/Bank.Account.API"
RUN dotnet build "Bank.Account.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.Account.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.Account.API.dll"]
