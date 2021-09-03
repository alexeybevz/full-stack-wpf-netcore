using System;
using System.Linq;
using SimpleTrader.Domain.Models;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;

namespace SimpleTrader.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());
            //userService.Create(new User() { UserName = "Test" }).Wait();
            Console.WriteLine(userService.GetAll().Result.Count());
        }
    }
}
