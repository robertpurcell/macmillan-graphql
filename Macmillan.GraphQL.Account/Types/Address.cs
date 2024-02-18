using System.ComponentModel.DataAnnotations;

namespace Macmillan.GraphQL.Account.Types
{
    public class Address()
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstLine { get; set; }

        public string SecondLine { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
