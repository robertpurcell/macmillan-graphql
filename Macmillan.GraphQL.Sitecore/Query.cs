using Macmillan.GraphQL.Sitecore.Data;
using Macmillan.GraphQL.Sitecore.Types;

namespace Macmillan.GraphQL.Sitecore
{
    public class Query
    {
        public Item? GetItem([Service] ISitecoreItemsRepository repository, string path)
        {
            return repository.GetItemByPath(path);
        }
    }
}
