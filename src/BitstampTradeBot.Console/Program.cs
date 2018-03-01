﻿using System;
using System.Collections.Specialized;
using BitstampTradeBot.Trader;
using BitstampTradeBot.Trader.Models;
using BitstampTradeBot.Trader.TradeRules;
using BitstampTradeBot.Trader.Models.Exchange;
using BitstampTradeBot.Trader.TradeHolders;
using Serilog;

namespace BitstampTradeBot.Console
{
    static class Program
    {
        private static BitstampTrader _trader;

        static void Main()
        {
            try
            {
                // initialize logger
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .MinimumLevel.Debug()
                    .CreateLogger();

                // initialize trader
                _trader = new BitstampTrader(TimeSpan.FromSeconds(15));

                var tradeSettings = new TradeSettings
                {
                    PairCode = "btceur",
                    BuyUnderPriceMargin = 2,
                    CounterAmount = 10,
                    BaseAmountSavingsRate = 3,
                    SellPriceRate = 15
                };

                var tradeRule = new BuyAfterDropTradeRule(_trader, tradeSettings, 3, TimeSpan.FromMinutes(15),
                    new WaitPeriodAfterBuyOrderHolder(TimeSpan.FromHours(1)),
                    new MaxNumberOfBuyOrdersHolder(1));

                //var tradeRule = new BuyPeriodicTradeRule(_trader, tradeSettings,
                //    new WaitPeriodAfterBuyOrderHolder(TimeSpan.FromMinutes(30)));

                _trader.AddTradeRule(tradeRule);

                _trader.ErrorOccured += ErrorOccured;
                _trader.TickerRetrieved += TickerRetrieved;
                _trader.BuyLimitOrderPlaced += BuyLimitOrderPlaced;
                _trader.BuyLimitOrderExecuted += BuyLimitOrderExecuted;
                _trader.SellLimitOrderPlaced += SellLimitOrderPlaced;

                // start trader
                _trader.Start();

                System.Console.ReadLine();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }

        private static void SellLimitOrderPlaced(object sender, BitstampOrderEventArgs e)
        {
            var basePairCode = e.Order.PairCode.Substring(0, 3).ToUpper();
            var counterPairCode = e.Order.PairCode.Substring(3, 3).ToUpper();

            Log.Information("Sell order placed for {Amount}{BasePairCode} @{Price}{CounterPairCode} ({Total:0.00}{CounterPairCode})",
                e.Order.Amount,
                basePairCode,
                e.Order.Price,
                counterPairCode,
                e.Order.Amount * e.Order.Price,
                counterPairCode);
        }

        private static void BuyLimitOrderExecuted(object sender, BitstampOrderEventArgs e)
        {
            var basePairCode = e.Order.PairCode.Substring(0, 3).ToUpper();
            var counterPairCode = e.Order.PairCode.Substring(3, 3).ToUpper();

            Log.Information("Buy order executed for {Amount}{BasePairCode} @{Price}{CounterPairCode}",
                e.Order.Amount,
                basePairCode,
                e.Order.Price,
                counterPairCode);
        }

        private static void BuyLimitOrderPlaced(object sender, BitstampOrderEventArgs e)
        {
            var basePairCode = e.Order.PairCode.Substring(0, 3).ToUpper();
            var counterPairCode = e.Order.PairCode.Substring(3, 3).ToUpper();

            Log.Information("Buy order placed for {Amount}{BasePairCode} @{Price}{CounterPairCode} ({Total:0.00}{CounterPairCode})",
                e.Order.Amount,
                basePairCode,
                e.Order.Price,
                counterPairCode,
                e.Order.Amount * e.Order.Price,
                counterPairCode);
        }

        private static void TickerRetrieved(object sender, BitstampTickerEventArgs e)
        {
            Log.Debug("Ticker retrieved : {TickerValue:0.00000000} ({PairCode})", e.Ticker.Last, e.PairCode);
        }

        private static void ErrorOccured(object sender, Exception e)
        {
            Log.Error(e, "Something went wrong");
        }
    }
}
