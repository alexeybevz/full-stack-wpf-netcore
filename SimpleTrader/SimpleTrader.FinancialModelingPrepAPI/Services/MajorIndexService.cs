using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType)
        {
            using (var client = new FinancialModelingPrepHttpClient())
            {
                string uri = $"profile/{GetUriSuffix(indexType)}";
                uri = client.AddApiKeyToEnd(uri);

                var response = await client.GetAsync(uri);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var majorIndex = await client.GetAsync<MajorIndex>(uri);
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
                    throw new Exception("MajorIndexType does not have a suffix defined.");
            }
        }
    }
}