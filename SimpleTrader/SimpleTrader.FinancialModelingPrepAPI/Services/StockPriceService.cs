using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<decimal> GetPrice(string symbol)
        {
            using (var client = new FinancialModelingPrepHttpClient())
            {
                string uri = $"quote-short/{symbol}";
                uri = client.AddApiKeyToEnd(uri);

                var stockPriceResult = await client.GetAsync<StockPriceResult>(uri);

                if (stockPriceResult.Price == 0)
                    throw new InvalidSymbolException(symbol);

                return stockPriceResult.Price;
            }
        }
    }
}