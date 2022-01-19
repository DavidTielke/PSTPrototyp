using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerBackend;
using ServerBackend.Models;

namespace BackendTests
{
    [TestClass]
    public class UnitTest1
    {
        private TestServer _server;
        private HttpClient _client;

        [TestInitialize]
        public void TestInitialize()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            }

        [TestMethod]
        public async Task People_GetTest()
        {
            var response = await _client.GetAsync("/People");
            response.EnsureSuccessStatusCode();

            var people = await response.Content.ReadFromJsonAsync<IEnumerable<Person>>();

            Assert.AreEqual(3, people.Count());
        }

        [TestMethod]
        public async Task People_PostTest()
        {
            var person = new Person(0, "Teddy", 6);

            var responsePost = await _client.PostAsync("/People", JsonContent.Create(person));
            
            responsePost.EnsureSuccessStatusCode();
            var responseGet = await _client.GetAsync("/People");
            var people = await responseGet.Content.ReadFromJsonAsync<IEnumerable<Person>>();

            Assert.AreEqual(4, people.Count());
        }
    }
}
