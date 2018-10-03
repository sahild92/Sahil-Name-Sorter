using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SahilNameSorterCore.Domain
{
    public interface IGenderizeClient
    {
        Task<List<string>> GetGender();
    }

    public class GenderizeClient : IGenderizeClient
    {
        public async Task<List<string>> GetGender()
        {
            using (HttpClient client = new HttpClient())
            {
                //Blah blah do everything here I want to do. 
                //var result = await client.GetAsync("/tweets");

                return new List<string> { "Hello from api" };
            }
        }
    }
}
