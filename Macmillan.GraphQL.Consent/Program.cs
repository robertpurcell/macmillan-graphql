using Macmillan.GraphQL.Consent;
using Macmillan.GraphQL.Consent.Types;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

var builder = WebApplication.CreateBuilder(args);

// Register Scoped DbContext. For each HTTP request we have a single DbContext.
builder.Services
    .AddSingleton(sp =>
    {
        var mongoConnectionUrl = new MongoUrl(builder.Configuration.GetValue<string>("MongoDbConfiguration:ConnectionString"));
        var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
        mongoClientSettings.ClusterConfigurator = cb =>
        {
            // This will print the executed command to the console
            cb.Subscribe<CommandStartedEvent>(e =>
            {
                Console.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
            });
        };
        var client = new MongoClient(mongoClientSettings);
        var database = client.GetDatabase(builder.Configuration.GetValue<string>("MongoDbConfiguration:Database"));

        return database.GetCollection<CustomerConsent>("consent");
    })
    .AddGraphQLServer()
    .AddMutationConventions()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    .AddMongoDbFiltering()
    .AddMongoDbSorting();

var app = builder.Build();

app.MapGraphQL();

app.Run();
