using Macmillan.GraphQL.Sitecore.Types;

namespace Macmillan.GraphQL.Sitecore.Data
{
    public class SitecoreItemsRepository : ISitecoreItemsRepository
    {
        public Item? GetItemByPath(string path)
        {
            return _items.FirstOrDefault(x => x.Path == path);
        }

        private readonly IEnumerable<Item> _items = new List<Item>
        {
            new Item
            {
                Id = "{3C1715FE-6A13-4FCF-845F-DE308BA9741D}",
                Name = "Cancer Information and Support",
                Path = "/cancer-information-and-support",
                Url = "https://www.macmillan.org.uk/cancer-information-and-support",
                Fields = new[]
                {
                    new Field { Name = "Heading", Value = "Cancer information and support" },
                    new Field { Name = "Subheading", Value = "If you or someone you care about has been diagnosed with cancer, we're here to help. Find out how we support you and get information about different cancer types." },
                    new Field { Name = "HeroImage", Value = "https://cdn.macmillan.org.uk/dfsmedia/1a6f23537f7f4519bb0cf14c45b2a629/10665-50033/reading-information-booklet" }
                },
                Children = new List<Item>
                {
                    Diagnosis,
                    Treatment,
                    WorriedAboutCancer
                }
            },
            Diagnosis,
            Treatment,
            WorriedAboutCancer
        };

        private static readonly Item Diagnosis = new Item
        {
            Id = "{B7BECA9D-3A3F-426E-B12A-DA9DEB07B5C5}",
            Name = "Diagnosis",
            Path = "/cancer-information-and-support/diagnosis",
            Url = "https://www.macmillan.org.uk/cancer-information-and-support/diagnosis",
            Fields = new[]
            {
                new Field { Name = "Heading", Value = "Cancer diagnosis" },
                new Field { Name = "Subheading", Value = "We have information about the different tests and scans that you might have if you're worried about cancer. We also have help, practical advice and information to help you understand your diagnosis.\r\n" },
                new Field { Name = "HeroImage", Value = "https://cdn.macmillan.org.uk/dfsmedia/1a6f23537f7f4519bb0cf14c45b2a629/14637-50034/cancer-diagnosis-information" }
            },
            Children = new List<Item>()
        };

        private static readonly Item Treatment = new Item
        {
            Id = "{A1D2632E-FFB5-412B-8B61-410A5EDDD78F}",
            Name = "Treatment",
            Path = "/cancer-information-and-support/treatment",
            Url = "https://www.macmillan.org.uk/cancer-information-and-support/treatment",
            Fields = new[]
            {
                new Field { Name = "Heading", Value = "Treatment" },
                new Field { Name = "Subheading", Value = "We know that starting treatment for cancer isn't easy. To help you prepare, we have information about the different types of treatment, what to expect, the options available to you and how to cope." },
                new Field { Name = "HeroImage", Value = "https://cdn.macmillan.org.uk/dfsmedia/1a6f23537f7f4519bb0cf14c45b2a629/12380-50033/treatment-banner-image" },
            },
            Children = new List<Item>()
        };

        private static readonly Item WorriedAboutCancer = new Item
        {
            Id = "{1CF96675-7A40-49B8-A873-71F9761CA5BA}",
            Name = "Worried About Cancer",
            Path = "/cancer-information-and-support/worried-about-cancer",
            Url = "https://www.macmillan.org.uk/cancer-information-and-support/worried-about-cancer",
            Fields = new[]
            {
                new Field { Name = "Heading", Value = "Worried About Cancer" },
                new Field { Name = "Subheading", Value = "People worry about cancer for many different reasons. Perhaps someone close to you has been diagnosed. Or maybe you have symptoms you think might be cancer. We have information about the causes, risk factors, signs and symptoms." },
                new Field { Name = "HeroImage", Value = "https://cdn.macmillan.org.uk/dfsmedia/1a6f23537f7f4519bb0cf14c45b2a629/10557-50033/reading-booklet-in-information-centre" }
            },
            Children = new List<Item>()
        };
    }
}
