using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        private readonly BuyViewModel _buyViewModel;
        private readonly IBuyStockService _buyStockService;
        public event EventHandler CanExecuteChanged;

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService)
        {
            _buyViewModel = buyViewModel;
            _buyStockService = buyStockService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                var account = await _buyStockService.BuyStock(new Account()
                {
                    Id = 1,
                    Balance = 500, 
                    AssetTransactions = new List<AssetTransaction>()
                }, _buyViewModel.Symbol, _buyViewModel.SharesToBuy);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}