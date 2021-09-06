namespace SimpleTrader.Domain.Models
{
    public class MajorIndex
    {
        public decimal Price { get; set; }
        public decimal Changes { get; set; }
        public MajorIndexType Type { get; set; }
    }
}