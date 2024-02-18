FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Macmillan.GraphQL.Account/Macmillan.GraphQL.Account.csproj", "Macmillan.GraphQL.Account/"]
RUN dotnet restore "Macmillan.GraphQL.Account/Macmillan.GraphQL.Account.csproj"
COPY . .
WORKDIR "/src/Macmillan.GraphQL.Account"
RUN dotnet build "Macmillan.GraphQL.Account.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Macmillan.GraphQL.Account.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Macmillan.GraphQL.Account.dll"]
