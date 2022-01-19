using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ServerBackend.Models;

namespace WpfClient.Proxies
{
    public class PersonProxy
    {
        private readonly HttpClient _client;

        public PersonProxy()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(@"https://localhost:44361");
        }

        private async Task<IQueryable<Person>> LoadPeopleByUriAsync(string uri)
        {
            var response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var people = await response.Content.ReadFromJsonAsync<IEnumerable<Person>>();
            return people.AsQueryable();
        }

        public async Task<IQueryable<Person>> GetAllAsync()
        {
            return await LoadPeopleByUriAsync("/People");
        }

        public async Task<IQueryable<Person>> GetAllAdultsAsync() => await LoadPeopleByUriAsync("/People/Adults");
        public async Task<IQueryable<Person>> GetAllChildrenAsync() => await LoadPeopleByUriAsync("/People/Children");

        public async Task AddAsync(Person person)
        {
            var response = await _client.PostAsync("/People", JsonContent.Create(person));
            response.EnsureSuccessStatusCode();
        }
        public async Task UpdateAsync(Person person)
        {
            var response = await _client.PutAsync("/People", JsonContent.Create(person));
            response.EnsureSuccessStatusCode();
        }
        public async Task RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"/People/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
