FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Zaliczenie.csproj", "Zaliczenie/"]
RUN ls -l
RUN dotnet restore "Zaliczenie/Zaliczenie.csproj"
COPY . .
WORKDIR "/src/Zaliczenie"
RUN dotnet build "Zaliczenie.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zaliczenie.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zaliczenie.dll"]
