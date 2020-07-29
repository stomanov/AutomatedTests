using IntegrationTests.Factories;
using IntegrationTests.Models;
using NUnit.Framework;
using RestSharp;
using System;

namespace IntegrationTests.Tests
{
    [TestFixture]
    public class ExamIntegrationTests : IntegrationBaseTests
    {
        private RestClient _restClient;
        private Author _author;

        [SetUp]
        public void Setup()
        {
            _restClient = new RestClient();
            _restClient.BaseUrl = new Uri("https://libraryjuly.azurewebsites.net");
            _author = AuthorFactory.CreateAuthorWithId();
        }

        [Test]
        public void Test1_PostNewAuthor()
        {
            var response = PostNewAuthor(_author, _restClient);

            Assert.IsTrue(response.IsSuccessful);
        }

        [Test]
        public void Test2_GetAnAuthor()
        {
            var response = PostNewAuthor(_author, _restClient);

            var postedAuthor = Author.FromJson(response.Content);
            var responseAfterPostingAnAuthor = GetAuthor($"/api/authors/{postedAuthor.Id}", _restClient);

            Assert.AreEqual(responseAfterPostingAnAuthor.FirstName, postedAuthor.FirstName);
            Assert.AreEqual(responseAfterPostingAnAuthor.LastName, postedAuthor.LastName);
            Assert.AreEqual(responseAfterPostingAnAuthor.Age, postedAuthor.Age);
        }

        [Test]
        public void Test3_DeleteAnAuthor()
        {
            var response = PostNewAuthor(_author, _restClient);

            var postedAuthor = Author.FromJson(response.Content);
            var responseAfterDeletingAnAuthor = DeleteAnAuthor(postedAuthor, _restClient);

            Assert.IsTrue(responseAfterDeletingAnAuthor.IsSuccessful);
        }
    }
}