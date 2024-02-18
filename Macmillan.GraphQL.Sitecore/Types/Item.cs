
namespace Macmillan.GraphQL.Sitecore.Types
{
    public class Item()
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Path { get; set; }

        public IEnumerable<Item> Children { get; set; }

        public IEnumerable<Field> Fields { get; set; }
    }
}
