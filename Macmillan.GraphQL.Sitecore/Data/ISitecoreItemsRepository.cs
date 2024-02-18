using Macmillan.GraphQL.Sitecore.Types;

namespace Macmillan.GraphQL.Sitecore.Data
{
    public interface ISitecoreItemsRepository
    {
        Item? GetItemByPath(string path);
    }
}
