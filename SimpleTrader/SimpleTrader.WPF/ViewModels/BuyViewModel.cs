﻿using System.Windows.Input;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;

namespace SimpleTrader.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {
        private string _symbol;
        private decimal _stockPrice;
        private int _sharesToBuy;

        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        public decimal StockPrice
        {
            get => _stockPrice;
            set
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
            }
        }

        public int SharesToBuy
        {
            get => _sharesToBuy;
            set
            {
                _sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public decimal TotalPrice => SharesToBuy * StockPrice;

        public ICommand SearchSymbolCommand { get; }
        public ICommand BuyStockCommand { get; }

        public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService);
        }
    }
}