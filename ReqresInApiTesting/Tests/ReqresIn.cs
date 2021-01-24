using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace Tests.ReqresInApiTesting
{
    [TestFixture]
    [Binding, Scope(Feature = "ReqresIn")]
    public class ReqresIn
    {
        readonly RestClient restClient;
        public ReqresIn()
        {
            restClient = new RestClient("https://reqres.in/");
        }

        [StepDefinition("(.*) numaralı sayfadaki user listesini döner")]
        public void ListUsers(int page)
        {
            RestRequest restRequest = new RestRequest("api/users/", Method.GET);

            restRequest.AddParameter("page", page);
            var response = restClient.Execute(restRequest);

            var result = JsonConvert.DeserializeObject<Dictionary<object, object>>(response.Content);

            var output = result["page"];

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");

            Assert.That(output, Is.EqualTo(2), "page is not correct");
        }

        [StepDefinition("(.*) numaralı user bilgisini döner")]
        public void SingleUser(int id)
        {
            RestRequest restRequest = new RestRequest("api/users/{id}", Method.GET);

            restRequest.AddUrlSegment("id", id);
            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");
        }

        [StepDefinition("(.*) numaralı user olmadığı için 404 döner")]
        public void SingleUserNotFound(int id)
        {
            RestRequest restRequest = new RestRequest("api/users/{id}", Method.GET);

            restRequest.AddUrlSegment("id", id);
            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Status Code is not NotFound");
        }

        [StepDefinition("unknown ListResource")]
        public void ListResource()
        {
            RestRequest restRequest = new RestRequest("api/unknown", Method.GET);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");
        }

        [StepDefinition("(.*) unknown SingleResource")]
        public void SingleResource(int id)
        {
            RestRequest restRequest = new RestRequest("api/unknown/{id}", Method.GET);

            restRequest.AddUrlSegment("id", id);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");
        }

        [StepDefinition("(.*) unknown SingleResourceNotFound")]
        public void SingleResourceNotFound(int id)
        {
            RestRequest restRequest = new RestRequest("api/unknown/{id}", Method.GET);

            restRequest.AddUrlSegment("id", id);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Status Code is no NotFound");
        }

        [StepDefinition("'(.*)' ve '(.*)' yeni user oluşturulur")]
        public void Create(string name, string job)
        {
            RestRequest restRequest = new RestRequest("api/users", Method.POST);

            restRequest.AddParameter("name", name);
            restRequest.AddParameter("job", job);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "Status Code is not Created");

        }

        [StepDefinition("(.*) numaralı user bilgisi put ile güncellenir")]
        public void UpdatePut(int id)
        {
            RestRequest restRequest = new RestRequest("api/users/{id}", Method.PUT);

            restRequest.AddUrlSegment("id", id);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");
        }

        [StepDefinition("(.*) numaralı user bilgisi patch ile güncellenir")]
        public void UpdatePatch(int id)
        {
            RestRequest restRequest = new RestRequest("api/users/{id}", Method.PATCH);

            restRequest.AddUrlSegment("id", id);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");
        }

        [StepDefinition("(.*) numaralı user bilgisi silinir")]
        public void Delete(int id)
        {
            RestRequest restRequest = new RestRequest("api/users/{id}", Method.DELETE);

            restRequest.AddUrlSegment("id", id);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode, "Status Code is not NoContent");
        }

        [StepDefinition("'(.*)' ve '(.*)' register edilir")]
        public void RegisterSuccessful(string email, string password)
        {
            RestRequest restRequest = new RestRequest("api/register", Method.POST);

            restRequest.AddParameter("email", email);
            restRequest.AddParameter("password", password);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");

        }

        [StepDefinition("'(.*)' register edilemedi")]
        public void RegisterUnsuccessful(string email)
        {
            RestRequest restRequest = new RestRequest("api/register", Method.POST);

            restRequest.AddParameter("email", email);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "Status Code is not BadRequest");
        }

        [StepDefinition("'(.*)' ve '(.*)' login olunur")]
        public void LoginSuccessful(string email, string password)
        {
            RestRequest restRequest = new RestRequest("api/login", Method.POST);

            restRequest.AddParameter("email", email);
            restRequest.AddParameter("password", password);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");

        }

        [StepDefinition("'(.*)' login olunamadı")]
        public void LoginUnsuccessful(string email)
        {
            RestRequest restRequest = new RestRequest("api/login", Method.POST);

            restRequest.AddParameter("email", email);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode, "Status Code is not BadRequest");

        }

        [StepDefinition("(.*) DelayedResponse")]
        public void DelayedResponse(int delay)
        {
            RestRequest restRequest = new RestRequest("api/users", Method.GET);

            restRequest.AddParameter("delay", delay);

            var response = restClient.Execute(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status Code is not OK");

        }
    }
}
