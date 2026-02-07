using System;

class Program
{
    static void Main()
    {
        // TASK 1: PriceSnapshot
        PriceSnapshot snapshot = new PriceSnapshot("AAPL", 150.50m);
        Console.WriteLine($"Market Snapshot - Symbol: {snapshot.StockSymbol}, Price: {snapshot.StockPrice:C}");
        Console.WriteLine();

        // TASK 4: Create repository
        TradeRepository<EquityTrade> repository = new TradeRepository<EquityTrade>();

        // TASK 3: Create equity trades
        EquityTrade trade1 = new EquityTrade
        {
            TradeID = 1001,
            StockSymbol = "AAPL",
            Quantity = 100,
            MarketPrice = 150.50m
        };

        EquityTrade trade2 = new EquityTrade
        {
            TradeID = 1002,
            StockSymbol = "GOOGL",
            Quantity = 50,
            MarketPrice = null
        };

        // Add trades to repository
        repository.AddTrade(trade1);
        repository.AddTrade(trade2);
        Console.WriteLine();

        // TASK 7: Process trades using pattern matching
        foreach (var trade in repository.GetTrades())
        {
            TradeProcessor.ProcessTrade(trade);
            Console.WriteLine();
        }

        // TASK 8: Boxing and Unboxing
        object boxedCount = TradeAnalytics.GetTotalTrades();
        int unboxedCount = (int)boxedCount;
        Console.WriteLine($"Boxed Total Trades: {boxedCount}");
        Console.WriteLine($"Unboxed Total Trades: {unboxedCount}");
        Console.WriteLine();

        // TASK 5: Display analytics
        TradeAnalytics.DisplayAnalytics();
    }
}
