using System.Net.Http.Headers;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

const string Account = "account";
const string Consent = "consent";
const string Sitecore = "sitecore";

string accountBaseAddress = builder.Configuration.GetValue<string>("AccountBaseAddress") ?? string.Empty;
string consentBaseAddress = builder.Configuration.GetValue<string>("ConsentBaseAddress") ?? string.Empty;
string sitecoreBaseAddress = builder.Configuration.GetValue<string>("SitecoreBaseAddress") ?? string.Empty;

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient(Account, GetHttpClient(accountBaseAddress));
builder.Services.AddHttpClient(Consent, GetHttpClient(consentBaseAddress));
builder.Services.AddHttpClient(Sitecore, GetHttpClient(sitecoreBaseAddress));

builder.Services
    .AddGraphQLServer()
    .AddRemoteSchema(Account)
    .AddRemoteSchema(Consent)
    .AddRemoteSchema(Sitecore)
    .AddTypeExtensionsFromFile("./Stitching.graphql");

var app = builder.Build();

app.MapGraphQL();

app.Run();

static Action<IServiceProvider, HttpClient> GetHttpClient(string baseAddress)
{
    return (serviceProvider, client) =>
    {
        var context = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;

        if (context is not null)
        {
            if (context.Request.Headers.TryGetValue(HeaderNames.Authorization, out StringValues value))
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(value.ToString());
            }
        }

        client.BaseAddress = new Uri(baseAddress);
    };
}