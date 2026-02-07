﻿class Program
{
    public static void Main()
    {
        Collection collection = new();
        Console.WriteLine("List:");
        collection.List01();
        Console.WriteLine("ArrayList:");    
        collection.ArrayList01();
        Console.WriteLine("HashTable:");
        collection.HashTable01();
        Console.WriteLine("Stack:");
        collection.Stack01();
        Console.WriteLine("Queue:");
        collection.Queue01();
        Console.WriteLine("Dictionary:");
        collection.Dictionary01();
        Console.WriteLine("HashSet:");
        collection.HashSet01();
        Console.WriteLine("SortedList:");
        collection.SortedList01();  

        Iterating2DArray iterating2DArray = new();
        Console.WriteLine("Iterating 2D Array:");
        iterating2DArray.Iterate01();

        iterating2DArray.Iterate02();
        Console.WriteLine("Clear 2D Array:");
        iterating2DArray.Clear01();
        Console.WriteLine("Copy 2D Array:");
        iterating2DArray.Copy01();
        Console.WriteLine("Resize 2D Array:");
        iterating2DArray.Resize01();
        Console.WriteLine("Find Index in 2D Array:");        
        iterating2DArray.IndexOf01();
        Console.WriteLine("Check if element exists in 2D Array:");
        iterating2DArray.Exists01();


        Console.WriteLine("Find Frequency:");
        FindTheFreq findTheFreq = new();
        findTheFreq.FindFrequency();

        Console.WriteLine("Merge Two Sorted Arrays:");
        MergeTwoSortedArray mergeTwoSortedArray = new();
        mergeTwoSortedArray.Merge01();
    }
}