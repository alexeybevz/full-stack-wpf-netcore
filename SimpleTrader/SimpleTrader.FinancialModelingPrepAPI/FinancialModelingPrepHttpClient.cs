using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        private const string ApiKey = "09c75fbb0acea9af68b8045f15c59b80";

        public FinancialModelingPrepHttpClient()
        {
            base.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }

        public string AddApiKeyToEnd(string uri)
        {
            return uri + $"?apikey={ApiKey}";
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await GetAsync(uri);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonResponse).FirstOrDefault();
        }
    }
}