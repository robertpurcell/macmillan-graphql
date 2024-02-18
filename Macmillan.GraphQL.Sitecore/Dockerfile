FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Macmillan.GraphQL.Sitecore/Macmillan.GraphQL.Sitecore.csproj", "Macmillan.GraphQL.Sitecore/"]
RUN dotnet restore "Macmillan.GraphQL.Sitecore/Macmillan.GraphQL.Sitecore.csproj"
COPY . .
WORKDIR "/src/Macmillan.GraphQL.Sitecore"
RUN dotnet build "Macmillan.GraphQL.Sitecore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macmillan.GraphQL.Sitecore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macmillan.GraphQL.Sitecore.dll"]
