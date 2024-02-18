using System.Security.Claims;
using FirebaseAdminAuthentication.DependencyInjection.Models;
using HotChocolate.Authorization;
using HotChocolate.Caching;
using Macmillan.GraphQL.Account.Data;
using Macmillan.GraphQL.Account.Types;

namespace Macmillan.GraphQL.Account
{
    public class Query
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [CacheControl(10000)]
        [GraphQLDescription("Gets a list of users")]
        public IQueryable<User> GetUsers(ApplicationDbContext dbContext)
        {
            return dbContext.Users;
        }

        [UseFirstOrDefault]
        [UseProjection]
        [GraphQLDescription("Gets a single user by ID")]
        public IQueryable<User> GetUser(ApplicationDbContext dbContext, Guid id)
        {
            return dbContext.Users.Where(x => x.Id == id);
        }

        [Authorize]
        [UseFirstOrDefault]
        [UseProjection]
        [GraphQLDescription("Gets the currently logged in user")]
        public IQueryable<User> GetMe(ApplicationDbContext dbContext, ClaimsPrincipal? user)
        {
            var email = user?.FindFirstValue(FirebaseUserClaimType.EMAIL);

            return dbContext.Users.Where(x => x.Email == email);
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets a list of addresses")]
        public IQueryable<Address> GetAddresses(ApplicationDbContext dbContext)
        {
            return dbContext.Addresses;
        }

        [UseFirstOrDefault]
        [UseProjection]
        [GraphQLDescription("Gets a single address by ID")]
        public IQueryable<Address> GetAddress(ApplicationDbContext dbContext, Guid id)
        {
            return dbContext.Addresses.Where(x => x.Id == id);
        }
    }
}
