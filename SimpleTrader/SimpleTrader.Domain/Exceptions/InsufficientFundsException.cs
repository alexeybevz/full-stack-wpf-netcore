using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public decimal AccountBalance { get; }
        public decimal RequiredBalance { get; }

        public InsufficientFundsException(decimal accountBalance, decimal requiredBalance)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public InsufficientFundsException(decimal accountBalance, decimal requiredBalance, string message) : base(message)
        {
        }

        public InsufficientFundsException(decimal accountBalance, decimal requiredBalance, string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}