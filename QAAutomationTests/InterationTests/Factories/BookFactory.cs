using IntegrationTests.Models;
using System;

namespace IntegrationTests.Factories
{
    public static class BookFactory
    {
        public static Book CreateBook()
        {
            var GuidId = Guid.NewGuid();

            return new Book
            {
                Id = GuidId,
                Title = "The Cruiser Aurora",
                Description = "Kasket Tales",
                AuthorId = GuidId
            };
        }
    }
}
