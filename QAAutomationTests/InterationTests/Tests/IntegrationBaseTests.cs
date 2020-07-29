using IntegrationTests.JsonExtension;
using IntegrationTests.Models;
using RestSharp;

namespace IntegrationTests.Tests
{
    public class IntegrationBaseTests
    {
        public IRestResponse PostNewAuthor(Author author, RestClient restClient)
        {
            var requestPostNewAuthor = new RestRequest("/api/authors", Method.POST);
            requestPostNewAuthor.AddParameter("application/json", author.ToJson(), ParameterType.RequestBody);
            IRestResponse response = restClient.Post(requestPostNewAuthor);
            return response;
        }

        public Author GetAuthor(string resourse, RestClient restClient)
        {
            var requestAuthor = new RestRequest(resourse);
            IRestResponse response = restClient.Get(requestAuthor);
            Author author = Author.FromJson(response.Content);
            return author;
        }

        public IRestResponse DeleteAnAuthor(Author author, RestClient restClient)
        {
            var requestAnAuthor = new RestRequest($"/api/authors/{author.Id}");
            IRestResponse response = restClient.Delete(requestAnAuthor);
            return response;
        }

        public IRestResponse PostBookForAuthor(Author author, Book book, RestClient restClient)
        {
            var requestPostBookForAuthor = new RestRequest($"/api/authors/{author.Id}/books", Method.POST);
            requestPostBookForAuthor.AddParameter("application/json", book.ToJson(), ParameterType.RequestBody);
            IRestResponse response = restClient.Post(requestPostBookForAuthor);
            return response;
        }

        public IRestResponse GetBookForAuthor(Author author, Book book, RestClient restClient)
        {
            var requestBookForAuthor = new RestRequest($"/api/authors/{author.Id}/books/{book.Id}");
            IRestResponse response = restClient.Get(requestBookForAuthor);
            return response;
        }

        public IRestResponse DeleteBookForAuthor(Author author, Book book, RestClient restClient)
        {
            var requestDeleteBookForAuthor = new RestRequest($"/api/authors/{author.Id}/books/{book.Id}");
            IRestResponse response = restClient.Delete(requestDeleteBookForAuthor);
            return response;
        }
    }
}