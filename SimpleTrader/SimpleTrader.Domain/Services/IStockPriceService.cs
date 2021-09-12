using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services
{
    public interface IStockPriceService
    {
        Task<decimal> GetPrice(string symbol);
    }
}