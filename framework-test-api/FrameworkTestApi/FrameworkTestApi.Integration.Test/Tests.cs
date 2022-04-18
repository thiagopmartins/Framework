using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FrameworkTestApi.Integration.Test.Context
{
    public class Tests
    {
        private HttpClient _httpClient;

        public Tests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [Fact]
        public async Task Deve_Retornar_Uma_Resposta_De_OK()
        {
            dynamic content = new
            {
                Number = 45
            };

            var contentJson = JsonConvert.SerializeObject(content);

            var response = await _httpClient.PostAsync("/api/Decomposition/Create", new StringContent(contentJson, Encoding.UTF8, "application/json"));

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Deve_Retornar_Uma_Resposta_De_BADREQUEST()
        {
            dynamic content = new
            {
                Number = 0
            };

            var contentJson = JsonConvert.SerializeObject(content);

            var response = await _httpClient.PostAsync("/api/Decomposition/Create", new StringContent(contentJson, Encoding.UTF8, "application/json"));

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }
    }
}
