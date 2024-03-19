using IntegrationTests.JsonExtension;
using IntegrationTests.Models;
using RestSharp;

namespace IntegrationTests.Tests
{
    public class IntegrationBaseTests
    {
        public RestResponse PostNewAuthor(Author author, RestClient restClient)
        {
            var requestPostNewAuthor = new RestRequest("/api/authors", Method.Post);
            requestPostNewAuthor.AddParameter("application/json", author.ToJson(), ParameterType.RequestBody);
            RestResponse response = restClient.Post(requestPostNewAuthor);
            return response;
        }

        public Author GetAuthor(string resourse, RestClient restClient)
        {
            var requestAuthor = new RestRequest(resourse);
            RestResponse response = restClient.Get(requestAuthor);
            Author author = response.Content.FromJson<Author>();
            return author;

        }

        public RestResponse DeleteAnAuthor(Author author, RestClient restClient)
        {
            var requestAnAuthor = new RestRequest($"/api/authors/{author.Id}");
            RestResponse response = restClient.Delete(requestAnAuthor);
            return response;
        }

        public RestResponse PostBookForAuthor(Author author, Book book, RestClient restClient)
        {
            var requestPostBookForAuthor = new RestRequest($"/api/authors/{author.Id}/books", Method.Post);
            requestPostBookForAuthor.AddParameter("application/json", book.ToJson(), ParameterType.RequestBody);
            RestResponse response = restClient.Post(requestPostBookForAuthor);
            return response;
        }

        public RestResponse GetBookForAuthor(Author author, Book book, RestClient restClient)
        {
            var requestBookForAuthor = new RestRequest($"/api/authors/{author.Id}/books/{book.Id}");
            RestResponse response = restClient.Get(requestBookForAuthor);
            return response;
        }

        public RestResponse DeleteBookForAuthor(Author author, Book book, RestClient restClient)
        {
            var requestDeleteBookForAuthor = new RestRequest($"/api/authors/{author.Id}/books/{book.Id}");
            RestResponse response = restClient.Delete(requestDeleteBookForAuthor);
            return response;
        }
    }
}