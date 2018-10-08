using Microsoft.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SahilNameSorterCore.Domain
{
    public interface IGenderizeClient
    {
        Task<string> GetGender(string firstName);
    }

    public class GenderizeClient : IGenderizeClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public GenderizeClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> GetGender(string firstName)
        {

            //Blah blah do everything here I want to do. 
            //var result = await client.GetAsync("/tweets");
            // return new List<string> { "Hello from api" };  
            var client = _httpClientFactory.CreateClient("gendrizeClient");
            Console.WriteLine("Calling genderize api");
          var responseMessage = await client.GetAsync("?name=" + firstName);
            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
