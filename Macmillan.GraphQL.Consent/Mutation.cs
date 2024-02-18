using Macmillan.GraphQL.Consent.Types;
using MongoDB.Driver;

namespace Macmillan.GraphQL.Consent
{
    public class Mutation
    {
        public async Task<CustomerConsent> AddCustomerConsent(
            [Service] IMongoCollection<CustomerConsent> collection,
            string firstName,
            string lastName,
            string email,
            string phone,
            string mobile,
            bool allowEmail,
            bool allowPhone,
            bool allowPost,
            bool allowSms
            )
        {
            var existingCustomerConsent = (await collection.FindAsync(x => string.Equals(x.Email, email))).FirstOrDefault();
            if (existingCustomerConsent != null)
            {
                throw new GraphQLException($"A consent record with email '{email}' already exists.");
            }

            var customerConsent = new CustomerConsent
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Mobile = mobile,
                AllowEmail = allowEmail,
                AllowPhone = allowPhone,
                AllowPost = allowPost,
                AllowSms = allowSms
            };
            await collection.InsertOneAsync(customerConsent);

            return customerConsent;
        }

        public async Task<CustomerConsent> UpdateCustomerConsent(
            [Service] IMongoCollection<CustomerConsent> collection,
            string id,
            bool allowEmail,
            bool allowPhone,
            bool allowPost,
            bool allowSms)
        {
            var existingCustomerConsent = (await collection.FindAsync(x => x.Id == id)).FirstOrDefault();
            if (existingCustomerConsent == null)
            {
                throw new GraphQLException($"Unable to find consent record with id '{id}'.");
            }

            var update = Builders<CustomerConsent>.Update
                .Set(x => x.AllowEmail, allowEmail)
                .Set(x => x.AllowPhone, allowPhone)
                .Set(x => x.AllowPost, allowPost)
                .Set(x => x.AllowSms, allowSms);
            var result = await collection.UpdateOneAsync(x => x.Id == id, update);

            return (await collection.FindAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async Task<bool> DeleteCustomerConsent([Service] IMongoCollection<CustomerConsent> collection, string id)
        {
            var existingCustomerConsent = (await collection.FindAsync(x => x.Id == id)).FirstOrDefault();
            if (existingCustomerConsent == null)
            {
                throw new GraphQLException($"Unable to find consent record with id '{id}'.");
            }

            var result = await collection.FindOneAndDeleteAsync(x => x.Id == id);

            return result is not null;
        }
    }
}
