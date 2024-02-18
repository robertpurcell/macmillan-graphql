using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Macmillan.GraphQL.Account;
using Macmillan.GraphQL.Account.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register Scoped DbContext. For each HTTP request we have a single DbContext.
builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .AddMutationConventions()
    .AddProjections() // Allows fetching from specific fields and related database tables
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    .RegisterDbContext<ApplicationDbContext>()
    .AddAuthorization()
    .AddCacheControl()
    .UseQueryCachePipeline();

// Authentication
builder.Services.AddSingleton(FirebaseApp.Create());
builder.Services.AddFirebaseAuthentication();

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();

app.MapGraphQL();

app.Run();
