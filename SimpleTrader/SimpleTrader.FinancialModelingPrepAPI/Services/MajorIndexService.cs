using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using (var client = new HttpClient())
            {
                string uri = $"https://financialmodelingprep.com/api/v3/profile/{GetUriSuffix(indexType)}?apikey=09c75fbb0acea9af68b8045f15c59b80";

                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var majorIndexes = JsonConvert.DeserializeObject<IEnumerable<MajorIndex>>(jsonResponse);
                var majorIndex = majorIndexes.FirstOrDefault();
                majorIndex.Type = indexType;
                return majorIndex;
            }
        }

        private string GetUriSuffix(MajorIndexType indexType)
        {
            switch (indexType)
            {
                case MajorIndexType.AAPL:
                    return "AAPL";
                case MajorIndexType.INTC:
                    return "INTC";
                case MajorIndexType.MSFT:
                    return "MSFT";
                default:
                    throw new ArgumentOutOfRangeException(nameof(indexType), indexType, null);
            }
        }
    }
}