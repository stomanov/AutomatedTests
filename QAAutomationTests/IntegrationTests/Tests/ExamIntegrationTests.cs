using IntegrationTests.Factories;
using IntegrationTests.JsonExtension;
using IntegrationTests.Models;
using NUnit.Framework;
using RestSharp;

namespace IntegrationTests.Tests
{
    [TestFixture]
    public class ExamIntegrationTests : IntegrationBaseTests
    {
        private RestClient restClient;
        private Author author;

        [SetUp]
        public void Setup()
        {
            restClient = new RestClient("https://libraryjuly.azurewebsites.net");
            author = AuthorFactory.CreateAuthorWithId();
        }

        [Test]
        public void Test1_PostNewAuthor()
        {
            var response = PostNewAuthor(author, restClient);

            Assert.IsTrue(response.IsSuccessful);
        }

        [Test]
        public void Test2_GetAnAuthor()
        {
            var response = PostNewAuthor(author, restClient);

            var postedAuthor = response.Content.FromJson<Author>();
            var responseAfterPostingAnAuthor = GetAuthor($"/api/authors/{postedAuthor.Id}", restClient);

            Assert.AreEqual(responseAfterPostingAnAuthor.FirstName, postedAuthor.FirstName);
            Assert.AreEqual(responseAfterPostingAnAuthor.LastName, postedAuthor.LastName);
            Assert.AreEqual(responseAfterPostingAnAuthor.Age, postedAuthor.Age);
        }

        [Test]
        public void Test3_DeleteAnAuthor()
        {
            var response = PostNewAuthor(author, restClient);

            var postedAuthor = response.Content.FromJson<Author>();
            var responseAfterDeletingAnAuthor = DeleteAnAuthor(postedAuthor, restClient);

            Assert.IsTrue(responseAfterDeletingAnAuthor.IsSuccessful);
        }
    }
}