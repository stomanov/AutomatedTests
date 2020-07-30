using IntegrationTests.Models;
using System;

namespace IntegrationTests.Factories
{
    public static class AuthorFactory
    {
        public static Author CreateAuthorWithId()
        {
            var GuidId = Guid.NewGuid();

            return new Author
            {
                Id = GuidId,
                FirstName = "Ivan",
                LastName = "Karenin",
                DateOfBirth = "1970-12-19T00:00:00",
                Genre = "Geschäft"
            };
        }
    }
}