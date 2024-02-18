using Macmillan.GraphQL.Account.Data;
using Macmillan.GraphQL.Account.Types;

namespace Macmillan.GraphQL.Account
{
    public class Mutation
    {
        public async Task<User?> AddUser(ApplicationDbContext context, string firstName, string lastName, string email)
        {
            var existingUser = context.Users.FirstOrDefault(x => string.Equals(x.Email, email));
            if (existingUser is not null)
            {
                throw new GraphQLException($"A user with email '{email}' already exists.");
            }

            var user = new User(firstName, lastName, email);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<Address> AddAddress(ApplicationDbContext context, string firstLine, string secondLine, string town,
            string county, string postalCode, string country, bool useAsDefaultAddress, Guid userId)
        {
            var user = await context.Users.FindAsync(userId);
            if (user is null)
            {
                throw new GraphQLException($"Unable to find user with id '{userId}'.");
            }

            var address = new Address
            {
                FirstLine = firstLine,
                SecondLine = secondLine,
                Town = town,
                County = county,
                PostalCode = postalCode,
                Country = country,
                UserId = userId,
                User = user
            };
            await context.Addresses.AddAsync(address);

            if (!user.DefaultAddressId.HasValue || useAsDefaultAddress)
            {
                user.DefaultAddressId = address.Id;
            }

            await context.SaveChangesAsync();

            return address;
        }

        public async Task<User> UpdateUser(ApplicationDbContext context, Guid id, string firstName, string lastName,
            string email, Guid? defaultAddressId)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null)
            {
                throw new GraphQLException($"Unable to find user with id '{id}'.");
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            if (defaultAddressId.HasValue)
            {
                user.DefaultAddressId = defaultAddressId.Value;
            }

            await context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(ApplicationDbContext context, Guid id)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null)
            {
                throw new GraphQLException($"Unable to find user with id '{id}'.");
            }

            user.DefaultAddressId = null;
            await context.SaveChangesAsync();

            var userAddresses = context.Addresses.Where(x => x.UserId == user.Id);
            context.Addresses.RemoveRange(userAddresses);
            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAddress(ApplicationDbContext context, Guid id)
        {
            var address = await context.Addresses.FindAsync(id);
            if (address is null)
            {
                throw new GraphQLException($"Unable to find address with id '{id}'.");
            }

            var user = await context.Users.FindAsync(address.UserId);
            if (user is null)
            {
                throw new GraphQLException($"Unable to find user with id '{address.UserId}'.");
            }

            if (user.DefaultAddressId == id)
            {
                user.DefaultAddressId = context.Addresses.FirstOrDefault(x => x.UserId == user.Id)?.Id;
            }

            context.Addresses.Remove(address);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
