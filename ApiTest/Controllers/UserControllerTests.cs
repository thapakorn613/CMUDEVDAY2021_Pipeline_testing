using CMUDevday2021;
using CMUDevday2021.Controllers;
using CMUDevday2021.Model.entity;
using CMUDevday2021.Model.Interface;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiTest.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        private readonly HttpClient _client;

        public UserControllerTests()
        {
            var app = new CustomWebApplicationFactory<Startup>();
            _client = app.CreateClient();
        }

        [TestMethod]
        public async Task getMenu()
        {
            // Arrange
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer zxcmbndfkglj");
            var response = await _client.GetAsync("api/v1/Menu");
            Assert.IsTrue(response.IsSuccessStatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            List<Menu> menus = JsonConvert.DeserializeObject<List<Menu>>(responseString);
            Assert.IsTrue(menus.Count > 0);
            _client.DefaultRequestHeaders.Remove("Authorization");
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer sdfsfsdfsdfsf");
            response = await _client.GetAsync("api/v1/Menu");
            Assert.IsTrue((int)response.StatusCode == 401);


        }
    }
}
