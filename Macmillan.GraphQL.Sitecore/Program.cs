using Macmillan.GraphQL.Sitecore;
using Macmillan.GraphQL.Sitecore.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ISitecoreItemsRepository, SitecoreItemsRepository>();

builder.Services
    .AddGraphQLServer()
    .RegisterService<ISitecoreItemsRepository>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
