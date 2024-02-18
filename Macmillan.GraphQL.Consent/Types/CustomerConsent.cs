using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Macmillan.GraphQL.Consent.Types
{
    public class CustomerConsent()
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public bool AllowEmail { get; set; }

        public bool AllowPhone { get; set; }

        public bool AllowPost { get; set; }

        public bool AllowSms { get; set; }
    }
}
