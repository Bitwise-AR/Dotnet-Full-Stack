using System;
using System.Collections.Generic;
using DialingCodesApp;

class Program
{
    static void Main()
    {
        Dictionary<int, string> emptyDict = DialingCodes.GetEmptyDictionary();
        Console.WriteLine($"Empty dictionary count: {emptyDict.Count}");

        Dictionary<int, string> existingDict = DialingCodes.GetExistingDictionary();
        DialingCodes.PrintDictionary(existingDict);

        Dictionary<int, string> singleEntryDict = DialingCodes.AddCountryToEmptyDictionary(81, "Japan");
        DialingCodes.PrintDictionary(singleEntryDict);

        DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");

        string country = DialingCodes.GetCountryNameFromDictionary(existingDict, 91);
        Console.WriteLine($"Country for code 91: {country}");

        bool exists = DialingCodes.CheckCodeExists(existingDict, 55);
        Console.WriteLine($"Code 55 exists: {exists}");

        DialingCodes.UpdateDictionary(existingDict, 55, "Federative Republic of Brazil");

        DialingCodes.RemoveCountryFromDictionary(existingDict, 1);

        string longestName = DialingCodes.FindLongestCountryName(existingDict);
        Console.WriteLine($"Longest country name: {longestName}");

        DialingCodes.PrintDictionary(existingDict);
    }
}
