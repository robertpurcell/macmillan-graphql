using HotChocolate.Data;
using Macmillan.GraphQL.Consent.Types;
using MongoDB.Driver;

namespace Macmillan.GraphQL.Consent
{
    public class Query
    {
        [UseSorting]
        [UseFiltering]
        public IExecutable<CustomerConsent> GetConsents([Service] IMongoCollection<CustomerConsent> collection)
        {
            return collection.AsExecutable();
        }

        [UseFirstOrDefault]
        public IExecutable<CustomerConsent> GetConsentById([Service] IMongoCollection<CustomerConsent> collection, string id)
        {
            return collection.Find(x => x.Id == id).AsExecutable();
        }

        [UseFirstOrDefault]
        public IExecutable<CustomerConsent> GetConsentByEmail([Service] IMongoCollection<CustomerConsent> collection, string email)
        {
            return collection.Find(x => x.Email == email).AsExecutable();
        }
    }
}
