// ASSIGNMENT TITLE
// Mini Project: SmartTrade – Real-Time Trading System Using Advanced C#

// COURSE CONTEXT
// Course: Advanced C# Programming
// Module: Generics, Nullable Types, Extension Methods, Pattern Matching
// Difficulty Level: Intermediate → Advanced
// Assignment Type: Individual Mini Project

// PROBLEM STATEMENT
// A brokerage firm wants to build a lightweight console-based trading system for internal testing and learning purposes.
// The system must simulate equity trading, handle market price fluctuations, calculate trade value and brokerage, and maintain global trade analytics.
// You are required to design and implement this system using advanced C# features, ensuring clean architecture, type safety, and performance.

// OBJECTIVES
// After completing this assignment, the student should be able to:
// Apply advanced C# language features in a real-world domain
// Design extensible and maintainable systems
// Demonstrate understanding of generics, nullable types, and extension methods
// Implement clean object-oriented design

// SYSTEM REQUIREMENTS
// The system must:
// Support equity trades
// Handle missing market prices safely
// Store trades generically
// Track total trades at system level
// Apply brokerage and tax calculations
// Process trades dynamically

// TASKS TO BE PERFORMED (VERY SPECIFIC)

// TASK 1: Market Price Snapshot Using Struct
// Student MUST do the following:
// Create ONE struct named PriceSnapshot
// The struct MUST contain:
// Stock Symbol
// Stock Price
// The struct MUST be used only for temporary market data
// Expected Implementation Proof:
// Create at least one PriceSnapshot instance
// Display symbol and price

// TASK 2: Base Trade Abstraction
// Student MUST do the following:
// Create ONE abstract class named Trade
// The class MUST contain:
// Trade ID
// Stock Symbol
// Quantity
// Declare ONE abstract method:
// To calculate trade value
// Override ToString() from System.Object
// Expected Implementation Proof:
// Display trade details using ToString()

// TASK 3: Equity Trade Implementation
// Student MUST do the following:
// Create ONE concrete class named EquityTrade
// The class MUST:
// Inherit from Trade
// Add ONE nullable property:
// Market Price
// Implement trade value calculation using:
// Null coalescing operator
// Expected Implementation Proof:
// Calculate trade value with:
// Market price present
// Market price missing (null)

// TASK 4: Generic Trade Repository
// Student MUST do the following:
// Create ONE generic class named TradeRepository<T>
// Apply generic constraint so that:
// Only Trade types are allowed
// The repository MUST:
// Store multiple trades
// Add new trades
// Increment a global counter whenever a trade is added
// Expected Implementation Proof:
// Add at least two trades
// Show repository contents

// TASK 5: Static Trade Analytics
// Student MUST do the following:
// Create ONE static class named TradeAnalytics
// The class MUST contain:
// Static variable to track total trades
// Static method to display analytics
// Expected Implementation Proof:
// Display total number of trades executed

// TASK 6: Extension Methods for Financial Calculations
// Student MUST do the following:
// Create ONE static class for extensions
// Add:
// Brokerage calculation method
// Tax (GST) calculation method
// These methods MUST:
// Extend numeric types
// Not modify Trade class
// Expected Implementation Proof:
// Apply brokerage and tax on trade value

// TASK 7: Pattern Matching for Trade Processing
// Student MUST do the following:
// Create ONE trade processing method
// Use pattern matching to:
// Identify EquityTrade
// Execute appropriate logic
// Expected Implementation Proof:
// Display trade type during processing

// TASK 8: Boxing and Unboxing
// Student MUST do the following:
// Store total trade count in an object type
// Retrieve it back into a value type
// Expected Implementation Proof:
// Print boxed and unboxed values

// TASK 9: Main Program Flow
// Student MUST do the following:
// Create repository instance
// Create at least two EquityTrade objects
// Assign:
// Trade ID
// Symbol
// Quantity
// Market price
// Add trades to repository
// Process trades
// Display:
// Trade details
// Trade value
// Brokerage
// Tax
// Display global analytics

// OUTPUT REQUIREMENTS (MANDATORY)
// The output MUST include:
// Trade processing message
// Trade details
// Calculated trade value
// Brokerage charges
// Tax amount
// Total trades executed

// CONSTRAINTS
// Do NOT use external libraries
// Do NOT skip any task
// Do NOT hardcode output values
// Follow object-oriented principles strictly

struct PriceSnapshot
{
    public string StockSymbol { get; set; }
    public decimal StockPrice { get; set; }

    public PriceSnapshot(string stockSymbol, decimal stockPrice)
    {
        StockSymbol = stockSymbol;
        StockPrice = stockPrice;
    }
}

abstract class Trade
{
    public int TradeID { get; set; }
    public string StockSymbol { get; set; }
    public int Quantity { get; set; }

    public abstract decimal CalculateTradeValue();

    public override string ToString()
    {
        return $"TradeID: {TradeID}, StockSymbol: {StockSymbol}, Quantity: {Quantity}";
    }
}

class EquityTrade : Trade
{
    public decimal? MarketPrice { get; set; }

    public override decimal CalculateTradeValue()
    {
        return Quantity * (MarketPrice ?? 0);
    }
}

class TradeRepository<T> where T : Trade
{
    private List<T> trades = new List<T>();

    public void AddTrade(T trade)
    {
        trades.Add(trade);
        TradeAnalytics.CountTrade();
    }

    public void DisplayTrades()
    {
        foreach (var trade in trades)
        {
            Console.WriteLine(trade);
        }
    }

    public List<T> GetTrades() => trades;
}

static class TradeAnalytics
{
    private static int totalTrades = 0;

    public static void CountTrade()
    {
        totalTrades++;
    }

    public static void DisplayAnalytics()
    {
        Console.WriteLine($"Total Trades Executed: {totalTrades}");
    }

    public static int GetTotalTrades() => totalTrades;
}

static class FinancialExtensions
{
    public static decimal CalculateBrokerage(this decimal tradeValue)
    {
        return tradeValue * 0.005m;
    }

    public static decimal CalculateTax(this decimal tradeValue)
    {
        return tradeValue * 0.18m;
    }
}

static class TradeProcessor
{
    public static void ProcessTrade(Trade trade)
    {
        if (trade is EquityTrade equityTrade)
        {
            Console.WriteLine("Processing Equity Trade");
            Console.WriteLine(equityTrade);
            decimal tradeValue = equityTrade.CalculateTradeValue();
            Console.WriteLine($"Trade Value: {tradeValue:C}");
            Console.WriteLine($"Brokerage: {tradeValue.CalculateBrokerage():C}");
            Console.WriteLine($"Tax (GST): {tradeValue.CalculateTax():C}");
        }
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
}