/*using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a piece of text:");
        string inputText = Console.ReadLine();

        // Word Count
        int wordCount = CountWords(inputText);
        Console.WriteLine($"Word Count: {wordCount}");

        // Email Validation
        string[] emails = ExtractEmails(inputText);
        Console.WriteLine("Email Addresses Found:");
        foreach (string email in emails)
        {
            Console.WriteLine(email);
        }

        // Mobile Number Extraction
        string[] mobileNumbers = ExtractMobileNumbers(inputText);
        Console.WriteLine("Mobile Numbers Found:");
        foreach (string number in mobileNumbers)
        {
            Console.WriteLine(number);
        }

        // Custom Regex Search
        Console.WriteLine("Enter a custom regular expression:");
        string customRegexPattern = Console.ReadLine();
        string[] customRegexMatches = PerformCustomRegexSearch(inputText, customRegexPattern);
        Console.WriteLine("Custom Regex Search Results:");
        foreach (string match in customRegexMatches)
        {
            Console.WriteLine(match);
        }
    }

    static int CountWords(string text)
    {
        return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    static string[] ExtractEmails(string text)
    {
        const string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";
        MatchCollection matches = Regex.Matches(text, emailPattern);
        string[] emails = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            emails[i] = matches[i].Value;
        }
        return emails;
    }

    static string[] ExtractMobileNumbers(string text)
    {
        const string mobileNumberPattern = @"\b\d{10}\b";
        MatchCollection matches = Regex.Matches(text, mobileNumberPattern);
        string[] mobileNumbers = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            mobileNumbers[i] = matches[i].Value;
        }
        return mobileNumbers;
    }

    static string[] PerformCustomRegexSearch(string text, string pattern)
    {
        MatchCollection matches = Regex.Matches(text, pattern);
        string[] results = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            results[i] = matches[i].Value;
        }
        return results;
    }
}*/
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a  text:");
        string inputText = Console.ReadLine();

        int wordCount = CountWords(inputText);
        Console.WriteLine($"Word Count: {wordCount}");

      

        var mobileNumbers = ExtractMobileNumbers(inputText);
        if (mobileNumbers.Count > 0)
        {
            Console.WriteLine("Mobile Numbers :  \t");
            foreach (var number in mobileNumbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No mobile numbers found.");
        }

        var emailAddresses = ExtractEmailAddresses(inputText);
        if (emailAddresses.Count > 0)
        {
            Console.WriteLine("Email Addresses Found:\t");
            foreach (var email in emailAddresses)
            {
                Console.WriteLine(email);
            }
        }
        else
        {
            Console.WriteLine("No email addresses found.");
        }

        Console.WriteLine("Enter a custom regular expression:");
        string customRegexPattern = Console.ReadLine();
        var customRegexResults = CustomRegexSearch(inputText, customRegexPattern);
        if (customRegexResults.Count > 0)
        {
            Console.WriteLine("Custom Regex Matches Found:");
            foreach (var match in customRegexResults)
            {
                Console.WriteLine(match);
            }
        }
        else
        {
            Console.WriteLine("No custom regex matches found.");
        }
    }

    static int CountWords(string text)
    {
        string[] words = text.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    static List<string> ExtractEmailAddresses(string text)
    {
        var emailAddresses = new List<string>();
        string pattern = @"[\w\.-]+@[\w\.-]+\.\w+";
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            emailAddresses.Add(match.Value);
        }
        return emailAddresses;
    }

    static List<string> ExtractMobileNumbers(string text)
    {
        var mobileNumbers = new List<string>();
        string pattern = @"\b\d{10}\b";
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            mobileNumbers.Add(match.Value);
        }
        return mobileNumbers;
    }

    static List<string> CustomRegexSearch(string text, string pattern)
    {
        var customRegexResults = new List<string>();
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            customRegexResults.Add(match.Value);
        }
        return customRegexResults;
    }
}


