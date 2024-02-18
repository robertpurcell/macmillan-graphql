FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Macmillan.GraphQL.Gateway/Macmillan.GraphQL.Gateway.csproj", "Macmillan.GraphQL.Gateway/"]
RUN dotnet restore "Macmillan.GraphQL.Gateway/Macmillan.GraphQL.Gateway.csproj"
COPY . .
WORKDIR "/src/Macmillan.GraphQL.Gateway"
RUN dotnet build "Macmillan.GraphQL.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macmillan.GraphQL.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macmillan.GraphQL.Gateway.dll"]
