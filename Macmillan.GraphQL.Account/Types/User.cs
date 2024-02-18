using System.ComponentModel.DataAnnotations;

namespace Macmillan.GraphQL.Account.Types
{
    public class User
    {
        // This parameterless constructor is required in order for projections to work
        public User()
        {
        }

        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Addresses = new List<Address>();
        }

        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public Address? DefaultAddress { get; set; }

        public Guid? DefaultAddressId { get; set; }
    }
}
